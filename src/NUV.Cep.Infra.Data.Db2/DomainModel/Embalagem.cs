
namespace NUV.Cep.Infra.Data.Db2.DomainModel
{
    public class Embalagem : DomainEntity
    {
        protected Embalagem()
        { }

        public string EMB_CD_CTB { get; set; }
        public string EMB_CD_LGON_RSP { get; set; }
        public decimal? EMB_CD_MTS { get; set; }
        public string EMB_CD_PECA_1 { get; set; }
        public string EMB_CD_PECA_10 { get; set; }
        public string EMB_CD_PECA_2 { get; set; }
        public string EMB_CD_PECA_3 { get; set; }
        public string EMB_CD_PECA_4 { get; set; }
        public string EMB_CD_PECA_5 { get; set; }
        public string EMB_CD_PECA_6 { get; set; }
        public string EMB_CD_PECA_7 { get; set; }
        public string EMB_CD_PECA_8 { get; set; }
        public string EMB_CD_PECA_9 { get; set; }
        public string EMB_DS_DET { get; set; }
        public string EMB_DS_RESD_MTS { get; set; }
        public DateTime? EMB_DT_INCL_TAB { get; set; }
        public TimeSpan? EMB_HR_INCL_TAB { get; set; }
        public string EMB_NM_FRN { get; set; }
        public decimal? EMB_QT_EMB_TTL { get; set; }
        public decimal? EMB_V_PREC_UNT { get; set; }
    }
}