using GSA.ToolKits.DawnUtility;
using GSA.ToolKits.FileUtility;
using GSA.ToolKits.FormUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

        //public static byte[] ByteArrayFromHexaString(string hexa)
        //{
        //    int length = hexa.Length;
        //    List<byte> result = new List<byte>();
        //    // Fetch whether there are an odd or even number of chars
        //    bool isOdd = ((length & 1) == 1);
        //    if (isOdd)
        //    {
        //        result.Add(byte.Parse(hexa[0], NumberStyles.HexNumber));
        //    }
        //    string s;
        //    for (int i = (isOdd) ? 1 : 0; i < length; i += 2)
        //    {
        //        s = hexa.Substring(i, 2);
        //        result.Add(byte.Parse(s, NumberStyles.HexNumber));
        //    }
        //    return result.ToArray();
        //}



        private void btnFormBase64_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkIsVarbinary.Checked)
                {
                    var hexString = txtBase64String.Text.Trim().Substring(2);
                    byte[] HexAsBytes = new byte[hexString.Length / 2];
                    for (int index = 0; index < HexAsBytes.Length; index++)
                    {
                        string byteValue = hexString.Substring(index * 2, 2);
                        HexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                    }

                    picFormBase64.Image = ImageHelper.ImageFromArray(HexAsBytes);
                }
                else
                {
                    picFormBase64.Image = ImageHelper.ImageFromBase64(txtBase64String.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowError(ex);
            }

            byte[] StrToByteArray(string str)
            {
                Dictionary<string, byte> hexindex = new Dictionary<string, byte>();
                for (int i = 0; i <= 255; i++)
                    hexindex.Add(i.ToString("X2"), (byte)i);

                List<byte> hexres = new List<byte>();
                for (int i = 0; i < str.Length; i += 2)
                    hexres.Add(hexindex[str.Substring(i, 2)]);

                return hexres.ToArray();
            }
        }

        private void btnToBase64_Click(object sender, EventArgs e)
        {
            try
            {
                var base64String = ImageHelper.ImageToBase64(txtFileSource.Text);
                txtBase64String.Text = base64String;
                lblBase64Length.Text = $"Length: {base64String.Length}";
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

        private void btnClearBase64String_Click(object sender, EventArgs e)
        {
            txtBase64String.Clear();
        }

        private void btnBase64StringLength_Click(object sender, EventArgs e)
        {
            lblBase64Length.Text = $"Length: {txtBase64String.Text.Length}";
        }
    }
}
