using ApiByteBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiByteBank.Repositories
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(SilvioBbAppBancoContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
