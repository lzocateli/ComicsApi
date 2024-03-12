using NUV.Cep.Infra.Data.DomainModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace NUV.Cep.Infra.Data.Commands
{
    public class GlobalCentroDeCustoFacilityQueryResult
    {
        public string TO_FAC_CD { get; set; }
        public string TO_FNCL_ORG_TYP { get; set; }

        /// <summary>
        /// Codigo da Fabrica
        /// </summary>
        /// <example>28</example>
        public string FAC_CD { get; set; }

        /// <summary>
        /// Data da ultima alteração
        /// </summary>
        /// <example>2021-07-27T13:10:39</example>
        public DateTime LAST_UPDT_TS { get; set; }

        /// <summary>
        /// Codigo do Centro de Custo
        /// </summary>
        /// <example>01026</example>
        [StringLength(CentroDeCustoSumary.MaxFNCL_ORG_CD)]
        public string FNCL_ORG_CD { get; set; }

        /// <summary>
        /// Tipo do Centro de Custo
        /// </summary>
        /// <example>S</example>
        [StringLength(CentroDeCustoSumary.MaxFNCL_ORG_TYP)]
        public string FNCL_ORG_TYP { get; set; }

        /// <summary>
        /// Data de efetivação do registro
        /// </summary>
        /// <example>2021-07-01T00:00:00</example>
        public DateTime EFF_DT { get; set; }

        /// <summary>
        /// Data de validade do registro
        /// </summary>
        /// <example>9999-12-31T00:00:00</example>
        public DateTime OBS_DT { get; set; }
    }
}