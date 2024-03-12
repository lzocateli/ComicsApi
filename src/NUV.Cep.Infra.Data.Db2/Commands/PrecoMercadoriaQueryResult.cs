namespace NUV.Cep.Infra.Data.Db2.Commands
{
    public class PrecoMercadoriaQueryResult
    {
        public string Mercadoria { get; set; }
        public bool Embalagem { get; set; }
        public decimal Preco { get; set; }
        public string OrigemPreco { get; set; }
        public string FornecedorNome { get; set; }
        public decimal Qtd { get; set; }

        public void SetPrecoFw(EmbalagemQueryResult fw)
        {
            Mercadoria = fw.EMB_CD_CTB;
            Embalagem = fw.EMB_QT_EMB_TTL > 0;
            OrigemPreco = "FW";
            Preco = fw.EMB_V_PREC_UNT;
            FornecedorNome = fw.EMB_NM_FRN;
            Qtd = fw.EMB_QT_EMB_TTL;
        }
    }
}