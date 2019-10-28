namespace AplicacaoBancoExtrato.WebApi.UseCases.Cadastro
{
    public class CadastroRequest {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal ValorInicial { get; set; }
    }
}