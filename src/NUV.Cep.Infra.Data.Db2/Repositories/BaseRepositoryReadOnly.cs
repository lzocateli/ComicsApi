using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nuuvify.CommonPack.Extensions.Notificator;
using Nuuvify.CommonPack.UnitOfWork;
using System.Collections.Generic;

namespace CBL.Common.Infra.Data.Repositories
{
    public abstract class BaseRepositoryReadOnly<TEntity> : RepositoryReadOnly<TEntity> where TEntity : class
    {
        protected string ownerDB;
        protected System.Data.IDbConnection cn;
        protected System.Data.IDbTransaction ts;
        protected readonly IMapper _mapper;

        protected BaseRepositoryReadOnly(DbContext dbContext, IMapper mapper)
            : base(dbContext)
        {
            _mapper = mapper;
        }

        public virtual IList<NotificationR> ValidationResult()
        {
            return GetNotifications();
        }

        public virtual void SetDbConnection(System.Data.IDbConnection dbConnection, string cnnString)
        {
            if (!(dbConnection is null))
                cn = dbConnection;

            if (string.IsNullOrWhiteSpace(cn?.ConnectionString))
                cn.ConnectionString = cnnString;
        }
    }
}