using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SitesChecker.Services
{
    public class SiteStatusChecker : ISiteStatusChecker
    {
        public async Task<bool> IsAvailableAsync(Uri url)
        {
            WebRequest request = WebRequest.Create(url);
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // Do nothing; we're only testing to see if we can get the response
                }
            }
            catch (WebException ex)
            {
                return false;
            }
            return true;
        }
    }
}
