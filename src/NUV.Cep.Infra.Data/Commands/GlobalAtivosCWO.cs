using System;

namespace NUV.Cep.Infra.Data.Commands
{
    public class GlobalAtivosCWO
    {
        public string FAC_CD { get; set; }
        public string FAC_EQP_NO_BDY { get; set; }

        public DateTime EFF_DT { get; set; }

        public DateTime OBS_DT { get; set; }

        public string ACCTG_ORD_DESC { get; set; }
    }
}