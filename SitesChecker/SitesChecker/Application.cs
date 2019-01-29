using SitesChecker.Configs;
using SitesChecker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SitesChecker
{
    public class Application : IApplication
    {
        private readonly Configuration _configuration;
        private readonly DisplayService _displayService;
        private readonly ISiteStatusChecker _siteStatusChecker;

        public Application(
            Configuration configuration,
            DisplayService displayService,
            ISiteStatusChecker siteStatusChecker)
        {
            _configuration = configuration;
            _displayService = displayService;
            _siteStatusChecker = siteStatusChecker;
        }


        public async Task RunAsync()
        {
            foreach (var site in _configuration.Sites)
            {
                var timer = new Timer(new TimerCallback(async (obj) =>
                {
                    var siteConfig = (SiteConfig)obj;
                    _displayService.ChangeData(siteConfig.Url.ToString(), $"{siteConfig.Url.ToString()} - {await _siteStatusChecker.IsAvailableAsync(siteConfig.Url)}");

                }), site, 0, (int)site.CheckInterval.TotalMilliseconds);
            }
        }
    }
}
