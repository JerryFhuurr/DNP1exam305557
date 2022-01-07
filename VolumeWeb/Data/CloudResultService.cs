using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VolumeWeb.VolumeCalculator;

namespace VolumeWeb.Data
{
    public class CloudResultService : IResultService
    {
        private string url = "https://localhost:5001";
        private readonly HttpClient client;

        public CloudResultService()
        {
            client = new HttpClient();
        }


        public async Task<IList<VolumeResult>> GetResultsAsync()
        {
            HttpResponseMessage response = await client.GetAsync(url + "/api/Calculator");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error");
            }

            string message = await response.Content.ReadAsStringAsync();
            List<VolumeResult> list = JsonSerializer.Deserialize<List<VolumeResult>>(message);
            return list;
        }

        public async Task RemoveVolumeResultAsync(int Id)
        {
            HttpResponseMessage responseMessage = await client.DeleteAsync($"{url}/Calculator/{Id}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }

        public async Task AddCylinderResultAsync(VolumeCalculator.VolumeCalculator calculator)
        {
            string reesultAsJson = JsonSerializer.Serialize(calculator);
            Console.WriteLine(reesultAsJson);
            HttpContent content = new StringContent(reesultAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PostAsync(url + "/cylinder", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }
        }

        public async Task AddConeResultAsync(VolumeCalculator.VolumeCalculator calculator)
        {
            string reesultAsJson = JsonSerializer.Serialize(calculator);
            HttpContent content = new StringContent(reesultAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PostAsync(url + "/cone", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }
        }
    }
}
