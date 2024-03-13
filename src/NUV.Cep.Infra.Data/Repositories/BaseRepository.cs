

namespace CBL.Common.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : Repository<TEntity> where TEntity : class
    {
        protected readonly IUserAuthenticated _userAuthenticated;
        protected string ownerDB;
        protected System.Data.IDbConnection cn;
        protected System.Data.IDbTransaction ts;
        protected readonly IMapper _mapper;

        protected BaseRepository(DbContext dbContext,
            IUnitOfWork unitOfWork,
            IUserAuthenticated userAuthenticated,
            IMapper mapper,
            IOptions<RequestConfiguration> requestConfigurationOptions)
            : base(dbContext, unitOfWork)
        {
            _userAuthenticated = userAuthenticated;
            _mapper = mapper;

            unitOfWork.UsernameContext = string.IsNullOrWhiteSpace(requestConfigurationOptions.Value.UserClaim)
                ? userAuthenticated.Username()
                : requestConfigurationOptions.Value.UserClaim;
            unitOfWork.UserIdContext = userAuthenticated.Username();

            dbContext.SetDbContextUsername(unitOfWork.UsernameContext, unitOfWork.UserIdContext);
        }

        public virtual void SetDbConnection(System.Data.IDbConnection dbConnection, string cnnString)
        {
            if (!(dbConnection is null))
                cn = dbConnection;

            if (string.IsNullOrWhiteSpace(cn?.ConnectionString))
                cn.ConnectionString = cnnString;
        }

        public virtual IList<NotificationR> ValidationResult()
        {
            return GetNotifications();
        }
    }
}