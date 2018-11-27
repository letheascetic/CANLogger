using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL_Framework
{
    public class Channel
    {
        private string name;
        private Device device;

        public Channel(string name, Device device)
        {
            this.name = name;
            this.device = device;
        }


    }
}
