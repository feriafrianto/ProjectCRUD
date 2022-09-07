using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraderSys.Portfolios.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace TraderSys.Portfolios.Repositories
{
    public class BaseRepository
    {
        protected readonly IDbContextFactory<Context> Context;

        public BaseRepository(IDbContextFactory<Context> context)
        {
            Context = context;
        }
    }
}