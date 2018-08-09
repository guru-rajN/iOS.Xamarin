using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ExtAppraisalApp.Services
{
    public class RestClient
    {
        public RestClient()
        {
        }

        // Initialize Httpclient
        public static HttpClient GetHttpClient()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false,
                UseProxy = false
            };
            HttpClient httpClient = new HttpClient(handler, true);
            httpClient.Timeout = new TimeSpan(0, 10, 30);
            httpClient.BaseAddress = new Uri(Url.BASE_URL);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + "RERDVXNlcjpERENVc2VyMDE=");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }

        // GET Method
        public static HttpResponseMessage doGet(string url)
        {

            HttpResponseMessage responseMessage = null;
            try
            {
                responseMessage = GetHttpClient().GetAsync(url).Result;
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception occurred :: " + exc.Message);
            }
            return responseMessage;
        }

        // POST Method
        public static HttpResponseMessage doPost(string url, string body)
        {
            HttpResponseMessage responseMessage = null;
            StringContent content = new StringContent(body);

            //var json = JsonConvert.SerializeObject(body);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                responseMessage = GetHttpClient().PostAsync(url, content).Result;
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception occurred :: " + exc.Message);
            }

            return responseMessage;
        }

        // PUT Method
        public static HttpResponseMessage doPut(string url, string contentdata)
        {
            HttpResponseMessage responseMessage = null;
            StringContent content = new StringContent(contentdata);

            //var json = JsonConvert.SerializeObject(body);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                responseMessage = GetHttpClient().PutAsync(url, content).Result;
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception occurred :: " + exc.Message);
            }

            return responseMessage;
        }

        // Delete Method
        public static HttpResponseMessage doDelete(string url)
        {
            HttpResponseMessage httpResponseMessage = null;

            try
            {
                httpResponseMessage = GetHttpClient().DeleteAsync(url).Result;
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception occurred :: " + exc.Message);
            }

            return httpResponseMessage;
        }
    }
}
