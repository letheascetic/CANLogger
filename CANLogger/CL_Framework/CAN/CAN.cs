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

    }
}
