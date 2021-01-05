using Core;
using Infrastructure.Context;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWorks
{
    public interface IWorkerUnitOfWork : IUnitOfWork
    {
        public ILoggingRepository LoggingRepository { get; set; }
    }

    public class WorkerUnitOfWork : UnitOfWork, IWorkerUnitOfWork
    {
        public ILoggingRepository LoggingRepository { get; set; }

        public WorkerUnitOfWork(WorkerContext dbContext,
            ILoggingRepository loggingRepository)
            : base(dbContext)
        {
            LoggingRepository = loggingRepository;
        }
    }
}
