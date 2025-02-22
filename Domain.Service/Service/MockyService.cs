using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Service.Service.Interface;
using System.Net.Http;
using System.Threading.Tasks;
using Azure;


namespace Domain.Service.Service
{
    public class MockyService: IMockyService
    {
        private readonly HttpClient _httpClient;

        public MockyService(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<string> MakeRequestSoap(string endpoint, string messageSoap)
        {
            try
            {
                var content = new StringContent(messageSoap, Encoding.UTF8, "text/xml"); 
                _httpClient.Timeout = TimeSpan.FromSeconds(60); 

                using var response = await _httpClient.PostAsync(endpoint, content);

                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException($"Error en la API: {response.StatusCode}");

                return await response.Content.ReadAsStringAsync();
            }
            catch (TaskCanceledException ex)
            {
                throw new HttpRequestException($"Request timed out: {ex.Message}", ex);
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"Error en la API: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error: {ex.Message}", ex);
            }
        }
    }
}
