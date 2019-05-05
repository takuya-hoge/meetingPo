using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace meetingPo
{
    public partial class line : Form
    {
        private bool mouseDown = false;
        private MouseEventArgs mouseDown_last;

        public line()
        {
            InitializeComponent();
        }

        public void setColor(Color set) {
            this.BackColor = set;
        }

        private void line_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
        }

        private void line_MouseMove(object sender, MouseEventArgs e)
        {
            if(false == mouseDown) {
                if ((Size.Width - 5) < e.X) {
                    if(Cursors.SizeWE != this.Cursor) {
                        this.Cursor = Cursors.SizeWE;
                    }
                }
                else {
                    if (Cursors.Hand != this.Cursor) {
                        this.Cursor = Cursors.Hand;
                    }
                }
            }else {
                if(Cursors.SizeWE == this.Cursor) {

                    // minimum size 10
                    int size = this.Size.Width - (mouseDown_last.X - e.X);
                    if (10 <= size) {
                        this.Size = new Size(size, this.Size.Height);
                        // save last
                        mouseDown_last = e;
                    }
                }else if(Cursors.Hand == this.Cursor) {
                    int x = this.Location.X - (mouseDown_last.X - e.X);
                    int y = this.Location.Y - (mouseDown_last.Y - e.Y);
                    this.Location = new Point(x,y);
                }
                else{
                    // This case Occur?
                }


            }

        }

        private void line_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void line_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown_last = e;
            mouseDown = true;
        }
    }
}
