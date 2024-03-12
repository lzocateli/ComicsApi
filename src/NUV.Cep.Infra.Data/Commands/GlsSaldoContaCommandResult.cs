using Nuuvify.CommonPack.Domain;
using System.ComponentModel.DataAnnotations;

namespace NUV.Cep.Infra.Data.Commands
{
    public class GlsSaldoContaCommandResult : ICommandResultR
    {
        [MaxLength(2)]
        [DataType("char")]
        public string Fac_cd { get; set; }

        public string Ack_rcd_typ { get; set; }
        public int Cal_yr { get; set; }
        public string Ack_vers { get; set; }
        public string Fncl_org_cd { get; set; }
        public string Fncl_org_typ { get; set; }
        public string Sum_ack_ind { get; set; }
        public string New_fncl_acct_no { get; set; }
        public string Conta { get; set; }
        public string Bdgt_src_cd { get; set; }
        public string Pctr_fac_cd { get; set; }
        public string Pctr_lwr_tier_1 { get; set; }
        public string Pctr_lwr_tier_2 { get; set; }
        public string Prd_var_cd { get; set; }
        public string Ccy_cd { get; set; }
        public string Src_ccy_cd { get; set; }
        public string Cal_fscl_cd { get; set; }
        public string Corp_acct_desc { get; set; }
        public decimal Acct_beg_bal { get; set; }
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

        [MaxLength(1)]
        [DataType("char")]
        public string Drill_dwn_ind { get; set; }
    }
}