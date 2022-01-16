/* ==============================================================================
* 类名称：Log
* 类描述：
* 创建人：siazon
* 创建时间：2022/1/16 18:23:25
* 修改人：
* 修改时间：
* 修改备注：
* @version 1.0
* ==============================================================================*/
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace APKServer
{
    /// <summary>
    /// Log
    /// </summary>
    public class Log
    {
    }
    public class Worker : BackgroundService
    {
        public readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger) =>
            _logger = logger;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.UtcNow);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}