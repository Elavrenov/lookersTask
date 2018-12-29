using Newtonsoft.Json;

namespace DAL.CosmosDb.Entities
{
    public class Item
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "make")]
        public string Make { get; set; }

        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }

        [JsonProperty(PropertyName = "colour")]
        public string Colour { get; set; }

        [JsonProperty(PropertyName = "features")]
        public ItemFeatures Features { get; set; }
    }
}