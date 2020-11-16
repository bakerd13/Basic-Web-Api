using System;
using System.Text;
using Newtonsoft.Json;

namespace DABTechs.eCommerce.Sales.Common.Config
{
    public class AppSettings
    {
        [JsonProperty("LocalDomain")]
        public string LocalDomain { get; set; }

        [JsonProperty("Domain")]
        public string Domain { get; set; }

        [JsonProperty("SaleDomain")]
        public string SaleDomain { get; set; }

        [JsonProperty("ClearanceDomain")]
        public string ClearanceDomain { get; set; }

        [JsonProperty("ProductsPerPage")]
        public int ProductsPerPage { get; set; }

        [JsonProperty("SearchProviderName")]
        public string SearchProviderName { get; set; }

        [JsonProperty("ImageBaseUrl")]
        public string ImageBaseUrl { get; set; }

        [JsonProperty("AzureApi")]
        public string AzureApi { get; set; }

        [JsonProperty("SearchApi")]
        public string SearchApi { get; set; }

        [JsonIgnore]
        public string SearchApiSettingsValue
        {
            get
            {
                var brSettings = new StringBuilder();
                brSettings.Append($"account_id={SearchAccountId}");
                brSettings.Append($"&auth_key={SearchAuthKey}");
                brSettings.Append($"&domain_key={SearchDomainKey}");
                brSettings.Append($"&request_id={DateTime.Now.ToString("yyyyMMddHHmmssfffffff")}");
                brSettings.Append($"&&_uid_2={SearchBRUID}");
                brSettings.Append($"&url={SearchUrl}");
                brSettings.Append($"&ref_url={SearchRefUrl}");
                brSettings.Append($"&request_type={SearchRequestType}");
                brSettings.Append($"&limit={SearchFacetLimit}");
                brSettings.Append($"&fl={SearchFL}");
                brSettings.Append($"&stats.field={Statistics}");

                return brSettings.ToString();
            }
        }

        [JsonProperty("SearchAccountId")]
        public string SearchAccountId { get; set; }

        [JsonProperty("SearchAuthKey")]
        public string SearchAuthKey { get; set; }

        [JsonProperty("SearchDomainKey")]
        public string SearchDomainKey { get; set; }

        [JsonProperty("SearchBRUID")]
        public string SearchBRUID { get; set; }

        [JsonProperty("SearchRequestId")]
        public string SearchRequestId { get; set; }

        [JsonProperty("SearchUrl")]
        public string SearchUrl { get; set; }

        [JsonProperty("SearchRefUrl")]
        public string SearchRefUrl { get; set; }

        [JsonProperty("SearchRequestType")]
        public string SearchRequestType { get; set; }

        [JsonProperty("SearchFacetLimit")]
        public string SearchFacetLimit { get; set; }

        [JsonProperty("Statistics")]
        public string Statistics { get; set; }

        [JsonProperty("SearchFL")]
        public string SearchFL { get; set; }

        [JsonProperty("AuthCookieSecretKey")]
        public string AuthCookieSecretKey { get; set; }

        [JsonProperty("FiltersHtmlString")]
        public string FiltersHtmlString { get; set; }

        [JsonProperty("SearchResultsHtmlString")]
        public string SearchResultsHtmlString { get; set; }

        [JsonProperty("RemoteServer")]
        public string RemoteServer { get; set; }

        [JsonProperty("LocalServer")]
        public string LocalServer { get; set; }

        [JsonProperty("TemplateCacheMins")]
        public int TemplateCacheMins { get; set; }

        [JsonProperty("DemandPublicKey")]
        public bool DemandPublicKey { get; set; }

        [JsonProperty("RemoteDomain")]
        public string RemoteDomain { get; set; }

        [JsonProperty("CookieDomain")]
        public string CookieDomain { get; set; }

        [JsonProperty("UseProxy")]
        public bool UseProxy { get; set; }

        [JsonProperty("ProxyAddress")]
        public string ProxyAddress { get; set; }

        [JsonProperty("LocalResource")]
        public string LocalResource { get; set; }

        [JsonProperty("MaxPages")]
        public int MaxPages { get; set; }
    }
}