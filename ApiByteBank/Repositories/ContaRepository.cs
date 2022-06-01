using ApiByteBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiByteBank.Repositories
{
    public class ContaRepository : GenericRepository<Conta>, IContaRepository
    {
        public ContaRepository(AppBancoContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
