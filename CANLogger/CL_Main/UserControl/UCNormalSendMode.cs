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

namespace CL_Main
{
    public partial class UCNormalSendMode : UserControl
    {
        private static readonly ILog Logger = log4net.LogManager.GetLogger("info");
        private static readonly string FRAME_ID_CHAR_SET = "0123456789abcdefABCDEF\b";
        private static readonly string SEND_NUM_CHAR_SET = "0123456789\b";
        private static readonly string FRAME_DATA_CHAR_SET = " 0123456789abcdefABCDEF\b";
        private static readonly string SEND_INTERVAL_CHAR_SET = "0123456789.\b";
        private static readonly uint SEND_NUM_MINIMUM = 1;
        private static readonly uint SEND_NUM_MAXIMUM = 1000000;
        private static readonly double SEND_INTERVAL_MINIMUM = 0.1;
        private static readonly double SEND_INTERVAL_MAXIMUM = 1000000000.0;
        private static readonly uint FRAME_DATA_LENGTH_MAXIMUM = 8;

        private Channel channel;
        private bool isSending = false;

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
            CAN_SEND_MODE sendMode = (CAN_SEND_MODE)CAN.CAN_SEND_MODE_LIST[this.cbxSendMode.SelectedItem.ToString()];
            CAN_FRAME_TYPE frameType = (CAN_FRAME_TYPE)CAN.CAN_FRAME_TYPE_LIST[this.cbxFrameType.SelectedItem];
            CAN_FRAME_FORMAT frameFormat = (CAN_FRAME_FORMAT)CAN.CAN_FRAME_FORMAT_LIST[this.cbxFrameFormat.SelectedItem];

            //get & check id
            uint id;
            try
            {
                id = Convert.ToUInt32(tbxFrameID.Text, 16);
                if (frameFormat == CAN_FRAME_FORMAT.STANDARD_FRAME && id > CAN.STANDARD_FRAME_ID_MAXIMUM)
                {
                    MessageBox.Show(string.Format("标准帧ID超过最大值[0x{0}].", CAN.STANDARD_FRAME_ID_MAXIMUM.ToString("x")));
                    return false;
                }
                else if (frameFormat == CAN_FRAME_FORMAT.EXTENDED_FRAME && id > CAN.EXTENDED_FRAME_ID_MAXIMUM)
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
            uint sendNum;
            try
            {
                sendNum = Convert.ToUInt32(this.tbxSendNum.Text);
                if (sendNum < SEND_NUM_MINIMUM)
                {
                    MessageBox.Show(string.Format("发送次数不能小于[{0}].", SEND_NUM_MINIMUM));
                    return false;
                }
                else if (sendNum > SEND_NUM_MAXIMUM)
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
            double sendInterval;
            try
            {
                sendInterval = Convert.ToDouble(this.tbxSendInterval.Text);
                if (sendInterval < SEND_INTERVAL_MINIMUM)
                {
                    MessageBox.Show(string.Format("发送时间间隔不能小于[{0}]ms.", SEND_INTERVAL_MINIMUM));
                    return false;
                }
                else if (sendInterval > SEND_INTERVAL_MAXIMUM)
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
                if (dataArr.Length > FRAME_DATA_LENGTH_MAXIMUM)
                {
                    MessageBox.Show(string.Format("发送数据长度不能超过[{0}].", FRAME_DATA_LENGTH_MAXIMUM));
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

        private IEnumerable<CAN_FRAME> GetCANFrames()
        {
            CAN_SEND_MODE sendMode = (CAN_SEND_MODE)CAN.CAN_SEND_MODE_LIST[this.cbxSendMode.SelectedItem.ToString()];
            CAN_FRAME_TYPE frameType = (CAN_FRAME_TYPE)CAN.CAN_FRAME_TYPE_LIST[this.cbxFrameType.SelectedItem];
            CAN_FRAME_FORMAT frameFormat = (CAN_FRAME_FORMAT)CAN.CAN_FRAME_FORMAT_LIST[this.cbxFrameFormat.SelectedItem];

            uint id = Convert.ToUInt32(tbxFrameID.Text, 16);
            uint sendNum = Convert.ToUInt32(this.tbxSendNum.Text, 10);
            //double sendInterval = Convert.ToDouble(this.tbxSendInterval.Text);
            string[] dataArr = new Regex("[\\s]+").Replace(this.tbxFrameData.Text.Trim(), " ").Split(' ');
            byte dataLen = (byte)dataArr.Length;
            StringBuilder sbBuilder = new StringBuilder();
            for (int index = dataLen -1 ; index >= 0; index--)
            {
                sbBuilder.Append(dataArr[index].PadLeft(2, '0'));
            }
            ulong data = Convert.ToUInt64(sbBuilder.ToString(), 16);

            bool incID = chbxIncID.Checked;
            bool incData = chbxIncData.Checked;
            
            for (uint index = 0; index < sendNum; index++)
            {
                CAN_OBJ pCANObj = new CAN_OBJ();
                pCANObj.ID = incID ? id + index : id;
                pCANObj.DataLen = dataLen;

                pCANObj.Data = new byte[FRAME_DATA_LENGTH_MAXIMUM];
                ulong ulData = incData ? data + index : data;
                Array.Copy(BitConverter.GetBytes(ulData), pCANObj.Data, dataLen);

                pCANObj.SendType = (byte)sendMode;
                pCANObj.RemoteFlag = (byte)frameType;
                pCANObj.ExternFlag = (byte)frameFormat;
                pCANObj.TimeFlag = (byte)CAN_FRAME_TIME_FLAG.VALID;
                pCANObj.TimeStamp = 0;

                CAN_FRAME pCANFrame = new CAN_FRAME(pCANObj, DateTime.Now, CAN_FRAME_DIRECTION.SEND, CAN_FRAME_STATUS.SUCCESS);
                yield return pCANFrame;
            }
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
            if (isSending || !Check())
            {
                return;
            }
            //double sendInterval = Convert.ToDouble(this.tbxSendInterval.Text);

            IEnumerable<CAN_FRAME> pCANFrames = GetCANFrames();
            IEnumerator<CAN_FRAME> pFramesQueue = pCANFrames.GetEnumerator();

            uint count = 0;
            CAN_FRAME[] pFrames = new CAN_FRAME[100];
            while (pFramesQueue.MoveNext())
            {
                pFrames[count++] = pFramesQueue.Current;
                if (count == 100)
                {
                    channel.Transmit(pFrames, 100);
                    pFrames = new CAN_FRAME[100];
                    count = 0;
                }
            }
            channel.Transmit(pFrames, count);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!isSending)
            {
                return;
            }
        }

        #endregion

    }
}
