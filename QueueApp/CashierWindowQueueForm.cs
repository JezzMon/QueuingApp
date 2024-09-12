using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueueApp
{
    public partial class CashierWindowQueueForm : Form
    {
        private Timer timer;
        public CashierWindowQueueForm()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }

        public void DisplayCashierQueue(IEnumerable<string> cashierList)
        {
            listCashierQueue.Items.Clear();

            foreach(object obj in cashierList)
            {
                listCashierQueue.Items.Add(obj.ToString());
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CashierClass.CashierQueue.Count > 0)
            {
                CashierClass.CashierQueue.Dequeue();
                DisplayCashierQueue(CashierClass.CashierQueue);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DisplayCashierQueue (CashierClass.CashierQueue);
        }
    }
}
