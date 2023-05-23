using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace OsloBySykkelApi.Extensions
{
    public static class HttpClientExtensions
    {
        public static void AddAuthorizationHeader(this HttpClient httpClient, string schema = "Bearer", string? parameter = null)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(schema, parameter);
        }

        public static void AddBearerAuthorizationValue(this HttpClient httpClient, string token)
        {
            var bearer = "Bearer";
            if (token.Contains(bearer))
            {
                token = token.Replace("Bearer ", "");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(bearer, token);
            }
            else
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(bearer, token);
            }
        }

        public static async Task EnsureSuccessStatusCodeAsync(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode) return;

            var content = await response.Content.ReadAsStringAsync();
            if (response.Content != null)
                response.Content.Dispose();
            throw new CustomHttpResponseException(response.StatusCode, content);
        }
        public static async Task<T> GetAsync<T>(this HttpClient client, string url)
        {

            var httpResopse = await client.GetAsync(url);
            await httpResopse.EnsureSuccessStatusCodeAsync();
            var jsonString = await httpResopse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonString);

        }
        public static async Task<T> PostAsync<T>(this HttpClient client, string url, object obj)
        {
            var httpContent = SerializeObjectToHttpContent(obj);
            var httpResopse = await client.PostAsync(url, httpContent);
            await httpResopse.EnsureSuccessStatusCodeAsync();
            var jsonString = await httpResopse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static async Task<T> PutAsync<T>(this HttpClient client, string url, object obj)
        {
            var httpContent = SerializeObjectToHttpContent(obj);
            var httpResopse = await client.PutAsync(url, httpContent);
            await httpResopse.EnsureSuccessStatusCodeAsync();
            var jsonString = await httpResopse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static async Task<T> DeleteAsync<T>(this HttpClient client, string url)
        {
            var httpResopse = await client.DeleteAsync(url);
            await httpResopse.EnsureSuccessStatusCodeAsync();
            var jsonString = await httpResopse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static async Task<T> PostFormDataAsync<T>(this HttpClient client, string url, IFormFile formFile,
            string name = "Bilde")
        {
            var formData = BildeFormData(formFile, name);
            var httpResopse = await client.PostAsync(url, formData);
            await httpResopse.EnsureSuccessStatusCodeAsync();
            var jsonString = await httpResopse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
        private static HttpContent SerializeObjectToHttpContent(object obj)
        {
            HttpContent httpContent =
                new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            return httpContent;
        }

        private static MultipartFormDataContent BildeFormData(IFormFile file, string name)
        {
            byte[] byteArray;
            using (var br = new BinaryReader(file.OpenReadStream()))
                byteArray = br.ReadBytes((int)file.OpenReadStream().Length);

            var multipartContent = new MultipartFormDataContent();
            var byteArrayContent = new ByteArrayContent(byteArray);
            multipartContent.Add(byteArrayContent, name, file.FileName);
            return multipartContent;
        }
    }
}