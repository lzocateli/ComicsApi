using Nuuvify.CommonPack.Domain;

namespace NUV.Cep.Infra.Data.Commands
{
    public class GlsHorasTrabalhadaCommandResult : ICommandResultR
    {
        public string FAC_CD { get; set; }
        public string ACK_RCD_TYP { get; set; }
        public int CAL_YR { get; set; }
        public string ACK_VERS { get; set; }
        public string FNCL_ORG_CD { get; set; }
        public string FNCL_ORG_TYP { get; set; }
        public string SUM_ACK_IND { get; set; }
        public string ACCT_NO { get; set; }
        public string ACCT_DESC { get; set; }
        public string BDGT_SRC_CD { get; set; }
        public string PCTR_FAC_CD { get; set; }
        public string PCTR_LWR_TIER_1 { get; set; }
        public string PCTR_LWR_TIER_2 { get; set; }
        public string PRD_VAR_CD { get; set; }
        public string CCY_CD { get; set; }
        public string CAL_FSCL_CD { get; set; }
        public decimal ACCT_BEG_BAL { get; set; }
        public decimal PRD_AMT_1 { get; set; }
        public decimal PRD_AMT_2 { get; set; }
        public decimal PRD_AMT_3 { get; set; }
        public decimal PRD_AMT_4 { get; set; }
        public decimal PRD_AMT_5 { get; set; }
        public decimal PRD_AMT_6 { get; set; }
        public decimal PRD_AMT_7 { get; set; }
        public decimal PRD_AMT_8 { get; set; }
        public decimal PRD_AMT_9 { get; set; }
        public decimal PRD_AMT_10 { get; set; }
        public decimal PRD_AMT_11 { get; set; }
        public decimal PRD_AMT_12 { get; set; }
    }
}