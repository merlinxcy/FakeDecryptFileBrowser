using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DecryptFileBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //go
            MyFunctionAction myfunc = new MyFunctionAction();
            myfunc.Run();
            //go
            OpenFileDialog ofd = new OpenFileDialog();
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string strNames = ofd.FileName;
                MessageBox.Show("您当前使用的是泰安金融控股集团有限公司加密文件，"+ strNames + "解密成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                try {
                    byte[] b = System.IO.File.ReadAllBytes(strNames);
                    //System.IO.File.WriteAllBytes(strNames, Enc.Decrypt(b, Config.bytes));
                    byte[] data = Enc.Decrypt(b, Config.bytes);
                    //byte[] data = Enc.Encrypt(b, Config.bytes);
                    System.IO.File.WriteAllBytes(strNames, data);
                }
                catch { }
                
            }

            //Application.Exit();
            
            Application.Exit();
        }
    }
}
