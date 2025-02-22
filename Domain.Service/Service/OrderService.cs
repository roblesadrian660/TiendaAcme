using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Common.Dto;
using Domain.Common.Helper;
using Domain.Service.Service.Interface;

namespace Domain.Service.Service
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IMockyService _mockyService;
        public OrderService(IMapper mapper, IMockyService mockyService = null)
        {
            _mapper = mapper;
            _mockyService = mockyService;
        }

        public async void CreateOrder(OrderRequest orderAcme)
        {
            OrderXml orderXml = _mapper.Map<OrderXml>(orderAcme.enviarPedido);
            var xml =  TransformJSONtoXMLHelper.ConvertOrderXmlToSoapXml(orderXml);


           var a = await _mockyService.MakeRequestSoap("https://run.mocky.io/v3/e169e9bc-16a7-4d76-b064-125efdab5b99", xml);
        }
    }
}
