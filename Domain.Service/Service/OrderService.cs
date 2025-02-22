using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Common.Dto;
using Domain.Common.Helper;
using Domain.Service.DomainService;
using Domain.Service.DomainService.Interface;
using Domain.Service.Service.Interface;
using Microsoft.Extensions.Configuration;

namespace Domain.Service.Service
{
    public class OrderService : IOrderService
    {
        private readonly string _baseUrl;
        private readonly IMapper _mapper;
        private readonly IOrderDomainService _orderDomainService;
        private readonly IMockyService _mockyService;
        private readonly TransformJSONtoXMLHelper _transformJSONtoXMLHelper;
        private readonly TransformXMLtoJSONHelper _transformXMLtoJSONHelper;

        public OrderService(IMapper mapper, 
                            IMockyService mockyService , 
                            IConfiguration configuration,
                            IOrderDomainService orderDomainService,
                            TransformJSONtoXMLHelper transformJSONtoXMLHelper, 
                            TransformXMLtoJSONHelper transformXMLtoJSONHelper
        )
        {
            _mapper = mapper;
            _mockyService = mockyService;
            _baseUrl = configuration["MockeyApi:Url"];
            _transformJSONtoXMLHelper = transformJSONtoXMLHelper;
            _transformXMLtoJSONHelper = transformXMLtoJSONHelper;
            _orderDomainService = orderDomainService;
        }

        public async Task<SendOrderResponse> CreateOrder(OrderRequest orderAcme)
        {
            _orderDomainService.ValidateOrderRequest(orderAcme);
            OrderXml orderXml = _mapper.Map<OrderXml>(orderAcme.enviarPedido);
            var xml = _transformJSONtoXMLHelper.ConvertOrderXmlToSoapXml(orderXml);
            var respRequestSoap = await _mockyService.MakeRequestSoap(_baseUrl, xml);
            SendOrderResponse sendOrderResponse = _transformXMLtoJSONHelper.ConvertSoapXmlToJson(respRequestSoap);
            return sendOrderResponse;
        }
    }
}
