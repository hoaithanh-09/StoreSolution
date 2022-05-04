using Newtonsoft.Json;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Text;
using System.Reflection;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Store.Services.Utilities;
using Store.ViewModels.Common;

namespace Store.Services.Core
{
    public interface IHttpService
    {
        Task<T> SendAsync<T>(string url, string method, object? parameter, object? payload);

        Task<T> GetAsync<T>(string url);

        Task<T> PostAsync<T>(string url, object payload, bool isJsonType = false);

        Task<T> PutAsync<T>(string url, object payload, bool isJsonType = false);

        Task<T> DeleteAsync<T>(string url);
    }

    public class HttpService : IHttpService
    {
        private readonly HttpClient _client;

        public HttpService(HttpClient client)
        {
            _client = client;
        }

        public async Task<T> SendAsync<T>(string url, string method, object? parameter, object? payload)
        {
            var urlBuilder = url;
            if (!parameter.Equals(null))
                urlBuilder = BuildUrlWithParams(url, parameter);

            var payloadBuilder = payload;
            if (payloadBuilder.Equals(null))
                payloadBuilder = new { };

            switch (method)
            {
                case "POST":
                    {
                        return await PostAsync<T>(urlBuilder, payloadBuilder);
                    }
                case "PUT":
                    {
                        return await PutAsync<T>(urlBuilder, payloadBuilder);
                    }
                case "DELETE":
                    {
                        return await DeleteAsync<T>(urlBuilder);
                    }
                default:
                    {
                        return await GetAsync<T>(urlBuilder);
                    }
            }
        }

        public async Task<T> GetAsync<T>(string url)
        {
            /* Request */
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            /* Deserialize */
            var responseText = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(responseText);
            return data;
        }

        public async Task<T> PostAsync<T>(string url, object payload, bool isJsonType = false)
        {
            /* Prepare */
            dynamic httpContent;
            if (isJsonType)
            {
                var stringPayload = JsonConvert.SerializeObject(payload);
                httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            }
            else
            {
                var convertedPayload = BuildPayloadFromObject(payload);
                httpContent = new FormUrlEncodedContent(convertedPayload);
            }

            /* Request */
            var response = await _client.PostAsync(url, httpContent);
            response.EnsureSuccessStatusCode();

            /* Deserialize */
            var responseText = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(responseText);
            return data;
        }

        public async Task<T> PutAsync<T>(string url, object payload, bool isJsonType = false)
        {
            /* Prepare */
            dynamic httpContent;
            if (isJsonType)
            {
                var stringPayload = JsonConvert.SerializeObject(payload);
                httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            }
            else
            {
                var convertedPayload = BuildPayloadFromObject(payload);
                httpContent = new FormUrlEncodedContent(convertedPayload);
            }

            /* Request */
            var response = await _client.PutAsync(url, httpContent);
            response.EnsureSuccessStatusCode();

            /* Deserialize */
            var responseText = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(responseText);
            return data;
        }

        public async Task<T> DeleteAsync<T>(string url)
        {
            /* Request */
            var response = await _client.DeleteAsync(url);
            response.EnsureSuccessStatusCode();

            /* Deserialize */
            var responseText = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(responseText);
            return data;
        }

        #region Utilities
        public string BuildUrlWithParams(string url, object parameter)
        {
            var parameters = new Dictionary<string, string>();
            foreach (PropertyInfo props in parameter.GetType().GetProperties())
            {
                parameters.Add(props.Name.Camelize(), props.GetValue(parameter, null).ToString());
            }

            return new Uri(QueryHelpers.AddQueryString(url, parameters)).ToString();
        }

        public List<KeyValuePair<string, string>> BuildPayloadFromObject(object payload)
        {
            var result = new List<KeyValuePair<string, string>>();
            foreach (PropertyInfo props in payload.GetType().GetProperties())
            {
                var key = props.Name.Camelize();
                try
                {
                    key = props.GetCustomAttribute<ObjectPropertyAttribute>().ToString();
                }
                catch (Exception)
                {
                }

                result.Add(
                        new KeyValuePair<string, string>(key, props.GetValue(payload, null).ToString())
                    );
            }

            return result;
        }
        #endregion
    }
}