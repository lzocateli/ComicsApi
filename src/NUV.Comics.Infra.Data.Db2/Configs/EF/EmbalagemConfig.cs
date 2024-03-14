using NUV.Comics.Infra.Data.Db2.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuuvify.CommonPack.UnitOfWork;

namespace NUV.Comics.Infra.Data.Db2.Configs.EF.AppDbContext
{
    public class EmbalagemConfig : EntityConfiguration<Embalagem>
    {
        public override void Configure(EntityTypeBuilder<Embalagem> builder)
        {
            builder.HasKey(e => e.EMB_CD_CTB)
                .HasName("EMB_CD_CTB");

            builder.ToTable("EMB_EMBALAGEM", "B8FW");

            builder.Property(e => e.EMB_CD_CTB).HasColumnType("char(10)");

            builder.Property(e => e.EMB_CD_LGON_RSP).HasColumnType("char(8)");

            builder.Property(e => e.EMB_CD_MTS).HasColumnType("decimal(3, 0)");

            builder.Property(e => e.EMB_CD_PECA_1).HasColumnType("char(10)");

            builder.Property(e => e.EMB_CD_PECA_10).HasColumnType("char(10)");

            builder.Property(e => e.EMB_CD_PECA_2).HasColumnType("char(10)");

            builder.Property(e => e.EMB_CD_PECA_3).HasColumnType("char(10)");

            builder.Property(e => e.EMB_CD_PECA_4).HasColumnType("char(10)");

            builder.Property(e => e.EMB_CD_PECA_5).HasColumnType("char(10)");

            builder.Property(e => e.EMB_CD_PECA_6).HasColumnType("char(10)");

            builder.Property(e => e.EMB_CD_PECA_7).HasColumnType("char(10)");

            builder.Property(e => e.EMB_CD_PECA_8).HasColumnType("char(10)");

            builder.Property(e => e.EMB_CD_PECA_9).HasColumnType("char(10)");

            builder.Property(e => e.EMB_DS_DET).HasColumnType("char(50)");

            builder.Property(e => e.EMB_DS_RESD_MTS).HasColumnType("char(4)");

            builder.Property(e => e.EMB_DT_INCL_TAB).HasColumnType("date(4)");

            builder.Property(e => e.EMB_HR_INCL_TAB).HasColumnType("time(0)");

            builder.Property(e => e.EMB_NM_FRN).HasColumnType("char(30)");

            builder.Property(e => e.EMB_QT_EMB_TTL).HasColumnType("decimal(7, 0)");

            builder.Property(e => e.EMB_V_PREC_UNT).HasColumnType("decimal(9, 2)");

            builder.Ignore(x => x.Id);

            AuditIgnore(builder);
            AuditUserIdIgnore(builder);
        }
    }
}