using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CL_Framework
{
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
            UInt32 DeviceInd,
            UInt32 Reserved);

        [DllImport("ECANVCI64.dll", EntryPoint = "CloseDevice")]
        public static extern CANResult CloseDevice(
            UInt32 DeviceType,
            UInt32 DeviceInd);

        [DllImport("ECANVCI64.dll", EntryPoint = "InitCAN")]
        public static extern CANResult InitCAN(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 CANInd,
            ref InitConfig InitConfig);

        [DllImport("ECANVCI64.dll", EntryPoint = "StartCAN")]
        public static extern CANResult StartCAN(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 CANInd);

        [DllImport("ECANVCI64.dll", EntryPoint = "ResetCAN")]
        public static extern CANResult ResetCAN(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 CANInd);

        [DllImport("ECANVCI64.dll", EntryPoint = "Transmit")]
        public static extern CANResult Transmit(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 CANInd,
            CANOBJ[] Send,
            UInt16 length);

        [DllImport("ECANVCI64.dll", EntryPoint = "Receive")]
        public static extern CANResult Receive(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 CANInd,
            out CANOBJ Receive,
            UInt32 length,
            UInt32 WaitTime);

        [DllImport("ECANVCI64.dll", EntryPoint = "ReadErrInfo")]
        public static extern CANResult ReadErrInfo(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 CANInd,
            out CANErrInfo ReadErrInfo);

        [DllImport("ECANVCI64.dll", EntryPoint = "ReadBoardInfo")]
        public static extern CANResult ReadBoardInfo(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            out BoardInfo ReadErrInfo);
    }

}
