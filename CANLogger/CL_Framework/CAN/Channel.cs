using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL_Framework
{
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

    public class Channel
    {
        //------------------------------------------------------------------------------
        public static readonly Hashtable CAN_MODE_LIST = new Hashtable();
        public static readonly Hashtable CAN_SEND_MODE_LIST = new Hashtable();
        public static readonly Hashtable CAN_FRAME_TYPE_LIST = new Hashtable();
        public static readonly Hashtable CAN_FRAME_FORMAT_LIST = new Hashtable();
        //------------------------------------------------------------------------------
        public static readonly string CAN_MODE_NORMAL = "正常模式";
        public static readonly string CAN_MODE_LOM = "只听模式";
        public static readonly string CAN_MODE_STM = "自发自收";
        public static readonly string CAN_SEND_MODE_NORMAL = "正常发送";
        public static readonly string CAN_SEND_MODE_SINGLE = "单次发送";
        public static readonly string CAN_FRAME_TYPE_DATA_FRAME = "数据帧";
        public static readonly string CAN_FRAME_TYPE_REMOTE_FRAME = "远程帧";
        public static readonly string CAN_FRAME_FORMAT_STANDARD_FRAME = "标准帧";
        public static readonly string CAN_FRAME_FORMAT_EXTEND_FRAME = "扩展帧";
        //------------------------------------------------------------------------------
        public static readonly int DEFAULT_BAUDRATE = 1000;
        public static readonly uint DEFAULT_ACC_CODE = 0x0;
        public static readonly uint DEFAULT_ACC_MASK = 0xffffffff;
        public static readonly byte DEFAULT_FILTER = 0x0;
        //------------------------------------------------------------------------------
        private uint channelIndex;
        private string channelName;
        private int baudRate;
        
        private Device parentDevice;
        private InitConfig initConfig;
        //------------------------------------------------------------------------------
        public InitConfig Config
        { get { return initConfig; } }

        public uint ChannelIndex
        { get { return channelIndex; } }

        public string ChannelName
        { get { return channelName; } }

        public Device ParentDevice
        { get { return parentDevice; } }

        public int BaudRate
        { get { return baudRate; } }

        public CAN_MODE Mode
        { get { return (CAN_MODE)Enum.ToObject(typeof(CAN_MODE), this.initConfig.Mode); } }

        static Channel()
        {
            CAN_MODE_LIST.Add(CAN_MODE.NORMAL, CAN_MODE_NORMAL);
            CAN_MODE_LIST.Add(CAN_MODE.LOM, CAN_MODE_LOM);
            CAN_MODE_LIST.Add(CAN_MODE.STM, CAN_MODE_STM);

            CAN_SEND_MODE_LIST.Add(CAN_SEND_MODE.NORMAL, CAN_SEND_MODE_NORMAL);
            CAN_SEND_MODE_LIST.Add(CAN_SEND_MODE.SINGLE, CAN_SEND_MODE_SINGLE);

            CAN_FRAME_TYPE_LIST.Add(CAN_FRAME_TYPE.DATA_FRAME, CAN_FRAME_TYPE_DATA_FRAME);
            CAN_FRAME_TYPE_LIST.Add(CAN_FRAME_TYPE.REMOTE_FRAME, CAN_FRAME_TYPE_REMOTE_FRAME);

            CAN_FRAME_FORMAT_LIST.Add(CAN_FRAME_FORMAT.STANDARD_FRAME, CAN_FRAME_FORMAT_STANDARD_FRAME);
            CAN_FRAME_FORMAT_LIST.Add(CAN_FRAME_FORMAT.EXTEND_FRAME, CAN_FRAME_FORMAT_EXTEND_FRAME);
        }

        public static string GetCANModeDesc(CAN_MODE mode)
        {
            return CAN_MODE_LIST.ContainsKey(mode) ? (string)CAN_MODE_LIST[mode] : null;
        }

        public static string GetCANSendModeDesc(CAN_SEND_MODE canSendMode)
        {
            return CAN_SEND_MODE_LIST.ContainsKey(canSendMode) ? 
                (string)CAN_SEND_MODE_LIST[canSendMode] : null;
        }

        public static string GetCANFrameTypeDesc(CAN_FRAME_TYPE canFrameType)
        {
            return CAN_FRAME_TYPE_LIST.ContainsKey(canFrameType) ?
                (string)CAN_FRAME_TYPE_LIST[canFrameType] : null;
        }

        public static string GetCANFrameFormatDesc(CAN_FRAME_FORMAT canFrameFormat)
        {
            return CAN_FRAME_FORMAT_LIST.ContainsKey(canFrameFormat) ?
                (string)CAN_FRAME_FORMAT_LIST[canFrameFormat] : null;
        }

        public Channel(uint channelIndex, string channelName, Device parentDevice)
        {
            this.channelIndex = channelIndex;
            this.channelName = channelName;
            this.parentDevice = parentDevice;
            this.initConfig = CreateBasicInitConfig();
            this.baudRate = DEFAULT_BAUDRATE;
        }
        
        public CANResult InitCAN(int baudRate, ref InitConfig initConfig)
        {
            InitConfig config = CreateBasicInitConfig();
            ConfigBaudRate(baudRate, ref config);
            if (config.Timing0 != initConfig.Timing0 || config.Timing1 != initConfig.Timing1)
            {
                return CANResult.STATUS_ERR;
            }

            this.baudRate = baudRate;
            this.initConfig = initConfig;
            return CANDLL.InitCAN((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex, ref initConfig);
        }

        public CANResult ReadErrInfo(out CANErrInfo canErrInfo)
        {
            return CANDLL.ReadErrInfo((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex, out canErrInfo);
        }

        public CANResult ReadCanStatus(out CANStatus canStatus)
        {
            return CANDLL.ReadCanStatus((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex, out canStatus);
        }

        public CANResult GetReference(UInt32 refType, IntPtr data)
        {
            return CANDLL.GetReference((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex, refType, data);
        }

        public CANResult SetReference(UInt32 refType, IntPtr data)
        {
            return CANDLL.SetReference((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex, refType, data);
        }

        public UInt32 GetReceiveNum()
        {
            return CANDLL.GetReceiveNum((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex);
        }

        public CANResult ClearBuffer()
        {
            return CANDLL.ClearBuffer((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex);
        }

        public CANResult StartCAN()
        {
            return CANDLL.StartCAN((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex);
        }

        public UInt32 Transmit(CANOBJ[] canFrames, UInt32 canFrameLength)
        {
            return CANDLL.Transmit((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex, canFrames, canFrameLength);
        }

        public UInt32 Receive(out CANOBJ[] canFrames, UInt32 canFrameLength, Int32 waitMilliseconds)
        {
            return CANDLL.Receive((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex,
                out canFrames, canFrameLength, waitMilliseconds);
        }

        public CANResult ResetCAN()
        {
            return CANDLL.ResetCAN((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex);
        }

        public static InitConfig CreateBasicInitConfig()
        {
            InitConfig initConfig = new InitConfig();
            initConfig.AccCode = DEFAULT_ACC_CODE;
            initConfig.AccMask = DEFAULT_ACC_MASK;
            initConfig.Filter = DEFAULT_FILTER;

            ConfigBaudRate(DEFAULT_BAUDRATE, ref initConfig);
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
