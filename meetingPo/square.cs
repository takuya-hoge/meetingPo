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
    public partial class square : Form
    {
        private bool mouseDown = false;
        private MouseEventArgs mouseDown_last;
        System.Drawing.Drawing2D.GraphicsPath gpath;

        public square()
        {
            InitializeComponent();
        }

        public void setColor(Color set) {
            this.BackColor = set;
        }

        private void square_Load(object sender, EventArgs e)
        {
            gpath = new System.Drawing.Drawing2D.GraphicsPath();

            Visible = true;
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;

            makeHole();
        }

        private void square_MouseMove(object sender, MouseEventArgs e)
        {
            if(false == mouseDown) {
                if ((Size.Width - 5) < e.X) {
                    if(Cursors.SizeWE != this.Cursor) {
                        this.Cursor = Cursors.SizeNWSE;
                    }
                }
                else {
                    if (Cursors.Hand != this.Cursor) {
                        this.Cursor = Cursors.Hand;
                    }
                }
            }else {
                if(Cursors.SizeNWSE == this.Cursor) {

                    // minimum size 10
                    int x = this.Size.Width - (mouseDown_last.X - e.X);
                    int y = this.Size.Height - (mouseDown_last.Y - e.Y);

                    if ( (10 <= x) && (10 <= y) ) {
                        this.Size = new Size(x, y);
                        makeHole();
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

        private void square_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void square_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown_last = e;
            mouseDown = true;
        }

        private void makeHole() {
            SuspendLayout();
            gpath.Reset();
            gpath.AddRectangle(new Rectangle(0, 0, this.Size.Width, this.Size.Height));
            gpath.AddRectangle(new Rectangle(6, 6, Size.Width -12, this.Size.Height -12));
            Region = new Region(gpath);
            ResumeLayout();
        }

    }
}
