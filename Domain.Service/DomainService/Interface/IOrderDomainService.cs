using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Dto;
using Infrastructure.Core.Entities;
using Infrastructure.Core.UnitOfWork.Interface;

namespace Domain.Service.DomainService.Interface
{
    public interface IOrderDomainService
    {
        void ValidateOrderRequest(OrderRequest orderRequest);
    }
}
