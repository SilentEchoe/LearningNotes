using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool isUpdate = true;

        public delegate void Entrust(string str);//委托   
        private delegate void SetPos(int ipos, string vinfo);//代理
        private void Form1_Load(object sender, EventArgs e)
        {
            //把方法赋值给委托

            // 创建更新方法的线程
            Entrust callback = new Entrust(CallBack); 
            Thread fThread = new Thread(update);

            // 创建计时的线程
            Entrust mainFun = new Entrust(CallBack); 
            Thread mThread = new Thread(runTime);

            fThread.Start(callback);//将委托传递到子线程中    
            mThread.Start(mainFun);




        }

        // 执行更新程序
        private void update(object obj)
        {
          
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);              
            }

            //强转为委托      
            Entrust callback = obj as Entrust;

            // 线程结束时执行方法
            CallBack("1");
        }


        // 执行计数
        private void runTime(object obj)
        {
            int sum = 0;
            while (true)
            {
                sum++;
                if (isUpdate) { 
                    Thread.Sleep(1000);
                    SetTextMesssage(sum, "\r\n");  }              
                else                
                    break;                
            }
            Entrust mainFun = obj as Entrust;//强转为委托
            CallBack("2");
        }


        // 子线程结束后，执行的方法 
        // 结束时修改更新状态，通知线程2结束
        private void CallBack(string str)
        {
            isUpdate = false;
            MessageBox.Show("线程结束"+str);

        }

        private void SetTextMesssage(int ipos, string vinfo)
        {

            if (this.InvokeRequired)
            {
                SetPos setpos = new SetPos(SetTextMesssage);
                this.Invoke(setpos, new object[] { ipos, vinfo });
            }
            else
            {
              
                 this.label1.Text = ipos.ToString();
            }

        }

      
    }
}
