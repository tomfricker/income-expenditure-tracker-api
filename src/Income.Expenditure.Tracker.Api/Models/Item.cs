using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Income.Expenditure.Tracker.Api.Models
{
    public class Item
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "income")]
        public int Income { get; set; }
        [JsonProperty(PropertyName = "expenditures")]
        public List<Expenditure> Expenditures { get; set; }
    }

    public class Expenditure
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "amount")]
        public int Amount { get; set; }
    }
}
