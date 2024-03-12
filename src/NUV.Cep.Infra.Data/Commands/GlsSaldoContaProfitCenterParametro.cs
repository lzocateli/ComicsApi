using Nuuvify.CommonPack.Extensions.Notificator;

namespace NUV.Cep.Infra.Data.Commands
{
    public class GlsSaldoContaProfitCenterParametro : NotifiableR
    {
        public string Empresa { get; set; }
        public string Conta { get; set; }
        public int Ano { get; set; }
        public string ACK_RCD_TYP { get; set; } = "H";
        public string ACK_VERS { get; set; } = "00";
        public string SUM_ACK_IND { get; set; } = "D";
        public string CAL_FSCL_CD { get; set; } = "C";
        public string DRILL_DWN_IND { get; set; } = "Y";
        public string PCTR_LWR_TIER_2 { get; set; } = "M%";
        public string CCY_CD { get; set; } = "USD";
        public string PRD_VAR_CD { get; set; }
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 25;
    }
}