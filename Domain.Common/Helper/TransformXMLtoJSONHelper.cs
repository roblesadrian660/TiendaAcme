using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using Domain.Common.Dto;

namespace Domain.Common.Helper
{
    public class TransformXMLtoJSONHelper
    {
        public TransformXMLtoJSONHelper() { }

        public static SendOrderResponse ConvertSoapXmlToJson(string soapXml)
        {
            try
            {
               
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(soapXml);
                var codigo = xmlDoc.SelectSingleNode("//Codigo")?.InnerText;
                var mensaje = xmlDoc.SelectSingleNode("//Mensaje")?.InnerText;

                return new SendOrderResponse
                {
                    CodigoEnvio = codigo,
                    Estado = mensaje
                };
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error converting SOAP XML to JSON", ex);
            }
        }
    }
}
