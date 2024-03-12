using Nuuvify.CommonPack.Extensions.Notificator;

namespace NUV.Cep.Infra.Data.Commands
{
    public class GlsSaldoContaProfitCenterEmHorasParametro : NotifiableR
    {
        public string FAC_CD { get; set; }
        public int CAL_YR { get; set; }
        public string NEW_FNCL_ACCT_NO { get; set; } = "W010%";
        public string BDGT_SRC_CD { get; set; } = "HRS";
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 25;
    }
}