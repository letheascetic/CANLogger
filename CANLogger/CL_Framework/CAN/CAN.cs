using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CL_Framework
{
    public enum CANMode : uint
    {
        MODE_NORMAL = 0,    //normal
        MODE_LOM = 1,       //listen only
        MODE_STM = 2        //self test mode
    }

    [Flags]
    public enum CANResult : uint
    {
        STATUS_ERR = 0x00000,
        STATUS_OK = 0x00001,
    }

    public struct BoardInfo
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
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public ushort[] Reserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CANOBJ
    {
        public uint ID;
        public uint TimeStamp;
        public byte TimeFlag;
        public byte SendType;
        public byte RemoteFlag;
        public byte ExternFlag;
        public byte DataLen;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] data;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Reserved;
    }

    public struct CANStatus
    {
        public byte ErrInterrupt;   //中断记录
        public byte RegMode;        //CAN控制器模式寄存器       
        public byte RegStatus;      //CAN控制器状态寄存器
        public byte RegALCapture;   //CAN控制器仲裁丢失寄存器
        public byte RegECCapture;   //CAN控制器错误寄存器
        public byte RegEWLimit;     //CAN控制器错误警告限制寄存器
        public byte RegRECounter;   //CAN控制器接收错误寄存器
        public byte RegTECounter;   //CAN 控制器发送错误寄存器值
        public uint Reserved;
    }

    public struct CANErrInfo
    {
        public uint ErrCode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] PassiveErrData;
        public byte ArLostErrData;
    }

    public struct InitConfig
    {
        public uint AccCode;
        public uint AccMask;
        public uint Reserved;
        public byte Filter;
        public byte Timing0;
        public byte Timing1;
        public byte Mode;
    }

    public struct FilterRecord
    {
        public uint ExtFrame;       //过滤的帧类型标志，为 1 代表要过滤的为扩展帧，为 0 代表要过滤的为标准帧
        public uint Start;          //滤波范围的起始帧ID
        public uint End;            //滤波范围的结束帧ID
    }

    public static class CANDLL
    {
        [DllImport("ECANVCI64.dll", EntryPoint = "OpenDevice")]
        public static extern CANResult OpenDevice(
            UInt32 DeviceType,
            UInt32 DeviceIndex,
            UInt32 Reserved);

        [DllImport("ECANVCI64.dll", EntryPoint = "CloseDevice")]
        public static extern CANResult CloseDevice(
            UInt32 DeviceType,
            UInt32 DeviceIndex);

        [DllImport("ECANVCI64.dll", EntryPoint = "InitCAN")]
        public static extern CANResult InitCAN(
            UInt32 DeviceType,
            UInt32 DeviceIndex,
            UInt32 CANIndex,
            ref InitConfig InitConfig);

        [DllImport("ECANVCI64.dll", EntryPoint = "ReadBoardInfo")]
        public static extern CANResult ReadBoardInfo(
            UInt32 DeviceType,
            UInt32 DeviceIndex,
            out BoardInfo BoardInfo);

        [DllImport("ECANVCI64.dll", EntryPoint = "ReadErrInfo")]
        public static extern CANResult ReadErrInfo(
            UInt32 DeviceType,
            UInt32 DeviceIndex,
            UInt32 CANIndex,
            out CANErrInfo CANErrInfo);

        [DllImport("ECANVCI64.dll", EntryPoint = "ReadCanStatus")]
        public static extern CANResult ReadCanStatus(
            UInt32 DeviceType,
            UInt32 DeviceIndex,
            UInt32 CANIndex,
            out CANStatus CANStatus);

        [DllImport("ECANVCI64.dll", EntryPoint = "GetReference")]
        public static extern CANResult GetReference(
            UInt32 DeviceType,
            UInt32 DeviceIndex,
            UInt32 CANIndex,
            UInt32 RefType,
            IntPtr data);

        [DllImport("ECANVCI64.dll", EntryPoint = "SetReference")]
        public static extern CANResult SetReference(
            UInt32 DeviceType,
            UInt32 DeviceIndex,
            UInt32 CANIndex,
            UInt32 RefType,
            IntPtr data);

        [DllImport("ECANVCI64.dll", EntryPoint = "GetReceiveNum")]
        public static extern UInt32 GetReceiveNum(
            UInt32 DeviceType,
            UInt32 DeviceIndex,
            UInt32 CANIndex);

        [DllImport("ECANVCI64.dll", EntryPoint = "ClearBuffer")]
        public static extern CANResult ClearBuffer(
            UInt32 DeviceType,
            UInt32 DeviceIndex,
            UInt32 CANIndex);

        [DllImport("ECANVCI64.dll", EntryPoint = "StartCAN")]
        public static extern CANResult StartCAN(
            UInt32 DeviceType,
            UInt32 DeviceIndex,
            UInt32 CANIndex);

        [DllImport("ECANVCI64.dll", EntryPoint = "Transmit")]
        public static extern UInt32 Transmit(
            UInt32 DeviceType,
            UInt32 DeviceIndex,
            UInt32 CANIndex,
            CANOBJ[] Send,
            UInt32 Length);

        [DllImport("ECANVCI64.dll", EntryPoint = "Receive")]
        public static extern UInt32 Receive(
            UInt32 DeviceType,
            UInt32 DeviceIndex,
            UInt32 CANIndex,
            out CANOBJ[] Receive,
            UInt32 Length,
            Int32 WaitTime);

        [DllImport("ECANVCI64.dll", EntryPoint = "ResetCAN")]
        public static extern CANResult ResetCAN(
            UInt32 DeviceType,
            UInt32 DeviceIndex,
            UInt32 CANIndex);

    }

}
