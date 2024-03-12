using System;
using System.Collections.Generic;
using System.Text;

namespace NUV.Cep.Infra.Data.Commands
{
    public class GlobalSerialNumberPrefixResult
    {
        public string DS_PROD_FAM_CD { get; set; }
        public string SER_NO_PFX { get; set; }
        public DateTime OBS_DT { get; set; }
        public DateTime EFF_DT { get; set; }
        public string EDS_PROD_FAM_CD { get; set; }
    }
}
