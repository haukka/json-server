using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace json_server.Models
{
    public class Geo
    {
        [JsonProperty(PropertyName = "lat")]
        public string Lat { get; set; }
        [JsonProperty(PropertyName = "lng")]
        public string Lng { get; set; }
    }

    public class Address
    {
        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }
        [JsonProperty(PropertyName = "suite")]
        public string Suite { get; set; }
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
        [JsonProperty(PropertyName = "zipcode")]
        public string Zipcode { get; set; }
        [JsonProperty(PropertyName = "geo")]
        public Geo Geo { get; set; }
    }

    public class Company
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "catchPhrase")]
        public string CatchPhrase { get; set; }
        [JsonProperty(PropertyName = "bs")]
        public string Bs { get; set; }
    }

    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "addresses")]
        public List<Address> Addresses { get; set; }
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }
        [JsonProperty(PropertyName = "website")]
        public string Website { get; set; }
        [JsonProperty(PropertyName = "company")]
        public Company Company { get; set; }
    }
}
