using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Dto;
using Domain.Service.DomainService.Interface;
using Infrastructure.Core.Entities;

namespace Domain.Service.DomainService
{
    public class OrderDomainService: IOrderDomainService
    {
        public OrderDomainService() { }

        public void ValidateOrderRequest(OrderRequest orderRequest)
        {

            if (orderRequest == null)
                throw new ArgumentNullException(nameof(orderRequest), "La solicitud de pedido no puede ser nula.");

            if (orderRequest.enviarPedido == null)
                throw new ArgumentNullException(nameof(orderRequest.enviarPedido), "El campo enviarPedido no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(orderRequest.enviarPedido.cantidadPedido))
                throw new ArgumentException("El campo cantidadPedido no puede ser nulo ni vacío.", nameof(orderRequest.enviarPedido.cantidadPedido));
        }
    }
}
