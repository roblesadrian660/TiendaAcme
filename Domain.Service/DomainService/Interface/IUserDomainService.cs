using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Core.Entities;
using Infrastructure.Core.UnitOfWork.Interface;

namespace Domain.Service.DomainService.Interface
{
    public interface IUserDomainService
    {
        void ValidateUserCreation(UserEntity userEntity, IUnitOfWork unitOfWork);
    }
}
