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
        line line_black;
        line line_red;
        line line_blue;
        square square_black;
        square square_red;
        square square_blue;

        public Form1()
        {
            InitializeComponent();
        }

        // First event
        private void Form1_Shown(object sender, EventArgs e)
        {
            // cursor initialize
            cursor = new cursorDLL.cursorControl();
            
            // create line
            line_black = new line();
            line_black.setColor(Color.Black);
            line_red = new line();
            line_red.setColor(Color.Red);
            line_blue = new line();
            line_blue.setColor(Color.Blue);

            // create square
            square_black = new square();
            square_black.setColor(Color.Black);
            square_red = new square();
            square_red.setColor(Color.Red);
            square_blue = new square();
            square_blue.setColor(Color.Blue);

            TopMost = true;
        }

        // Last event
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            cursor.SetDefaultCursor();
        }

        // 
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox tmp = (CheckedListBox)sender;

            switch (tmp.SelectedIndex) {
            case 0: // ∠（ ・∀・）／
                case0(tmp);
                break;
            case 1: // 黒 - (･-･)つ □ 
                case1(tmp);
                break;
            case 2: // 赤 - (･-･)つ □ 
                case2(tmp);
                break;
            case 3: // 青 - (･-･)つ □ 
                case3(tmp);
                break;
            case 4: // 黒 - (*・・)つ --
                case4(tmp);
                break;
            case 5: // 赤 - (*・・)つ --
                case5(tmp);
                break;
            case 6: // 青 - (*・・)つ --
                case6(tmp);
                break;
            }

            // it is no particular meaning.
            this.timer1.Start();
            this.progressBar1.Value = 0;
        }

        // ∠（ ・∀・）／
        private void case0(CheckedListBox set) {
            
            if( false == set.GetItemChecked(0) ) {
                cursor.SetBigCursor();
            }
            else {
                cursor.SetDefaultCursor();
            }
        }

        // (･-･)つ □ 
        private void case1(CheckedListBox set) {
            if (false == set.GetItemChecked(1)) {
                square_black.Show();
            }
            else {
                square_black.Hide();
            }
        }

        // (･-･)つ □ 
        private void case2(CheckedListBox set)
        {
            if (false == set.GetItemChecked(2)) {
                square_red.Show();
            }
            else {
                square_red.Hide();
            }
        }

        // (･-･)つ □ 
        private void case3(CheckedListBox set)
        {
            if (false == set.GetItemChecked(3)) {
                square_blue.Show();
            }
            else {
                square_blue.Hide();
            }
        }

        // (*・・)つ --
        private void case4(CheckedListBox set)
        {
            if (false == set.GetItemChecked(4)) {
                line_black.Show();
            }
            else {
                line_black.Hide();
            }
        }

        // (*・・)つ --
        private void case5(CheckedListBox set)
        {
            if (false == set.GetItemChecked(5)) {
                line_red.Show();
            }
            else {
                line_red.Hide();
            }
        }

        // (*・・)つ --
        private void case6(CheckedListBox set)
        {
            if (false == set.GetItemChecked(6)) {
                line_blue.Show();
            }
            else {
                line_blue.Hide();
            }
        }

        // Progress bar
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.PerformStep();
            if(this.progressBar1.Maximum == this.progressBar1.Value) {
                this.timer1.Stop();
            }
        }

        // ALL OFF
        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0;i < checkedListBox1.Items.Count; i++) {
                checkedListBox1.SetItemChecked(i, true);
                checkedListBox1.SelectedIndex = i;
                checkedListBox1_ItemCheck(checkedListBox1, null);
            }
        }
    }
}
