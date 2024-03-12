using System;

namespace NUV.Cep.Infra.Data.Commands
{
    public class GlobalJEContabilizacaoCommandResult
    {
        public string FAC_CD { get; set; }
        public string JE_NO { get; set; }

        /// <summary>
        /// ANO
        /// </summary>
        public int ACCTG_YR { get; set; }

        /// <summary>
        /// MES
        /// </summary>
        public int ACCTG_PRD_NO { get; set; }

        /// <summary>
        /// DIA
        /// </summary>
        public int JE_GRP_NO { get; set; }

        /// <summary>
        /// DEBITO
        /// </summary>
        public double JE_GRP_DR_TOT { get; set; }

        /// <summary>
        /// CREDITO
        /// </summary>
        public double JE_GRP_CR_TOT { get; set; }

        public DateTime JE_GRP_UPDT_TS { get; set; }
        public string UPDT_USER_LOGON_ID { get; set; }
    }
}