using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL_Framework
{
    public class Channel
    {
        private uint channelIndex;
        private string channelName;
        
        private Device parentDevice;
        private InitConfig initConfig;

        public Channel(uint channelIndex, string channelName, Device parentDevice)
        {
            this.channelIndex = channelIndex;
            this.channelName = channelName;
            this.parentDevice = parentDevice;
        }
        


    }
}
