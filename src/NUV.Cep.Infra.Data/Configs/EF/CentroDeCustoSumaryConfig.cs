using NUV.Cep.Infra.Data.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuuvify.CommonPack.UnitOfWork;

namespace NUV.Cep.Infra.Data.Configs.EF.AppDbContext
{
    public class CentroDeCustoSumaryConfig : EntityConfiguration<CentroDeCustoSumary>
    {
        public override void Configure(EntityTypeBuilder<CentroDeCustoSumary> builder)
        {
            builder.HasNoKey();

            builder.ToTable("FNCL_ORG_SUM");

            builder.Ignore(x => x.Id);

            AuditIgnore(builder);
            AuditUserIdIgnore(builder);
        }
    }
}