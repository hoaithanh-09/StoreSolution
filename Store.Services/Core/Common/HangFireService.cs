using Hangfire;
using System;
using System.Threading.Tasks;
using Store.Data.Constants;
using Store.Services.Utilities;

namespace Store.Services.Core
{
    public interface IHangFireService
    {
        void StartBackgroundService();
    }

    public class HangFireService: IHangFireService
    {
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public HangFireService(
            IRecurringJobManager recurringJobManager,
            IBackgroundJobClient backgroundJobClient
        )
        {
            _recurringJobManager = recurringJobManager;
            _backgroundJobClient = backgroundJobClient;
        }

        public void StartBackgroundService()
        {
        }
    }
}