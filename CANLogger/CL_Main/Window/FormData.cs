using CL_Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CL_Main
{
    public partial class FormData : DockContent
    {
        private readonly static int SEND_MODE_NORMAL = 0;
        private readonly static int SEND_MODE_LIST = 1;
        private readonly static string[] SEND_MODE_DESC = new string[] { "普通发送模式", "列表发送模式" };

        private DeviceGroup pDeviceGroup = DeviceGroup.CreateInstance();
        private Channel channel = null;
        private UCNormalSendMode pUCSendModeNormal = null;
        private UCListSendMode pUCSendModeList = null;

        private List<CANData> pCANDataQueue = new List<CANData>();

        private int sendMode = SEND_MODE_LIST;

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
            this.Text = channel.ChannelName;
            this.pUCSendModeNormal = new UCNormalSendMode(this.channel);
            this.pUCSendModeList = new UCListSendMode(this.channel);
            this.pnlSend.Controls.Add(this.pUCSendModeNormal);
            this.pnlSend.Controls.Add(this.pUCSendModeList);

            if (channel.IsStarted)
            {
                this.btnStartReset.Text = "复位CAN";
                this.btnStartReset.Image = global::CL_Main.Properties.Resources.stop;
            }
            else
            {
                this.btnStartReset.Text = "启动CAN";
                this.btnStartReset.Image = global::CL_Main.Properties.Resources.start;
            }

            pDeviceGroup.ChannelUpdated += new ChannelEventHandler(this.UpdateChannel);

            ChangeSendMode();
        }

        private void Finish()
        {
            pDeviceGroup.ChannelUpdated -= this.UpdateChannel;
            this.Dispose();
        }

        private void ChangeSendMode()
        {
            if (sendMode == SEND_MODE_NORMAL)
            {
                sendMode = SEND_MODE_LIST;
                this.pUCSendModeNormal.Dock = DockStyle.None;
                this.pUCSendModeNormal.Visible = false;
                this.pUCSendModeList.Dock = DockStyle.Fill;
                this.pUCSendModeList.Visible = true;
            }
            else
            {
                sendMode = SEND_MODE_NORMAL;
                this.pUCSendModeList.Dock = DockStyle.None;
                this.pUCSendModeList.Visible = false;
                this.pUCSendModeNormal.Dock = DockStyle.Fill;
                this.pUCSendModeNormal.Visible = true;
            }
            this.btnSendMode.Text = SEND_MODE_DESC[this.sendMode];
        }

        private void ReceiveData(CAN_FRAME pCANFrame)
        {
            long queueIndex = this.pCANDataQueue.Count + 1;
            int index = this.dgvData.Rows.Add();
            DataGridViewRow row = this.dgvData.Rows[index];
            CANData pCANData = new CANData(queueIndex, pCANFrame, row);
            this.pCANDataQueue.Add(pCANData);
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
                    this.btnStartReset.Text = "复位CAN";
                    this.btnStartReset.Image = global::CL_Main.Properties.Resources.stop;
                }
                else
                {
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
                        pDeviceGroup.UpdateChannel(channel);
                        return;
                    }
                    MessageBox.Show(string.Format("复位当前CAN通道[{0}]失败.", channel.ChannelName));
                }
            }
            else
            {
                if (channel.StartCAN() == (uint)CAN_RESULT.SUCCESSFUL)
                {
                    pDeviceGroup.UpdateChannel(channel);
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
            this.dgvData.Rows.Clear();
        }

        private void FormData_FormClosing(object sender, FormClosingEventArgs e)
        {
            Finish();
        }

        private void rcvTimer_Tick(object sender, EventArgs e)
        {
            if (channel.RcvBufQueue.Count > 0)
            {
                this.rcvTimer.Stop();

                int count = channel.RcvBufQueue.Count;
                for (int index = 0; index < count; index++)
                {
                    CAN_FRAME pCANFrame;
                    if (channel.RcvBufQueue.TryDequeue(out pCANFrame))
                    {
                        ReceiveData(pCANFrame);
                    }
                }
                this.rcvTimer.Start();
            }
        }

        #endregion

    }

    class CANData
    {
        private static readonly string DATA_FRAME_DESC = "DATA";
        private static readonly string REMOTE_FRAME_DESC = "RTR";
        private static readonly string STANDARD_FRAME_DESC = "STANDARD";
        private static readonly string EXTENDED_FRAME_DESC = "EXTENDED";
        private static readonly string SEND_SUCCESS_DESC = "发送成功";
        private static readonly string SEND_FAILED_DESC = "发送失败";
        private static readonly string RECEIVE_SUCCESS_DESC = "接收成功";
        private static readonly string RECEIVE_FAILED_DESC = "接收失败";

        private long queueIndex;
        private DataGridViewRow row = null;
        private CAN_FRAME pCANFrame;
        
        public DataGridViewRow Row
        { get { return this.row; } }

        public bool Visible
        { get { return this.row.Visible; } set { this.row.Visible = value; } }

        public long QueueIndex
        { get { return this.queueIndex; } }

        public CANData(long queueIndex, CAN_FRAME pCANFrame, DataGridViewRow row)
        {
            this.queueIndex = queueIndex;
            this.pCANFrame = pCANFrame;
            this.row = row;
            this.Init();
        }

        private void Init()
        {
            //queue index
            this.row.Cells[0].Value = this.queueIndex;
            //local time
            this.row.Cells[1].Value = this.pCANFrame.Time.ToString();
            //time stamp
            this.row.Cells[2].Value = string.Empty;
            if (this.pCANFrame.CANObj.TimeFlag == (byte)CAN_FRAME_TIME_FLAG.INVALID)
            {
                this.row.Cells[2].Value = this.pCANFrame.CANObj.TimeStamp;
            }
            //can send/receive status
            if (this.pCANFrame.Direction == CAN_FRAME_DIRECTION.RECEIVE)
            {
                this.row.Cells[3].Value = this.pCANFrame.Status == CAN_FRAME_STATUS.SUCCESS ? RECEIVE_SUCCESS_DESC : RECEIVE_FAILED_DESC;
            }
            else
            {
                this.row.Cells[3].Value = this.pCANFrame.Status == CAN_FRAME_STATUS.SUCCESS ? SEND_SUCCESS_DESC : SEND_FAILED_DESC;
            }

            //can id
            this.row.Cells[4].Value = this.pCANFrame.CANObj.ID.ToString("x");
            //can frame type
            if (this.pCANFrame.CANObj.RemoteFlag == (byte)CAN_FRAME_TYPE.DATA_FRAME)
            {
                this.row.Cells[5].Value = DATA_FRAME_DESC;
            }
            else
            {
                this.row.Cells[5].Value = REMOTE_FRAME_DESC;
            }
            //can frame format
            if (this.pCANFrame.CANObj.ExternFlag == (byte)CAN_FRAME_FORMAT.STANDARD_FRAME)
            {
                this.row.Cells[6].Value = STANDARD_FRAME_DESC;
            }
            else
            {
                this.row.Cells[6].Value = EXTENDED_FRAME_DESC;
            }
            //can data length
            this.row.Cells[7].Value = this.pCANFrame.CANObj.DataLen;
            //can data
            this.row.Cells[8].Value = string.Join(" ", this.pCANFrame.CANObj.data);
        }

    }
}
