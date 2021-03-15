using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stronghold_Finder
{
    public partial class showImage : Form
    {
        public showImage(Bitmap b, int maxWidth, int maxHeight)
        {
            InitializeComponent();
            pictureBox1.Image = b;
            this.MaximumSize = new System.Drawing.Size(maxWidth, maxHeight);
        }

        public void setImagePic(Bitmap b)
        {
            this.pictureBox1.Image = b;
        }
    }
}
