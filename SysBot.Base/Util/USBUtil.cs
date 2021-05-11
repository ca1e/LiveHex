using LibUsbDotNet;
using LibUsbDotNet.Main;
using System.Collections.Generic;

namespace SysBot.Base
{
    public static class USBUtil
    {
        public static List<string> GetList()
        {
            var list = new List<string>();
            foreach (UsbRegistry ur in UsbDevice.AllLibUsbDevices)
            {
                if (ur.Vid != 0x057E)
                    continue;
                if (ur.Pid != 0x3000)
                    continue;

                ur.DeviceProperties.TryGetValue("Address", out object addr);
                list.Add(addr.ToString());
            }

            return list;
        }
    }
}
