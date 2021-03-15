using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Stronghold_Finder
{
    public partial class windowList : Form
    {
        Form1 form;

        public windowList(Form1 form1)
        {
            InitializeComponent();
            this.form = form1;
        }

        private void windowList_Load(object sender, EventArgs e)
        {
            Process[] processCollection = Process.GetProcesses();
            List<string> listOfProcesses = (processCollection.Select(item =>
            {
                return (item.MainWindowTitle.ToLower().Contains("minecraft")) ? item.MainWindowTitle : "";
            }).ToList());
            listOfProcesses.RemoveAll(t => t == "");
            listBox1.Items.AddRange(listOfProcesses.ToArray());

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                form.setWindowTitle(listBox1.SelectedItem.ToString(), true);

                this.Close();
            }
        }
    }
}
