using Nuuvify.CommonPack.Extensions.Notificator;

namespace NUV.Cep.Infra.Data.Commands
{
    public class GlsObterHorasTrabalhadaParametro : NotifiableR
    {
        public string FAC_CD { get; set; }
        public int CAL_YR { get; set; }
        public string FNCL_ORG_CD { get; set; } = "0%";
        public string ACK_VERS { get; set; } = "00";
        public string NEW_FNCL_ACCT_NO { get; set; } = "00%";
        public string BDGT_SRC_CD { get; set; } = "HRS";
        public string PCTR_FAC_CD { get; set; } = "RK";
        public string CAL_FSCL_CD { get; set; } = "C";
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 25;
    }
}