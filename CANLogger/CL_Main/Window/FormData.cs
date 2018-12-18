using CL_Framework;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CL_Main
{
    public partial class FormData : DockContent
    {
        /************************************************************************************/
        private readonly static int SEND_MODE_NORMAL = 0;
        private readonly static int SEND_MODE_LIST = 1;
        private readonly static string[] SEND_MODE_DESC = new string[] { "普通发送模式", "列表发送模式" };
        private readonly static ILog Logger = log4net.LogManager.GetLogger("info");
        /************************************************************************************/
        private DeviceGroup p_DeviceGroup = DeviceGroup.CreateInstance();
        private Channel channel = null;
        private UCListSendMode p_UCSendModeList = null;
        private UCNormalSendMode p_UCSendModeNormal = null;
        private readonly object locker = new object();
        private List<CAN_DATA> p_CANDataQueue = new List<CAN_DATA>();
        private int m_SendMode = SEND_MODE_LIST;
        private DISPLAY_FRAME p_DisplayFrame;
        /************************************************************************************/

        /************************************************************************************/
        #region public apis

        public FormData(Channel channel)
        {
            InitializeComponent();
            this.channel = channel;
        }

        public Channel GetChannel()
        {
            return this.channel;
        }

        #endregion

        #region private functions

        private void Init()
        {
            this.p_DeviceGroup.ChannelUpdated += new ChannelEventHandler(this.UpdateChannel);

            this.Text = channel.ChannelName;
            this.p_UCSendModeNormal = new UCNormalSendMode(this.channel);
            this.p_UCSendModeList = new UCListSendMode(this.channel);
            this.pnlSend.Controls.Add(this.p_UCSendModeNormal);
            this.pnlSend.Controls.Add(this.p_UCSendModeList);

            DISPLAY_FRAME pDisplayFrame = new DISPLAY_FRAME();
            pDisplayFrame.DisplayMode = DISPLAY_MODE.ROLLING;
            pDisplayFrame.ShowSendFrame = true;
            pDisplayFrame.ShowErrorFrame = true;
            pDisplayFrame.ShowFrameInterval = true;
            pDisplayFrame.ShowLocalTime = false;
            Display(pDisplayFrame, true);

            this.UpdateChannel(this.channel, null);

            ChangeSendMode();
        }

        private void Finish()
        {
            p_DeviceGroup.ChannelUpdated -= this.UpdateChannel;
            this.Dispose();
        }

        private void ChangeSendMode()
        {
            if (m_SendMode == SEND_MODE_NORMAL)
            {
                m_SendMode = SEND_MODE_LIST;
                this.p_UCSendModeNormal.Dock = DockStyle.None;
                this.p_UCSendModeNormal.Visible = false;
                this.p_UCSendModeList.Dock = DockStyle.Fill;
                this.p_UCSendModeList.Visible = true;
            }
            else
            {
                m_SendMode = SEND_MODE_NORMAL;
                this.p_UCSendModeList.Dock = DockStyle.None;
                this.p_UCSendModeList.Visible = false;
                this.p_UCSendModeNormal.Dock = DockStyle.Fill;
                this.p_UCSendModeNormal.Visible = true;
            }
            this.btnSendMode.Text = SEND_MODE_DESC[this.m_SendMode];
        }

        private void Receive()
        {
            uint length = channel.GetRcvBufSize();
            CAN_FRAME[] pCANFrames;
            uint nRealNum = channel.Receive(out pCANFrames, length);

            Logger.Info(string.Format("FormData[{0}] gets [{1}/{2}] frames from rcv buf queue.", channel.ChannelName, nRealNum, length));
            lock (locker)
            {
                for (int index = 0; index < pCANFrames.Length; index++)
                {
                    long mQueueIndex = this.p_CANDataQueue.Count + 1;
                    int nRowIndex = this.dgvData.Rows.Add();
                    DataGridViewRow row = this.dgvData.Rows[nRowIndex];
                    CAN_DATA pCANData = new CAN_DATA(mQueueIndex, pCANFrames[index], row);
                    pCANData.SetVisible(this.p_DisplayFrame.ShowSendFrame, this.p_DisplayFrame.ShowErrorFrame);
                    this.p_CANDataQueue.Add(pCANData);
                }
            }
        }

        private void GetSended()
        {
            uint length = channel.GetSendedBufSize();
            CAN_FRAME[] pCANFrames;
            uint nRealNum = channel.GetSended(out pCANFrames, length);

            Logger.Info(string.Format("FormData[{0}] gets [{1}/{2}] frames from sended buf queue.", channel.ChannelName, nRealNum, length));
            lock (locker)
            {
                for (int index = 0; index < pCANFrames.Length; index++)
                {
                    long mQueueIndex = this.p_CANDataQueue.Count + 1;
                    int nRowIndex = this.dgvData.Rows.Add();
                    DataGridViewRow row = this.dgvData.Rows[nRowIndex];
                    CAN_DATA pCANData = new CAN_DATA(mQueueIndex, pCANFrames[index], row);
                    this.p_CANDataQueue.Add(pCANData);
                }
            }
        }

        private void Display(DISPLAY_FRAME pDisplayFrame, bool mIgnoreCompare=false)
        {
            if (!mIgnoreCompare && this.p_DisplayFrame.Equals(pDisplayFrame))
            {
                Logger.Info(string.Format("FormData[{0}] display frame paras no change, no need to update.", channel.ChannelName));
                return;
            }

            if (mIgnoreCompare || this.p_DisplayFrame.ShowLocalTime != pDisplayFrame.ShowLocalTime)
            {
                this.dgvData.Columns[1].Visible = pDisplayFrame.ShowLocalTime;
            }
            if (mIgnoreCompare || this.p_DisplayFrame.ShowFrameInterval != pDisplayFrame.ShowFrameInterval)
            {
                this.dgvData.Columns[2].Visible = pDisplayFrame.ShowFrameInterval;
            }
            if (mIgnoreCompare 
                || this.p_DisplayFrame.ShowErrorFrame != pDisplayFrame.ShowErrorFrame
                || this.p_DisplayFrame.ShowSendFrame != pDisplayFrame.ShowSendFrame)
            {
                foreach (CAN_DATA pCANData in this.p_CANDataQueue)
                {
                    if (pCANData.CANFrame.Direction == CAN_FRAME_DIRECTION.SEND)
                    {
                        if (pCANData.CANFrame.Status != CAN_FRAME_STATUS.SUCCESS)
                        {
                            pCANData.Visible = pDisplayFrame.ShowErrorFrame && pDisplayFrame.ShowSendFrame;
                        }
                        else
                        {
                            pCANData.Visible = pDisplayFrame.ShowSendFrame;
                        }
                    }
                    else
                    {
                        if (pCANData.CANFrame.Status != CAN_FRAME_STATUS.SUCCESS)
                        {
                            pCANData.Visible = pDisplayFrame.ShowErrorFrame;
                        }
                    }
                }
            }
            this.p_DisplayFrame = pDisplayFrame;
        }

        #endregion

        public void SetLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(language);
            System.ComponentModel.ComponentResourceManager resources = new ComponentResourceManager(this.GetType());

            resources.ApplyResources(this, "$this");

            resources.ApplyResources(this.btnStartReset, this.btnStartReset.Name);
            resources.ApplyResources(this.btnShowMode, this.btnShowMode.Name);
            resources.ApplyResources(this.btnFilter, this.btnFilter.Name);
        }

        public void UpdateChannel(Channel channel, object paras)
        {
            if (Object.ReferenceEquals(channel, this.channel))
            {
                if (channel.IsStarted)
                {
                    this.displayTimer.Start();
                    this.btnStartReset.Text = "复位CAN";
                    this.btnStartReset.Image = global::CL_Main.Properties.Resources.stop;
                }
                else
                {
                    this.displayTimer.Stop();
                    this.btnStartReset.Text = "启动CAN";
                    this.btnStartReset.Image = global::CL_Main.Properties.Resources.start;
                }
            }
        }

        #region events

        private void FormData_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void btnSendMode_Click(object sender, EventArgs e)
        {
            ChangeSendMode();
        }

        private void btnStartReset_Click(object sender, EventArgs e)
        {
            if (channel.IsStarted)
            {
                string content = string.Format("确定要复位当前CAN通道[{0}]吗？", channel.ChannelName);
                DialogResult dialogResult = MessageBox.Show(content, "复位CAN", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    if (channel.ResetCAN() == (uint)CAN_RESULT.SUCCESSFUL)
                    {
                        p_DeviceGroup.UpdateChannel(channel);
                        return;
                    }
                    MessageBox.Show(string.Format("复位当前CAN通道[{0}]失败.", channel.ChannelName));
                }
            }
            else
            {
                if (channel.StartCAN() == (uint)CAN_RESULT.SUCCESSFUL)
                {
                    p_DeviceGroup.UpdateChannel(channel);
                    return;
                }
                else
                {
                    MessageBox.Show(string.Format("启动当前CAN通道[{0}]失败.", channel.ChannelName));
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            string content = string.Format("确定要清除当前CAN通道[{0}]的数据吗？", channel.ChannelName);
            DialogResult dialogResult = MessageBox.Show(content, "清除CAN通道数据", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK)
            {
                this.p_CANDataQueue.Clear();
                this.dgvData.Rows.Clear();
            }
        }

        private void FormData_FormClosing(object sender, FormClosingEventArgs e)
        {
            Finish();
        }

        private void displayTimer_Tick(object sender, EventArgs e)
        {
            if (channel.GetRcvBufSize() > 0 || channel.GetSendedBufSize() > 0)
            {
                this.displayTimer.Stop();
                if (channel.GetRcvBufSize() > 0)
                {
                    this.Receive();
                }
                if (channel.GetSendedBufSize() > 0)
                {
                    this.GetSended();
                }
                this.displayTimer.Start();
            }
        }

        private void btnShowMode_Click(object sender, EventArgs e)
        {
            DisplayConfigDialog pDialog = new DisplayConfigDialog(this.p_DisplayFrame);
            if (pDialog.ShowDialog() == DialogResult.OK)
            {
                Display(pDialog.DisplayFrame, false);
                pDialog.Close();
            }
        }

        #endregion
    }

    public enum DISPLAY_MODE : byte
    {
        ROLLING,        //滚动模式
        STATISTICAL     //统计模式
    }

    public struct DISPLAY_FRAME
    {
        public DISPLAY_MODE DisplayMode;
        public bool ShowSendFrame;
        public bool ShowErrorFrame;
        public bool ShowLocalTime;
        public bool ShowFrameInterval;
    }

    class CAN_DATA
    {
        /************************************************************************************/
        private static readonly string DATA_FRAME_DESC = "DATA";
        private static readonly string REMOTE_FRAME_DESC = "RTR";
        private static readonly string STANDARD_FRAME_DESC = "STANDARD";
        private static readonly string EXTENDED_FRAME_DESC = "EXTENDED";
        private static readonly string SEND_SUCCESS_DESC = "发送成功";
        private static readonly string SEND_FAILED_DESC = "发送失败";
        private static readonly string RECEIVE_SUCCESS_DESC = "接收成功";
        private static readonly string RECEIVE_FAILED_DESC = "接收失败";
        /************************************************************************************/
        private CAN_FRAME p_CANFrame;
        public DataGridViewRow Row { get; } = null;
        public bool Visible
        { get { return this.Row.Visible; } set { this.Row.Visible = value; } }
        public long QueueIndex { get; }
        public CAN_FRAME CANFrame
        { get { return this.p_CANFrame; } set{ this.p_CANFrame = value; } }
        /************************************************************************************/
        public CAN_DATA(long mQueueIndex, CAN_FRAME pCANFrame, DataGridViewRow row)
        {
            this.QueueIndex = mQueueIndex;
            this.CANFrame = pCANFrame;
            this.Row = row;
            this.Init();
        }

        unsafe private void Init()
        {
            //queue index
            this.Row.Cells[0].Value = this.QueueIndex;
            //local time
            this.Row.Cells[1].Value = this.CANFrame.Time.ToString("yyyy-MM-dd hh:mm:ss.ffff");
            //time stamp
            this.Row.Cells[2].Value = this.CANFrame.CANObj.TimeStamp.ToString("N0");
            if (this.CANFrame.CANObj.TimeFlag == (byte)CAN_FRAME_TIME_FLAG.INVALID)
            {
                this.Row.Cells[2].Value = this.CANFrame.CANObj.TimeStamp;
            }
            //can send/receive status
            if (this.CANFrame.Direction == CAN_FRAME_DIRECTION.RECEIVE)
            {
                this.Row.Cells[3].Value = this.CANFrame.Status == CAN_FRAME_STATUS.SUCCESS ? RECEIVE_SUCCESS_DESC : RECEIVE_FAILED_DESC;
            }
            else
            {
                this.Row.Cells[3].Value = this.CANFrame.Status == CAN_FRAME_STATUS.SUCCESS ? SEND_SUCCESS_DESC : SEND_FAILED_DESC;
            }

            //can id
            this.Row.Cells[4].Value = this.CANFrame.CANObj.ID.ToString("x");
            //can frame type
            if (this.CANFrame.CANObj.RemoteFlag == (byte)CAN_FRAME_TYPE.DATA_FRAME)
            {
                this.Row.Cells[5].Value = DATA_FRAME_DESC;
            }
            else
            {
                this.Row.Cells[5].Value = REMOTE_FRAME_DESC;
            }
            //can frame format
            if (this.CANFrame.CANObj.ExternFlag == (byte)CAN_FRAME_FORMAT.STANDARD_FRAME)
            {
                this.Row.Cells[6].Value = STANDARD_FRAME_DESC;
            }
            else
            {
                this.Row.Cells[6].Value = EXTENDED_FRAME_DESC;
            }
            //can data length
            this.Row.Cells[7].Value = this.CANFrame.CANObj.DataLen;
            //can data

            StringBuilder sb = new StringBuilder();
            //byte[] data = new byte[CAN.FRAME_DATA_LENGTH_MAXIMUM];
            fixed (byte* pData = this.p_CANFrame.CANObj.Data)
            {
                //Marshal.Copy((IntPtr)pData, data, 0, (int)CAN.FRAME_DATA_LENGTH_MAXIMUM);
                for (int index = 0; index < this.CANFrame.CANObj.DataLen; index++)
                {
                    sb.Append(Convert.ToString(pData[index], 16).PadLeft(2, '0')).Append(" ");
                }
            }
            this.Row.Cells[8].Value = string.Join(" ", sb.ToString().Trim());

        }

        public void SetVisible(bool mShowSendFrame, bool mShowErrorFrame)
        {
            if (CANFrame.Direction == CAN_FRAME_DIRECTION.SEND)
            {
                if (CANFrame.Status != CAN_FRAME_STATUS.SUCCESS)
                {
                    Visible = mShowErrorFrame && mShowSendFrame;
                }
                else
                {
                    Visible = mShowSendFrame;
                }
            }
            else
            {
                if (CANFrame.Status != CAN_FRAME_STATUS.SUCCESS)
                {
                    Visible = mShowErrorFrame;
                }
                else
                {
                    Visible = true;
                }
            }
        }

    }
}
