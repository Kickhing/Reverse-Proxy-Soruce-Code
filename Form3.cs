using FireSocks.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FireSocks
{
  public class Form3 : Form
  {
    private IContainer components;
    private GroupBox groupBox1;
    private Button button1;
    private TextBox textBox1;
    private GroupBox groupBox2;
    private Label label2;
    private TextBox textBox2;
    private Label label1;
    private NumericUpDown numericUpDown1;
    private CheckBox checkBox1;
    private Button button2;

    public Form3() => this.InitializeComponent();

    private void button1_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "Executables (*.exe)|*.exe";
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      this.textBox1.Text = saveFileDialog.FileName;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      try
      {
        byte[] proxclient = Resources.proxclient;
        byte[] bytes1 = BitConverter.GetBytes(8090);
        int index1 = 0;
        while (index1 < proxclient.Length && ((int) proxclient[index1] != (int) bytes1[0] || (int) proxclient[index1 + 1] != (int) bytes1[1] || (int) proxclient[index1 + 2] != (int) bytes1[2] || (int) proxclient[index1 + 3] != (int) bytes1[3]))
          ++index1;
        if (index1 == bytes1.Length)
          throw new Exception("Resource file error!");
        int num = index1 - 128;
        int index2 = index1 + 4;
        byte[] bytes2 = Encoding.ASCII.GetBytes(this.textBox2.Text);
        byte[] bytes3 = BitConverter.GetBytes(Decimal.ToInt32(this.numericUpDown1.Value));
        if (bytes2.Length > (int) sbyte.MaxValue)
          throw new Exception("Host too long!");
        for (int index3 = 0; index3 < bytes2.Length; ++index3)
          proxclient[num + index3] = bytes2[index3];
        for (int index4 = 0; index4 < 4; ++index4)
          proxclient[index1 + index4] = bytes3[index4];
        proxclient[index2] = !this.checkBox1.Checked ? (byte) 0 : (byte) 1;
        File.WriteAllBytes(this.textBox1.Text, proxclient);
        throw new Exception("Proxy executable " + this.textBox1.Text + " created!");
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.groupBox1 = new GroupBox();
      this.button1 = new Button();
      this.textBox1 = new TextBox();
      this.groupBox2 = new GroupBox();
      this.label2 = new Label();
      this.textBox2 = new TextBox();
      this.label1 = new Label();
      this.numericUpDown1 = new NumericUpDown();
      this.checkBox1 = new CheckBox();
      this.button2 = new Button();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.numericUpDown1.BeginInit();
      this.SuspendLayout();
      this.groupBox1.Controls.Add((Control) this.button1);
      this.groupBox1.Controls.Add((Control) this.textBox1);
      this.groupBox1.Location = new Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(373, 53);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Output";
      this.button1.Location = new Point(292, 18);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 20);
      this.button1.TabIndex = 1;
      this.button1.Text = "Browse";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.textBox1.Location = new Point(6, 19);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(280, 20);
      this.textBox1.TabIndex = 0;
      this.textBox1.Text = "proxy.exe";
      this.groupBox2.Controls.Add((Control) this.checkBox1);
      this.groupBox2.Controls.Add((Control) this.numericUpDown1);
      this.groupBox2.Controls.Add((Control) this.label2);
      this.groupBox2.Controls.Add((Control) this.textBox2);
      this.groupBox2.Controls.Add((Control) this.label1);
      this.groupBox2.Location = new Point(12, 71);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(373, 77);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Configuration";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(6, 47);
      this.label2.Name = "label2";
      this.label2.Size = new Size(29, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Port:";
      this.textBox2.Location = new Point(140, 19);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(227, 20);
      this.textBox2.TabIndex = 1;
      this.textBox2.Text = "localhost";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(6, 22);
      this.label1.Name = "label1";
      this.label1.Size = new Size(128, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Address (IP or hostname):";
      this.numericUpDown1.Location = new Point(41, 45);
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
      this.numericUpDown1.Size = new Size(65, 20);
      this.numericUpDown1.TabIndex = 3;
      this.numericUpDown1.Value = new Decimal(new int[4]
      {
        8090,
        0,
        0,
        0
      });
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new Point(140, 48);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(94, 17);
      this.checkBox1.TabIndex = 4;
      this.checkBox1.Text = "Show Console";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.button2.Location = new Point(310, 154);
      this.button2.Name = "button2";
      this.button2.Size = new Size(75, 23);
      this.button2.TabIndex = 2;
      this.button2.Text = "Build";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(397, 190);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (Form3);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Build Proxy";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.numericUpDown1.EndInit();
      this.ResumeLayout(false);
    }
  }
}
