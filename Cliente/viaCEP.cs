using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApplication5.Cliente.Interface;
using WebApplication5.Model;

namespace WebApplication5.Cliente
{
    public class viaCEP : IviaCEP
    {

        private readonly IHttpClientFactory _factory;

        public viaCEP(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<string> GetEnderecoAsync(string cep)
        {
            string url = $"https://ws.apicep.com/cep/{cep}.json";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _factory.CreateClient("viacep");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string readString = await response.Content.ReadAsStringAsync();        
                return readString;
            }
            else
            {
                return "Erro ao buscar CEP;";
            }






        }

    }
}
