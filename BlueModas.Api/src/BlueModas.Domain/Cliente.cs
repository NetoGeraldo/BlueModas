using System.Collections.Generic;

namespace BlueModas.Domain
{
    public class Cliente : Entity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }

        private readonly List<Pedido> _pedidos;
        public IReadOnlyCollection<Pedido> Pedidos => _pedidos;

        public Cliente(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }


    }
}
