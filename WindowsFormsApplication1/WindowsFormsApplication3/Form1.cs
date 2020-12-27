using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("User32.dll", EntryPoint = "SetParent")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();

            string fexePath = ofd.FileName; // 外部exe位置

            Process p = new Process();
            p.StartInfo.FileName = fexePath;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.Start();

            while (p.MainWindowHandle.ToInt32() == 0)
            {
                System.Threading.Thread.Sleep(100);
            }
            SetParent(p.MainWindowHandle, this.panel1.Handle);
            ShowWindow(p.MainWindowHandle, (int)ProcessWindowStyle.Normal);
        }
    }
}
