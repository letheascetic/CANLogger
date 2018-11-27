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
    public struct CAN_OBJ
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

    public struct CAN_ERR_INFO
    {
        public uint ErrCode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Passive_ErrData;
        public byte ArLost_ErrData;
    }

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

    public struct BOARD_INFO
    {
        public ushort hw_Version;
        public ushort fw_Version;
        public ushort dr_Version;
        public ushort in_Version;
        public ushort irq_Num;
        public byte can_Num;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] str_Serial_Num;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public byte[] str_hw_Type;
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
            ref INIT_CONFIG InitConfig);

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
            CAN_OBJ[] Send,
            UInt16 length);

        [DllImport("ECANVCI64.dll", EntryPoint = "Receive")]
        public static extern CANStatus Receive(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 CANInd,
            out CAN_OBJ Receive,
            UInt32 length,
            UInt32 WaitTime);

        [DllImport("ECANVCI64.dll", EntryPoint = "ReadErrInfo")]
        public static extern CANStatus ReadErrInfo(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 CANInd,
            out CAN_ERR_INFO ReadErrInfo);

        [DllImport("ECANVCI64.dll", EntryPoint = "ReadBoardInfo")]
        public static extern CANStatus ReadBoardInfo(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            out BOARD_INFO ReadErrInfo);
    }

}
