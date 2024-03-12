using Nuuvify.CommonPack.Domain;
using System;

namespace NUV.Cep.Infra.Data.DomainModel
{
    public class ContaContabil : DomainEntity
    {
        protected ContaContabil()
        { }

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
}