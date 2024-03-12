using System;

namespace NUV.Cep.Infra.Data.Commands
{
    public class GlobalJECommandResult
    {
        public string FAC_CD { get; set; }
        public DateTime LAST_UPDT_TS { get; set; }
        public string JE_NO { get; set; }
        public string IP_ENT_NO { get; set; }
        public string JE_NM { get; set; }

        public DateTime EFF_DT { get; set; }

        public DateTime OBS_DT { get; set; }

        public string MECH_JE_IND { get; set; }
        public string DTA_TYP_CD { get; set; }
    }
}