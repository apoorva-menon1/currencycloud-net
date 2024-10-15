using System;
using NUnit.Framework;
using CurrencyCloud.Tests.Mock.Data;
using CurrencyCloud.Entity.Pagination;
using CurrencyCloud.Tests.Mock.Http;
using CurrencyCloud.Environment;
using System.Threading.Tasks;
using CurrencyCloud.Entity;

namespace CurrencyCloud.Tests
{
    [TestFixture]
    class CollectionsScreeningTest
    {
        Client client = new Client();
        Player player = new Player("/../../Mock/Http/Recordings/CollectionsScreening.json");

        [OneTimeSetUpAttribute]
        public void SetUp()
        {
            player.Start(ApiServer.Mock.Url);
            player.Play("SetUp");

            var credentials = Authentication.Credentials;

            client.InitializeAsync(Authentication.ApiServer, credentials.LoginId, credentials.ApiKey).Wait();
        }

        [OneTimeTearDownAttribute]
        public void TearDown()
        {
            player.Play("TearDown");

            client.CloseAsync().Wait();

            player.Close();
        }

        /// <summary>
        /// Successfully completes client screening.
        /// </summary>
        [Test]
        public async Task CompleteScreening()
        {
            player.Play("CompleteScreening");
            CollectionsScreening screening = await client.CollectionsScreeningCompleteAsync("272d42b9-9b97-4407-ac08-d75cd067cd12",
                true, "Accepted");

            Assert.NotNull(screening);
            Assert.AreEqual("272d42b9-9b97-4407-ac08-d75cd067cd12", screening.TransactionId);
            Assert.AreEqual("f2ea2099-306e-47a6-8fb0-123b304e601c", screening.AccountId);
            Assert.AreEqual("f276146d-0a35-4df9-b9d7-fff869fadd8e", screening.HouseAccountId);
            Assert.NotNull(screening.Result);
            Assert.AreEqual("Accepted", screening.Result.Reason);
            Assert.AreEqual(true, screening.Result.Accepted);
        }
    }
}
