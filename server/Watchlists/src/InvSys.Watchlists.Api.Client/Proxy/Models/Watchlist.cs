// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace InvSys.Watchlists.Api.Client.Proxy.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class Watchlist
    {
        /// <summary>
        /// Initializes a new instance of the Watchlist class.
        /// </summary>
        public Watchlist() { }

        /// <summary>
        /// Initializes a new instance of the Watchlist class.
        /// </summary>
        public Watchlist(Guid? id = default(Guid?), string culture = default(string), Guid? userId = default(Guid?), string userName = default(string), string name = default(string), string description = default(string), IList<Item> items = default(IList<Item>))
        {
            Id = id;
            Culture = culture;
            UserId = userId;
            UserName = userName;
            Name = name;
            Description = description;
            Items = items;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "culture")]
        public string Culture { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "userId")]
        public Guid? UserId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "items")]
        public IList<Item> Items { get; set; }

    }
}
