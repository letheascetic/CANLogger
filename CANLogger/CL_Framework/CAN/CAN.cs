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
        ERR_CAN_OVERFLOW = 0x00000001,      //CAN控制器内部FIFO溢出
        ERR_CAN_ERRALARM = 0x00000002,      //CAN控制器错误报警
        ERR_CAN_PASSIVE = 0x00000004,       //CAN控制器消极错误
        ERR_CAN_LOSE = 0x00000008,          //CAN控制器仲裁丢失
        ERR_CAN_BUSERR = 0x00000010,        //CAN控制器总线错误
        ERR_CAN_BUSOFF = 0x00000020,        //CAN控制器总线关闭
        ERR_DEVICEOPENED = 0x00000100,      //设备已经打开
        ERR_DEVICEOPEN = 0x00000200,        //打开设备错误
        ERR_DEVICENOTOPEN = 0x00000400,     //设备没有打开
        ERR_BUFFEROVERFLOW = 0x00000800,    //缓冲区溢出
        ERR_DEVICENOTEXIST = 0x00001000,    //此设备不存在
        ERR_LOADKERNELDLL = 0x00002000,     //装载动态库失败
        ERR_CMDFAILED = 0x00004000,         //执行命令失败错误码
        ERR_BUFFERCREATE = 0x00008000,      //内存不足
        ERR_UNKNOWN = 0x80000000            //未知错误
    }

    /// <summary>
    /// 设备类型
    /// </summary>
    public enum DEVICE_TYPE : uint
    {
        UNKNOWN = 0,
        USBCAN = 3,
        USBCANII = 4
    }

    /// <summary>
    /// CAN工作模式
    /// </summary>
    public enum CAN_MODE : uint
    {
        NORMAL = 0,    //normal
        LOM = 1,       //listen only
        STM = 2        //self test mode
    }

    /// <summary>
    /// CAN发送模式
    /// </summary>
    public enum CAN_SEND_MODE : uint
    {
        NORMAL = 0,
        SINGLE = 1
    }

    /// <summary>
    /// CAN帧类型
    /// </summary>
    public enum CAN_FRAME_TYPE : uint
    {
        DATA_FRAME = 0,       //数据帧
        REMOTE_FRAME = 1      //远程帧
    }

    /// <summary>
    /// CAN帧（ID）格式
    /// </summary>
    public enum CAN_FRAME_FORMAT : uint
    {
        STANDARD_FRAME = 0,     //标准帧
        EXTENDED_FRAME = 1      //扩展帧
    }

    /// <summary>
    /// CAN传输方向
    /// </summary>
    public enum CAN_FRAME_DIRECTION : byte
    {
        SEND = 0,       //发送
        RECEIVE = 1     //接收
    }

    /// <summary>
    /// CAN帧传输结果
    /// </summary>
    public enum CAN_FRAME_STATUS : byte
    {
        SUCCESS = 0,    //发送或接收成功
        FAILED = 1,     //发送或接收失败
        UNKNOWN = 255
    }

    /// <summary>
    /// 时间戳有效标识符
    /// </summary>
    public enum CAN_FRAME_TIME_FLAG : byte
    {
        INVALID = 0,        //时间戳无效
        VALID = 1           //时间戳有效
    }

    /// <summary>
    /// CAN配置参数类型
    /// </summary>
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

    /// <summary>
    /// 自定义的CAN帧结构体
    /// </summary>
    public struct CAN_FRAME
    {
        public CAN_OBJ CANObj;
        public CAN_ERR_INFO CANErrInfo;
        public DateTime Time;
        public CAN_FRAME_DIRECTION Direction;
        public CAN_FRAME_STATUS Status;

        public CAN_FRAME(CAN_OBJ pCANObj, DateTime time, CAN_FRAME_DIRECTION direction, CAN_FRAME_STATUS status)
        {
            this.CANObj = pCANObj;
            this.Time = time;
            this.Direction = direction;
            this.Status = status;
            this.CANErrInfo = new CAN_ERR_INFO();
        }
    }

    public struct CAN_ERR_DETAIL
    {
        public uint ErrCode;
        public string Descreption;
        public string Detail;
    }

    public static class CAN
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static readonly uint CAN_DLL_RESULT_SUCCESS = 1;
        public static readonly uint CAN_DLL_RESULT_FAILED = 0;
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static readonly string CAN_RESULT_SUCCESSFUL = "操作成功";
        public static readonly string CAN_RESULT_ERR_CAN_OVERFLOW = "CAN控制器内部FIFO溢出";
        public static readonly string CAN_RESULT_ERR_CAN_ERRALARM = "CAN控制器错误报警";
        public static readonly string CAN_RESULT_ERR_CAN_PASSIVE = "CAN控制器消极错误";
        public static readonly string CAN_RESULT_ERR_CAN_LOSE = "CAN控制器仲裁丢失";
        public static readonly string CAN_RESULT_ERR_CAN_BUSERR = "CAN控制器总线错误";
        public static readonly string CAN_RESULT_ERR_CAN_BUSOFF = "CAN控制器总线关闭";
        public static readonly string CAN_RESULT_ERR_DEVICEOPENED = "设备已经打开";
        public static readonly string CAN_RESULT_ERR_DEVICEOPEN = "打开设备错误";
        public static readonly string CAN_RESULT_ERR_DEVICENOTOPEN = "设备没有打开";
        public static readonly string CAN_RESULT_ERR_BUFFEROVERFLOW = "缓冲区溢出";
        public static readonly string CAN_RESULT_ERR_DEVICENOTEXIST = "此设备不存在";
        public static readonly string CAN_RESULT_ERR_LOADKERNELDLL = "装载动态库失败";
        public static readonly string CAN_RESULT_ERR_CMDFAILED = "执行命令失败错误码";
        public static readonly string CAN_RESULT_ERR_BUFFERCREATE = "内存不足";
        public static readonly string CAN_RESULT_ERR_UNKNOWN = "未知错误";
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static readonly uint STANDARD_FRAME_ID_MAXIMUM = 0x000007FF;
        public static readonly uint EXTENDED_FRAME_ID_MAXIMUM = 0x1FFFFFFF;
        public static readonly uint FRAME_DATA_LENGTH_MAXIMUM = 8;
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static readonly uint CHANNEL_RCV_BUF_MAXIMUM = 130000;
        public static readonly uint CHANNEL_SEND_BUF_MAXIMUM = 130000;
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
        public static readonly Hashtable CAN_RESULT_MAPPING = new Hashtable();
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

            CAN_RESULT_MAPPING.Add(CAN_RESULT.SUCCESSFUL, CAN_RESULT_SUCCESSFUL);
            CAN_RESULT_MAPPING.Add(CAN_RESULT.ERR_CAN_OVERFLOW, CAN_RESULT_ERR_CAN_OVERFLOW);
            CAN_RESULT_MAPPING.Add(CAN_RESULT.ERR_CAN_ERRALARM, CAN_RESULT_ERR_CAN_ERRALARM);
            CAN_RESULT_MAPPING.Add(CAN_RESULT.ERR_CAN_PASSIVE, CAN_RESULT_ERR_CAN_PASSIVE);
            CAN_RESULT_MAPPING.Add(CAN_RESULT.ERR_CAN_LOSE, CAN_RESULT_ERR_CAN_LOSE);
            CAN_RESULT_MAPPING.Add(CAN_RESULT.ERR_CAN_BUSERR, CAN_RESULT_ERR_CAN_BUSERR);
            CAN_RESULT_MAPPING.Add(CAN_RESULT.ERR_CAN_BUSOFF, CAN_RESULT_ERR_CAN_BUSOFF);
            CAN_RESULT_MAPPING.Add(CAN_RESULT.ERR_DEVICEOPENED, CAN_RESULT_ERR_DEVICEOPENED);
            CAN_RESULT_MAPPING.Add(CAN_RESULT.ERR_DEVICEOPEN, CAN_RESULT_ERR_DEVICEOPEN);
            CAN_RESULT_MAPPING.Add(CAN_RESULT.ERR_DEVICENOTOPEN, CAN_RESULT_ERR_DEVICENOTOPEN);
            CAN_RESULT_MAPPING.Add(CAN_RESULT.ERR_BUFFEROVERFLOW, CAN_RESULT_ERR_BUFFEROVERFLOW);
            CAN_RESULT_MAPPING.Add(CAN_RESULT.ERR_DEVICENOTEXIST, CAN_RESULT_ERR_DEVICENOTEXIST);
            CAN_RESULT_MAPPING.Add(CAN_RESULT.ERR_LOADKERNELDLL, CAN_RESULT_ERR_LOADKERNELDLL);
            CAN_RESULT_MAPPING.Add(CAN_RESULT.ERR_CMDFAILED, CAN_RESULT_ERR_CMDFAILED);
            CAN_RESULT_MAPPING.Add(CAN_RESULT.ERR_BUFFERCREATE, CAN_RESULT_ERR_BUFFERCREATE);
            CAN_RESULT_MAPPING.Add(CAN_RESULT.ERR_UNKNOWN, CAN_RESULT_ERR_UNKNOWN);
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

        /// <summary>
        /// 获取对应的错误说明
        /// </summary>
        /// <param name="pCANErrInfo"></param>
        /// <returns></returns>
        public static CAN_ERR_DETAIL[] GetErrDetail(CAN_ERR_INFO pCANErrInfo)
        {
            List<CAN_ERR_DETAIL> pCANErrDetails = new List<CAN_ERR_DETAIL>();
            foreach (CAN_RESULT pCANResult in CAN_RESULT_MAPPING.Keys)
            {
                if ((pCANErrInfo.ErrCode & (uint)pCANResult) != 0)
                {
                    CAN_ERR_DETAIL pCANErrDetail = new CAN_ERR_DETAIL();
                    pCANErrDetail.ErrCode = (uint)CAN_RESULT.ERR_CAN_OVERFLOW;
                    pCANErrDetail.Descreption = CAN_RESULT_MAPPING[CAN_RESULT.ERR_CAN_OVERFLOW].ToString();
                    pCANErrDetail.Detail = string.Empty;

                    if (pCANResult == CAN_RESULT.ERR_CAN_PASSIVE)
                    {
                        StringBuilder pDetail = new StringBuilder("错误类型:");
                        switch ((pCANErrInfo.PassiveErrData1 & 0xc0) >> 6)
                        {
                            case 0:
                                pDetail.Append("位错误");
                                break;
                            case 1:
                                pDetail.Append("格式错误");
                                break;
                            case 2:
                                pDetail.Append("填充错误");
                                break;
                            case 3:
                            default:
                                pDetail.Append("其他错误");
                                break;
                        }
                        pDetail.Append("|传输方向:");
                        pDetail.Append((pCANErrInfo.PassiveErrData1 & 0x20) == 0 ? "发送" : "接收");
                        pDetail.Append("|错误位置:");
                        switch (pCANErrInfo.PassiveErrData1 & 0x1f)
                        {
                            case 0x03:
                                pDetail.Append("帧开始");
                                break;
                            case 0x02:
                                pDetail.Append("ID.28-ID.21");
                                break;
                            case 0x06:
                                pDetail.Append("ID.20-ID.18");
                                break;
                            case 0x04:
                                pDetail.Append("SRTR位");
                                break;
                            case 0x05:
                                pDetail.Append("IDE位");
                                break;
                            case 0x07:
                                pDetail.Append("ID.17-ID.13");
                                break;
                            case 0x0f:
                                pDetail.Append("ID.12-ID.5");
                                break;
                            case 0x0e:
                                pDetail.Append("ID.4-ID.0");
                                break;
                            case 0x0c:
                                pDetail.Append("RTR位");
                                break;
                            case 0x0b:
                                pDetail.Append("数据长度");
                                break;
                            case 0x0a:
                                pDetail.Append("数据区");
                                break;
                            case 0x08:
                                pDetail.Append("CRC序列");
                                break;
                            case 0x18:
                                pDetail.Append("CRC定义符");
                                break;
                            case 0x19:
                                pDetail.Append("应答通道");
                                break;
                            case 0x1b:
                                pDetail.Append("应答定义符");
                                break;
                            case 0x1a:
                                pDetail.Append("帧结束");
                                break;
                            case 0x12:
                                pDetail.Append("中止");
                                break;
                            case 0x11:
                                pDetail.Append("活动错误标志");
                                break;
                            case 0x16:
                                pDetail.Append("消极错误标志");
                                break;
                            case 0x13:
                                pDetail.Append("支配(控制)位误差");
                                break;
                            case 0x17:
                                pDetail.Append("错误定义符");
                                break;
                            case 0x1c:
                                pDetail.Append("溢出标志");
                                break;
                            case 0x09:
                            case 0x0d:
                            default:
                                pDetail.Append("无");
                                break;
                        }
                        pDetail.Append("|接收错误计数器:").Append(pCANErrInfo.PassiveErrData2.ToString());
                        pDetail.Append("|发送错误计数器:").Append(pCANErrInfo.PassiveErrData3.ToString());
                        pCANErrDetail.Detail = pDetail.ToString();
                    }
                    else if (pCANResult == CAN_RESULT.ERR_CAN_LOSE)
                    {
                        StringBuilder pDetail = new StringBuilder("仲裁丢失位置:");
                        switch (pCANErrInfo.ArLostErrData & 0x1f)
                        {
                            case 0x0b:
                                pDetail.Append("SRTR位");
                                break;
                            case 0x0c:
                                pDetail.Append("IDE位");
                                break;
                            case 0x1f:
                                pDetail.Append("ERTR位");
                                break;
                            default:
                                byte pos = (byte)(pCANErrInfo.ArLostErrData & 0x1f);
                                if (pos <= 10)
                                {
                                    pDetail.Append("bit" + (pos + 1) + "位");
                                }
                                else
                                {
                                    pDetail.Append("bit" + (pos + 1) + "位");
                                }
                                break;
                        }
                        pCANErrDetail.Detail = pDetail.ToString();
                    }

                    pCANErrDetails.Add(pCANErrDetail);
                }
            }
            return pCANErrDetails.ToArray();
        }
    }
}
