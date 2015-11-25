using SteamKit2.Unified.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configdownloader
{
    public class ConfigItem
    {
        public string App { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public uint RatesUp { get; set; }

        public uint RatesDown { get; set; }

        public PublishedFileDetails Details { get; set; }
    }
}
