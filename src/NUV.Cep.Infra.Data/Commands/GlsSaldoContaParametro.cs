using Nuuvify.CommonPack.Extensions.Notificator;
using System.ComponentModel;

namespace NUV.Cep.Infra.Data.Commands
{
    public class GlsSaldoContaParametro : NotifiableR
    {
        private string tipo;
        private string versao;
        private string somaInd;
        private string fiscalCd;

        public string Empresa { get; set; }
        public string Conta { get; set; }
        public int Ano { get; set; }

        [DefaultValue("H")]
        public string Tipo
        {
            get => tipo;
            set => tipo = string.IsNullOrWhiteSpace(value) ? "H" : value;
        }

        [DefaultValue("00")]
        public string Versao
        {
            get => versao;
            set => versao = string.IsNullOrWhiteSpace(value) ? "00" : value;
        }

        [DefaultValue("D")]
        public string SomaInd
        {
            get => somaInd;
            set => somaInd = string.IsNullOrWhiteSpace(value) ? "D" : value;
        }

        [DefaultValue("C")]
        public string FiscalCd
        {
            get => fiscalCd;
            set => fiscalCd = string.IsNullOrWhiteSpace(value) ? "C" : value;
        }

        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 25;
    }
}