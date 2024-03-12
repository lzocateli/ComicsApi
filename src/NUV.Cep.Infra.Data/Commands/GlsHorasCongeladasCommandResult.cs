using Nuuvify.CommonPack.Domain;

namespace NUV.Cep.Infra.Data.Commands
{
    public class GlsHorasCongeladasCommandResult : ICommandResultR
    {
        public string Fac_cd { get; set; }
        public int Cal_yr { get; set; }
        public string New_fncl_acct_no { get; set; }
        public string Fncl_org_cd { get; set; }
        public string Pctr_lwr_tier_2 { get; set; }
        public string Bdgt_src_cd { get; set; }
        public string Corp_acct_desc { get; set; }
        public decimal Prd_amt_1 { get; set; }
        public decimal Prd_amt_2 { get; set; }
        public decimal Prd_amt_3 { get; set; }
        public decimal Prd_amt_4 { get; set; }
        public decimal Prd_amt_5 { get; set; }
        public decimal Prd_amt_6 { get; set; }
        public decimal Prd_amt_7 { get; set; }
        public decimal Prd_amt_8 { get; set; }
        public decimal Prd_amt_9 { get; set; }
        public decimal Prd_amt_10 { get; set; }
        public decimal Prd_amt_11 { get; set; }
        public decimal Prd_amt_12 { get; set; }
    }
}