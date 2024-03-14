

namespace NUV.Comics.Infra.Data.Db2.Interfaces
{
    public interface IEmbalagemRepositorio : IRepositoryReadOnly<Embalagem>
    {

        IList<NotificationR> ValidationResult();
    }
}