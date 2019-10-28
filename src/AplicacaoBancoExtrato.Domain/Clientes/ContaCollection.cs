namespace AplicacaoBancoExtrato.Domain.Clientes
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System;

    public sealed class ContaCollection {
        private readonly IList<Guid> _ContaIds;

        public ContaCollection () {
            _ContaIds = new List<Guid> ();
        }

        public IReadOnlyCollection<Guid> ToReadOnlyCollection () {
            IReadOnlyCollection<Guid> ContaIds = new ReadOnlyCollection<Guid> (_ContaIds);
            return ContaIds;
        }

        public void Add (Guid IdConta) {
            _ContaIds.Add (IdConta);
        }
    }
}