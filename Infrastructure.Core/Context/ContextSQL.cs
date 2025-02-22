using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Core.Context
{
    public class ContextSQL: DbContext
    {
        public ContextSQL(DbContextOptions dbContextOptions)
          : base(dbContextOptions)
        {
        }

        public virtual DbSet<UserEntity> Customer { get; set; }
    }
}
