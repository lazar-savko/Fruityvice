﻿using System.Text.Json.Serialization;

namespace Fruityvice.Models
{
    public class Fruit
    {
        [JsonPropertyName("id")]  // Adding this line to map the "id" from the JSON to the "Id" property
        public int Id { get; set; }  // New Id property

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("genus")]
        public string Genus { get; set; }

        [JsonPropertyName("family")]
        public string Family { get; set; }

        [JsonPropertyName("order")]
        public string Order { get; set; }

        [JsonPropertyName("nutritions")]
        public Nutritions Nutritions { get; set; }
    }
}
