using NUV.Cep.Infra.Data.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuuvify.CommonPack.UnitOfWork;

namespace NUV.Cep.Infra.Data.Configs.EF.AppDbContext
{
    public class CentroDeCustoConfig : EntityConfiguration<GlobalCentroDeCusto>
    {
        public override void Configure(EntityTypeBuilder<GlobalCentroDeCusto> builder)
        {
            builder.HasNoKey();

            builder.ToTable("FNCL_ORG");

            builder.Ignore(x => x.Id);

            AuditIgnore(builder);
            AuditUserIdIgnore(builder);
        }
    }
}