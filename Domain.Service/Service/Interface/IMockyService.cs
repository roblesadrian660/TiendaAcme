using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Service.Interface
{
    public interface IMockyService
    {
        Task<string> MakeRequestSoap(string endpoint, string messageSoap);
    }
}
