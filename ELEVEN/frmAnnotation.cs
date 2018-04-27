using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELEVEN
{
    public partial class frmAnnotation : KryptonForm
    {
        public frmAnnotation()
        {
            InitializeComponent();
        }
        private string annotationText { get; set; }
        public string AnnotationText
        {
            get { return annotationText; }
            set { annotationText = value; }
        }
        private void BtnAnnotation_Click(object sender, EventArgs e)
        {
            if(this.txtAnnotation.Text!=string.Empty)
            {
                AnnotationText = txtAnnotation.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
