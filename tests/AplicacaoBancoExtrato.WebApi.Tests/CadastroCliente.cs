namespace AplicacaoBancoExtrato.IntegrationTests
{
    using Microsoft.AspNetCore.Hosting;
    using Autofac.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using AplicacaoBancoExtrato.WebApi;
    using Microsoft.AspNetCore.TestHost;
    using Xunit;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Newtonsoft.Json;
    using System.Text;
    using Newtonsoft.Json.Linq;
    using System;

    public class CadastroCliente
    {
        private readonly TestServer server;
        private readonly HttpClient client;

        public CadastroCliente()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    IHostingEnvironment env = builderContext.HostingEnvironment;
                    config.AddJsonFile("autofac.json")
                    .AddEnvironmentVariables();
                })
                .ConfigureServices(services => services.AddAutofac());

            server = new TestServer(webHostBuilder);
            client = server.CreateClient();
        }

        [Fact]
        public async Task CadastrarDepositarSacarEncerrar()
        {
            Tuple<string, string> idCliente_idConta = await Cadastrar(100);
            await GetCliente(idCliente_idConta.Item1);
            await GetConta(idCliente_idConta.Item2);
            await Saque(idCliente_idConta.Item2, 100);
            await GetCliente(idCliente_idConta.Item1);
            await Deposito(idCliente_idConta.Item2, 500);
            await Deposito(idCliente_idConta.Item2, 400);
            await GetCliente(idCliente_idConta.Item1);
            await Saque(idCliente_idConta.Item2, 400);
            await Saque(idCliente_idConta.Item2, 500);
            await Encerrar(idCliente_idConta.Item2);
        }

        private async Task GetCliente(string customerId)
        {
            string result = await client.GetStringAsync("/api/Clientes/" + customerId);
        }

        private async Task GetConta(string accountId)
        {
            string result = await client.GetStringAsync("/api/Contas/" + accountId);
        }

        private async Task<Tuple<string, string>> Cadastrar(double initialAmount)
        {
            var register = new
            {
                pin = "08724050601",
                name = "Everton Varago",
                initialAmount = initialAmount
            };

            string registerData = JsonConvert.SerializeObject(register);
            StringContent content = new StringContent(registerData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Clientes", content);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("idCliente", responseString);
            JObject customer = JsonConvert.DeserializeObject<JObject>(responseString);

            string idCliente = customer["idCliente"].Value<string>();
            string idConta = ((JContainer)customer["contas"]).First["idConta"].Value<string>();

            return new Tuple<string, string>(idCliente, idConta);
        }

        private async Task Deposito(string conta, double valor)
        {
            var json = new
            {
                idConta = conta,
                valor = valor,
            };

            string data = JsonConvert.SerializeObject(json);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = await client.PatchAsync("api/Accounts/Deposito", content);
            string result = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }

        private async Task Saque(string conta, double valor)
        {
            var json = new
            {
                idConta = conta,
                valor = valor,
            };

            string data = JsonConvert.SerializeObject(json);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = await client.PatchAsync("api/Contas/Saque", content);
            string result = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }

        private async Task Encerrar(string account)
        {
            var response = await client.DeleteAsync("api/Contas/" + account);
            response.EnsureSuccessStatusCode();
        }
    }

    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content)
        {
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = content
            };

            var response = await client.SendAsync(request);
            return response;
        }
    }
}