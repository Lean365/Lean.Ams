using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Ams.Service.Filters;

namespace Ams.Admin.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 服务监控
    /// API控制器
    /// @author Lean365(Davis.Ching)
    /// @date 2022-01-11
    /// </summary>
    [ApiExplorerSettings(GroupName = "monitor")]
    [Verify]
    public class MonitorController : BaseController
    {
        private OptionsSetting Options;
        private IWebHostEnvironment HostEnvironment;
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public MonitorController(IOptions<OptionsSetting> options, IWebHostEnvironment hostEnvironment)
        {
            this.HostEnvironment = hostEnvironment;
            this.Options = options.Value;
        }

        /// <summary>
        /// 获取缓存监控数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("monitor/cache")]
        public IActionResult GetCache()
        {
            return SUCCESS(1);
        }

        /// <summary>
        /// 获取服务器信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("monitor/server")]
        public IActionResult Server()
        {
            //核心数
            int cpuNum = Environment.ProcessorCount;
            string computerName = Environment.MachineName;
            string osName = RuntimeInformation.OSDescription;
            string osArch = RuntimeInformation.OSArchitecture.ToString();
            string version = RuntimeInformation.FrameworkDescription;
            string appRAM = ((double)Process.GetCurrentProcess().WorkingSet64 / 1048576).ToString("N2") + " MB";
            string startTime = Process.GetCurrentProcess().StartTime.ToString("yyyy-MM-dd HH:mm:ss");
            string sysRunTime = ComputerHelper.GetRunTime();
            string serverIP = Request.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString() + ":" + Request.HttpContext.Connection.LocalPort;//获取服务器IP

            var programStartTime = Process.GetCurrentProcess().StartTime;
            string programRunTime = DateTimeHelper.FormatTime((DateTime.Now - programStartTime).TotalMilliseconds.ToString().Split('.')[0].ParseToLong());
            var data = new
            {
                cpu = ComputerHelper.GetComputerInfo(),
                disk = ComputerHelper.GetDiskInfos(),
                sys = new { cpuNum, computerName, osName, osArch, serverIP, runTime = sysRunTime },
                app = new
                {
                    name = HostEnvironment.EnvironmentName,
                    rootPath = HostEnvironment.ContentRootPath,
                    webRootPath = HostEnvironment.WebRootPath,
                    version,
                    appRAM,
                    startTime,
                    runTime = programRunTime,
                    host = serverIP
                },
            };

            return SUCCESS(data);
        }
    }
}