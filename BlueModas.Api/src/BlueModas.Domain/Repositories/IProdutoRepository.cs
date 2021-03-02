using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.Domain.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        public Task AdicionarAsync(Produto produto);
        public void Atualizar(Produto produto);
        public void Remover(Produto produto);
        public Task<List<Produto>> ObterTodosAsync();
        public Task<Produto> ObterPorIdAsync(Guid id);

    }
}
