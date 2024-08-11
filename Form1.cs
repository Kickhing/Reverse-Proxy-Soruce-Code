using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FireSocks
{
    public class Form1 : Form
    {
        private IContainer components;
        private ToolStripMenuItem startToolStripMenuItem;
        private BPListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ToolStripMenuItem buildProxyToolStripMenuItem;
        private MenuStrip menuStrip1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ColumnHeader columnHeader3;
        private ProxyNotifications _PN;
        private int _TotalProxies;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form1));
            this.startToolStripMenuItem = new ToolStripMenuItem();
            this.menuStrip1 = new MenuStrip();
            this.buildProxyToolStripMenuItem = new ToolStripMenuItem();
            this.statusStrip1 = new StatusStrip();
            this.toolStripStatusLabel1 = new ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new ToolStripStatusLabel();
            this.listView1 = new BPListView();
            this.columnHeader1 = new ColumnHeader();
            this.columnHeader2 = new ColumnHeader();
            this.columnHeader3 = new ColumnHeader();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();

            // startToolStripMenuItem
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new Size(43, 20);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new EventHandler(this.startToolStripMenuItem_Click);

            // menuStrip1
            this.menuStrip1.Items.AddRange(new ToolStripItem[]
            {
                this.startToolStripMenuItem,
                this.buildProxyToolStripMenuItem
            });
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(276, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";

            // buildProxyToolStripMenuItem
            this.buildProxyToolStripMenuItem.Name = "buildProxyToolStripMenuItem";
            this.buildProxyToolStripMenuItem.Size = new Size(79, 20);
            this.buildProxyToolStripMenuItem.Text = "Build Proxy";
            this.buildProxyToolStripMenuItem.Click += new EventHandler(this.buildProxyToolStripMenuItem_Click);

            // statusStrip1
            this.statusStrip1.Items.AddRange(new ToolStripItem[]
            {
                this.toolStripStatusLabel1,
                this.toolStripStatusLabel2
            });
            this.statusStrip1.Location = new Point(0, 284);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new Size(276, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";

            // toolStripStatusLabel1
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new Size(76, 17);
            this.toolStripStatusLabel1.Text = "Total Proxies:";

            // toolStripStatusLabel2
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new Size(13, 17);
            this.toolStripStatusLabel2.Text = "0";

            // listView1
            this.listView1.Columns.AddRange(new ColumnHeader[]
            {
                this.columnHeader1,
                this.columnHeader2,
                this.columnHeader3
            });
            this.listView1.Dock = DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new Point(0, 24);
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new Size(276, 282);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = View.Details;

            // columnHeader1
            this.columnHeader1.Text = "Local Port";
            this.columnHeader1.Width = 65;

            // columnHeader2
            this.columnHeader2.Text = "Address";
            this.columnHeader2.Width = 129;

            // columnHeader3
            this.columnHeader3.Text = "Usage";
            this.columnHeader3.Width = 45;

            // Form1
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(276, 306);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            //this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.Name = nameof(Form1);
            this.Opacity = 0.9;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "FireSocks";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        [DllImport("proxlib.dll", EntryPoint = "proxy_listener_start", CallingConvention = CallingConvention.Cdecl)]
        private static extern int ProxyListenerStart(
            ref ProxyConfig pconfig,
            ref ProxyNotifications pnotf);

        [DllImport("proxlib.dll", EntryPoint = "proxy_listener_stop", CallingConvention = CallingConvention.Cdecl)]
        private static extern void ProxyListenerStop();

        public Form1()
        {
            this.InitializeComponent();
            AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();
            this.Text = $"{assemblyName.Name} v{assemblyName.Version}";
            this._PN.newproxy = new NTFCBNewProxy(this.NewProxy);
            this._PN.deadproxy = new NTFCBDeadProxy(this.DeadProxy);
            this._PN.inuse = new NTFCBInUse(this.InUseProxy);
        }

        private void NewProxy(string addr_ip, int addr_port, int local_port)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new NTFCBNewProxy(this.NewProxy), addr_ip, addr_port, local_port);
            }
            else
            {
                this.listView1.Items.Add(new ListViewItem(local_port.ToString())
                {
                    SubItems =
                    {
                        $"{addr_ip}:{addr_port}",
                        ""
                    }
                });
                this._TotalProxies++;
                this.toolStripStatusLabel2.Text = this._TotalProxies.ToString();
            }
        }

        private void DeadProxy(int local_port)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new NTFCBDeadProxy(this.DeadProxy), local_port);
            }
            else
            {
                foreach (ListViewItem item in this.listView1.Items)
                {
                    if (int.Parse(item.Text) == local_port)
                    {
                        this.listView1.Items.Remove(item);
                        this._TotalProxies--;
                        this.toolStripStatusLabel2.Text = this._TotalProxies.ToString();
                        break;
                    }
                }
            }
        }

        private void InUseProxy(int local_port)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new NTFCBInUse(this.InUseProxy), local_port);
            }
            else
            {
                foreach (ListViewItem item in this.listView1.Items)
                {
                    if (int.Parse(item.Text) == local_port)
                    {
                        this.listView1.MarkUsage(item);
                        break;
                    }
                }
            }
        }

        private void buildProxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form3 form3 = new Form3())
            {
                form3.ShowDialog();
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.startToolStripMenuItem.Text == "Start")
            {
                using (Form2 form2 = new Form2())
                {
                    if (form2.ShowDialog() == DialogResult.OK)
                    {
                        var proxyConfig = new ProxyConfig
                        {
                            pclient_port = form2.ClientPort,
                            pp_start = form2.LocalStartPort,
                            pp_end = form2.LocalEndPort
                        };

                        int result = ProxyListenerStart(ref proxyConfig, ref this._PN);
                        if (result != 0)
                        {
                            MessageBox.Show($"Error {result}");
                        }
                        else
                        {
                            this.startToolStripMenuItem.Text = "Stop";
                        }
                    }
                }
            }
            else
            {
                ProxyListenerStop();
                this.startToolStripMenuItem.Text = "Start";
                this.listView1.Items.Clear();
                this.toolStripStatusLabel2.Text = "0";
            }
        }

        private delegate void NTFCBNewProxy(string addr_ip, int addr_port, int local_port);
        private delegate void NTFCBDeadProxy(int local_port);
        private delegate void NTFCBInUse(int local_port);

        private struct ProxyNotifications
        {
            public NTFCBNewProxy newproxy;
            public NTFCBDeadProxy deadproxy;
            public NTFCBInUse inuse;
        }

        private struct ProxyConfig
        {
            public int pclient_port;
            public int pp_start;
            public int pp_end;
        }
    }
}