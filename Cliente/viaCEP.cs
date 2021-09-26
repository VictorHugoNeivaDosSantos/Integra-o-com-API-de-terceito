using Newtonsoft.Json;
using System;
using System.Net.Http;
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

        public async Task<CEPModel> GetEnderecoAsync(string cep)
        {
            string url = $"https://ws.apicep.com/cep/{cep}.json";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _factory.CreateClient("viacep");
            var response = await client.SendAsync(request);
            string readString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var endereco = JsonConvert.DeserializeObject<CEPModel>(readString);
                return endereco;
            }
            else
            {
                throw new Exception("Endereço não encontrado.");
            }

        }

    }
}
