using Nuuvify.CommonPack.Domain.ValueObjects;
using System;

namespace NUV.Cep.Infra.Data.Commands
{
    public class GlobalCentroDeCustoFacilityInputQuery : SkipTake
    {
        private string codigoEmpresa;

        /// <summary>
        /// Codigo da Empresa
        /// </summary>
        /// <example>28</example>
        public string CodigoEmpresa
        {
            get
            {
                return codigoEmpresa;
            }
            set
            {
                codigoEmpresa = value?.Trim().ToUpper();
            }
        }

        private string centroCusto;

        public string CentroCusto
        {
            get
            {
                return centroCusto;
            }
            set
            {
                var centro = value?.Trim().ToUpper().Replace(".", "");
                centroCusto = centro?.Length > 5 ? centro[..5] : centro;
            }
        }

        private string facility;

        public string Facility
        {
            get
            {
                return facility;
            }
            set
            {
                facility = value?.Trim().ToUpper();
            }
        }

        public DateTime Vigencia { get; set; }
    }
}