using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Core.Context;
using Infrastructure.Core.Entities;
using Infrastructure.Core.Repository;
using Infrastructure.Core.Repository.Interface;
using Infrastructure.Core.UnitOfWork.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Core.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ContextSQL _context;

        public UnitOfWork(ContextSQL context ) {
            _context = context;
            Users = new BaseModel<UserEntity>(_context);
        }

        public IBaseModel<UserEntity> Users { get; private set; }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
