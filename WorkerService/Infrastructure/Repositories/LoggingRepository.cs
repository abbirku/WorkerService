using Core;
using Infrastructure.Context;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public interface ILoggingRepository : IRepository<Logging, int, WorkerContext>
    {
    }

    public class LoggingRepository : Repository<Logging, int, WorkerContext>, ILoggingRepository
    {
        public LoggingRepository(WorkerContext dbContext)
            : base(dbContext)
        {

        }
    }
}
