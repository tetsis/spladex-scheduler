using System;
using System.Collections.Generic;
using ApplicationService.Videos.Update;
using Flurl.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace splatoon2_video_index_scheduler
{
    public class UpdateVideos
    {
        [FunctionName("UpdateVideos")]
        public void Run([TimerTrigger("0 30 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            string userId = Environment.GetEnvironmentVariable("USER_ID");
            string sessionId = Environment.GetEnvironmentVariable("SESSION_ID");
            string baseUrl = Environment.GetEnvironmentVariable("BASE_URL");

            var videoIds = $"{baseUrl}/Video/ids".GetJsonAsync<List<string>>().Result;

            foreach (var videoId in videoIds)
            {
                var command = new VideoUpdateCommand
                {
                    UserId = userId,
                    SessionId = sessionId,
                    VideoId = videoId
                };
                $"{baseUrl}/Video/{videoId}/update".PostJsonAsync(command).Wait();
                log.LogInformation($"Video ID: {videoId} is updated at: {DateTime.Now}");
            }
        }
    }
}
