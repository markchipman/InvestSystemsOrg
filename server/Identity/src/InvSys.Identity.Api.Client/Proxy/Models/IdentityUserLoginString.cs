// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace InvSys.Identity.Api.Client.Proxy.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class IdentityUserLoginString
    {
        /// <summary>
        /// Initializes a new instance of the IdentityUserLoginString class.
        /// </summary>
        public IdentityUserLoginString() { }

        /// <summary>
        /// Initializes a new instance of the IdentityUserLoginString class.
        /// </summary>
        public IdentityUserLoginString(string loginProvider = default(string), string providerKey = default(string), string providerDisplayName = default(string), string userId = default(string))
        {
            LoginProvider = loginProvider;
            ProviderKey = providerKey;
            ProviderDisplayName = providerDisplayName;
            UserId = userId;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "loginProvider")]
        public string LoginProvider { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "providerKey")]
        public string ProviderKey { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "providerDisplayName")]
        public string ProviderDisplayName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

    }
}
