using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Core.Entities;
using Infrastructure.Core.Repository.Interface;

namespace Infrastructure.Core.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IBaseModel<UserEntity> Users { get; }
        Task SaveAsync();
    }
}
