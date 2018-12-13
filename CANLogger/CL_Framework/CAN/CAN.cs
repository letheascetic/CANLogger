using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL_Framework
{
    public enum CAN_RESULT : uint
    {
        SUCCESSFUL = 0x00000000,
        ERR_DEVICEOPENED = 0x00000100,
        ERR_DEVICEOPEN = 0x00000200,
        ERR_DEVICENOTOPEN = 0x00000400,
        ERR_UNKNOWN = 0xFFFFFFFF
    }

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
        EXTENDED_FRAME = 1        //扩展帧
    }

    public enum CAN_FRAME_DIRECTION : byte
    {
        SEND = 0,       //发送
        RECEIVE = 1     //接收
    }

    public enum CAN_FRAME_STATUS : byte
    {
        SUCCESS = 0,    //发送或接收成功
        FAILED = 1      //发送或接收失败
    }

    public enum CAN_FRAME_TIME_FLAG : byte
    {
        INVALID = 0,        //时间戳无效
        VALID = 1           //时间戳有效
    }

    public enum CAN_REFERENCE_REFTYPE : uint
    {
        CONFIG_BAUDRATE = 0,
        CONFIG_FILTER = 1,
        START_FILTERING = 2,
        STOP_FILTERING = 3,
        CONFIG_RESEND_TIMEOUT = 4,
        CONFIG_AUTO_SEND = 5,
        CLEAR_AUTO_SEND = 6
    }

    public struct CAN_FRAME
    {
        public CAN_OBJ CANObj;
        public DateTime Time;
        public CAN_FRAME_DIRECTION Direction;
        public CAN_FRAME_STATUS Status;

        public CAN_FRAME(CAN_OBJ pCANObj, DateTime time, CAN_FRAME_DIRECTION direction, CAN_FRAME_STATUS status)
        {
            this.CANObj = pCANObj;
            this.Time = time;
            this.Direction = direction;
            this.Status = status;
        }
    }

    public static class CAN
    {
        public static readonly uint CAN_DLL_RESULT_SUCCESS = 1;
        public static readonly uint CAN_DLL_RESULT_FAILED = 0;
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static readonly uint STANDARD_FRAME_ID_MAXIMUM = 0x000001FF;
        public static readonly uint EXTENDED_FRAME_ID_MAXIMUM = 0x1FFFFFFF;
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static readonly uint CHANNEL_REC_BUF_MAXIMUM = 130000;
        public static readonly int CHANNEL_DEFAULT_BAUDRATE = 1000;
        public static readonly uint CHANNEL_DEFAULT_ACC_CODE = 0x0;
        public static readonly uint CHANNEL_DEFAULT_ACC_MASK = 0xffffffff;
        public static readonly byte CHANNEL_DEFAULT_FILTER = 0x0;
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static readonly uint DEVICE_CANNUM_MAXIMUM = 2;
        public static readonly string DEVICE_TYPE_UNKNOWN = "UNKNOWN";
        public static readonly string DEVICE_TYPE_USBCAN = "USBCAN";
        public static readonly string DEVICE_TYPE_USBCANII = "USBCAN-II";
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static readonly string CAN_MODE_NORMAL = "正常模式";
        public static readonly string CAN_MODE_LOM = "只听模式";
        public static readonly string CAN_MODE_STM = "自发自收";
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static readonly string CAN_SEND_MODE_NORMAL = "正常发送";
        public static readonly string CAN_SEND_MODE_SINGLE = "单次发送";
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static readonly string CAN_FRAME_TYPE_DATA_FRAME = "数据帧";
        public static readonly string CAN_FRAME_TYPE_REMOTE_FRAME = "远程帧";
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static readonly string CAN_FRAME_FORMAT_STANDARD_FRAME = "标准帧";
        public static readonly string CAN_FRAME_FORMAT_EXTEND_FRAME = "扩展帧";
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static readonly Hashtable DEVICE_TYPE_LIST = new Hashtable();
        public static readonly Hashtable CAN_MODE_LIST = new Hashtable();
        public static readonly Hashtable CAN_SEND_MODE_LIST = new Hashtable();
        public static readonly Hashtable CAN_FRAME_TYPE_LIST = new Hashtable();
        public static readonly Hashtable CAN_FRAME_FORMAT_LIST = new Hashtable();
        ///////////////////////////////////////////////////////////////////////////////////////////
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
            CAN_FRAME_FORMAT_LIST.Add(CAN_FRAME_FORMAT_EXTEND_FRAME, CAN_FRAME_FORMAT.EXTENDED_FRAME);
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

        public static string FindDeviceTypeKey(DEVICE_TYPE mDeviceType)
        {
            if (mDeviceType == DEVICE_TYPE.UNKNOWN)
            {
                return DEVICE_TYPE_UNKNOWN;
            }
            return FindKey(mDeviceType, DEVICE_TYPE_LIST);
        }

        public static string FindCANModeKey(CAN_MODE mode)
        {
            return FindKey(mode, CAN_MODE_LIST);
        }

        public static string FindCANSendModeKey(CAN_SEND_MODE mCANSendMode)
        {
            return FindKey(mCANSendMode, CAN_SEND_MODE_LIST);
        }

        public static string FindCANFrameTypeKey(CAN_FRAME_TYPE mCANFrameType)
        {
            return FindKey(mCANFrameType, CAN_FRAME_TYPE_LIST);
        }

        public static string FindCANFrameFormatKey(CAN_FRAME_FORMAT mCANFrameFormat)
        {
            return FindKey(mCANFrameFormat, CAN_FRAME_FORMAT_LIST);
        }

        public static INIT_CONFIG CreateBasicInitConfig()
        {
            INIT_CONFIG pInitConfig = new INIT_CONFIG();
            pInitConfig.AccCode = CAN.CHANNEL_DEFAULT_ACC_CODE;
            pInitConfig.AccMask = CAN.CHANNEL_DEFAULT_ACC_MASK;
            pInitConfig.Filter = CAN.CHANNEL_DEFAULT_FILTER;

            ConfigBaudRate(CAN.CHANNEL_DEFAULT_BAUDRATE, ref pInitConfig);
            ConfigMode(CAN_MODE.NORMAL, ref pInitConfig);

            return pInitConfig;
        }

        public static void ConfigMode(CAN_MODE mode, ref INIT_CONFIG pInitConfig)
        {
            pInitConfig.Mode = (byte)mode;
        }

        public static void ConfigBaudRate(int mBaudRate, ref INIT_CONFIG pInitConfig)
        {
            switch (mBaudRate)
            {
                case 1000:
                    pInitConfig.Timing0 = 0x00;
                    pInitConfig.Timing1 = 0x14;
                    break;
                case 800:
                    pInitConfig.Timing0 = 0x00;
                    pInitConfig.Timing1 = 0x16;
                    break;
                case 666:
                    pInitConfig.Timing0 = 0x80;
                    pInitConfig.Timing1 = 0xb6;
                    break;
                case 500:
                    pInitConfig.Timing0 = 0x00;
                    pInitConfig.Timing1 = 0x1c;
                    break;
                case 400:
                    pInitConfig.Timing0 = 0x80;
                    pInitConfig.Timing1 = 0xfa;
                    break;
                case 250:
                    pInitConfig.Timing0 = 0x01;
                    pInitConfig.Timing1 = 0x1c;
                    break;
                case 200:
                    pInitConfig.Timing0 = 0x81;
                    pInitConfig.Timing1 = 0xfa;
                    break;
                case 125:
                    pInitConfig.Timing0 = 0x03;
                    pInitConfig.Timing1 = 0x1c;
                    break;
                case 100:
                    pInitConfig.Timing0 = 0x04;
                    pInitConfig.Timing1 = 0x1c;
                    break;
                case 80:
                    pInitConfig.Timing0 = 0x83;
                    pInitConfig.Timing1 = 0xff;
                    break;
                case 50:
                    pInitConfig.Timing0 = 0x09;
                    pInitConfig.Timing1 = 0x1c;
                    break;
                case 40:
                    pInitConfig.Timing0 = 0x87;
                    pInitConfig.Timing1 = 0xff;
                    break;
                case 20:
                    pInitConfig.Timing0 = 0x18;
                    pInitConfig.Timing1 = 0x1c;
                    break;
                case 10:
                    pInitConfig.Timing0 = 0x31;
                    pInitConfig.Timing1 = 0x1c;
                    break;
                case 5:
                    pInitConfig.Timing0 = 0xbf;
                    pInitConfig.Timing1 = 0xff;
                    break;
                default:
                    pInitConfig.Timing0 = 0x00;
                    pInitConfig.Timing1 = 0x14;
                    break;
            }
        }
    }
}
