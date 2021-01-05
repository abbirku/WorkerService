using Infrastructure.Entities;
using Infrastructure.UnitOfWorks;
using System;

namespace Infrastructure.Services
{
    public interface ILoggingService
    {
        void AddLoggingMessage(string message);
    }

    public class LoggingService : ILoggingService
    {
        public readonly IWorkerUnitOfWork _workerUnitOfWork;

        public LoggingService(IWorkerUnitOfWork workerUnitOfWork)
        {
            _workerUnitOfWork = workerUnitOfWork;
        }

        public void AddLoggingMessage(string message)
        {
            try
            {
                _workerUnitOfWork.LoggingRepository.Add(new Logging
                {
                    LogMessage = message,
                    LogTime = DateTime.Now
                });
                _workerUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
