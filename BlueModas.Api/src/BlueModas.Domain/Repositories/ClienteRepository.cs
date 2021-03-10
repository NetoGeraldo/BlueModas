using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.Domain.Repositories
{
    public interface IClienteRepository :IRepository<Cliente>
    {
        Task<Cliente> ObterPorIdAsync(Guid id);
        Task<Cliente> ObterPorEmailAsync(string email);

        Task AdicionarAsync(Cliente cliente);
    }
}
