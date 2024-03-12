using System;
using System.ComponentModel.DataAnnotations;

namespace NUV.Cep.Infra.Data.Commands
{
    public class GlobalCentroDeCustoPorEmpresaInputQuery
    {
        private string codigoEmpresa;

        /// <summary>
        /// Codigo da Empresa
        /// </summary>
        /// <example>28</example>
        [Required]
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

        /// <summary>
        /// Vigencia do registro
        /// </summary>
        /// <example>2021-01-01</example>
        [Required]
        [DataType(DataType.Date)]
        public DateTime Vigencia { get; set; }

        private int pageIndex;

        /// <summary>
        /// Pagina que devera ser recuperada entre 0 a N
        /// </summary>
        /// <examaple>0</examaple>
        public int PageIndex
        {
            get
            {
                return pageIndex;
            }
            set
            {
                pageIndex = value < 0 ? 0 : value;
            }
        }

        private int pageSize;

        /// <summary>
        /// Quantos registros uma pagina deve exibir
        /// </summary>
        /// <example>25</example>
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value <= 0 ? 25 : value;
            }
        }
    }
}