

namespace NUV.Cep.Infra.Data.Db2.Interfaces
{
    public interface IEmbalagemRepositorio : IRepositoryReadOnly<Embalagem>
    {

        IList<NotificationR> ValidationResult();
    }
}