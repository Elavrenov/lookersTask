using Newtonsoft.Json;

namespace DAL.CosmosDb.Entities
{
    public class ItemFeatures
    {
        [JsonProperty(PropertyName = "airconditioning")]
        public bool AirConditioning { get; set; }

        [JsonProperty(PropertyName = "audioplayer")]
        public bool AudioPlayer { get; set; }

        [JsonProperty(PropertyName = "heatingseats")]
        public bool HeatingSeats { get; set; }

        [JsonProperty(PropertyName = "cupholder")]
        public bool CupHolder { get; set; }
    }
}