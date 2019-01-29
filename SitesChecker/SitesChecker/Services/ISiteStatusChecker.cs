using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitesChecker.Services
{
    public interface ISiteStatusChecker
    {
        Task<bool> IsAvailableAsync(Uri url);
    }
}
