namespace AplicacaoBancoExtrato.Domain.ValueObjects {
    public sealed class ValorTransacao
    {
        private decimal _valor;

        public ValorTransacao (decimal valor) {
            if (valor < 0)
                throw new ValorTransacaoDeveSerPositivoException ($"O valor {valor} não é válido. Deve ser um valor positivo.");

            _valor = valor;
        }

        public override string ToString () {
            return _valor.ToString ("C");
        }

        public static implicit operator decimal (ValorTransacao valor) {
            return valor._valor;
        }

        public static implicit operator ValorTransacao (decimal valor) {
            return new ValorTransacao (valor);
        }

        public static ValorTransacao operator + (ValorTransacao ValorTransacao1, ValorTransacao ValorTransacao2) {
            return new ValorTransacao (ValorTransacao1._valor + ValorTransacao2._valor);
        }

        public static ValorTransacao operator - (ValorTransacao ValorTransacao1, ValorTransacao ValorTransacao2) {
            return new ValorTransacao (ValorTransacao1._valor - ValorTransacao2._valor);
        }

        public static bool operator < (ValorTransacao ValorTransacao1, ValorTransacao ValorTransacao2) {
            return ValorTransacao1._valor < ValorTransacao2._valor;
        }

        public static bool operator > (ValorTransacao ValorTransacao1, ValorTransacao ValorTransacao2) {
            return ValorTransacao1._valor > ValorTransacao2._valor;
        }

        public static bool operator <= (ValorTransacao ValorTransacao1, ValorTransacao ValorTransacao2) {
            return ValorTransacao1._valor <= ValorTransacao2._valor;
        }

        public static bool operator >= (ValorTransacao ValorTransacao1, ValorTransacao ValorTransacao2) {
            return ValorTransacao1._valor >= ValorTransacao2._valor;
        }

        public override bool Equals (object obj) {
            if (ReferenceEquals (null, obj)) {
                return false;
            }

            if (ReferenceEquals (this, obj)) {
                return true;
            }

            if (obj is decimal) {
                return (decimal) obj == _valor;
            }

            return ((ValorTransacao) obj)._valor == _valor;
        }

        public override int GetHashCode () {
            return -1939223833 + _valor.GetHashCode ();
        }
    }
}