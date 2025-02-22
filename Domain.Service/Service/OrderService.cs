using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Common.Dto;
using Domain.Common.Helper;
using Domain.Service.Service.Interface;
using Microsoft.Extensions.Configuration;

namespace Domain.Service.Service
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IMockyService _mockyService;
        private readonly string _baseUrl;

        public OrderService(IMapper mapper, IMockyService mockyService , IConfiguration configuration)
        {
            _mapper = mapper;
            _mockyService = mockyService;
            _baseUrl = configuration["MockeyApi:Url"];
        }

        public async Task<SendOrderResponse> CreateOrder(OrderRequest orderAcme)
        {
            OrderXml orderXml = _mapper.Map<OrderXml>(orderAcme.enviarPedido);
            var xml = TransformJSONtoXMLHelper.ConvertOrderXmlToSoapXml(orderXml);
            var respRequestSoap = await _mockyService.MakeRequestSoap(_baseUrl, xml);
            SendOrderResponse sendOrderResponse = TransformXMLtoJSONHelper.ConvertSoapXmlToJson(respRequestSoap);
            return sendOrderResponse;
        }
    }
}
