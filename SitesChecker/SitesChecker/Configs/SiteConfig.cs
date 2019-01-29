using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitesChecker.Configs
{
    public class SiteConfig
    {
        public Uri Url { get; set; }
        public TimeSpan CheckInterval { get; set; }
    }
}
