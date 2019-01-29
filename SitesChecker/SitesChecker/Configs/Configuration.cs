using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitesChecker.Configs
{
    public class Configuration
    {
        public IEnumerable<SiteConfig> Sites { get; set; }
    }
}
