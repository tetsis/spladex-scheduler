using System;
using System.Collections.Generic;
using ApplicationService.Channels.Commons;
using ApplicationService.Channels.Update;
using Flurl.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace splatoon2_video_index_scheduler
{
    public class UpdateChannels
    {
        [FunctionName("UpdateChannels")]
        public void Run([TimerTrigger("0 20 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            string userId = Environment.GetEnvironmentVariable("USER_ID");
            string sessionId = Environment.GetEnvironmentVariable("SESSION_ID");
            string baseUrl = Environment.GetEnvironmentVariable("BASE_URL");

            var channels = $"{baseUrl}/Channel".GetJsonAsync<List<ChannelData>>().Result;

            foreach (var channel in channels)
            {
                var command = new ChannelUpdateCommand
                {
                    UserId = userId,
                    SessionId = sessionId,
                    ChannelId = channel.Id
                };
                $"{baseUrl}/Channel/{channel.Id}/update".PostJsonAsync(command).Wait();
                log.LogInformation($"{channel.ChannelInfo.Name} ({channel.Id}) is updated at: {DateTime.Now}");
            }
        }
    }
}
