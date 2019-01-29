using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitesChecker.Services
{
    public class DisplayService : IDisplayService
    {
        private object _lockObject = new object();
        private readonly IDictionary<string, string> _lines;
        public DisplayService()
        {
            _lines = new Dictionary<string, string>();
        }

        public void ChangeData(string key, string value)
        {
            lock (_lockObject)
            {
                if (_lines.TryGetValue(key, out var valueFromLine))
                {
                    _lines[key] = value;
                }
                else
                {
                    _lines.Add(key, value);
                }
                Console.Clear();
                _lines.Select(el => el.Value).ToList()
                    .ForEach(el => Console.WriteLine(el));
            }
        }
    }
}
