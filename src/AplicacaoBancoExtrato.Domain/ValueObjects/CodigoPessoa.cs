namespace AplicacaoBancoExtrato.Domain.ValueObjects {
    using System.Text.RegularExpressions;

    public sealed class CodigoPessoa {
        private string _text;
        const string RegExForValidation = @"^\d{6,8}[-|(\s)]{0,1}\d{4}$";

        public CodigoPessoa (string text) {
            if (string.IsNullOrWhiteSpace (text))
                throw new CodigoPessoaNaoPodeSerVazioException ("O 'Código' é um campo obrigatório");

            Regex regex = new Regex (RegExForValidation);
            Match match = regex.Match (text);

            if (!match.Success)
                throw new CodigoPessoaInvalidoException ($"{text} código da pessoa é inválido. Use o formato YYMMDDNNNN.");

            _text = text;
        }

        public static implicit operator CodigoPessoa (string text) {
            return new CodigoPessoa (text);
        }

        public static implicit operator string (CodigoPessoa ssn) {
            return ssn._text;
        }
    }
}