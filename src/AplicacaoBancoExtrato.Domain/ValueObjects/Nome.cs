namespace AplicacaoBancoExtrato.Domain.ValueObjects {
    public sealed class Nome {
        private string _text;

        public Nome (string text) {
            if (string.IsNullOrWhiteSpace (text))
                throw new NomeNaoPodeSerVazioException ("O 'Nome' é um campo obrigatório.");

            _text = text;
        }

        public static implicit operator Nome (string text) {
            return new Nome (text);
        }

        public static implicit operator string (Nome name) {
            return name._text;
        }

        public override bool Equals (object obj) {
            if (ReferenceEquals (null, obj)) {
                return false;
            }

            if (ReferenceEquals (this, obj)) {
                return true;
            }

            if (obj is string) {
                return obj.ToString () == _text;
            }

            return ((Nome) obj)._text == _text;
        }
    }
}