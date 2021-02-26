
namespace GSA.ToolKits.DawnApp.FormView
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
			this.txtMobile = new System.Windows.Forms.TextBox();
			this.cboxPhone = new System.Windows.Forms.ComboBox();
			this.btnEnter = new System.Windows.Forms.Button();
			this.lblResultPhone = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.btnEmail = new System.Windows.Forms.Button();
			this.lblResultEmail = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtString = new System.Windows.Forms.TextBox();
			this.btnString = new System.Windows.Forms.Button();
			this.lblResultString = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cboxString = new System.Windows.Forms.ComboBox();
			this.cboxChinese = new System.Windows.Forms.ComboBox();
			this.txtChinese = new System.Windows.Forms.TextBox();
			this.btnChinese = new System.Windows.Forms.Button();
			this.lblResultChinese = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cboxSqlInjection = new System.Windows.Forms.ComboBox();
			this.txtSqlInjection = new System.Windows.Forms.TextBox();
			this.btnSqlInjection = new System.Windows.Forms.Button();
			this.lblResultSqlInjection = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.cboxIpAdress = new System.Windows.Forms.ComboBox();
			this.txtIpAdress = new System.Windows.Forms.TextBox();
			this.btnIpAdress = new System.Windows.Forms.Button();
			this.lblResultIpAdress = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.cboxNumeral = new System.Windows.Forms.ComboBox();
			this.txtNumeral = new System.Windows.Forms.TextBox();
			this.btnNumeral = new System.Windows.Forms.Button();
			this.lblResultNumeral = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.txtColor = new System.Windows.Forms.TextBox();
			this.btnColor = new System.Windows.Forms.Button();
			this.lblResultColor = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtIDCard = new System.Windows.Forms.TextBox();
			this.btnIDCard = new System.Windows.Forms.Button();
			this.lblResultIDCard = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtUrl = new System.Windows.Forms.TextBox();
			this.btnUrl = new System.Windows.Forms.Button();
			this.lblResultUrl = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.txtPost = new System.Windows.Forms.TextBox();
			this.btnPost = new System.Windows.Forms.Button();
			this.lblResultPost = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtMobile
			// 
			this.txtMobile.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtMobile.Location = new System.Drawing.Point(109, 12);
			this.txtMobile.Name = "txtMobile";
			this.txtMobile.Size = new System.Drawing.Size(223, 29);
			this.txtMobile.TabIndex = 0;
			// 
			// cboxPhone
			// 
			this.cboxPhone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboxPhone.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cboxPhone.FormattingEnabled = true;
			this.cboxPhone.Items.AddRange(new object[] {
			"电话号码",
			"中国移动",
			"中国联通",
			"中国电信"});
			this.cboxPhone.Location = new System.Drawing.Point(338, 12);
			this.cboxPhone.Name = "cboxPhone";
			this.cboxPhone.Size = new System.Drawing.Size(121, 29);
			this.cboxPhone.TabIndex = 1;
			// 
			// btnEnter
			// 
			this.btnEnter.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnEnter.Location = new System.Drawing.Point(465, 12);
			this.btnEnter.Name = "btnEnter";
			this.btnEnter.Size = new System.Drawing.Size(86, 29);
			this.btnEnter.TabIndex = 2;
			this.btnEnter.Text = "检验号码";
			this.btnEnter.UseVisualStyleBackColor = true;
			this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
			// 
			// lblResultPhone
			// 
			this.lblResultPhone.AutoSize = true;
			this.lblResultPhone.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblResultPhone.Location = new System.Drawing.Point(557, 16);
			this.lblResultPhone.Name = "lblResultPhone";
			this.lblResultPhone.Size = new System.Drawing.Size(74, 21);
			this.lblResultPhone.TabIndex = 3;
			this.lblResultPhone.Text = "验证结果";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(13, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 21);
			this.label1.TabIndex = 3;
			this.label1.Text = "电话号码：";
			// 
			// txtEmail
			// 
			this.txtEmail.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtEmail.Location = new System.Drawing.Point(109, 44);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(350, 29);
			this.txtEmail.TabIndex = 0;
			// 
			// btnEmail
			// 
			this.btnEmail.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnEmail.Location = new System.Drawing.Point(465, 44);
			this.btnEmail.Name = "btnEmail";
			this.btnEmail.Size = new System.Drawing.Size(86, 29);
			this.btnEmail.TabIndex = 2;
			this.btnEmail.Text = "检验邮箱";
			this.btnEmail.UseVisualStyleBackColor = true;
			this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
			// 
			// lblResultEmail
			// 
			this.lblResultEmail.AutoSize = true;
			this.lblResultEmail.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblResultEmail.Location = new System.Drawing.Point(557, 48);
			this.lblResultEmail.Name = "lblResultEmail";
			this.lblResultEmail.Size = new System.Drawing.Size(74, 21);
			this.lblResultEmail.TabIndex = 3;
			this.lblResultEmail.Text = "验证结果";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(13, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 21);
			this.label3.TabIndex = 3;
			this.label3.Text = "电子邮箱：";
			// 
			// txtString
			// 
			this.txtString.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtString.Location = new System.Drawing.Point(109, 76);
			this.txtString.Name = "txtString";
			this.txtString.Size = new System.Drawing.Size(223, 29);
			this.txtString.TabIndex = 0;
			// 
			// btnString
			// 
			this.btnString.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnString.Location = new System.Drawing.Point(465, 76);
			this.btnString.Name = "btnString";
			this.btnString.Size = new System.Drawing.Size(86, 29);
			this.btnString.TabIndex = 2;
			this.btnString.Text = "检验字符";
			this.btnString.UseVisualStyleBackColor = true;
			this.btnString.Click += new System.EventHandler(this.btnString_Click);
			// 
			// lblResultString
			// 
			this.lblResultString.AutoSize = true;
			this.lblResultString.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblResultString.Location = new System.Drawing.Point(557, 79);
			this.lblResultString.Name = "lblResultString";
			this.lblResultString.Size = new System.Drawing.Size(74, 21);
			this.lblResultString.TabIndex = 3;
			this.lblResultString.Text = "验证结果";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label4.Location = new System.Drawing.Point(13, 79);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(90, 21);
			this.label4.TabIndex = 3;
			this.label4.Text = "字母字符：";
			// 
			// cboxString
			// 
			this.cboxString.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboxString.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cboxString.FormattingEnabled = true;
			this.cboxString.Items.AddRange(new object[] {
			"用户密码",
			"用户密码2",
			"注册帐号",
			"26个字母",
			"大写字母",
			"小写字母",
			"字母数字",
			"英头数字",
			"字数下线"});
			this.cboxString.Location = new System.Drawing.Point(338, 77);
			this.cboxString.Name = "cboxString";
			this.cboxString.Size = new System.Drawing.Size(121, 29);
			this.cboxString.TabIndex = 1;
			// 
			// cboxChinese
			// 
			this.cboxChinese.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboxChinese.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cboxChinese.FormattingEnabled = true;
			this.cboxChinese.Items.AddRange(new object[] {
			"中文汉字",
			"中字母数",
			"真实姓名",
			"半角转换"});
			this.cboxChinese.Location = new System.Drawing.Point(338, 109);
			this.cboxChinese.Name = "cboxChinese";
			this.cboxChinese.Size = new System.Drawing.Size(121, 29);
			this.cboxChinese.TabIndex = 1;
			// 
			// txtChinese
			// 
			this.txtChinese.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtChinese.Location = new System.Drawing.Point(109, 108);
			this.txtChinese.Name = "txtChinese";
			this.txtChinese.Size = new System.Drawing.Size(223, 29);
			this.txtChinese.TabIndex = 0;
			// 
			// btnChinese
			// 
			this.btnChinese.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnChinese.Location = new System.Drawing.Point(465, 108);
			this.btnChinese.Name = "btnChinese";
			this.btnChinese.Size = new System.Drawing.Size(86, 29);
			this.btnChinese.TabIndex = 2;
			this.btnChinese.Text = "检验中文";
			this.btnChinese.UseVisualStyleBackColor = true;
			this.btnChinese.Click += new System.EventHandler(this.btnChinese_Click);
			// 
			// lblResultChinese
			// 
			this.lblResultChinese.AutoSize = true;
			this.lblResultChinese.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblResultChinese.Location = new System.Drawing.Point(557, 112);
			this.lblResultChinese.Name = "lblResultChinese";
			this.lblResultChinese.Size = new System.Drawing.Size(74, 21);
			this.lblResultChinese.TabIndex = 3;
			this.lblResultChinese.Text = "验证结果";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label5.Location = new System.Drawing.Point(13, 112);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(90, 21);
			this.label5.TabIndex = 3;
			this.label5.Text = "中文汉字：";
			// 
			// cboxSqlInjection
			// 
			this.cboxSqlInjection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboxSqlInjection.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cboxSqlInjection.FormattingEnabled = true;
			this.cboxSqlInjection.Items.AddRange(new object[] {
			"四方法合一",
			"SQL关键字",
			"SQL数据类型",
			"SQL危险命令",
			"SQL危险字符"});
			this.cboxSqlInjection.Location = new System.Drawing.Point(338, 141);
			this.cboxSqlInjection.Name = "cboxSqlInjection";
			this.cboxSqlInjection.Size = new System.Drawing.Size(121, 29);
			this.cboxSqlInjection.TabIndex = 1;
			// 
			// txtSqlInjection
			// 
			this.txtSqlInjection.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtSqlInjection.Location = new System.Drawing.Point(109, 140);
			this.txtSqlInjection.Name = "txtSqlInjection";
			this.txtSqlInjection.Size = new System.Drawing.Size(223, 29);
			this.txtSqlInjection.TabIndex = 0;
			// 
			// btnSqlInjection
			// 
			this.btnSqlInjection.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnSqlInjection.Location = new System.Drawing.Point(465, 140);
			this.btnSqlInjection.Name = "btnSqlInjection";
			this.btnSqlInjection.Size = new System.Drawing.Size(86, 29);
			this.btnSqlInjection.TabIndex = 2;
			this.btnSqlInjection.Text = "检验中文";
			this.btnSqlInjection.UseVisualStyleBackColor = true;
			this.btnSqlInjection.Click += new System.EventHandler(this.btnSqlInjection_Click);
			// 
			// lblResultSqlInjection
			// 
			this.lblResultSqlInjection.AutoSize = true;
			this.lblResultSqlInjection.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblResultSqlInjection.Location = new System.Drawing.Point(557, 144);
			this.lblResultSqlInjection.Name = "lblResultSqlInjection";
			this.lblResultSqlInjection.Size = new System.Drawing.Size(74, 21);
			this.lblResultSqlInjection.TabIndex = 3;
			this.lblResultSqlInjection.Text = "验证结果";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label6.Location = new System.Drawing.Point(13, 144);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 21);
			this.label6.TabIndex = 3;
			this.label6.Text = "SQL注入：";
			// 
			// cboxIpAdress
			// 
			this.cboxIpAdress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboxIpAdress.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cboxIpAdress.FormattingEnabled = true;
			this.cboxIpAdress.Items.AddRange(new object[] {
			"常规IP地址",
			"IPSect"});
			this.cboxIpAdress.Location = new System.Drawing.Point(338, 176);
			this.cboxIpAdress.Name = "cboxIpAdress";
			this.cboxIpAdress.Size = new System.Drawing.Size(121, 29);
			this.cboxIpAdress.TabIndex = 1;
			// 
			// txtIpAdress
			// 
			this.txtIpAdress.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtIpAdress.Location = new System.Drawing.Point(109, 175);
			this.txtIpAdress.Name = "txtIpAdress";
			this.txtIpAdress.Size = new System.Drawing.Size(223, 29);
			this.txtIpAdress.TabIndex = 0;
			// 
			// btnIpAdress
			// 
			this.btnIpAdress.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnIpAdress.Location = new System.Drawing.Point(465, 175);
			this.btnIpAdress.Name = "btnIpAdress";
			this.btnIpAdress.Size = new System.Drawing.Size(86, 29);
			this.btnIpAdress.TabIndex = 2;
			this.btnIpAdress.Text = "检测咦IP";
			this.btnIpAdress.UseVisualStyleBackColor = true;
			this.btnIpAdress.Click += new System.EventHandler(this.btnIpAdress_Click);
			// 
			// lblResultIpAdress
			// 
			this.lblResultIpAdress.AutoSize = true;
			this.lblResultIpAdress.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblResultIpAdress.Location = new System.Drawing.Point(557, 179);
			this.lblResultIpAdress.Name = "lblResultIpAdress";
			this.lblResultIpAdress.Size = new System.Drawing.Size(74, 21);
			this.lblResultIpAdress.TabIndex = 3;
			this.lblResultIpAdress.Text = "验证结果";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label7.Location = new System.Drawing.Point(13, 179);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(89, 21);
			this.label7.TabIndex = 3;
			this.label7.Text = "咦IP地址：";
			// 
			// cboxNumeral
			// 
			this.cboxNumeral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboxNumeral.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cboxNumeral.FormattingEnabled = true;
			this.cboxNumeral.Items.AddRange(new object[] {
			"纯数字",
			"零和非零",
			"正数两位小数",
			"正数一至三位",
			"非零正整数",
			"非零负整数",
			"正浮点数",
			"负浮点数",
			"Int32类型",
			"Double类型",
			"Int32类型逗号"});
			this.cboxNumeral.Location = new System.Drawing.Point(338, 209);
			this.cboxNumeral.Name = "cboxNumeral";
			this.cboxNumeral.Size = new System.Drawing.Size(121, 29);
			this.cboxNumeral.TabIndex = 1;
			// 
			// txtNumeral
			// 
			this.txtNumeral.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtNumeral.Location = new System.Drawing.Point(109, 208);
			this.txtNumeral.Name = "txtNumeral";
			this.txtNumeral.Size = new System.Drawing.Size(223, 29);
			this.txtNumeral.TabIndex = 0;
			// 
			// btnNumeral
			// 
			this.btnNumeral.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnNumeral.Location = new System.Drawing.Point(465, 208);
			this.btnNumeral.Name = "btnNumeral";
			this.btnNumeral.Size = new System.Drawing.Size(86, 29);
			this.btnNumeral.TabIndex = 2;
			this.btnNumeral.Text = "检测数字";
			this.btnNumeral.UseVisualStyleBackColor = true;
			this.btnNumeral.Click += new System.EventHandler(this.btnNumeral_Click);
			// 
			// lblResultNumeral
			// 
			this.lblResultNumeral.AutoSize = true;
			this.lblResultNumeral.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblResultNumeral.Location = new System.Drawing.Point(557, 211);
			this.lblResultNumeral.Name = "lblResultNumeral";
			this.lblResultNumeral.Size = new System.Drawing.Size(74, 21);
			this.lblResultNumeral.TabIndex = 3;
			this.lblResultNumeral.Text = "验证结果";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label8.Location = new System.Drawing.Point(13, 211);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(90, 21);
			this.label8.TabIndex = 3;
			this.label8.Text = "数字校验：";
			// 
			// txtColor
			// 
			this.txtColor.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtColor.Location = new System.Drawing.Point(109, 241);
			this.txtColor.Name = "txtColor";
			this.txtColor.Size = new System.Drawing.Size(350, 29);
			this.txtColor.TabIndex = 0;
			// 
			// btnColor
			// 
			this.btnColor.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnColor.Location = new System.Drawing.Point(465, 241);
			this.btnColor.Name = "btnColor";
			this.btnColor.Size = new System.Drawing.Size(86, 29);
			this.btnColor.TabIndex = 2;
			this.btnColor.Text = "检验颜色";
			this.btnColor.UseVisualStyleBackColor = true;
			this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
			// 
			// lblResultColor
			// 
			this.lblResultColor.AutoSize = true;
			this.lblResultColor.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblResultColor.Location = new System.Drawing.Point(557, 245);
			this.lblResultColor.Name = "lblResultColor";
			this.lblResultColor.Size = new System.Drawing.Size(74, 21);
			this.lblResultColor.TabIndex = 3;
			this.lblResultColor.Text = "验证结果";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label9.Location = new System.Drawing.Point(13, 245);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(90, 21);
			this.label9.TabIndex = 3;
			this.label9.Text = "颜色校验：";
			// 
			// txtIDCard
			// 
			this.txtIDCard.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtIDCard.Location = new System.Drawing.Point(109, 273);
			this.txtIDCard.Name = "txtIDCard";
			this.txtIDCard.Size = new System.Drawing.Size(350, 29);
			this.txtIDCard.TabIndex = 0;
			// 
			// btnIDCard
			// 
			this.btnIDCard.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnIDCard.Location = new System.Drawing.Point(465, 273);
			this.btnIDCard.Name = "btnIDCard";
			this.btnIDCard.Size = new System.Drawing.Size(86, 29);
			this.btnIDCard.TabIndex = 2;
			this.btnIDCard.Text = "检验身份";
			this.btnIDCard.UseVisualStyleBackColor = true;
			this.btnIDCard.Click += new System.EventHandler(this.btnIDCard_Click);
			// 
			// lblResultIDCard
			// 
			this.lblResultIDCard.AutoSize = true;
			this.lblResultIDCard.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblResultIDCard.Location = new System.Drawing.Point(557, 277);
			this.lblResultIDCard.Name = "lblResultIDCard";
			this.lblResultIDCard.Size = new System.Drawing.Size(74, 21);
			this.lblResultIDCard.TabIndex = 3;
			this.lblResultIDCard.Text = "验证结果";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label10.Location = new System.Drawing.Point(13, 277);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(90, 21);
			this.label10.TabIndex = 3;
			this.label10.Text = "身份证号：";
			// 
			// txtUrl
			// 
			this.txtUrl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtUrl.Location = new System.Drawing.Point(109, 306);
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.Size = new System.Drawing.Size(350, 29);
			this.txtUrl.TabIndex = 0;
			// 
			// btnUrl
			// 
			this.btnUrl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnUrl.Location = new System.Drawing.Point(465, 306);
			this.btnUrl.Name = "btnUrl";
			this.btnUrl.Size = new System.Drawing.Size(86, 29);
			this.btnUrl.TabIndex = 2;
			this.btnUrl.Text = "检验链接";
			this.btnUrl.UseVisualStyleBackColor = true;
			this.btnUrl.Click += new System.EventHandler(this.btnUrl_Click);
			// 
			// lblResultUrl
			// 
			this.lblResultUrl.AutoSize = true;
			this.lblResultUrl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblResultUrl.Location = new System.Drawing.Point(557, 309);
			this.lblResultUrl.Name = "lblResultUrl";
			this.lblResultUrl.Size = new System.Drawing.Size(74, 21);
			this.lblResultUrl.TabIndex = 3;
			this.lblResultUrl.Text = "验证结果";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label11.Location = new System.Drawing.Point(13, 309);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(90, 21);
			this.label11.TabIndex = 3;
			this.label11.Text = "链接地址：";
			// 
			// txtPost
			// 
			this.txtPost.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtPost.Location = new System.Drawing.Point(109, 338);
			this.txtPost.Name = "txtPost";
			this.txtPost.Size = new System.Drawing.Size(350, 29);
			this.txtPost.TabIndex = 0;
			// 
			// btnPost
			// 
			this.btnPost.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnPost.Location = new System.Drawing.Point(465, 338);
			this.btnPost.Name = "btnPost";
			this.btnPost.Size = new System.Drawing.Size(86, 29);
			this.btnPost.TabIndex = 2;
			this.btnPost.Text = "检验邮编";
			this.btnPost.UseVisualStyleBackColor = true;
			this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
			// 
			// lblResultPost
			// 
			this.lblResultPost.AutoSize = true;
			this.lblResultPost.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblResultPost.Location = new System.Drawing.Point(557, 342);
			this.lblResultPost.Name = "lblResultPost";
			this.lblResultPost.Size = new System.Drawing.Size(74, 21);
			this.lblResultPost.TabIndex = 3;
			this.lblResultPost.Text = "验证结果";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label12.Location = new System.Drawing.Point(13, 342);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(90, 21);
			this.label12.TabIndex = 3;
			this.label12.Text = "邮政编码：";
			// 
			// TestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(799, 486);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblResultNumeral);
			this.Controls.Add(this.lblResultIpAdress);
			this.Controls.Add(this.lblResultSqlInjection);
			this.Controls.Add(this.lblResultChinese);
			this.Controls.Add(this.lblResultString);
			this.Controls.Add(this.lblResultPost);
			this.Controls.Add(this.lblResultUrl);
			this.Controls.Add(this.lblResultIDCard);
			this.Controls.Add(this.lblResultColor);
			this.Controls.Add(this.lblResultEmail);
			this.Controls.Add(this.btnNumeral);
			this.Controls.Add(this.btnIpAdress);
			this.Controls.Add(this.btnSqlInjection);
			this.Controls.Add(this.lblResultPhone);
			this.Controls.Add(this.btnChinese);
			this.Controls.Add(this.btnString);
			this.Controls.Add(this.btnPost);
			this.Controls.Add(this.btnUrl);
			this.Controls.Add(this.btnIDCard);
			this.Controls.Add(this.btnColor);
			this.Controls.Add(this.btnEmail);
			this.Controls.Add(this.txtNumeral);
			this.Controls.Add(this.txtIpAdress);
			this.Controls.Add(this.txtSqlInjection);
			this.Controls.Add(this.btnEnter);
			this.Controls.Add(this.cboxNumeral);
			this.Controls.Add(this.txtChinese);
			this.Controls.Add(this.cboxIpAdress);
			this.Controls.Add(this.txtString);
			this.Controls.Add(this.cboxSqlInjection);
			this.Controls.Add(this.txtPost);
			this.Controls.Add(this.txtUrl);
			this.Controls.Add(this.txtIDCard);
			this.Controls.Add(this.txtColor);
			this.Controls.Add(this.txtEmail);
			this.Controls.Add(this.cboxChinese);
			this.Controls.Add(this.cboxString);
			this.Controls.Add(this.cboxPhone);
			this.Controls.Add(this.txtMobile);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TestForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "数据校验验证窗体";		
			this.ResumeLayout(false);
			this.PerformLayout();
		}

        #endregion

        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.ComboBox cboxPhone;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Label lblResultPhone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Label lblResultEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtString;
        private System.Windows.Forms.Button btnString;
        private System.Windows.Forms.Label lblResultString;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboxString;
        private System.Windows.Forms.ComboBox cboxChinese;
        private System.Windows.Forms.TextBox txtChinese;
        private System.Windows.Forms.Button btnChinese;
        private System.Windows.Forms.Label lblResultChinese;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboxSqlInjection;
        private System.Windows.Forms.TextBox txtSqlInjection;
        private System.Windows.Forms.Button btnSqlInjection;
        private System.Windows.Forms.Label lblResultSqlInjection;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboxIpAdress;
        private System.Windows.Forms.TextBox txtIpAdress;
        private System.Windows.Forms.Button btnIpAdress;
        private System.Windows.Forms.Label lblResultIpAdress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboxNumeral;
        private System.Windows.Forms.TextBox txtNumeral;
        private System.Windows.Forms.Button btnNumeral;
        private System.Windows.Forms.Label lblResultNumeral;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label lblResultColor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIDCard;
        private System.Windows.Forms.Button btnIDCard;
        private System.Windows.Forms.Label lblResultIDCard;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnUrl;
        private System.Windows.Forms.Label lblResultUrl;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPost;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Label lblResultPost;
        private System.Windows.Forms.Label label12;
    }
}