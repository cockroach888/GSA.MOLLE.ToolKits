using GSA.ToolKits.FileUtility;
using GSA.ToolKits.FormUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSA.ToolKits.DawnApp.FormView
{
    public partial class ImageBase64Form : Form
    {
        public ImageBase64Form()
        {
            InitializeComponent();
        }

        private void btnFormBase64_Click(object sender, EventArgs e)
        {
            try
            {
                picFormBase64.Image = ImageHelper.ImageFromBase64(txtBase64String.Text.Trim());
            }
            catch (Exception ex)
            {
                MsgBox.ShowError(ex);
            }
        }

        private void btnToBase64_Click(object sender, EventArgs e)
        {
            try
            {
                txtBase64String.Text = ImageHelper.ImageToBase64(txtFileSource.Text);
            }
            catch (Exception ex)
            {
                MsgBox.ShowError(ex);
            }
        }

        private void btnFileBrowser_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "请选择需要转换为Base64字符串的图片文件...";
                dialog.DefaultExt = ".png";
                dialog.Filter = "PNG文件(*.png)|*.png|JPG文件(*.jpg)|*.jpg|JPEG文件(*.jpeg)|*.jpeg";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtFileSource.Text = dialog.FileName;
                    picToBase64.Image = Image.FromFile(dialog.FileName);
                }
            }
        }
    }
}
