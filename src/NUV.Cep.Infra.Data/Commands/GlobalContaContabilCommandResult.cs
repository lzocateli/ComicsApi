using System;

namespace NUV.Cep.Infra.Data.Commands
{
    public class GlobalContaContabilCommandResult
    {
        public string FAC_CD { get; set; }
        public DateTime LAST_UPDT_TS { get; set; }
        public string CTL_ACCT_NO { get; set; }
        public string SUB_ACCT_NO { get; set; }
        public string SUB_SUB_ACCT_NO { get; set; }
        public string SPL_EXP_ACCT_NO { get; set; }

        public DateTime EFF_DT { get; set; }

        public DateTime OBS_DT { get; set; }
        public string VALD_ACT_IND { get; set; }
        public string CTL_ACCT_DESC { get; set; }
        public string ACCT_LVL { get; set; }
    }

    public class GlobalContaDepartamentalCommandResult
    {
        public string FAC_CD { get; set; }
        public DateTime LAST_UPDT_TS { get; set; }
        public string EXP_ACCT_NO { get; set; }
        public string EXP_ACCT_TYP { get; set; }

        public DateTime EFF_DT { get; set; }

        public DateTime OBS_DT { get; set; }
        public string VALD_ACT_IND { get; set; }
        public string EXP_ACCT_DESC { get; set; }
    }

    public class GlobalContaDepartamentalSecaoCommandResult
    {
        public string FAC_CD { get; set; }
        public DateTime LAST_UPDT_TS { get; set; }
        public string EXP_ACCT_NO { get; set; }
        public string EXP_ACCT_TYP { get; set; }

        public DateTime EFF_DT { get; set; }

        public DateTime OBS_DT { get; set; }
        public string FNCL_ORG_CD { get; set; }
        public string FNCL_ORG_TYP { get; set; }
    }
}