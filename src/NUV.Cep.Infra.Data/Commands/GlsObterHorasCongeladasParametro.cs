using Nuuvify.CommonPack.Extensions.Notificator;

namespace NUV.Cep.Infra.Data.Commands
{
    public class GlsObterHorasCongeladasParametro : NotifiableR
    {
        public string FAC_CD { get; set; }
        public int CAL_YR { get; set; }
        public string PCTR_LWR_TIER_2 { get; set; } = "M%";
        public string NEW_FNCL_ACCT_NO { get; set; } = "Z916%";
        public string BDGT_SRC_CD { get; set; } = "HRS";
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 25;
    }
}