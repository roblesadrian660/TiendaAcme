using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Dto;
using System.Xml.Linq;

namespace Domain.Common.Helper
{
    public class TransformJSONtoXMLHelper
    {
        public TransformJSONtoXMLHelper() { }

        public static string ConvertOrderXmlToSoapXml(OrderXml orderXml)
        {
            try
            {
                XNamespace soapenv = "http://schemas.xmlsoap.org/soap/envelope/";
                XNamespace env = "http://WSDLs/EnvioPedidos/EnvioPedidosAcme";

                var soapXml = new XDocument(
                    new XElement(soapenv + "Envelope",
                        new XAttribute(XNamespace.Xmlns + "soapenv", soapenv),
                        new XAttribute(XNamespace.Xmlns + "env", env),
                        new XElement(soapenv + "Header"),
                        new XElement(soapenv + "Body",
                            new XElement(env + "EnvioPedidoAcme",
                                new XElement("EnvioPedidoRequest",
                                    new XElement("pedido", orderXml.pedido),
                                    new XElement("Cantidad", orderXml.Cantidad),
                                    new XElement("EAN", orderXml.EAN),
                                    new XElement("Producto", orderXml.Producto),
                                    new XElement("Cedula", orderXml.Cedula),
                                    new XElement("Direccion", orderXml.Direccion)
                                )
                            )
                        )
                    )
                );
                return soapXml.ToString();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error converting OrderXml to SOAP XML", ex);
            }
        }
    }
}
