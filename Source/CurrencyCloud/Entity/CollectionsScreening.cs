using Newtonsoft.Json;
using System;

namespace CurrencyCloud.Entity
{
    public class CollectionsScreening: Entity
    {
        [JsonConstructor]
        public CollectionsScreening() { }

        /// <summary>
        /// UUID of the Transaction which needs to marked as completed wit accept/reject
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// UUID of the Account
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// UUID of the House Account
        /// </summary>
        public string HouseAccountId { get; set; }

        /// <summary>
        /// Result of Complete Screening
        /// </summary>
        public CollectionsScreeningResult Result { get; set; }

        public string ToJSON()
        {
            var obj = new[]
            {
                new
                {
                    TransactionId,
                    AccountId,
                    HouseAccountId,
                    Result
                }
            };
            return JsonConvert.SerializeObject(obj);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is CollectionsScreening))
            {
                return false;
            }

            var collectionsScreening = obj as CollectionsScreening;

            return TransactionId == collectionsScreening.TransactionId &&
                   AccountId == collectionsScreening.AccountId &&
                   HouseAccountId == collectionsScreening.HouseAccountId &&
                   Result == collectionsScreening.Result;
        }

        public override int GetHashCode()
        {
            return TransactionId.GetHashCode();
        }
    }
}

