﻿using Nuuvify.CommonPack.Domain;
using System;

namespace NUV.Cep.Infra.Data.DomainModel
{
    public class GlobalCentroDeCusto : DomainEntity
    {
        protected GlobalCentroDeCusto()
        { }

        public string FAC_CD { get; set; }
        public DateTime LAST_UPDT_TS { get; set; }
        public string FNCL_ORG_CD { get; set; }
        public string FNCL_ORG_TYP { get; set; }

        public DateTime EFF_DT { get; set; }

        public DateTime OBS_DT { get; set; }
        public string VALD_ACT_IND { get; set; }
        public string FNCL_ORG_DESC { get; set; }

        public const int MaxFNCL_ORG_CD = 5;
        public const int MaxVALD_ACT_IND = 1;
    }
}