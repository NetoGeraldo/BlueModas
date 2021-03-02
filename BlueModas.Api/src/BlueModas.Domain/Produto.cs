using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.Domain
{
    public class Produto : Entity
    {
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public byte[] Imagem { get; private set; }

        public Produto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public void AlterarNome(string novoNome)
        {
            if (string.IsNullOrWhiteSpace(novoNome))
                return;

            Nome = novoNome;
        }

        public void AlterarPreco(decimal novoPreco)
        {
            if (novoPreco <= 0)
                return;

            Preco = novoPreco;
        }

        public void AlterarImagem(byte[] novaImagem)
        {
            if (novaImagem.Length <= 0)
                return;

            Imagem = novaImagem;
        }

    }
}
