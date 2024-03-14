namespace NUV.Comics.Infra.Data.Db2.Commands
{
    public class EmbalagemQueryResult
    {
        /// <summary>
        /// Codigo da Embalagem
        /// </summary>
        /// <example>28PL10214 </example>
        public string EMB_CD_CTB { get; set; }

        /// <summary>
        /// Descrição da embalagem
        /// </summary>
        /// <example>12 PÇS P/ RACK                                    </example>
        public string EMB_DS_DET { get; set; }

        /// <summary>
        /// Nome do fornecedor
        /// </summary>
        /// <example>    REQUIPH INDUS             </example>
        public string EMB_NM_FRN { get; set; }

        /// <summary>
        /// Quantidade
        /// </summary>
        /// <example>7.0</example>
        public decimal EMB_QT_EMB_TTL { get; set; }

        /// <summary>
        /// Preço
        /// </summary>
        /// <example>2500.00</example>
        public decimal EMB_V_PREC_UNT { get; set; }

        public void SetPrecoCache(PrecoMercadoriaQueryResult cache)
        {
            EMB_CD_CTB = cache.Mercadoria;
            EMB_V_PREC_UNT = cache.Preco;
            EMB_NM_FRN = cache.FornecedorNome;
            EMB_QT_EMB_TTL = cache.Qtd;
        }
    }
}