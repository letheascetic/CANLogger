using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL_Framework
{
    public enum DEVICE_TYPE : uint
    {
        UNKNOWN = 0,
        USBCAN = 3,
        USBCANII = 4
    }

    public enum CAN_MODE : uint
    {
        NORMAL = 0,    //normal
        LOM = 1,       //listen only
        STM = 2        //self test mode
    }

    public enum CAN_SEND_MODE : uint
    {
        NORMAL = 0,
        SINGLE = 1
    }

    public enum CAN_FRAME_TYPE : uint
    {
        DATA_FRAME = 0,       //数据帧
        REMOTE_FRAME = 1      //远程帧
    }

    public enum CAN_FRAME_FORMAT : uint
    {
        STANDARD_FRAME = 0,     //标准帧
        EXTEND_FRAME = 1        //扩展帧
    }

    public static class CAN
    {
        //------------------------------------------------------------------------------
        public static readonly uint DEVICE_CANNUM_MAXIMUM = 2;
        //------------------------------------------------------------------------------
        public static readonly int DEFAULT_BAUDRATE = 1000;
        public static readonly uint DEFAULT_ACC_CODE = 0x0;
        public static readonly uint DEFAULT_ACC_MASK = 0xffffffff;
        public static readonly byte DEFAULT_FILTER = 0x0;
        //------------------------------------------------------------------------------
        public static readonly string DEVICE_TYPE_UNKNOWN = "UNKNOWN";
        public static readonly string DEVICE_TYPE_USBCAN = "USBCAN";
        public static readonly string DEVICE_TYPE_USBCANII = "USBCAN-II";
        //------------------------------------------------------------------------------
        public static readonly string CAN_MODE_NORMAL = "正常模式";
        public static readonly string CAN_MODE_LOM = "只听模式";
        public static readonly string CAN_MODE_STM = "自发自收";
        //------------------------------------------------------------------------------
        public static readonly string CAN_SEND_MODE_NORMAL = "正常发送";
        public static readonly string CAN_SEND_MODE_SINGLE = "单次发送";
        //------------------------------------------------------------------------------
        public static readonly string CAN_FRAME_TYPE_DATA_FRAME = "数据帧";
        public static readonly string CAN_FRAME_TYPE_REMOTE_FRAME = "远程帧";
        //------------------------------------------------------------------------------
        public static readonly string CAN_FRAME_FORMAT_STANDARD_FRAME = "标准帧";
        public static readonly string CAN_FRAME_FORMAT_EXTEND_FRAME = "扩展帧";
        //------------------------------------------------------------------------------
        public static readonly Hashtable DEVICE_TYPE_LIST = new Hashtable();
        public static readonly Hashtable CAN_MODE_LIST = new Hashtable();
        public static readonly Hashtable CAN_SEND_MODE_LIST = new Hashtable();
        public static readonly Hashtable CAN_FRAME_TYPE_LIST = new Hashtable();
        public static readonly Hashtable CAN_FRAME_FORMAT_LIST = new Hashtable();
        //------------------------------------------------------------------------------
        static CAN()
        {
            //DEVICE_TYPE_LIST.Add(DEVICE_TYPE_UNKNOWN, DEVICE_TYPE.UNKNOWN);
            DEVICE_TYPE_LIST.Add(DEVICE_TYPE_USBCAN, DEVICE_TYPE.USBCAN);
            DEVICE_TYPE_LIST.Add(DEVICE_TYPE_USBCANII, DEVICE_TYPE.USBCANII);

            CAN_MODE_LIST.Add(CAN_MODE_NORMAL, CAN_MODE.NORMAL);
            CAN_MODE_LIST.Add(CAN_MODE_LOM, CAN_MODE.LOM);
            CAN_MODE_LIST.Add(CAN_MODE_STM, CAN_MODE.STM);

            CAN_SEND_MODE_LIST.Add(CAN_SEND_MODE_NORMAL, CAN_SEND_MODE.NORMAL);
            CAN_SEND_MODE_LIST.Add(CAN_SEND_MODE_SINGLE, CAN_SEND_MODE.SINGLE);

            CAN_FRAME_TYPE_LIST.Add(CAN_FRAME_TYPE_DATA_FRAME, CAN_FRAME_TYPE.DATA_FRAME);
            CAN_FRAME_TYPE_LIST.Add(CAN_FRAME_TYPE_REMOTE_FRAME, CAN_FRAME_TYPE.REMOTE_FRAME);

            CAN_FRAME_FORMAT_LIST.Add(CAN_FRAME_FORMAT_STANDARD_FRAME, CAN_FRAME_FORMAT.STANDARD_FRAME);
            CAN_FRAME_FORMAT_LIST.Add(CAN_FRAME_FORMAT_EXTEND_FRAME, CAN_FRAME_FORMAT.EXTEND_FRAME);
        }

        public static string FindKey(object value, Hashtable table)
        {
            if (!table.ContainsValue(value))
            {
                return null;
            }
            foreach (DictionaryEntry keyValuePair in table)
            {
                if (keyValuePair.Value.Equals(value))
                {
                    return (string)keyValuePair.Key;
                }
            }
            return null;
        }

        public static string FindDeviceTypeKey(DEVICE_TYPE deviceType)
        {
            if (deviceType == DEVICE_TYPE.UNKNOWN)
            {
                return DEVICE_TYPE_UNKNOWN;
            }
            return FindKey(deviceType, DEVICE_TYPE_LIST);
        }

        public static string FindCANModeKey(CAN_MODE mode)
        {
            return FindKey(mode, CAN_MODE_LIST);
        }

        public static string FindCANSendModeKey(CAN_SEND_MODE canSendMode)
        {
            return FindKey(canSendMode, CAN_SEND_MODE_LIST);
        }

        public static string FindCANFrameTypeKey(CAN_FRAME_TYPE canFrameType)
        {
            return FindKey(canFrameType, CAN_FRAME_TYPE_LIST);
        }

        public static string FindCANFrameFormatKey(CAN_FRAME_FORMAT canFrameFormat)
        {
            return FindKey(canFrameFormat, CAN_FRAME_FORMAT_LIST);
        }

        public static InitConfig CreateBasicInitConfig()
        {
            InitConfig initConfig = new InitConfig();
            initConfig.AccCode = CAN.DEFAULT_ACC_CODE;
            initConfig.AccMask = CAN.DEFAULT_ACC_MASK;
            initConfig.Filter = CAN.DEFAULT_FILTER;

            ConfigBaudRate(CAN.DEFAULT_BAUDRATE, ref initConfig);
            ConfigMode(CAN_MODE.NORMAL, ref initConfig);

            return initConfig;
        }

        public static CANResult ConfigMode(CAN_MODE mode, ref InitConfig initConfig)
        {
            initConfig.Mode = (byte)mode;
            return CANResult.STATUS_OK;
        }

        public static CANResult ConfigBaudRate(int baudRate, ref InitConfig initConfig)
        {
            switch (baudRate)
            {
                case 1000:
                    initConfig.Timing0 = 0x00;
                    initConfig.Timing1 = 0x14;
                    break;
                case 800:
                    initConfig.Timing0 = 0x00;
                    initConfig.Timing1 = 0x16;
                    break;
                case 666:
                    initConfig.Timing0 = 0x80;
                    initConfig.Timing1 = 0xb6;
                    break;
                case 500:
                    initConfig.Timing0 = 0x00;
                    initConfig.Timing1 = 0x1c;
                    break;
                case 400:
                    initConfig.Timing0 = 0x80;
                    initConfig.Timing1 = 0xfa;
                    break;
                case 250:
                    initConfig.Timing0 = 0x01;
                    initConfig.Timing1 = 0x1c;
                    break;
                case 200:
                    initConfig.Timing0 = 0x81;
                    initConfig.Timing1 = 0xfa;
                    break;
                case 125:
                    initConfig.Timing0 = 0x03;
                    initConfig.Timing1 = 0x1c;
                    break;
                case 100:
                    initConfig.Timing0 = 0x04;
                    initConfig.Timing1 = 0x1c;
                    break;
                case 80:
                    initConfig.Timing0 = 0x83;
                    initConfig.Timing1 = 0xff;
                    break;
                case 50:
                    initConfig.Timing0 = 0x09;
                    initConfig.Timing1 = 0x1c;
                    break;
                case 40:
                    initConfig.Timing0 = 0x87;
                    initConfig.Timing1 = 0xff;
                    break;
                case 20:
                    initConfig.Timing0 = 0x18;
                    initConfig.Timing1 = 0x1c;
                    break;
                case 10:
                    initConfig.Timing0 = 0x31;
                    initConfig.Timing1 = 0x1c;
                    break;
                case 5:
                    initConfig.Timing0 = 0xbf;
                    initConfig.Timing1 = 0xff;
                    break;
                default:
                    initConfig.Timing0 = 0x00;
                    initConfig.Timing1 = 0x14;
                    break;
            }
            return CANResult.STATUS_OK;
        }


    }
}
