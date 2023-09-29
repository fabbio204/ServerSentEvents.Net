using Lib.AspNetCore.ServerSentEvents;
using Microsoft.Extensions.Options;

namespace ServerSentEvents.Net.Services
{
    public class ReportServerSentEventsService : ServerSentEventsService, IServerSentEventsService
    {
        public ReportServerSentEventsService(IOptions<ServerSentEventsServiceOptions<ServerSentEventsService>> options)
            : base(options)
        {
        }
    }
}
