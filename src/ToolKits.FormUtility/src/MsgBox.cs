//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：MsgBox.cs
// 项目名称：窗体常用操作工具集
// 创建时间：2015-05-25 09:35:07
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GSA.ToolKits.FormUtility
{
    /// <summary>
    /// 消息提示窗体
    /// </summary>
    public sealed class MsgBox
    {
        /// <summary>
        /// 消息提示窗体类型
        /// </summary>
        private enum DialogType
        {
            /// <summary>
            /// 普通消息窗体
            /// </summary>
            UsualDialog,
            /// <summary>
            /// 错误消息窗体
            /// </summary>
            ErrorDialog,
            /// <summary>
            /// 确认消息窗体
            /// </summary>
            ConfirmDialog,
        }
        /// <summary>
        /// 显示消息提示窗体
        /// </summary>
        /// <param name="text">显示文本</param>
        /// <param name="caption">显示标题</param>
        /// <param name="numSecond">自动关闭秒数，小于零时不自动关闭。</param>
        /// <param name="icon">需要显示的图标</param>
        /// <param name="dialogType">消息提示窗体类型</param>
        /// <returns>显示结果</returns>
        private static DialogResult ShowDialogForm(string text, string caption, int numSecond, Bitmap icon, DialogType dialogType)
        {
            if (string.IsNullOrEmpty(text)) return DialogResult.None;

            var textFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            var msgForm = new Form();
            //msgForm.BackColor = Color.Yellow;
            msgForm.ShowInTaskbar = false;
            msgForm.MaximizeBox = false;
            msgForm.MinimizeBox = false;
            msgForm.ShowIcon = false;
            msgForm.FormBorderStyle = FormBorderStyle.None;
            msgForm.WindowState = FormWindowState.Normal;
            msgForm.StartPosition = FormStartPosition.CenterScreen;
            // 隐性8个像素,所以预设宽度要减8
            msgForm.Width = 382;

            // 
            // 标题栏
            //
            if (!string.IsNullOrEmpty(caption))
            {
                msgForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                msgForm.Text = caption;
            }

            // 
            // 图标
            // 
            var iconHeight = 3;
            if (null != icon)
            {
                var picIcon = new PictureBox();
                picIcon.Name = "picIcon";
                picIcon.Image = icon;
                picIcon.Size = new Size(icon.Width, icon.Height);
                picIcon.Location = new Point(10, iconHeight);
                msgForm.Controls.Add(picIcon);
                iconHeight = icon.Height + 5;
            }

            // 
            // 文本容器（palText） ******************************
            // 
            var palText = new Panel();
            //palText.BackColor = Color.Blue;
            palText.BorderStyle = BorderStyle.None;
            palText.Name = "palText";
            palText.Size = new Size(350, 0);
            palText.Location = new Point(10, iconHeight);
            msgForm.Controls.Add(palText);

            // 
            // 文本对象（lblText）
            // 
            var lblText = new Label();
            lblText.MaximumSize = new Size(350, 0);
            lblText.AutoSize = true;
            lblText.AutoEllipsis = true;
            lblText.Dock = DockStyle.Fill;
            lblText.Font = textFont;
            lblText.Name = "lblText";
            lblText.Text = text;
            lblText.Size = new Size(350, 0);
            lblText.Location = new Point(0, 0);
            palText.Controls.Add(lblText);
            // 将面板高度设置为文本控件高度
            palText.Height = lblText.Height + 10;

            // 
            // 按钮容器（palButton） ******************************
            // 
            var palButton = new Panel();
            //palButton.BackColor = Color.Red;
            palButton.BorderStyle = BorderStyle.None;
            palButton.Name = "palButton";
            palButton.Size = new Size(350, 45);
            palButton.Location = new Point(10, palText.Location.Y + palText.Height);
            msgForm.Controls.Add(palButton);

            // 
            // 文本对象（lblButton）
            // 
            var lblButton = new Label();
            lblButton.AutoSize = true;
            lblButton.Font = textFont;
            lblButton.Name = "lblButton";
            lblButton.Size = new Size(0, 12);
            lblButton.Text = "";
            lblButton.Location = new Point(5, 16);
            palButton.Controls.Add(lblButton);

            // 
            // 确认按钮（btnOK）
            // 
            var btnOK = new Button();
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Name = "btnOK";
            btnOK.Text = "确认";
            btnOK.Tag = null;
            btnOK.Cursor = Cursors.Hand;
            btnOK.Font = textFont;
            btnOK.Size = new Size(65, 35);
            btnOK.Padding = new Padding(0);
            btnOK.Click += new EventHandler((object sender, EventArgs e) =>
            {
                msgForm.Close();
            });
            palButton.Controls.Add(btnOK);

            // 
            // 自动关闭
            // 
            if (numSecond > 0)
            {
                var tmrClose = new Timer();
                tmrClose.Interval = 1000;
                tmrClose.Tick += new EventHandler((object sender, EventArgs e) =>
                {
                    lblButton.Text = string.Format("{0} 秒后自动关闭", numSecond);
                    if (0 == numSecond)
                    {
                        tmrClose.Stop();
                        tmrClose.Dispose();
                        msgForm.Close();
                    }
                    numSecond--;
                });
                tmrClose.Start();
            }

            // 
            // 窗体类型设定
            // 
            switch (dialogType)
            {
                case DialogType.UsualDialog:
                case DialogType.ErrorDialog:
                    {
                        btnOK.Location = new Point(palButton.Width - btnOK.Width - 1, 5);
                    }
                    break;
                case DialogType.ConfirmDialog:
                    {
                        // 
                        // 取消按钮（btnCancel）
                        // 
                        var btnCancel = new Button();
                        btnCancel.DialogResult = DialogResult.Cancel;
                        btnCancel.Name = "btnCancel";
                        btnCancel.Text = "取消";
                        btnCancel.Tag = null;
                        btnCancel.Cursor = Cursors.Hand;
                        btnCancel.Font = textFont;
                        btnCancel.Size = new Size(65, 35);
                        btnCancel.Padding = new Padding(0);
                        btnCancel.Click += new EventHandler((object sender, EventArgs e) =>
                        {
                            msgForm.Close();
                        });
                        btnCancel.Location = new Point(palButton.Width - btnCancel.Width - 1, 5);
                        palButton.Controls.Add(btnCancel);
                        msgForm.CancelButton = btnCancel;

                        btnOK.Location = new Point(btnCancel.Location.X - btnOK.Width - 5, 5);
                    }
                    break;
            }

            // 
            // 窗体参数设定
            // 
            msgForm.Height = iconHeight + palText.Height + palButton.Height + 48;
            msgForm.AcceptButton = btnOK;
            return msgForm.ShowDialog();
        }

        /// <summary>
        /// 显示消息提示窗体
        /// </summary>
        /// <param name="text">显示文本</param>
        /// <param name="caption">显示标题</param>
        /// <param name="numSecond">自动关闭秒数，小于零时不自动关闭；默认2秒。</param>
        /// <param name="icon">需要显示的图标</param>
        /// <returns>显示结果</returns>
        public static DialogResult Show(string text, string caption = "系统提示", int numSecond = 2, Bitmap icon = null)
        {
            return ShowDialogForm(text, caption, numSecond, icon, DialogType.UsualDialog);
        }
        /// <summary>
        /// 显示异常消息提示窗体
        /// </summary>
        /// <param name="ex">异常信息对象</param>
        /// <param name="caption">显示标题</param>
        /// <param name="numSecond">自动关闭秒数，小于零时不自动关闭；默认2秒。</param>
        /// <param name="icon">需要显示的图标</param>
        /// <returns>显示结果</returns>
        public static DialogResult ShowError(Exception ex, string caption = "系统提示", int numSecond = -1, Bitmap icon = null)
        {
            var sb = new StringBuilder();
            sb.Append($"●Message: {ex.Message}");
            sb.Append($"\r\n●StackTrace: {ex.StackTrace}");
            sb.Append($"\r\n●Source: {ex.Source}");
            if (ex.InnerException != null)
            {
                sb.Append($"\r\n●InnerMessage: {ex.Message}");
                sb.Append($"\r\n●InnerStackTrace: {ex.StackTrace}");
                sb.Append($"\r\n●InnerSource: {ex.Source}");
            }
            return ShowDialogForm(sb.ToString(), caption, numSecond, icon, DialogType.ErrorDialog);
        }
        /// <summary>
        /// 显示确认消息提示窗体
        /// </summary>
        /// <param name="text">显示文本</param>
        /// <param name="caption">显示标题</param>
        /// <param name="icon">需要显示的图标</param>
        /// <returns>显示结果</returns>
        public static DialogResult ShowConfirm(string text, string caption = "系统提示", Bitmap icon = null)
        {
            return ShowDialogForm(text, caption, -1, icon, DialogType.ConfirmDialog);
        }
    }
}
