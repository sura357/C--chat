using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Socket_test
{
    public partial class Form1 : Form
    {
        //▇▇▇▇▇▇▇▇▇▇▇▇▇▇結構
        struct _Packet
        {
            public string packed;       //組合完成的packet
            public string head;         //標頭
            public string host;         //位址
            public string main_func;    //主指令
            public string suba_func;    //副指令
            public string message;      //訊息
            public string size;         //檔案大小
            public string total_times;  //傳輸次數
            public string sub_name;     //副檔名
            public string file_name;    //檔名
            /// <summary>
            /// 結構初始化
            /// </summary>
            /// <param name="Packed">封包內文(必填)</param>
            public _Packet(string Packed)
            {
                packed = Packed;
                head = "Ninja";
                host = "";
                main_func = "";
                suba_func = "";
                message = "";
                size = "";
                total_times = "";
                sub_name = "";
                file_name = "";
            }
            /// <summary>
            /// 拆解封包
            /// </summary>
            /// <returns>bool</returns>
            public bool Disassemble_Packet()
            {
                int[] dot = new int[6];

                try
                {
                    if (packed == "")
                        return false;
                    dot[0] = packed.IndexOf("#");
                    dot[5] = packed.LastIndexOf("@");

                    //case "0"
                    head = packed.Substring(0, 5);
                    host = packed.Substring(5, dot[0] - 5);
                    main_func = packed.Substring(dot[0] + 1, 1);
                    suba_func = packed.Substring(dot[0] + 2, 1);

                    switch (main_func)
                    {
                        case "0":

                            break;
                        case "1":
                            dot[1] = packed.IndexOf("$");
                            message     = packed.Substring(dot[1] + 1, dot[5] - dot[1] - 1);
                            break;
                        case "2":
                            dot[1] = packed.IndexOf("$");
                            dot[2] = packed.IndexOf("?");
                            dot[3] = packed.IndexOf("!");
                            dot[4] = packed.IndexOf("&");
                            size        = packed.Substring(dot[1] + 1, dot[2] - dot[1] - 1);
                            total_times = packed.Substring(dot[2] + 1, dot[3] - dot[2] - 1);
                            sub_name    = packed.Substring(dot[3] + 1, dot[4] - dot[3] - 1);
                            file_name   = packed.Substring(dot[4] + 1, dot[5] - dot[4] - 1);
                            break;
                        default:
                            return false;
                            
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Disassemble_Packet：" + ex.ToString());
                    return false;
                }
                return true;
            }
            /// <summary>
            /// 組合封包
            /// </summary>
            /// <param name="data">封包陣列[6]</param>
            /// <returns>bool</returns>
            public bool Assemble_Packet(string[] data)
            {
                #region data 詳細資料
                //0 host = ""
                //1 main_func = 0
                //2 suba_func = 0

                //3 message = ""

                //3 size = ""
                //4 total_times = ""
                //5 sub_name = ""
                //6 file_name = ""
                #endregion
                try
                {
                    switch (data[1])
                    {
                        case "0"://連線
                            packed = head + data[0] + "#" + data[1] + data[2] + "$@";
                            break;
                        case "1"://訊息
                            packed = head + data[0] + "#" + data[1] + data[2] + "$" + data[3] + "@";
                            break;
                        case "2"://檔案
                            //Ninja192.168.56.1#20$768?1!txt&1K@
                            //head.IP#size?totaltime!subname&filename@
                            packed = head + data[0] + "#"
                                + data[1] + data[2] + "$"
                                + data[3] + "?" + data[4] + "!"
                                + data[5] + "&" + data[6] + "@";
                            break;
                        default:
                            return false;
                    }
                }
                catch (Exception ex)
                {
                    packed = null;
                    MessageBox.Show("Assemble_Packet：" + ex.ToString());
                    return false;
                }
                return true;
            }
        }
        struct _OtherSide
        {
            public string IP;
            public int ID;
            public bool status;
            public byte[] date;
            public int count;
            public _Packet pack;

            public Socket _Socket;
            public Thread Thread_Read;  //讀取
            public Thread Thread_Write; //寫入
            public Thread Thread_Send;  //傳送
            public _OtherSide(string ip)
            {
                IP = ip;
                ID = -1;
                status = false;
                date = new byte[10240 * 10240];
                count = -1;//收訊息，Count取得長度，date收取資料
                pack = new _Packet("");
                _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Thread_Read = null;
                Thread_Write = null;
                Thread_Send = null;
            }
            public void reSetDate()
            {
                date = new byte[10240 * 10240];
            }
            public void reSetThread()
            {
                Thread_Read = null;
                Thread_Write = null;
                Thread_Send = null;
            }
        }
        //▇▇▇▇▇▇▇▇▇▇▇▇▇▇全域變數
        string IP = "";
        int Port = 8080;//1025
        int Identity = 0;//身分 0空 1S 2C
        List<_OtherSide>Other = new List<_OtherSide>();
        int failTime = 0;
        const int timeout = 2;
        int eachPieceSize = 10240 * 10240;
        bool isSendAll = false;
        const string SENDALL = "Send all.";

        //Server
        Socket serverSocket;
        Thread serverAccept;
        IPAddress IPaddress;
        IPEndPoint IPendpoint;

        //File
        string dirFile = "";
        string dir = "";
        string file = "";

        //▇▇▇▇▇▇▇▇▇▇▇▇▇▇Server
        void Being_Listen()
        {
            GetSelfIp();
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPaddress = IPAddress.Parse(IP);
                IPendpoint = new IPEndPoint(IPaddress, Port);
                serverSocket.Bind(IPendpoint);//繫結完成
                Connect_Status("Server 建置成功，IP：" + IP.ToString());
                Clipboard.SetDataObject(IP);
                Switch_Groupbox(G_Server);
                serverSocket.Listen(0);//處理連結佇列個數 為0則為不限制

                serverAccept = new Thread(S_Accept);
                serverAccept.IsBackground = true;
                serverAccept.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server啟動監聽失敗：" + ex.ToString());
                return;
            }
            
        }
        void S_Accept()//Target_Other
        {
            //_OtherSide Tg_Other = (_OtherSide)Tg;
            while (Identity==1)
            {
                _OtherSide tmp = new _OtherSide("");
                try
                {
                    tmp._Socket = serverSocket.Accept();
                    IPEndPoint remoteIpEndPoint = tmp._Socket.RemoteEndPoint as IPEndPoint;

                    tmp.IP = remoteIpEndPoint.Address.ToString();
                    tmp.ID = remoteIpEndPoint.Port;
                    tmp.status = true;

                    //開啟讀取執行續
                    ParameterizedThreadStart paramStart =
                        new ParameterizedThreadStart(T_Read);
                    tmp.Thread_Read = new Thread(paramStart);
                    tmp.Thread_Read.IsBackground = true;
                    tmp.Thread_Read.Start(tmp);

                    //寄出連線封包
                    _Packet packet = new _Packet("");
                    packet.Assemble_Packet(new string[] { tmp.IP + ":" + tmp.ID, "0", "1" });
                    tmp._Socket.Send(Encoding.UTF8.GetBytes(packet.packed));
                    //MessageBox.Show(packet.packed);

                    Other.Add(tmp);
                    Reflash_Other_List();
                    //C_SChooseSendTo.SelectedIndex = 0;
                }
                catch (Exception)
                {
                    
                }
            }
            serverSocket.Close();
            MessageBox.Show("S_Accept關閉");
        }

        _OtherSide GetSelectSocket(List<_OtherSide> list, string target)
        {
            foreach (var item in list)
            {
                string bindStr = item.IP + "：" + item.ID;
                if (bindStr == target)
                    return item;
            }

            return new _OtherSide("false");
        }
        //▇▇▇▇▇▇▇▇▇▇▇▇▇▇Client
        void Being_Connect(string IP)
        {
            GetSelfIp();
            //因為Client To Server 是1V1，所以先清空再建新的。
            Other.Clear();
            _OtherSide tmp = new _OtherSide(IP);
            tmp.IP = IP;
            tmp.ID = 0;
            tmp.status = true;

            failTime = 0;
            for (int i = 0; i < timeout; i++)
                try
                {
                    tmp._Socket.Connect(new IPEndPoint(IPAddress.Parse(IP), Port));
                    L_CconnectStatus.Text = "Connect";
                }
                catch (Exception)
                {
                    failTime++;
                    
                    continue;
                }

            if (failTime == timeout)
            {
                MessageBox.Show("連線失敗");
                L_CconnectStatus.Text = "UnConnect";
                return;
            }
            
            //開啟讀取執行續
            ParameterizedThreadStart paramStart =
                new ParameterizedThreadStart(T_Read);
            tmp.Thread_Read = new Thread(paramStart);
            tmp.Thread_Read.IsBackground = true;
            tmp.Thread_Read.Start(tmp);

            Other.Add(tmp);
            Switch_Groupbox(G_Client);
        }
        //▇▇▇▇▇▇▇▇▇▇▇▇▇▇共用函式(主)
        /// <summary>
        /// 取得本機IP
        /// </summary>
        void GetSelfIp()
        {
            #region 取得IP
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    IP = ip.ToString();
                    break;
                }
            }
            #endregion
        }
        /// <summary>
        /// 讀取函式，應用於讀取訊息執行續
        /// </summary>
        /// <param name="Tg_Other">_OtherSide</param>
        void T_Read(object Tg)//Target_Other
        {
            _OtherSide Tg_Other = (_OtherSide)Tg;
            while (Tg_Other.status)
            {
                string msg = null;
                Tg_Other.reSetDate();
                try
                {
                    Tg_Other.count = Tg_Other._Socket.Receive(Tg_Other.date);//收訊息，Count取得長度，date收取資料
                }
                catch (Exception)
                {
                    MessageBox.Show("連接斷線");
                    removeOther(Tg_Other);

                    if (Other.Count==0)
                    {
                        Switch_Groupbox(G_chooseSC, false);
                        AllDisConnect();
                    }
                    
                    return;
                }
                
                msg = Encoding.UTF8.GetString(Tg_Other.date, 0, Tg_Other.count);//Encode資訊
                if (!ParseRead(Tg_Other, msg))
                {
                    T_disConnect(Tg_Other);
                    singleDisConnect(Tg_Other);
                    removeOther(Tg_Other);
                    break;
                }
            }
            MessageBox.Show("T_Read關閉");
        }
        bool ParseRead(_OtherSide ts,string msg)
        {
            _Packet pk = new _Packet(msg);
            if (pk.Disassemble_Packet())
            {
                switch (pk.main_func)
                {
                    case "0":
                        // ts._Socket
                        switch (pk.suba_func)
                        {
                            case "0"://斷線
                                //////////////////////////////////////
                                return false;
                                break;
                            case "1"://連線
                                if (Identity == 2)
                                    ts._Socket.Send(Encoding.UTF8.GetBytes(pk.packed));
                                break;
                            case "2"://握手
                                if (Identity == 2)
                                    break;
                                break;
                        }
                        break;
                    case "1":
                        Add_ListText(pk.host+"-訊息：" + pk.message);
                        break;
                    case "2":
                        Add_ListText(pk.host + "-檔案：" + pk.file_name + "." + pk.sub_name);
                        ts.pack = pk;
                        T_Write(ts);

                        break;
                    default:

                        break;
                }
                return true;
            }
            else
            {
                Add_ListText("封包解讀失敗："+ msg);
                return false;
            }
        }

        void removeOther(_OtherSide Tg_Other)
        {
            for (int i = 0; i < Other.Count; i++)
                if ((Other[i].IP + "：" + Other[i].ID) == (Tg_Other.IP + "：" + Tg_Other.ID))
                {
                    Other.RemoveAt(i);
                }
        }

        /// <summary>
        /// 傳送文字函式，應用於按鈕
        /// </summary>
        /// <param name="Tg_Other">_OtherSide</param>
        void T_SendText(object Tg,string txt)//Target_Other
        {
            _OtherSide Tg_Other = (_OtherSide)Tg;
            _Packet packet = new _Packet("");
            packet.Assemble_Packet(new string[] { IP, "1", "1", txt });
            Tg_Other._Socket.Send(Encoding.UTF8.GetBytes(packet.packed));
        }

        void T_disConnect(object Tg)
        {
            _OtherSide Tg_Other = (_OtherSide)Tg;
            _Packet packet = new _Packet("");
            packet.Assemble_Packet(new string[] { IP, "0", "0"});
            try
            {
                Tg_Other._Socket.Send(Encoding.UTF8.GetBytes(packet.packed));
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                return;
            }
            
            
        }

        /// <summary>
        /// 傳送檔案函式，應用於按鈕
        /// </summary>
        /// <param name="Tg_Other">_OtherSide</param>
        void T_SendFile(object Tg)//Target_Other
        {
            List<_OtherSide> Tg_Others = (List<_OtherSide>)Tg;
            foreach (var ot in Tg_Others)
            {
                _Packet packet = new _Packet("");
                string[] fileName = file.Split((".").ToCharArray());
                string size, totalTime;
                //head.IP#size?totaltime!subname&filename@
                using (FileStream fsRead = new FileStream(dirFile, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    size = fsRead.Length.ToString();
                    totalTime = Math.Ceiling((double)(fsRead.Length / eachPieceSize)).ToString();
                    packet.Assemble_Packet(new string[] { ot.IP, "2", "0", size, totalTime, fileName[1], fileName[0] });
                    ot._Socket.Send(Encoding.UTF8.GetBytes(packet.packed));

                    byte[] Filebuffer = new byte[eachPieceSize];//定義緩存空間
                    int readLength = 0;  //定義讀取的長度
                    bool firstRead = true;
                    long sentFileLength = 0;//定義發送的長度
                    while ((readLength = fsRead.Read(Filebuffer, 0, Filebuffer.Length)) > 0)
                    {
                        sentFileLength += readLength;
                        ot._Socket.Send(Filebuffer, 0, readLength, SocketFlags.None);
                    }
                }
            }
        }
        /// <summary>
        /// 寫入函式，應用於寫檔案的執行續
        /// </summary>
        /// <param name="Tg_Other">_OtherSide</param>
        void T_Write(object Tg)//Target_Other
        {
            _OtherSide Tg_Other = (_OtherSide)Tg;
            long fileLength = Convert.ToInt64(Tg_Other.pack.size);//文件長度

            string recStr = Tg_Other.pack.file_name + "." + Tg_Other.pack.sub_name;//文件名
            string spath = "share";//制定存儲路徑
            string savePath = Path.Combine(spath, recStr);//獲取存儲路徑及文件名

            byte[] Filebuffer = new byte[eachPieceSize];//定義緩存空間
            int rec = 0;
            long recFileLength = 0;
            using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write))
            {
                while (recFileLength < fileLength)
                {
                    rec = Tg_Other._Socket.Receive(Filebuffer);
                    fs.Write(Filebuffer, 0, rec);
                    fs.Flush();
                    recFileLength += rec;

                }
                fs.Close();
            }
        }
        /// <summary>
        /// 全關閉
        /// </summary>
        void AllDisConnect()
        {
            if (Identity == 1 && serverAccept != null)
            {
                Identity = 0;

                try
                {
                    serverSocket.Shutdown(SocketShutdown.Both);
                }
                catch (Exception)
                {
                    
                }
                finally
                {
                    serverSocket.Close();
                }

                serverAccept = null;
            }
            


            foreach (_OtherSide ot in Other)
            {
                T_disConnect(ot);

                singleDisConnect(ot);
                
            }
        }
        void singleDisConnect(_OtherSide ot)
        {
            ot.status = false;
            try
            {
                ot._Socket.Shutdown(SocketShutdown.Both);
            }
            catch (Exception)
            {

            }
            finally
            {
                ot._Socket.Close();
            }
        }
        //▇▇▇▇▇▇▇▇▇▇▇▇▇▇共用函式(次)
        /// <summary>
        /// 切換Groupbox
        /// </summary>
        /// <param name="GB">GroupBox</param>
        void Switch_Groupbox(GroupBox GB, bool ShowArea_Visible = true)
        {
            try
            {
                foreach (Control item in this.Controls.OfType<GroupBox>())
                {
                    GroupBox GBitem = (GroupBox)item;
                    GBitem.Invoke(new Action(() =>
                    {
                        GBitem.Visible = false;
                    }));

                }
                GB.Invoke(new Action(() =>
                {
                    GB.Visible = true;
                }));

                G_ShowArea.Invoke(new Action(() =>
                {
                    G_ShowArea.Visible = ShowArea_Visible;
                }));
            }
            catch (Exception)
            {
                MessageBox.Show("Ｎａｎｉ？！");
                return;
            }
            
        }
        void Connect_Status(string str)
        {
            this.Text = str;
        }
        void ChooseFile(ref string dirFile, ref string dir, ref string file)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//該值確定是否可以選擇多個檔案
            dialog.Title = "請選擇資料夾";
            dialog.Filter = "所有檔案(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dirFile = dialog.FileName;
                int dirDot = dirFile.LastIndexOf("\\");
                dir = dirFile.Substring(0, dirDot);
                file = dirFile.Substring(dirDot + 1);
            }
        }
        /// <summary>
        /// 更新傳送對象List
        /// </summary>
        void Reflash_Other_List()
        {
            C_SChooseSendTo.Invoke(new Action(() =>
            {
                C_SChooseSendTo.Items.Clear();
                if (Other.Count != 0)
                {
                    if (Other.Count > 1)
                        C_SChooseSendTo.Items.Add(SENDALL);

                    foreach (var item in Other)
                        C_SChooseSendTo.Items.Add(item.IP + "：" + item.ID);
                }
            }));


        }
        void Clear_ListText()
        {
            List_Text.Invoke(new Action(() =>
            {
                List_Text.Items.Clear();
            }));
        }
        void Add_ListText(string text)
        {
            List_Text.Invoke(new Action(() =>
            {
                List_Text.Items.Add(text);
            }));

        }
        //▇▇▇▇▇▇▇▇▇▇▇▇▇▇元件事件
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //勾選預設選項
            R_SsendMessage.Checked = true;
            R_CsendMessage.Checked = true;
            //切換成初始Groupbox
            Switch_Groupbox(G_chooseSC,false);
            GetSelfIp();
            T_IP.Text = IP;

        }

        private void Test1_Click(object sender, EventArgs e)
        {
            #region 測試封包拆解
            //_Packet packet1 = new _Packet("Ninja127.0.0.1#00@");
            //packet1.Disassemble_Packet();
            //MessageBox.Show("head:" + packet1.head);
            //MessageBox.Show("main_func:" + packet1.main_func);
            //MessageBox.Show("suba_func:" + packet1.suba_func);
            //_Packet packet2 = new _Packet("Ninja127.0.0.1#11$being chilling@");
            //packet2.Disassemble_Packet();
            //MessageBox.Show("head:" + packet2.head);
            //MessageBox.Show("main_func:" + packet2.main_func);
            //MessageBox.Show("suba_func:" + packet2.suba_func);
            //MessageBox.Show("message:" + packet2.message);
            //_Packet packet3 = new _Packet("Ninja127.0.0.1#21$1?2!3&4@");
            //packet3.Disassemble_Packet();
            //MessageBox.Show("head:" + packet3.head);
            //MessageBox.Show("main_func:" + packet3.main_func);
            //MessageBox.Show("suba_func:" + packet3.suba_func);
            //MessageBox.Show("size:" + packet3.size);
            //MessageBox.Show("total_times:" + packet3.total_times);
            //MessageBox.Show("sub_name:" + packet3.sub_name);
            //MessageBox.Show("file_name:" + packet3.file_name);
            #endregion
            #region 測試封包組合
            //_Packet packet4 = new _Packet("");
            //packet4.Assemble_Packet(new string[] { "127.0.0.1", "0", "0", "", "", "", "" });
            //MessageBox.Show(packet4.packed);
            //_Packet packet5 = new _Packet("");
            //packet5.Assemble_Packet(new string[] { "127.0.0.1", "1", "1", "yee", "", "", "" });
            //MessageBox.Show(packet5.packed);
            //_Packet packet6 = new _Packet("");
            //packet6.Assemble_Packet(new string[] { "127.0.0.1", "2", "2", "1", "2", "3", "4" });
            //MessageBox.Show(packet6.packed);
            #endregion
            #region 測試Groupbox切換功能
            //Switch_Groupbox(G_chooseSC);
            //MessageBox.Show("");
            //Switch_Groupbox(G_Server);
            //MessageBox.Show("");
            //Switch_Groupbox(G_Client);
            //MessageBox.Show("");
            //Switch_Groupbox(G_ShowArea);
            #endregion
            #region 測試選擇檔案 路徑
            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Multiselect = true;//該值確定是否可以選擇多個檔案
            //dialog.Title = "請選擇資料夾";
            //dialog.Filter = "所有檔案(*.*)|*.*";
            //if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    dirFile = dialog.FileName;
            //    int dirDot = dirFile.LastIndexOf("\\");
            //    dir = dirFile.Substring(0, dirDot);
            //    file = dirFile.Substring(dirDot + 1);
            //}
            //MessageBox.Show(dirFile);
            //MessageBox.Show(dir);
            //MessageBox.Show(file);
            #endregion
            #region
            //_Packet packet = new _Packet("");
            //packet.Assemble_Packet(new string[] { Other[0].IP + ":" + Other[0].ID, "1", "1","44" });
            //Other[0]._Socket.Send(Encoding.UTF8.GetBytes(packet.packed));
            //MessageBox.Show(packet.packed);
            #endregion
        }

        private void Being_Click(object sender, EventArgs e)
        {
            Button self = sender as Button;
            Other.Clear();
            Other = new List<_OtherSide>();
            if (self.Name == Being_Server.Name)
            {
                //Server
                Identity = 1;
                Being_Listen();
            }
            else
            if (self.Name == Being_Client.Name)
            {
                //Client
                Identity = 2;
                Being_Connect(T_IP.Text);
                
            }
        }

        private void C_SChooseSendTo_MouseClick(object sender, MouseEventArgs e)
        {
            Reflash_Other_List();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //AllDisConnect();
        }

        private void B_Go_Click(object sender, EventArgs e)
        {
            Button self = sender as Button;
            isSendAll = (C_SChooseSendTo.Text == SENDALL);

            if (C_SChooseSendTo.Text == "" && Identity==1)
                return;
            switch (Identity)
            {
                case 1://Server
                    string target = C_SChooseSendTo.Text;
                    if (R_SsendMessage.Checked)//文字
                    {
                        if (isSendAll)
                            foreach (var ot in Other)
                                T_SendText(ot, T_SMessage.Text);
                        else
                            T_SendText(GetSelectSocket(Other, target), T_SMessage.Text);
                    }
                    else
                    {
                        List < _OtherSide > ots = new List < _OtherSide>();
                        if (isSendAll)
                            ots = Other;
                        else
                            ots.Add(GetSelectSocket(Other, target));

                        _OtherSide ot = Other[0];
                        ParameterizedThreadStart paramStart =
                            new ParameterizedThreadStart(T_SendFile);
                        ot.Thread_Send = new Thread(paramStart);
                        ot.Thread_Send.IsBackground = true;
                        ot.Thread_Send.Start(ots);
                    }
                    break;

                case 2://Client
                    if (R_CsendMessage.Checked)//文字
                    {
                        T_SendText(Other[0], T_CMessage.Text);
                    }
                    else
                    {
                        List<_OtherSide> ots = new List<_OtherSide>();
                        _OtherSide ot = Other[0];
                        ots.Add(ot);
                        ParameterizedThreadStart paramStart =
                            new ParameterizedThreadStart(T_SendFile);
                        ot.Thread_Send = new Thread(paramStart);
                        ot.Thread_Send.IsBackground = true;
                        ot.Thread_Send.Start(ots);
                    }
                    break;

                default:
                    break;
            }

        }

        private void B_ChooseFile_Click(object sender, EventArgs e)
        {
            Button self = sender as Button;
            ChooseFile(ref dirFile, ref dir, ref file);
            L_CFileName.Text = file;
            L_SFileName.Text = file;
        }

        private void B_DisConnect_Click(object sender, EventArgs e)
        {
            AllDisConnect();
            Identity = 0;
            Switch_Groupbox(G_chooseSC);
        }


    }
}