using Newtonsoft.Json;

namespace VowsApp.Services
{
    public class ApiServiceHandler
    {
        HttpClient client;
        public ApiServiceHandler()
        {
            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            #if DEBUG
                client = new HttpClient(clientHandler);
            #else
                client = new HttpClient();
            #endif

            //#if DEBUG
            //    client = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());
            //#else
            //    client = new HttpClient();
            //#endif
        }

        //public static async Task<T> GetDataAsync<T>(string method)
        //{
        //    client.DefaultRequestHeaders.ExpectContinue = false;
        //    T returnResult = default(T);

        //    client.BaseAddress = new Uri("http://192.168.0.135:49820/api/todoitems");

        //    try
        //    {
        //        var response = await client.GetAsync(method);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var content = await response.Content.ReadAsStringAsync();
        //            returnResult = JsonConvert.DeserializeObject<T>(content);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return returnResult;
        //}

        public async Task<T> GetDataAsync<T>(string method)
        {
            try
            {
                client.DefaultRequestHeaders.ExpectContinue = false;
                T returnResult = default(T);

                string uri = string.Format(Constants.WeatherForecastUrl, method);
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    returnResult = JsonConvert.DeserializeObject<T>(content);
                }
                return returnResult;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
