using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CL_Framework
{
    /// <summary>
    /// 定义板卡信息
    /// </summary>
    public struct BOARD_INFO
    {
        public ushort HWVersion;            //硬件版本号，用16进制表示,0x0100表示V1.00。
        public ushort FWVersion;            //固件版本号
        public ushort DriverVersion;
        public ushort InVersion;
        public ushort IRQNum;
        public byte CANNum;                 //CAN通道数量
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] StrSerialNO;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public byte[] StrHWType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public ushort[] Reserved;
    }

    /// <summary>
    /// 定义CAN信息帧的数据类型
    /// </summary>
    unsafe public struct CAN_OBJ       //使用不安全代码
    {
        public uint ID;
        public uint TimeStamp;
        public byte TimeFlag;
        public byte SendType;
        public byte RemoteFlag;//是否是远程帧
        public byte ExternFlag;//是否是扩展帧
        public byte DataLen;

        public fixed byte Data[8];
        public fixed byte Reserved[3];
    }

    /// <summary>
    /// 定义CAN控制器状态的数据类型
    /// </summary>
    public struct CAN_STATUS
    {
        public byte ErrInterrupt;   //中断记录
        public byte RegMode;        //CAN控制器模式寄存器       
        public byte RegStatus;      //CAN控制器状态寄存器
        public byte RegALCapture;   //CAN控制器仲裁丢失寄存器
        public byte RegECCapture;   //CAN控制器错误寄存器
        public byte RegEWLimit;     //CAN控制器错误警告限制寄存器
        public byte RegRECounter;   //CAN控制器接收错误寄存器
        public byte RegTECounter;   //CAN 控制器发送错误寄存器值
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Reserved;
    }

    /// <summary>
    /// 定义错误信息的数据类型
    /// </summary>
    public struct CAN_ERR_INFO
    {
        public UInt32 ErrCode;
        public byte PassiveErrData1;
        public byte PassiveErrData2;
        public byte PassiveErrData3;
        public byte ArLostErrData;
    }

    /// <summary>
    /// 定义初始化CAN的数据类型
    /// </summary>
    public struct INIT_CONFIG
    {
        public uint AccCode;
        public uint AccMask;
        public uint Reserved;
        public byte Filter;
        public byte Timing0;
        public byte Timing1;
        public byte Mode;
    }

    /// <summary>
    /// 定义滤波数据类型
    /// </summary>
    public struct FILTER_RECORD
    {
        public uint ExtFrame;       //过滤的帧类型标志，为 1 代表要过滤的为扩展帧，为 0 代表要过滤的为标准帧
        public uint Start;          //滤波范围的起始帧ID
        public uint End;            //滤波范围的结束帧ID
    }

    public static class CANDLL
    {
        [DllImport("ECANVCI64.dll", EntryPoint = "OpenDevice")]
        public static extern UInt32 OpenDevice(UInt32 DeviceType, UInt32 DeviceIndex, UInt32 Reserved);
        [DllImport("ECANVCI64.dll", EntryPoint = "CloseDevice")]
        public static extern UInt32 CloseDevice(UInt32 DeviceType, UInt32 DeviceIndex);
        [DllImport("ECANVCI64.dll", EntryPoint = "InitCAN")]
        public static extern UInt32 InitCAN(UInt32 DeviceType, UInt32 DeviceIndex, UInt32 CANIndex, ref INIT_CONFIG pInitConfig);
        [DllImport("ECANVCI64.dll", EntryPoint = "ReadBoardInfo")]
        public static extern UInt32 ReadBoardInfo(UInt32 DeviceType, UInt32 DeviceIndex, ref BOARD_INFO pBoardInfo);
        [DllImport("ECANVCI64.dll", EntryPoint = "ReadErrInfo")]
        public static extern UInt32 ReadErrInfo(UInt32 DeviceType, UInt32 DeviceIndex, Int32 CANIndex, ref CAN_ERR_INFO pCANErrInfo);
        [DllImport("ECANVCI64.dll", EntryPoint = "ReadCanStatus")]
        public static extern UInt32 ReadCanStatus( UInt32 DeviceType, UInt32 DeviceIndex, UInt32 CANIndex, ref CAN_STATUS pCANStatus);
        [DllImport("ECANVCI64.dll", EntryPoint = "GetReference")]
        public static extern UInt32 GetReference(UInt32 DeviceType, UInt32 DeviceIndex, UInt32 CANIndex, UInt32 RefType, ref byte pData);
        [DllImport("ECANVCI64.dll", EntryPoint = "SetReference")]
        unsafe public static extern UInt32 SetReference(UInt32 DeviceType, UInt32 DeviceIndex, UInt32 CANIndex, UInt32 RefType, byte* pData);
        [DllImport("ECANVCI64.dll", EntryPoint = "GetReceiveNum")]
        public static extern UInt32 GetReceiveNum(UInt32 DeviceType, UInt32 DeviceIndex, UInt32 CANIndex);
        [DllImport("ECANVCI64.dll", EntryPoint = "ClearBuffer")]
        public static extern UInt32 ClearBuffer(UInt32 DeviceType, UInt32 DeviceIndex, UInt32 CANIndex);
        [DllImport("ECANVCI64.dll", EntryPoint = "StartCAN")]
        public static extern UInt32 StartCAN(UInt32 DeviceType, UInt32 DeviceIndex, UInt32 CANIndex);
        [DllImport("ECANVCI64.dll", EntryPoint = "ResetCAN")]
        public static extern UInt32 ResetCAN(UInt32 DeviceType, UInt32 DeviceIndex, UInt32 CANIndex);
        [DllImport("ECANVCI64.dll", EntryPoint = "Transmit")]
        public static extern UInt32 Transmit(UInt32 DeviceType, UInt32 DeviceIndex, UInt32 CANIndex, ref CAN_OBJ pSend, UInt32 Length);
        [DllImport("ECANVCI64.dll", EntryPoint = "Receive", CharSet = CharSet.Ansi)]
        public static extern UInt32 Receive(UInt32 DeviceType, UInt32 DeviceIndex, UInt32 CANIndex, IntPtr pReceive, UInt32 Length, Int32 WaitTime);
    }

}
