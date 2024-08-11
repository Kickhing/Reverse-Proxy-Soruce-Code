using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FireSocks
{
  public class Form2 : Form
  {
    private IContainer components;
    private GroupBox groupBox1;
    private NumericUpDown numericUpDown3;
    private NumericUpDown numericUpDown2;
    private NumericUpDown numericUpDown1;
    private Label label3;
    private Label label2;
    private Label label1;
    private TextBox textBox1;
    private Label label4;
    private Button button1;
    public int ClientPort;
    public int LocalStartPort;
    public int LocalEndPort;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.groupBox1 = new GroupBox();
      this.textBox1 = new TextBox();
      this.label4 = new Label();
      this.numericUpDown3 = new NumericUpDown();
      this.numericUpDown2 = new NumericUpDown();
      this.numericUpDown1 = new NumericUpDown();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.button1 = new Button();
      this.groupBox1.SuspendLayout();
      this.numericUpDown3.BeginInit();
      this.numericUpDown2.BeginInit();
      this.numericUpDown1.BeginInit();
      this.SuspendLayout();
      this.groupBox1.Controls.Add((Control) this.textBox1);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.numericUpDown3);
      this.groupBox1.Controls.Add((Control) this.numericUpDown2);
      this.groupBox1.Controls.Add((Control) this.numericUpDown1);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Location = new Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(206, 130);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Configuration";
      this.textBox1.Enabled = false;
      this.textBox1.Location = new Point(138, 97);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(56, 20);
      this.textBox1.TabIndex = 7;
      this.textBox1.Text = "0";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(42, 100);
      this.label4.Name = "label4";
      this.label4.Size = new Size(90, 13);
      this.label4.TabIndex = 6;
      this.label4.Text = "Maximum proxies:";
      this.numericUpDown3.Location = new Point(138, 71);
      this.numericUpDown3.Maximum = new Decimal(new int[4]
      {
        (int) ushort.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown3.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown3.Name = "numericUpDown3";
      this.numericUpDown3.Size = new Size(56, 20);
      this.numericUpDown3.TabIndex = 5;
      this.numericUpDown3.Value = new Decimal(new int[4]
      {
        6524,
        0,
        0,
        0
      });
      this.numericUpDown3.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
      this.numericUpDown2.Location = new Point(138, 45);
      this.numericUpDown2.Maximum = new Decimal(new int[4]
      {
        (int) ushort.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown2.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown2.Name = "numericUpDown2";
      this.numericUpDown2.Size = new Size(56, 20);
      this.numericUpDown2.TabIndex = 4;
      this.numericUpDown2.Value = new Decimal(new int[4]
      {
        5500,
        0,
        0,
        0
      });
      this.numericUpDown2.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
      this.numericUpDown1.Location = new Point(138, 19);
      this.numericUpDown1.Maximum = new Decimal(new int[4]
      {
        (int) ushort.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown1.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new Size(56, 20);
      this.numericUpDown1.TabIndex = 3;
      this.numericUpDown1.Value = new Decimal(new int[4]
      {
        8090,
        0,
        0,
        0
      });
      this.label3.AutoSize = true;
      this.label3.Location = new Point(113, 73);
      this.label3.Name = "label3";
      this.label3.Size = new Size(19, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "to:";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(6, 47);
      this.label2.Name = "label2";
      this.label2.Size = new Size(126, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Local listening ports from:";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(52, 21);
      this.label1.Name = "label1";
      this.label1.Size = new Size(80, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Port for proxies:";
      this.button1.Location = new Point(143, 148);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "OK";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(228, 185);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.groupBox1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (Form2);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Start Listening";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.numericUpDown3.EndInit();
      this.numericUpDown2.EndInit();
      this.numericUpDown1.EndInit();
      this.ResumeLayout(false);
    }

    public Form2()
    {
      this.InitializeComponent();
      this.numericUpDown_ValueChanged((object) null, (EventArgs) null);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.LocalStartPort = Decimal.ToInt32(this.numericUpDown2.Value);
      this.LocalEndPort = Decimal.ToInt32(this.numericUpDown3.Value);
      this.ClientPort = Decimal.ToInt32(this.numericUpDown1.Value);
      if (this.LocalEndPort < this.LocalStartPort)
      {
        int num1 = (int) MessageBox.Show("Ending port cannot be less than starting port!");
      }
      else if (this.ClientPort <= this.LocalEndPort && this.ClientPort >= this.LocalStartPort)
      {
        int num2 = (int) MessageBox.Show("Proxy port cannot be inside local port range!");
      }
      else
      {
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }

    private void numericUpDown_ValueChanged(object sender, EventArgs e)
    {
      int int32 = Decimal.ToInt32(this.numericUpDown2.Value);
      this.textBox1.Text = Math.Abs(Decimal.ToInt32(this.numericUpDown3.Value) - int32 + 1).ToString();
    }
  }
}
