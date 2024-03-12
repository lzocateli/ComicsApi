using NUV.Cep.Infra.Data.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuuvify.CommonPack.UnitOfWork;

namespace NUV.Cep.Infra.Data.Configs.EF.AppDbContext
{
    public class ContaContabilConfig : EntityConfiguration<ContaContabil>
    {
        public override void Configure(EntityTypeBuilder<ContaContabil> builder)
        {
            builder.HasNoKey();

            builder.ToTable("FAC_CTL_ACCT", "Z1FS001$");

            builder.Property(e => e.FAC_CD).HasColumnType("char(2)");
            builder.Property(e => e.CTL_ACCT_NO).HasColumnType("char(5)");
            builder.Property(e => e.SUB_ACCT_NO).HasColumnType("char(3)");
            builder.Property(e => e.LAST_UPDT_TS).HasColumnType("TIMESTMP");
            builder.Property(e => e.SUB_SUB_ACCT_NO).HasColumnType("char(2)");
            builder.Property(e => e.SPL_EXP_ACCT_NO).HasColumnType("char(2)");
            builder.Property(e => e.EFF_DT).HasColumnType("date");
            builder.Property(e => e.OBS_DT).HasColumnType("date");
            builder.Property(e => e.VALD_ACT_IND).HasColumnType("char(1)");
            builder.Property(e => e.CTL_ACCT_DESC).HasColumnType("char(50)");
            builder.Property(e => e.ACCT_LVL).HasColumnType("char(8)");

            builder.Ignore(x => x.Id);

            AuditIgnore(builder);
            AuditUserIdIgnore(builder);
        }
    }
}