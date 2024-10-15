using Newtonsoft.Json;
using System;

namespace CurrencyCloud.Entity
{
    public class CollectionsScreeningResult: Entity
    {
        [JsonConstructor]
        public CollectionsScreeningResult() { }

        /// <summary>
        /// Reason of accept/reject
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Accepted/Rejected as bool
        /// </summary>
        public bool Accepted { get; set; }

        public string ToJSON()
        {
            var obj = new[]
            {
                new
                {
                    Accepted,
                    Reason
                }
            };
            return JsonConvert.SerializeObject(obj);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is CollectionsScreeningResult))
            {
                return false;
            }

            var collectionsScreeningResult = obj as CollectionsScreeningResult;

            return Accepted == collectionsScreeningResult.Accepted &&
                   Reason == collectionsScreeningResult.Reason;
        }

        public override int GetHashCode()
        {
            return Reason.GetHashCode();
        }
    }
}

