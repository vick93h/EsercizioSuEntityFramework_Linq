using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EsercizioSuEntityFramework_Linq.Database
{
    [Table("RootObject")]
    public class RootObject
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Brand")]
        public string Brand { get; set; }

        [JsonPropertyName("Model")]
        public string Model { get; set; }

        [JsonPropertyName("Color")]
        public string Color { get; set; }

        [JsonPropertyName("Vin")]
        public string Vin { get; set; }

        [JsonPropertyName("Year")]
        public int Year { get; set; }

        [JsonPropertyName("NumberOfPort")]
        public int NumberOfPort { get; set; }

        [JsonPropertyName("power")]
        public int Power { get; set; }

        [JsonPropertyName("Country")]
        public string Country { get; set; }

        [JsonPropertyName("Price")]
        public string Price { get; set; }
    }


}
