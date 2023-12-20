using OPCAutomation;
using Microsoft.Extensions.Configuration;
using NLog;
using System.Text;
using NLog.Fluent;
using Sunny.UI;

namespace ultimate
{
    public partial class main : UIForm
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
        /// �쳣��
        /// </summary>
        public OPCGroup? ErrorGroup { get; set; }

        /// <summary>
        /// �쳣�����
        /// </summary>
        public OPCItems? ErrorGroupItems { get; set; }

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
        public Dictionary<int, ModeBase> modes = new Dictionary<int, ModeBase>();

        /// <summary>
        /// ��ʾ��ǰģʽ��ʾ�Ŀؼ�
        /// </summary>
        private ModeBase? current_control { get; set; } = null;

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

            current_control = modes[1];

            //Ĭ��Ϊ��һ��ģʽ
            main_layout.Panel1.Controls.Add(current_control);
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
                                    main_layout.Panel1.Controls.Remove(current_control);
                                }
                                current_control = modes[mode_id];
                               main_layout.Panel1.Controls.Add(current_control);                               
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
                        object? value = ItemValues.GetValue(i);
                        if (value != null)
                        {
                            float current = (float)value;
                            current_label.Text = $"��ǰ������{current} A";
                        }
                    }
                    else if (clientHandle == ultimate.MetaGroup.time.ClientHandle)
                    {
                        //ʱ��
                        object? value = ItemValues.GetValue(i);
                        if (value != null)
                        {
                            float time = (Int16)value * 0.1f;
                            rising_time.Text = $"����ʱ�䣺{time.ToString("f2")} S";
                        }
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
            for (int i = 1; i <= NumItems; ++i)
            {
                object? value = ItemValues.GetValue(i);
                if (value != null)
                {
                    Int16 step = (Int16)value;

                    switch (step)
                    {
                        case 0:
                            {
                                clear_message();
                                add_step_message("������Ű壬�������豸��");
                                break;
                            }
                        case 10:
                            {
                                clear_warn_message();
                                add_step_message("����ѹ�����׹�����");
                                break;
                            }
                        case 20:
                            {
                                add_step_message("���װ����˿�뻺��顣");
                                break;
                            }
                        case 30:
                            {
                                add_step_message("����ߵ���ѡ��");
                                break;
                            }
                        case 40:
                            {
                                add_step_message("��������ֹ�����С�");
                                current_control?.start_down_arrow_blink();
                                break;
                            }
                        case 50:
                            {
                                add_step_message("�ŷ��������������͵����С�");
                                break;
                            }
                        case 60:
                            {
                                add_step_message("����ƽ�����׹�����");
                                break;
                            }
                        case 70:
                            {
                                add_step_message("�������׹�����");
                                break;
                            }
                        case 80:
                            {
                                add_step_message("��˿���ɽ���⡣");
                                break;
                            }
                        case 90:
                            {
                                add_step_message("�½Ӽ̵���������");
                                break;
                            }
                        case 100:
                            {
                                add_step_message("��˿���½Ӽ�⡣");
                                //todo:�½Ӽ�ⱨ��
                                break;
                            }
                        case 110:
                            {
                                add_step_message("�������׻ػ���λ��");
                                break;
                            }
                        case 120:
                            {
                                add_step_message("����ƽ�����׻ػ���λ��");
                                break;
                            }
                        case 130:
                            {
                                add_step_message("�������׹�����");
                                break;
                            }
                        case 140:
                            {
                                add_step_message("��������ֹ�����С�");
                                current_control?.start_up_arrow_blink();
                                break;
                            }
                        case 150:
                            {
                                add_step_message("�жϵ�����е����Ƿ񳬲");
                                break;
                            }
                        case 151:
                            {
                                add_step_message("�������׻ػ���λ��");
                                break;
                            }
                        case 160:
                            {
                                add_step_message("����ƽ�����׹�����");
                                break;
                            }
                        case 170:
                            {
                                add_step_message("�������׹�����");
                                break;
                            }
                        case 180:
                            {
                                add_step_message("��˿���ɽ���⡣");
                                break;
                            }
                        case 190:
                            {
                                add_step_message("�½Ӽ̵���������");
                                break;
                            }
                        case 200:
                            {
                                add_step_message("��˿���½Ӽ�⡣");
                                break;
                            }
                        case 210:
                            {
                                add_step_message("�������׻ػ���λ��");
                                break;
                            }
                        case 220:
                            {
                                add_step_message("����ƽ�����׻ػ���λ��");
                                break;
                            }
                        case 230:
                            {
                                add_step_message("�������׹�����");
                                break;
                            }
                        case 240:
                            {
                                add_step_message("����򽻸�λ�����У�����λ���źż���С�");
                                //todo:���鵽λ���
                                break;
                            }
                        case 260:
                            {
                                add_step_message("����λ��ȷ�ϡ�");
                                break;
                            }
                        case 270:
                            {
                                add_step_message("�������׻ػ���λ��");
                                break;
                            }
                        case 280:
                            {
                                add_step_message("����ѹ�����׻ػ���λ��");
                                break;
                            }
                        case 290:
                            {
                                add_step_message("��ӡ��ǩ�С�");
                                break;
                            }
                        case 300:
                            {
                                add_step_message("��ȡ���Ű塣");
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
                                    add_warn_message(ultimate.WarnGroup.x428_3_warn_message[j]);
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
                                    add_warn_message(ultimate.WarnGroup.x430_8_warn_message[j]);
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
                                    add_warn_message(ultimate.WarnGroup.x431_8_warn_message[j]);
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
                                    add_warn_message(ultimate.WarnGroup.x432_2_warn_message[j]);
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
                                    add_warn_message(ultimate.WarnGroup.x434_8_warn_message[j]);
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
                                    add_warn_message(ultimate.WarnGroup.x435_8_warn_message[j]);
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
                                    add_warn_message(ultimate.WarnGroup.x436_5_warn_message[j]);
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
                                    add_warn_message(ultimate.WarnGroup.x438_8_warn_message[j]);
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
                                    add_warn_message(ultimate.WarnGroup.x439_3_warn_message[j]);
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
        /// �����龯���¼��������
        /// </summary>
        /// <param name="TransactionID"></param>
        /// <param name="NumItems"></param>
        /// <param name="ClientHandles"></param>
        /// <param name="ItemValues"></param>
        /// <param name="Qualities"></param>
        /// <param name="TimeStamps"></param>
        private void error_group_data_change(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            for (int i = 1; i <= NumItems; ++i)
            {
                object? handle_ = ClientHandles.GetValue(i);
                if (handle_ != null)
                {
                    int handle = (int)handle_;
                    if (handle == ultimate.ErrorGroup.long_rail_bottom_check.ClientHandle || handle == ultimate.ErrorGroup.short_trail_bottom_check.ClientHandle)
                    {
                        //�ѵ�����ֹ��
                        current_control?.stop_down_arrow_blink();
                    }
                    else if (handle == ultimate.ErrorGroup.long_trail_top_check.ClientHandle || handle == ultimate.ErrorGroup.short_trail_top_check.ClientHandle)
                    {
                        //�ѵ�����ֹ��
                        current_control?.stop_up_arrow_blink();
                    }
                    else if (handle == ultimate.ErrorGroup.reset.ClientHandle)
                    {
                        object? is_pressed = ItemValues.GetValue(i);
                        if (is_pressed != null)
                        {
                            if ((bool)is_pressed) reset();
                        }
                    }
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

                    //�쳣��
                    ErrorGroup = Groups.Add("err_group");
                    ErrorGroup.IsSubscribed = true;
                    ErrorGroup.DataChange += error_group_data_change;
                    ErrorGroupItems = ErrorGroup.OPCItems;

                    ErrorGroupItems.AddItem($"{AddressPrefix}{ultimate.ErrorGroup.delivery_position_check.Name}", ultimate.ErrorGroup.delivery_position_check.ClientHandle);
                    ErrorGroupItems.AddItem($"{AddressPrefix}{ultimate.ErrorGroup.long_rail_buffer_check.Name}", ultimate.ErrorGroup.long_rail_buffer_check.ClientHandle);
                    ErrorGroupItems.AddItem($"{AddressPrefix}{ultimate.ErrorGroup.short_rail_buffer_check.Name}", ultimate.ErrorGroup.short_rail_buffer_check.ClientHandle);
                    ErrorGroupItems.AddItem($"{AddressPrefix}{ultimate.ErrorGroup.long_rail_screw_check.Name}", ultimate.ErrorGroup.long_rail_screw_check.ClientHandle);
                    ErrorGroupItems.AddItem($"{AddressPrefix}{ultimate.ErrorGroup.short_rail_screw_check.Name}", ultimate.ErrorGroup.short_rail_screw_check.ClientHandle);
                    ErrorGroupItems.AddItem($"{AddressPrefix}{ultimate.ErrorGroup.long_rail_bottom_check.Name}", ultimate.ErrorGroup.long_rail_bottom_check.ClientHandle);
                    ErrorGroupItems.AddItem($"{AddressPrefix}{ultimate.ErrorGroup.short_trail_bottom_check.Name}", ultimate.ErrorGroup.short_trail_bottom_check.ClientHandle);
                    ErrorGroupItems.AddItem($"{AddressPrefix}{ultimate.ErrorGroup.steel_brush_check_1.Name}", ultimate.ErrorGroup.steel_brush_check_1.ClientHandle);
                    ErrorGroupItems.AddItem($"{AddressPrefix}{ultimate.ErrorGroup.steel_brush_check_2.Name}", ultimate.ErrorGroup.steel_brush_check_2.ClientHandle);
                    ErrorGroupItems.AddItem($"{AddressPrefix}{ultimate.ErrorGroup.steel_brush_check_3.Name}", ultimate.ErrorGroup.steel_brush_check_3.ClientHandle);
                    ErrorGroupItems.AddItem($"{AddressPrefix}{ultimate.ErrorGroup.steel_brush_splice_check_1.Name}", ultimate.ErrorGroup.steel_brush_splice_check_1.ClientHandle);
                    ErrorGroupItems.AddItem($"{AddressPrefix}{ultimate.ErrorGroup.steel_brush_splice_check_2.Name}", ultimate.ErrorGroup.steel_brush_splice_check_2.ClientHandle);
                    ErrorGroupItems.AddItem($"{AddressPrefix}{ultimate.ErrorGroup.long_trail_top_check.Name}", ultimate.ErrorGroup.long_trail_top_check.ClientHandle);
                    ErrorGroupItems.AddItem($"{AddressPrefix}{ultimate.ErrorGroup.short_trail_top_check.Name}", ultimate.ErrorGroup.short_trail_top_check.ClientHandle);
                    ErrorGroupItems.AddItem($"{AddressPrefix}{ultimate.ErrorGroup.reset.Name}", ultimate.ErrorGroup.reset.ClientHandle);

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
        private void add_warn_message(string message)
        {
            warn_display.Rows.Add(DateTime.Now, message);
            warn_display.FirstDisplayedScrollingRowIndex = warn_display.Rows.Count - 1;
        }

        /// <summary>
        /// ���������Ϣ
        /// </summary>
        /// <param name="message"></param>
        private void add_step_message(string message)
        {
            info_display.Rows.Add(DateTime.Now, message);
            info_display.FirstDisplayedScrollingRowIndex = info_display.Rows.Count - 1;
        }

        /// <summary>
        /// ��������Լ�������Ϣ
        /// </summary>
        private void clear_message()
        {
            clear_info_message();
            clear_warn_message();
        }

        /// <summary>
        /// ���������Ϣ
        /// </summary>
        private void clear_info_message()
        {
            info_display.Rows.Clear();
        }

        /// <summary>
        /// ���������Ϣ
        /// </summary>
        private void clear_warn_message()
        {
            warn_display.Rows.Clear();
        }
        
        /// <summary>
        /// ����λ��ť���º��Ӧ�Ĳ���
        /// 1. ����ָʾ����˸
        /// 2. ����б���Ϣ
        /// </summary>
        private void reset()
        {
            //��λ����
            current_control?.stop_down_arrow_blink();
            current_control?.stop_up_arrow_blink();
            clear_message();
        }
    }
}