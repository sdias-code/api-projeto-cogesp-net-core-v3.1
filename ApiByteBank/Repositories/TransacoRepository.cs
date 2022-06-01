using ApiByteBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiByteBank.Repositories
{
    public class TransacoRepository : GenericRepository<Transaco>, ITransacoRepository
    {
        public TransacoRepository(AppBancoContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
