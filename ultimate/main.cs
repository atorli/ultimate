using OPCAutomation;
using Microsoft.Extensions.Configuration;
using NLog;
using System.Text;

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

                    if (clientHandle == OPCAddress.load_id.ClientHandle)
                    {
                        //����ģʽ
                        Object? value = ItemValues.GetValue(i);

                        if (value != null)
                        {
                            Int16 mode_id = (Int16)value;
                            if (modes.ContainsKey(mode_id))
                            {
                                this.main_layout.Controls.Add(modes[mode_id], 0, 0);
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
                    else if (clientHandle == OPCAddress.product_name.ClientHandle)
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
                    else if (clientHandle == OPCAddress.motor_current.ClientHandle)
                    {
                        //����
                    }
                    else if (clientHandle == OPCAddress.time.ClientHandle)
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

            if (info_display.Rows.Count == 500)
            {
                info_display.Rows.Clear();
            }

            object? value = ItemValues.GetValue(1);
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
                    MetaGroupItems.AddItem($"{AddressPrefix}{OPCAddress.load_id.Name}", OPCAddress.load_id.ClientHandle);
                    //��Ʒ����
                    MetaGroupItems.AddItem($"{AddressPrefix}{OPCAddress.product_name.Name}", OPCAddress.product_name.ClientHandle);
                    //��ǰ����
                    MetaGroupItems.AddItem($"{AddressPrefix}{OPCAddress.motor_current.Name}", OPCAddress.motor_current.ClientHandle);
                    //��ǰʱ��
                    MetaGroupItems.AddItem($"{AddressPrefix}{OPCAddress.time.Name}", OPCAddress.time.ClientHandle);

                    //������
                    StepGroup = Groups.Add("step_group");
                    StepGroup.IsSubscribed = true;
                    StepGroup.DataChange += step_group_data_change;
                    StepGroupItems = StepGroup.OPCItems;
                    //״̬��ת����
                    StepGroupItems.AddItem($"{AddressPrefix}{OPCAddress.step.Name}", OPCAddress.step.ClientHandle);
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
        /// ��˸��ʱ�����ؼ���ͷ����˸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void blink_timer_Tick(object sender, EventArgs e)
        {
            //if (this.arrow1.PaintColor == Color.Transparent)
            //{
            //    this.arrow1.PaintColor = Color.Green;
            //}
            //else if (this.arrow1.PaintColor == Color.Green)
            //{
            //    arrow1.PaintColor = Color.Transparent;
            //}
        }
    }
}