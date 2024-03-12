using Nuuvify.CommonPack.Domain;
using System;

namespace NUV.Cep.Infra.Data.Commands
{
    public class GlobalTaxaCommandResult : ICommandResultR
    {
        public string FAC_CD { get; set; }
        public string ACCT_TRNSLT_CD { get; set; }

        public DateTime EFF_DT { get; set; }

        public DateTime OBS_DT { get; set; }
        public double ACCT_TRNSLT_RATE { get; set; }
        public string ACCT_TRNSLT_DESC { get; set; }
        public string SEC_BY_FAC_CD { get; set; }
        public string SEC_BY_MGMT_AREA { get; set; }
        public DateTime LAST_UPDT_TS { get; set; }
        public string LAST_UPDT_ACTV_ID { get; set; }
        public string UPDT_USER_LOGON_ID { get; set; }
    }
}