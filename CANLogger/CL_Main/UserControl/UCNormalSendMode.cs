using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using log4net;
using System.Text;
using CL_Framework;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace CL_Main
{
    public partial class UCNormalSendMode : UserControl
    {
        /************************************************************************************/
        private static readonly ILog Logger = log4net.LogManager.GetLogger("info");
        private static readonly string FRAME_ID_CHAR_SET = "0123456789abcdefABCDEF\b";
        //private static readonly string SEND_NUM_CHAR_SET = "0123456789\b";
        private static readonly string FRAME_DATA_CHAR_SET = " 0123456789abcdefABCDEF\b";
        //private static readonly string SEND_INTERVAL_CHAR_SET = "0123456789.\b";
        private static readonly uint SEND_NUM_MINIMUM = 1;
        private static readonly uint SEND_NUM_MAXIMUM = 1000000;
        private static readonly double SEND_INTERVAL_MINIMUM = 0.1;
        private static readonly double SEND_INTERVAL_MAXIMUM = 1000000000.0;
        /************************************************************************************/
        private Channel channel;
        private bool m_IsSending = false;

        #region public apis

        public UCNormalSendMode(Channel channel)
        {
            InitializeComponent();
            this.channel = channel;
        }

        #endregion

        #region private functions

        private void Init()
        {
            BindingSource bsSendMode = new BindingSource();
            bsSendMode.DataSource = CAN.CAN_SEND_MODE_LIST.Keys;
            cbxSendMode.DataSource = bsSendMode;
            cbxSendMode.SelectedIndex = cbxSendMode.FindString(CAN.CAN_SEND_MODE_NORMAL);

            BindingSource bsFrameType = new BindingSource();
            bsFrameType.DataSource = CAN.CAN_FRAME_TYPE_LIST.Keys;
            cbxFrameType.DataSource = bsFrameType;
            cbxFrameType.SelectedIndex = cbxFrameType.FindString(CAN.CAN_FRAME_TYPE_DATA_FRAME);

            BindingSource bsFrameFormat = new BindingSource();
            bsFrameFormat.DataSource = CAN.CAN_FRAME_FORMAT_LIST.Keys;
            cbxFrameFormat.DataSource = bsFrameFormat;
            cbxFrameFormat.SelectedIndex = cbxFrameFormat.FindString(CAN.CAN_FRAME_FORMAT_STANDARD_FRAME);
        }

        private bool Check()
        {
            //get send mode & frame type & frame format
            CAN_SEND_MODE mSendMode = (CAN_SEND_MODE)CAN.CAN_SEND_MODE_LIST[this.cbxSendMode.SelectedItem.ToString()];
            CAN_FRAME_TYPE mFrameType = (CAN_FRAME_TYPE)CAN.CAN_FRAME_TYPE_LIST[this.cbxFrameType.SelectedItem];
            CAN_FRAME_FORMAT mFrameFormat = (CAN_FRAME_FORMAT)CAN.CAN_FRAME_FORMAT_LIST[this.cbxFrameFormat.SelectedItem];

            //get & check id
            uint id;
            try
            {
                id = Convert.ToUInt32(tbxFrameID.Text, 16);
                if (mFrameFormat == CAN_FRAME_FORMAT.STANDARD_FRAME && id > CAN.STANDARD_FRAME_ID_MAXIMUM)
                {
                    MessageBox.Show(string.Format("标准帧ID超过最大值[0x{0}].", CAN.STANDARD_FRAME_ID_MAXIMUM.ToString("x")));
                    return false;
                }
                else if (mFrameFormat == CAN_FRAME_FORMAT.EXTENDED_FRAME && id > CAN.EXTENDED_FRAME_ID_MAXIMUM)
                {
                    MessageBox.Show(string.Format("扩展帧ID超过最大值[0x{0}].", CAN.STANDARD_FRAME_ID_MAXIMUM.ToString("x")));
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ID格式不正确.");
                Logger.Info(string.Format("channel[{0}] send frame id format error: [{1}].", channel.ChannelName, tbxFrameID.Text), e);
                return false;
            }

            //get & check send num
            uint mSendNum;
            try
            {
                mSendNum = Convert.ToUInt32(this.tbxSendNum.Text);
                if (mSendNum < SEND_NUM_MINIMUM)
                {
                    MessageBox.Show(string.Format("发送次数不能小于[{0}].", SEND_NUM_MINIMUM));
                    return false;
                }
                else if (mSendNum > SEND_NUM_MAXIMUM)
                {
                    MessageBox.Show(string.Format("发送次数不能超过[{0}].", SEND_NUM_MAXIMUM));
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("发送次数格式不正确.");
                Logger.Info(string.Format("channel[{0}] send num format error: [{1}].", channel.ChannelName, tbxSendNum.Text), e);

                return false;
            }

            //get & check send interval
            double mSendInterval;
            try
            {
                mSendInterval = Convert.ToDouble(this.tbxSendInterval.Text);
                if (mSendInterval < SEND_INTERVAL_MINIMUM)
                {
                    MessageBox.Show(string.Format("发送时间间隔不能小于[{0}]ms.", SEND_INTERVAL_MINIMUM));
                    return false;
                }
                else if (mSendInterval > SEND_INTERVAL_MAXIMUM)
                {
                    MessageBox.Show(string.Format("发送时间间隔不能超过[{0}]ms.", SEND_INTERVAL_MAXIMUM));
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("发送时间间隔格式不正确.");
                Logger.Info(string.Format("channel[{0}] send time interval error: [{1}].", channel.ChannelName, tbxSendInterval.Text), e);
                return false;
            }

            //get & check data
            try
            {
                string[] dataArr = new Regex("[\\s]+").Replace(this.tbxFrameData.Text.Trim(), " ").Split(' ');
                if (dataArr.Length > CAN.FRAME_DATA_LENGTH_MAXIMUM)
                {
                    MessageBox.Show(string.Format("发送数据长度不能超过[{0}].", CAN.FRAME_DATA_LENGTH_MAXIMUM));
                    return false;
                }
                foreach (string dataStr in dataArr)
                {
                    if (dataStr.Length > 2)
                    {
                        MessageBox.Show(string.Format("发送数据格式不正确:[{0}].", dataStr));
                        return false;
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("发送数据格式不正确.");
                Logger.Info(string.Format("channel[{0}] send data format error: [{1}].", channel.ChannelName, tbxFrameData.Text), e);
                return false;
            }

            return true;
        }

        unsafe private CAN_FRAME[] GetCANFrames()
        {
            CAN_SEND_MODE mSendMode = (CAN_SEND_MODE)CAN.CAN_SEND_MODE_LIST[this.cbxSendMode.SelectedItem.ToString()];
            CAN_FRAME_TYPE mFrameType = (CAN_FRAME_TYPE)CAN.CAN_FRAME_TYPE_LIST[this.cbxFrameType.SelectedItem];
            CAN_FRAME_FORMAT mFrameFormat = (CAN_FRAME_FORMAT)CAN.CAN_FRAME_FORMAT_LIST[this.cbxFrameFormat.SelectedItem];

            uint id = Convert.ToUInt32(tbxFrameID.Text, 16);
            uint mSendNum = Convert.ToUInt32(this.tbxSendNum.Text, 10);
            double mSendInterval = Convert.ToDouble(this.tbxSendInterval.Text);

            string[] sDataArr = new Regex("[\\s]+").Replace(this.tbxFrameData.Text.Trim(), " ").Split(' ');
            byte mDataLen = (byte)sDataArr.Length;

            StringBuilder sbBuilder = new StringBuilder("0x");
            for (int index = mDataLen - 1 ; index >= 0; index--)
            {
                sbBuilder.Append(sDataArr[index].PadLeft(2, '0'));
            }
            ulong data = Convert.ToUInt64(sbBuilder.ToString(), 16);
            
            bool incID = chbxIncID.Checked;
            bool incData = chbxIncData.Checked;

            CAN_FRAME[] pCANFrames = new CAN_FRAME[mSendNum];
            for (uint index = 0; index < mSendNum; index++)
            {
                CAN_OBJ pCANObj = new CAN_OBJ();
                pCANObj.ID = incID ? id + index : id;
                pCANObj.DataLen = mDataLen;

                ulong ulData = incData ? data + index : data;
                Marshal.Copy(BitConverter.GetBytes(ulData), 0, (IntPtr)pCANObj.Data, (int)CAN.FRAME_DATA_LENGTH_MAXIMUM);

                pCANObj.SendType = (byte)mSendMode;
                pCANObj.RemoteFlag = (byte)mFrameType;
                pCANObj.ExternFlag = (byte)mFrameFormat;
                pCANObj.TimeFlag = (byte)CAN_FRAME_TIME_FLAG.INVALID;
                pCANObj.TimeStamp = 0;

                pCANFrames[index] = new CAN_FRAME(pCANObj, DateTime.Now, CAN_FRAME_DIRECTION.SEND, CAN_FRAME_STATUS.FAILED);
            }
            return pCANFrames;
        }

        #endregion

        #region events

        private void UCNormalSendMode_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void tbxSendNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxSendInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && e.KeyChar != '.' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxFrameID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!FRAME_ID_CHAR_SET.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxFrameData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!FRAME_DATA_CHAR_SET.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (m_IsSending || !Check())
            {
                return;
            }
            //double sendInterval = Convert.ToDouble(this.tbxSendInterval.Text);
            CAN_FRAME[] pCANFrames = GetCANFrames();
            channel.Transmit(pCANFrames);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!m_IsSending)
            {
                return;
            }
        }

        #endregion

    }
}
