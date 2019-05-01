using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace meetingPo
{
    public partial class Form1 : Form
    {
        cursorDLL.cursorControl cursor;

        public Form1()
        {
            InitializeComponent();
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox tmp = (CheckedListBox)sender;

            switch (tmp.SelectedIndex) {
            case 0: // ∠（ ・∀・）／
                case0(tmp);
                break;


            }
        }

        // ∠（ ・∀・）／
        private void case0(CheckedListBox set) {
            
            if( false == set.GetItemChecked(0) ) {
                cursor.SetBigCursor();
            }
            else {
                cursor.SetDefaultCursor();
            }

            // it is no particular meaning.
            this.timer1.Start();
            this.progressBar1.Value = 0;
        }



        private void Form1_Shown(object sender, EventArgs e)
        {
            cursor = new cursorDLL.cursorControl();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            cursor.SetDefaultCursor();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.PerformStep();
            if(this.progressBar1.Maximum == this.progressBar1.Value) {
                this.timer1.Stop();
            }
        }

    }
}
