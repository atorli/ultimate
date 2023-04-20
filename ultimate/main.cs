using OPCAutomation;
using Microsoft.Extensions.Configuration;
using NLog;
using System.Text;
using NLog.Fluent;

namespace ultimate
{
    public partial class main : Form
    {
        /// <summary>
        /// opc���������󣬱����ڴ��������ʱ�򴴽���
        /// </summary>
        public OPCServer Server { get; set; }

        /// <summary>
        /// opc��Ⱥ�������ڰ������飬����Ϊnull
        /// </summary>
        public OPCGroups? Groups { get; set; }

        /// <summary>
        /// Ԫ�����飬��������ģʽ,��Ʒ���Ƶ�
        /// </summary>
        public OPCGroup? MetaGroup { get; set; }

        /// <summary>
        /// Ԫ���������
        /// </summary>
        public OPCItems? MetaGroupItems { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public OPCGroup? StepGroup { get; set; }

        /// <summary>
        /// ���������
        /// </summary>
        public OPCItems? StepGroupItems { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public OPCGroup? WarnGroup { get; set; }

        /// <summary>
        /// ���������
        /// </summary>
        public OPCItems? WarnGroupItems { get; set; }

        /// <summary>
        /// ���ö���
        /// </summary>
        public IConfigurationRoot Config { get; set; }

        /// <summary>
        /// ��־����
        /// </summary>
        public Logger Logger { get; set; }

        /// <summary>
        /// ģʽ��Ӧ�Ŀؼ�����
        /// </summary>
        public Dictionary<int, Control> modes = new Dictionary<int, Control>();

        /// <summary>
        /// ��ʾ��ǰģʽ��ʾ�Ŀؼ�
        /// </summary>
        private Control? current_control { get; set; } = null;

        /// <summary>
        /// opc��ַǰ׺
        /// </summary>
        public string AddressPrefix = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="logger"></param>
        public main(IConfigurationRoot root, Logger logger)
        {
            InitializeComponent();
            Config = root;
            Logger = logger;
            Server = new OPCServer();

            AddressPrefix = $"{Config["channel"]}.{Config["device"]}.";

            modes.Add(1, new mode1());
            modes.Add(2, new mode2());
            modes.Add(3, new mode3());
            modes.Add(4, new mode4());

            foreach (var values in modes.Values)
            {
                values.Dock = DockStyle.Fill;
            }
        }

        /// <summary>
        /// Ԫ���������ݱ仯�¼��������
        /// </summary>
        /// <param name="TransactionID"></param>
        /// <param name="NumItems"></param>
        /// <param name="ClientHandles"></param>
        /// <param name="ItemValues"></param>
        /// <param name="Qualities"></param>
        /// <param name="TimeStamps"></param>
        private void meta_group_data_change(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            for (int i = 1; i <= NumItems; i++)
            {
                object? _clientHandle = ClientHandles.GetValue(i);
                if (_clientHandle != null)
                {
                    int clientHandle = (int)_clientHandle;

                    if (clientHandle == ultimate.MetaGroup.load_id.ClientHandle)
                    {
                        //����ģʽ
                        Object? value = ItemValues.GetValue(i);

                        if (value != null)
                        {
                            Int16 mode_id = (Int16)value;
                            if (modes.ContainsKey(mode_id))
                            {
                                if (current_control != null)
                                {
                                    this.main_layout.Controls.Remove(current_control);
                                }

                                this.main_layout.Controls.Add(modes[mode_id], 0, 0);
                                this.current_control = modes[mode_id];
                            }
                            else
                            {
                                Logger.Error($"����ļ���ģʽ:{mode_id}");
                            }
                        }
                        else
                        {
                            Logger.Error("��ȡ����ģʽ�쳣������ģʽΪ������");
                        }
                    }
                    else if (clientHandle == ultimate.MetaGroup.product_name.ClientHandle)
                    {
                        //��Ʒ����
                        Object? value = ItemValues.GetValue(i);
                        if (value as Byte[] != null)
                        {
                            StringBuilder sb = new StringBuilder();
                            foreach (var c in (Byte[])value)
                            {
                                sb.Append((Char)c);
                            }
                            this.Text = sb.ToString();
                        }
                        else
                        {
                            this.Text = string.Empty;
                            Logger.Error("��ȡ��Ʒ�����쳣����Ʒ����Ϊ������");
                        }
                    }
                    else if (clientHandle == ultimate.MetaGroup.motor_current.ClientHandle)
                    {
                        //����
                    }
                    else if (clientHandle == ultimate.MetaGroup.time.ClientHandle)
                    {
                        //ʱ��
                    }
                }
                else
                {
                    Logger.Error("��ȡ����쳣�������Ϊ������");
                }
            }
        }

        /// <summary>
        /// ���������ݱ仯�¼��������
        /// </summary>
        /// <param name="TransactionID"></param>
        /// <param name="NumItems"></param>
        /// <param name="ClientHandles"></param>
        /// <param name="ItemValues"></param>
        /// <param name="Qualities"></param>
        /// <param name="TimeStamps"></param>
        private void step_group_data_change(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            object? _clientHandle = ClientHandles.GetValue(i);
            if (info_display.Rows.Count == 500)
            {
                info_display.Rows.Clear();
            }

            for (int i = 1;i <= NumItems;++i)
            {
                object? value = ItemValues.GetValue(i);
                if (value != null)
                {
                    Int16 step = (Int16)value;

                    switch (step)
                    {
                        case 0:
                            {
                                info_display.Rows.Add(DateTime.Now, "�ȴ��豸����");
                                break;
                            }
                        case 10:
                            {
                                info_display.Rows.Add(DateTime.Now, "����ѹ�����׹���");
                                break;
                            }
                        case 20:
                            {
                                info_display.Rows.Add(DateTime.Now, "���װ����˿�뻺���");
                                break;
                            }
                        case 30:
                            {
                                info_display.Rows.Add(DateTime.Now, "����ߵ���ѡ��");
                                break;
                            }

                        case 40:
                            {
                                info_display.Rows.Add(DateTime.Now, "��������ֹ������");
                                break;
                            }
                        case 50:
                            {
                                info_display.Rows.Add(DateTime.Now, "�ŷ��������������͵�����");
                                break;
                            }
                        case 60:
                            {
                                info_display.Rows.Add(DateTime.Now, "����ƽ�����׹���");
                                break;
                            }
                        case 70:
                            {
                                info_display.Rows.Add(DateTime.Now, "�������׹���");
                                break;
                            }
                        case 80:
                            {
                                info_display.Rows.Add(DateTime.Now, "��˿���ɽ����");
                                break;
                            }
                        case 90:
                            {
                                info_display.Rows.Add(DateTime.Now, "�½Ӽ̵�������");
                                break;
                            }
                        case 100:
                            {
                                info_display.Rows.Add(DateTime.Now, "��˿���½Ӽ��");
                                break;
                            }
                        case 110:
                            {
                                info_display.Rows.Add(DateTime.Now, "�������׻ػ���λ");
                                break;
                            }
                        case 120:
                            {
                                info_display.Rows.Add(DateTime.Now, "����ƽ�����׻ػ���λ");
                                break;
                            }
                        case 130:
                            {
                                info_display.Rows.Add(DateTime.Now, "�������׹���");
                                break;
                            }
                        case 140:
                            {
                                info_display.Rows.Add(DateTime.Now, "��������ֹ������");
                                break;
                            }
                        case 150:
                            {
                                info_display.Rows.Add(DateTime.Now, "�жϵ�����е����Ƿ񳬲�");
                                break;
                            }
                        case 151:
                            {
                                info_display.Rows.Add(DateTime.Now, "�������׻ػ���λ");
                                break;
                            }
                        case 160:
                            {
                                info_display.Rows.Add(DateTime.Now, "����ƽ�����׹���");
                                break;
                            }
                        case 170:
                            {
                                info_display.Rows.Add(DateTime.Now, "�������׹���");
                                break;
                            }
                        case 180:
                            {
                                info_display.Rows.Add(DateTime.Now, "��˿���ɽ����");
                                break;
                            }
                        case 190:
                            {
                                info_display.Rows.Add(DateTime.Now, "�½Ӽ̵�������");
                                break;
                            }
                        case 200:
                            {
                                info_display.Rows.Add(DateTime.Now, "��˿���½Ӽ��");
                                break;
                            }
                        case 210:
                            {
                                info_display.Rows.Add(DateTime.Now, "�������׻ػ���λ");
                                break;
                            }
                        case 220:
                            {
                                info_display.Rows.Add(DateTime.Now, "����ƽ�����׻ػ���λ");
                                break;
                            }
                        case 230:
                            {
                                info_display.Rows.Add(DateTime.Now, "�������׹���");
                                break;
                            }
                        case 240:
                            {
                                info_display.Rows.Add(DateTime.Now, "����򽻸�λ�����У�����λ���źż����");
                                break;
                            }
                        case 260:
                            {
                                info_display.Rows.Add(DateTime.Now, "����λ��ȷ��");
                                break;
                            }
                        case 270:
                            {
                                info_display.Rows.Add(DateTime.Now, "�������׻ػ���λ");
                                break;
                            }
                        case 280:
                            {
                                info_display.Rows.Add(DateTime.Now, "����ѹ�����׻ػ���λ");
                                break;
                            }
                        case 290:
                            {
                                info_display.Rows.Add(DateTime.Now, "��ӡ��ǩ��");
                                break;
                            }
                        case 300:
                            {
                                info_display.Rows.Add(DateTime.Now, "��ȡ���Ű�");
                                break;
                            }
                        default:
                            Logger.Error("δ֪���̲���!");
                            break;
                    }
                }
                else
                {
                    Logger.Error("��ȡ����״̬�쳣������״̬Ϊ������");
                }
            }
        }

        /// <summary>
        /// ���������ݱ仯ʱ�䴦�����
        /// </summary>
        /// <param name="TransactionID"></param>
        /// <param name="NumItems"></param>
        /// <param name="ClientHandles"></param>
        /// <param name="ItemValues"></param>
        /// <param name="Qualities"></param>
        /// <param name="TimeStamps"></param>
        private void warn_group_data_change(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            for (int i = 1; i <= NumItems; ++i)
            {
                object? clienthandle_ = ClientHandles.GetValue(i);
                if (clienthandle_ != null)
                {
                    int clienthandle = (int)(clienthandle_);

                    object? value = ItemValues.GetValue(i);
                    var bool_arr = value as bool[];

                    if (bool_arr != null)
                    {
                        if (clienthandle == ultimate.WarnGroup.x428_3.ClientHandle)
                        {
                            for (int j = 0; j < bool_arr.Length; ++j)
                            {
                                if (bool_arr[j])
                                {
                                    add_warn_info(ultimate.WarnGroup.x428_3_warn_message[j]);
                                    Logger.Warn($"����������{ultimate.WarnGroup.x428_3_warn_message[j]}");
                                }
                            }
                        }
                        else if (clienthandle == ultimate.WarnGroup.x430_8.ClientHandle)
                        {
                            for (int j = 0; j < bool_arr.Length; ++j)
                            {
                                if (bool_arr[j])
                                {
                                    add_warn_info(ultimate.WarnGroup.x430_8_warn_message[j]);
                                    Logger.Warn($"����������{ultimate.WarnGroup.x430_8_warn_message[j]}");
                                }
                            }
                        }
                        else if (clienthandle == ultimate.WarnGroup.x431_8.ClientHandle)
                        {
                            for (int j = 0; j < bool_arr.Length; ++j)
                            {
                                if (bool_arr[j])
                                {
                                    add_warn_info(ultimate.WarnGroup.x431_8_warn_message[j]);
                                    Logger.Warn($"����������{ultimate.WarnGroup.x431_8_warn_message[j]}");
                                }
                            }
                        }
                        else if (clienthandle == ultimate.WarnGroup.x432_2.ClientHandle)
                        {
                            for (int j = 0; j < bool_arr.Length; ++j)
                            {
                                if (bool_arr[j])
                                {
                                    add_warn_info(ultimate.WarnGroup.x432_2_warn_message[j]);
                                    Logger.Warn($"����������{ultimate.WarnGroup.x432_2_warn_message[j]}");
                                }
                            }
                        }
                        else if (clienthandle == ultimate.WarnGroup.x434_8.ClientHandle)
                        {
                            for (int j = 0; j < bool_arr.Length; ++j)
                            {
                                if (bool_arr[j])
                                {
                                    add_warn_info(ultimate.WarnGroup.x434_8_warn_message[j]);
                                    Logger.Warn($"����������{ultimate.WarnGroup.x434_8_warn_message[j]}");
                                }
                            }
                        }
                        else if (clienthandle == ultimate.WarnGroup.x435_8.ClientHandle)
                        {
                            for (int j = 0; j < bool_arr.Length; ++j)
                            {
                                if (bool_arr[j])
                                {
                                    add_warn_info(ultimate.WarnGroup.x435_8_warn_message[j]);
                                    Logger.Warn($"����������{ultimate.WarnGroup.x435_8_warn_message[j]}");
                                }
                            }
                        }
                        else if (clienthandle == ultimate.WarnGroup.x436_5.ClientHandle)
                        {
                            for (int j = 0; j < bool_arr.Length; ++j)
                            {
                                if (bool_arr[j])
                                {
                                    add_warn_info(ultimate.WarnGroup.x436_5_warn_message[j]);
                                    Logger.Warn($"����������{ultimate.WarnGroup.x436_5_warn_message[j]}");
                                }
                            }
                        }
                        else if (clienthandle == ultimate.WarnGroup.x438_8.ClientHandle)
                        {
                            for (int j = 0; j < bool_arr.Length; ++j)
                            {
                                if (bool_arr[j])
                                {
                                    add_warn_info(ultimate.WarnGroup.x438_8_warn_message[j]);
                                    Logger.Warn($"����������{ultimate.WarnGroup.x438_8_warn_message[j]}");
                                }
                            }
                        }
                        else if (clienthandle == ultimate.WarnGroup.x439_3.ClientHandle)
                        {
                            for (int j = 0; j < bool_arr.Length; ++j)
                            {
                                if (bool_arr[j])
                                {
                                    add_warn_info(ultimate.WarnGroup.x439_3_warn_message[j]);
                                    Logger.Warn($"����������{ultimate.WarnGroup.x439_3_warn_message[j]}");
                                }
                            }
                        }
                        else
                        {
                            Logger.Error("�������쳣��δ֪�ľ���Դ��");
                        }
                    }
                    else
                    {
                        Logger.Error("��ȡ������Ϣ��������Ϊ�����ã�");
                    }
                }
                else
                {
                    Logger.Error("��ȡ�������󣬾��Ϊ�����ã�");
                }
            }
        }

        /// <summary>
        /// ���������һ����ʾʱ����ʼ���ӷ����������ҿ�ʼ��һЩ
        /// �������ݵĲ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void main_Shown(object sender, EventArgs e)
        {
            try
            {
                Server.Connect(Config["server_name"]);
                if (Server.ServerState == (int)OPCServerState.OPCRunning)
                {
                    this.server_connect_stratus.Text = "����������״̬��������";
                    this.server_connect_stratus.ForeColor = Color.Green;

                    Groups = Server.OPCGroups;
                    Groups.DefaultGroupDeadband = 0;
                    Groups.DefaultGroupIsActive = true;
                    Groups.DefaultGroupUpdateRate = 250;

                    //Ԫ������
                    MetaGroup = Groups.Add("meta_group");
                    MetaGroup.IsSubscribed = true;
                    MetaGroup.DataChange += meta_group_data_change;
                    MetaGroupItems = MetaGroup.OPCItems;
                    //����ģʽ
                    MetaGroupItems.AddItem($"{AddressPrefix}{ultimate.MetaGroup.load_id.Name}", ultimate.MetaGroup.load_id.ClientHandle);
                    //��Ʒ����
                    MetaGroupItems.AddItem($"{AddressPrefix}{ultimate.MetaGroup.product_name.Name}", ultimate.MetaGroup.product_name.ClientHandle);
                    //��ǰ����
                    MetaGroupItems.AddItem($"{AddressPrefix}{ultimate.MetaGroup.motor_current.Name}", ultimate.MetaGroup.motor_current.ClientHandle);
                    //��ǰʱ��
                    MetaGroupItems.AddItem($"{AddressPrefix}{ultimate.MetaGroup.time.Name}", ultimate.MetaGroup.time.ClientHandle);

                    //������
                    StepGroup = Groups.Add("step_group");
                    StepGroup.IsSubscribed = true;
                    StepGroup.DataChange += step_group_data_change;
                    StepGroupItems = StepGroup.OPCItems;
                    //״̬��ת����
                    StepGroupItems.AddItem($"{AddressPrefix}{ultimate.StepGroup.step.Name}", ultimate.StepGroup.step.ClientHandle);

                    //������
                    WarnGroup = Groups.Add("warn_group");
                    WarnGroup.IsSubscribed = true;
                    WarnGroup.DataChange += warn_group_data_change;
                    WarnGroupItems = WarnGroup.OPCItems;
                    WarnGroupItems.AddItem($"{AddressPrefix}{ultimate.WarnGroup.x428_3.Name}", ultimate.WarnGroup.x428_3.ClientHandle);
                    WarnGroupItems.AddItem($"{AddressPrefix}{ultimate.WarnGroup.x430_8.Name}", ultimate.WarnGroup.x430_8.ClientHandle);
                    WarnGroupItems.AddItem($"{AddressPrefix}{ultimate.WarnGroup.x431_8.Name}", ultimate.WarnGroup.x431_8.ClientHandle);
                    WarnGroupItems.AddItem($"{AddressPrefix}{ultimate.WarnGroup.x432_2.Name}", ultimate.WarnGroup.x432_2.ClientHandle);
                    WarnGroupItems.AddItem($"{AddressPrefix}{ultimate.WarnGroup.x434_8.Name}", ultimate.WarnGroup.x434_8.ClientHandle);
                    WarnGroupItems.AddItem($"{AddressPrefix}{ultimate.WarnGroup.x435_8.Name}", ultimate.WarnGroup.x435_8.ClientHandle);
                    WarnGroupItems.AddItem($"{AddressPrefix}{ultimate.WarnGroup.x436_5.Name}", ultimate.WarnGroup.x436_5.ClientHandle);
                    WarnGroupItems.AddItem($"{AddressPrefix}{ultimate.WarnGroup.x438_8.Name}", ultimate.WarnGroup.x438_8.ClientHandle);
                    WarnGroupItems.AddItem($"{AddressPrefix}{ultimate.WarnGroup.x439_3.Name}", ultimate.WarnGroup.x439_3.ClientHandle);
                }
                else
                {
                    //����ʧ��
                    Logger.Error($"����KepServerʧ��,����˵�״̬Ϊ:{Enum.GetName<OPCServerState>((OPCServerState)Server.ServerState)}");
                }
            }
            catch (Exception ex)
            {
                //����ʧ��
                Logger.Error($"����KepServerʧ�ܣ�{ex.Message}.����Kepserver�Ƿ����������Լ������ļ��еķ����������Ƿ���ȷ!");
            }
        }

        /// <summary>
        /// ��ӱ�����Ϣ
        /// </summary>
        /// <param name="message"></param>
        private void add_warn_info(string message)
        {
            this.info_display.Rows.Add(DateTime.Now, message);
            this.info_display.Rows[this.info_display.Rows.Count - 1].Cells[0].Style.ForeColor = Color.Red;
            this.info_display.Rows[this.info_display.Rows.Count - 1].Cells[1].Style.ForeColor = Color.Red;
        }
    }
}