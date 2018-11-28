using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CL_Framework
{
    [Flags]
    public enum CANStatus : uint
    {
        STATUS_ERR = 0x00000,
        STATUS_OK = 0x00001,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CANFrame
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

    public struct BOARD_INFO
    {
        public ushort HWVersion;
        public ushort FWVersion;
        public ushort DriverVersion;
        public ushort InVersion;
        public ushort IRQNum;
        public byte CANNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] StrSerialNO;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public byte[] StrHWType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public ushort[] Reserved;
    }

    public static class CANDLL
    {
        [DllImport("ECANVCI64.dll", EntryPoint = "OpenDevice")]
        public static extern CANStatus OpenDevice(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 Reserved);

        [DllImport("ECANVCI64.dll", EntryPoint = "CloseDevice")]
        public static extern CANStatus CloseDevice(
            UInt32 DeviceType,
            UInt32 DeviceInd);

        [DllImport("ECANVCI64.dll", EntryPoint = "InitCAN")]
        public static extern CANStatus InitCAN(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 CANInd,
            ref InitConfig InitConfig);

        [DllImport("ECANVCI64.dll", EntryPoint = "StartCAN")]
        public static extern CANStatus StartCAN(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 CANInd);

        [DllImport("ECANVCI64.dll", EntryPoint = "ResetCAN")]
        public static extern CANStatus ResetCAN(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 CANInd);

        [DllImport("ECANVCI64.dll", EntryPoint = "Transmit")]
        public static extern CANStatus Transmit(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 CANInd,
            CANFrame[] Send,
            UInt16 length);

        [DllImport("ECANVCI64.dll", EntryPoint = "Receive")]
        public static extern CANStatus Receive(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 CANInd,
            out CANFrame Receive,
            UInt32 length,
            UInt32 WaitTime);

        [DllImport("ECANVCI64.dll", EntryPoint = "ReadErrInfo")]
        public static extern CANStatus ReadErrInfo(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 CANInd,
            out CANErrInfo ReadErrInfo);

        [DllImport("ECANVCI64.dll", EntryPoint = "ReadBoardInfo")]
        public static extern CANStatus ReadBoardInfo(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            out BOARD_INFO ReadErrInfo);
    }

}
