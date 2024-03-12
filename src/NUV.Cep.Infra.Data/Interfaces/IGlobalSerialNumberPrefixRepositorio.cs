using NUV.Cep.Infra.Data.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NUV.Cep.Infra.Data.Interfaces
{
    public interface IGlobalSerialNumberPrefixRepositorio
    {
        Task<GlobalSerialNumberPrefixResult> FamilyCodeByMachineSerialNumber(string serialNumberPrefix);
    }
}
