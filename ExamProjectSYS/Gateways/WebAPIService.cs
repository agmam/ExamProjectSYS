using Newtonsoft.Json;
using ProjectManagementAPI.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectManagementAPI.Gateways
{
    public class WebAPIService
    {
        public WebAPIService(string baseUri)
        {
            BaseUri = baseUri;

        }


        public string BaseUri { get; private set; }



        private static async Task<T> DeserializeObject<T>(HttpResponseMessage result)
        {

            string json = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            throw new Exception();
        }

        private string ActionUri(string action)
        {
            var c = BaseUri + action;
            return c;
        }

        public async Task<T> GetAsync<T>(string action)
        {
            RestClient c = new RestClient();
            c.BaseUrl = new Uri(ActionUri(action));

            var req = new RestRequest("", Method.GET);
            var response = c.Execute(req);
            var data = response.Content;
            T t = JsonConvert.DeserializeObject<T>(data);
            return t;
            //using (var client = new HttpClient())
            //{



            //using (Stream s = data)
            //using (StreamReader sr = new StreamReader(s))
            //using (JsonReader reader = new JsonTextReader(sr))
            //{
            //    JsonSerializer serializer = new JsonSerializer();

            //    // read the json from a stream
            //    // json size doesn't matter because only a small piece is read at a time from the HTTP request
            //    T t = serializer.Deserialize<T>(reader);
            //    return t;
            //}


            //    //var result = client.GetAsync(ActionUri(action)).Result;
            //    // return await DeserializeObject<T>(result);
            //}
        }



        public async Task<bool> PutAsync<T>(string action, T data)
        {
            RestClient c = new RestClient();
            c.BaseUrl = new Uri(ActionUri(action));

            var req = new RestRequest("", Method.PUT);
            req.AddJsonBody(data);
            var response = c.Execute(req);
           
            return response.IsSuccessful;
            //using (var client = new HttpClient())
            //{

            //    var result = client.PutAsJsonAsync(ActionUri(action), data).Result;
            //    string json = await result.Content.ReadAsStringAsync();
            //    if (result.IsSuccessStatusCode)
            //    {
            //        return true;
            //    }
            //    return false;
            //}
        }

        public async Task<T> PostAsync<T>(string action, T data)
        {
            RestClient c = new RestClient();
            c.BaseUrl = new Uri(ActionUri(action));

            var req = new RestRequest("", Method.POST);
            req.AddJsonBody(data);
            var response = c.Execute(req);

            if( response.IsSuccessful)
            {
                var content = response.Content;
                T t = JsonConvert.DeserializeObject<T>(content);
                return t;
            }
            return default(T);
            //using (var client = new HttpClient())
            //{

            //    var result = client.PostAsJsonAsync(ActionUri(action), data).Result;
            //    return await DeserializeObject<T>(result);
            //}
        }

        public async Task<bool> DeleteAsync<T>(string action)
        {

            RestClient c = new RestClient();
            c.BaseUrl = new Uri(ActionUri(action));

            var req = new RestRequest("", Method.DELETE);
       
            var response = c.Execute(req);

            return response.IsSuccessful;
            //using (var client = new HttpClient())
            //{

            //    var result = client.DeleteAsync(ActionUri(action)).Result;
            //    string json = await result.Content.ReadAsStringAsync();
            //    if (result.IsSuccessStatusCode)
            //    {
            //        return true;
            //    }
            //    return false;
            //}
        }
    }
}
