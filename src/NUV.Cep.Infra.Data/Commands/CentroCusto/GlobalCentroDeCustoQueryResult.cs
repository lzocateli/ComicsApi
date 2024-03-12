using NUV.Cep.Infra.Data.DomainModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace NUV.Cep.Infra.Data.Commands
{
    public class GlobalCentroDeCustoQueryResult
    {
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
        [StringLength(GlobalCentroDeCusto.MaxFNCL_ORG_CD)]
        public string FNCL_ORG_CD { get; set; }

        /// <summary>
        /// Tipo do Centro de Custo
        /// </summary>
        /// <example>S</example>
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

        /// <summary>
        /// Indicador de validade
        /// </summary>
        /// <example>Y</example>
        [StringLength(GlobalCentroDeCusto.MaxVALD_ACT_IND)]
        public string VALD_ACT_IND { get; set; }

        /// <summary>
        /// Descricao do Centro de Custo
        /// </summary>
        /// <example>LEADERSHIP</example>
        public string FNCL_ORG_DESC { get; set; }
    }
}