//==================================================================== 
//*****                    晨曦小竹常用工具集                    *****
//====================================================================
//**   Copyright © DawnXZ.com 2014 -- QQ：6808240 -- 请保留此注释   **
//====================================================================
// 文件名称：CheckCodeHelper.cs
// 项目名称：常用方法实用工具集
// 创建时间：2014年2月25日16时1分
// 创建人员：宋杰军
// 负 责 人：宋杰军
// 参与人员：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace DawnXZ.DawnUtility {
	/// <summary>
	/// 验证码操作辅助类
	/// <para>1、MVC调用方法：File(DawnXZ.Utilities.CheckCodeHelper.CreateToByte(6, 1, out checkCode), @"image/jpeg");</para>
	/// <para>2、ASPX调用方法：</para>
	/// <para>　　Response.ClearContent();</para>
	/// <para>　　Response.ContentType = "image/Jpeg";</para>
	/// <para>　　Response.BinaryWrite(DawnXZ.Utilities.CheckCodeHelper.CreateToByte(6, 1, out checkCode));</para>
	/// <para>   ASPX页面同时增加如下方法：</para>
	/// <para>　　///设置页面不被缓存</para>
	/// <para>　　private void SetPageNoCache()</para>
	/// <para>　　{</para>
	/// <para>　　　　Response.Buffer = true;</para>
	/// <para>　　　　Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);</para>
	/// <para>　　　　Response.Expires = 0;</para>
	/// <para>　　　　Response.CacheControl = "no-cache";</para>
	/// <para>　　　　Response.AppendHeader("Pragma", "No-Cache");</para>
	/// <para>　　}</para>
	/// <para>页面刷新方式：</para>
	/// <para>JavaScript函数：  function refCode(){document.getElementById('Captcha').src='Captcha.aspx?r='+Math.random();}</para>
	/// <para>JQuery形式：  $('#Captcha').bind('click',function(){var url='/Auth/Captcha/';url+=(new Date()).getTime();this.src=url;});</para>
	/// </summary>
	public static class CheckCodeHelper {

		#region 获得指定数量的中文

		/// <summary>
		/// 获得指定数量的中文
		/// <para>默认4位</para>
		/// <para>由指定中文字符串随机取数</para>
		/// </summary>
		/// <param name="chsNum">要生成的中文数量</param>
		/// <returns>中文字符串</returns>
		public static string GetChs(int chsNum = 4) {
			string checkCode = String.Empty;
			string chinese = "居的一是在不了有和人这中大为上个国我以要他时来用们生到作地于出就分对成会可主发年动同工也能下过子说产种面而方后多定行学法所民得经十三之进着等部度家电力里如水化高自二理起小物现实加量都两体制机当使点从业本去把性好应开它合还因由其些然前外天政四日那社义事平形相全表间样与关各重新线内数正心反你明看原又么利比或但质气第向道命此变条只没结解问意建月公无系军很情者最立代想已通并提直题党程展五果料象员革位入常文总次品式活设及管特件长求老头基资边流路级少图山统接知较将组见计别她手角期根论运农指几九区强放决西被干做必战先回则任取据处队南给色光门即保治北造百规热领七海口东导器压志世金增争济阶油思术极交受联什认六共权收证改清己美再采转更单风切打白教速花带安场身车例真务具万每目至达走积示议声报斗完类八离华名确才科张信马节话米整空元况今集温传土许步群广石记需段研界拉林律叫且究观越织装影算低持音众书布复容儿须际商非验连断深难近矿千周委素技备半办青省列习响约支般史感劳便团往酸历市克何除消构府称太准精值号率族维划选标写存候毛亲快效斯院查江型眼王按格养易置派层片始却专状育厂京识适属圆包火住调满县局照参红细引听该铁价严";
			Random random = new Random();
			for (int i = 0; i < chsNum; i++) {
				checkCode += chinese.Substring(random.Next(0, chinese.Length), 1);
			}
			return checkCode;
		}
		/// <summary>
		/// 获得指定数量的中文
		/// <para>默认4位</para>
		/// <para>通过区位码计算</para>
		/// </summary>
		/// <param name="chsNum">要生成的中文数量</param>
		/// <returns>中文字符串</returns>
		public static string GetChsAt(int chsNum = 4) {
			string checkCode = String.Empty;
			Encoding gb = Encoding.GetEncoding("gb2312");
			object[] bytes = GetChsOfZone(chsNum);
			for (int i = 0; i < chsNum; i++) {
				checkCode += gb.GetString(Convert.ChangeType(bytes[i], typeof(byte[])) as byte[]);
			}
			return checkCode;
		}
		/// <summary>
		/// 获得指定数量的中文
		/// <para>默认4位</para>
		/// <remarks>
		/// <para>每循环一次产生一个含两个元素的十六进制字节数组，并将其放入数组中</para>
		/// <para>每个汉字有四个区位码组成</para>
		/// <para>区位码第1位和区位码第2位作为字节数组第一个元素 </para>
		/// <para>区位码第3位和区位码第4位作为字节数组第二个元素</para>
		/// </remarks>
		/// </summary>
		/// <param name="chsNum">要生成的中文数量</param>
		/// <returns>中文字符数组对象</returns>
		private static object[] GetChsOfZone(int chsNum = 4) {
			string[] rBase = new String[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
			Random rnd = new Random();
			object[] bytes = new object[chsNum];
			for (int i = 0; i < chsNum; i++) {
				//区位码第1位 
				int r1 = rnd.Next(11, 14);
				string str_r1 = rBase[r1].Trim();
				//区位码第2位 
				rnd = new Random(r1 * unchecked((int)DateTime.Now.Ticks) + i);//更换随机数发生器的
				//种子避免产生重复值 
				int r2;
				if (r1 == 13) {
					r2 = rnd.Next(0, 7);
				}
				else {
					r2 = rnd.Next(0, 16);
				}
				string str_r2 = rBase[r2].Trim();
				//区位码第3位 
				rnd = new Random(r2 * unchecked((int)DateTime.Now.Ticks) + i);
				int r3 = rnd.Next(10, 16);
				string str_r3 = rBase[r3].Trim();
				//区位码第4位 
				rnd = new Random(r3 * unchecked((int)DateTime.Now.Ticks) + i);
				int r4;
				if (r3 == 10) {
					r4 = rnd.Next(1, 16);
				}
				else if (r3 == 15) {
					r4 = rnd.Next(0, 15);
				}
				else {
					r4 = rnd.Next(0, 16);
				}
				string str_r4 = rBase[r4].Trim();
				//定义两个字节变量存储产生的随机汉字区位码 
				byte byte1 = Convert.ToByte(str_r1 + str_r2, 16);
				byte byte2 = Convert.ToByte(str_r3 + str_r4, 16);
				//将两个字节变量存储在字节数组中 
				byte[] str_r = new byte[] { byte1, byte2 };
				//将产生的一个汉字的字节数组放入object数组中 
				bytes.SetValue(str_r, i);
			}
			return bytes;
		}

		#endregion

		#region 获得指定数量的英文及数字组合

		/// <summary>
		/// 获得指定数量的英文组合
		/// <para>默认4位</para>
		/// </summary>
		/// <param name="engNum">要生成的英文数量</param>
		/// <returns>英文字符串</returns>
		public static string GetEng(int engNum = 4) {
			int rand;
			char code;
			string checkCode = String.Empty;
			//生成一定长度的验证码
			System.Random random = new Random();
			for (int i = 0; i < engNum; i++) {
				rand = random.Next();
				code = (char)('A' + (char)(rand % 26));
				checkCode += code.ToString();
			}
			return checkCode;
		}
		/// <summary>
		/// 获得指定数量的数字组合
		/// <para>默认6位</para>
		/// </summary>
		/// <param name="numLength">要生成的数字数量</param>
		/// <returns>数字字符串</returns>
		public static string GetNumber(int numLength = 6) {
			int rand;
			char code;
			string checkCode = String.Empty;
			//生成一定长度的验证码
			System.Random random = new Random();
			for (int i = 0; i < numLength; i++) {
				rand = random.Next();
				code = (char)('0' + (char)(rand % 10));
				checkCode += code.ToString();
			}
			return checkCode;
		}
		/// <summary>
		/// 获得指定数量的英文及数字组合
		/// <para>默认4位</para>
		/// </summary>
		/// <param name="engNum">要生成的英文及数字数量</param>
		/// <returns>英文及数字字符串</returns>
		public static string GetEngAndNum(int engNum = 4) {
			int rand;
			char code;
			string checkCode = String.Empty;
			//生成一定长度的验证码
			System.Random random = new Random();
			for (int i = 0; i < engNum; i++) {
				rand = random.Next();
				if (rand % 3 == 0) {
					code = (char)('A' + (char)(rand % 26));
				}
				else {
					code = (char)('0' + (char)(rand % 10));
				}
				checkCode += code.ToString();
			}
			return checkCode;
		}

		#endregion

		#region 生成图片底纹式验证码

		/// <summary>
		/// 生成图片底纹式验证码
		/// <para>默认非中文</para>
		/// </summary>
		/// <param name="checkCode">验证码字符串</param>
		/// <param name="isChs">是否为中文</param>
		/// <param name="codeFlag">验证码生成方式：true 通常型 / false 完美型</param>
		/// <returns>验证码字节数组对象</returns>
		public static byte[] CreateToByte(string checkCode, bool isChs = false, bool codeFlag = false) {
			if (codeFlag) {
				return CreateToStreamAt(checkCode, isChs).ToArray();
			}
			else {
				return CreateToStream(checkCode, isChs).ToArray();
			}
		}
		/// <summary>
		/// 生成图片底纹式验证码
		/// </summary>
		/// <param name="checkCode">验证码字符串</param>
		/// <param name="codeNum">验证码数量</param>
		/// <param name="codeType">验证码编码类型</param>
		/// <param name="codeFlag">验证码生成方式：true 通常型 / false 完美型</param>
		/// <returns>验证码字节数组对象</returns>
		public static byte[] CreateToByte(out string checkCode, int codeNum = 4, CodeType codeType = CodeType.GetEngAndNum, bool codeFlag = false) {
			string result = string.Empty;
			bool isChs = false;
			BuindCode(codeNum, codeType, out result, out isChs);
			checkCode = result;
			if (codeFlag) {
				return CreateToStreamAt(result, isChs).ToArray();
			}
			else {
				return CreateToStream(result, isChs).ToArray();
			}
		}
		/// <summary>
		/// 生成图片底纹式验证码
		/// <para>默认非中文</para>
		/// </summary>
		/// <param name="checkCode">验证码字符串</param>
		/// <param name="isChs">是否为中文</param>
		/// <param name="codeFlag">验证码生成方式：true 通常型 / false 完美型</param>
		/// <returns>验证码图片对象</returns>
		public static Image CreateToImage(string checkCode, bool isChs = false, bool codeFlag = false) {
			if (codeFlag) {
				return Image.FromStream(CreateToStreamAt(checkCode, isChs));
			}
			else {
				return Image.FromStream(CreateToStream(checkCode, isChs));
			}
		}
		/// <summary>
		/// 生成图片底纹式验证码
		/// </summary>
		/// <param name="checkCode">验证码字符串</param>
		/// <param name="codeNum">验证码数量</param>
		/// <param name="codeType">验证码编码类型</param>
		/// <param name="codeFlag">验证码生成方式：true 通常型 / false 完美型</param>
		/// <returns>验证码图片对象</returns>
		public static Image CreateToImage(out string checkCode, int codeNum = 4, CodeType codeType = CodeType.GetEngAndNum, bool codeFlag = false) {
			string result = string.Empty;
			bool isChs = false;
			BuindCode(codeNum, codeType, out result, out isChs);
			checkCode = result;
			if (codeFlag) {
				return Image.FromStream(CreateToStreamAt(result, isChs));
			}
			else {
				return Image.FromStream(CreateToStream(result, isChs));
			}
		}
		/// <summary>
		/// 生成验证码字符串
		/// </summary>
		/// <param name="codeNum">验证码个数</param>
		/// <param name="codeType">验证码类型</param>
		/// <param name="checkCode">验证码结果</param>
		/// <param name="chsFlag">验证码中文标记</param>
		private static void BuindCode(int codeNum, CodeType codeType, out string checkCode, out bool chsFlag) {
			chsFlag = false;
			switch (codeType) {
				case CodeType.GetEng:
					checkCode = GetEng(codeNum);
					break;
				case CodeType.GetNumber:
					checkCode = GetNumber(codeNum);
					break;
				case CodeType.GetEngAndNum:
					checkCode = GetEngAndNum(codeNum);
					break;
				case CodeType.GetChs:
					checkCode = GetChs(codeNum);
					chsFlag = true;
					break;
				case CodeType.GetChsAt:
					checkCode = GetChsAt(codeNum);
					chsFlag = true;
					break;
				default:
					checkCode = GetEngAndNum(codeNum);
					break;
			}
		}
		/// <summary>
		/// 验证码类型枚举器
		/// </summary>
		public enum CodeType {
			/// <summary>
			/// 英文
			/// </summary>
			GetEng,
			/// <summary>
			/// 数字
			/// </summary>
			GetNumber,
			/// <summary>
			/// 英文及数字
			/// </summary>
			GetEngAndNum,
			/// <summary>
			/// 中文定义字符串
			/// </summary>
			GetChs,
			/// <summary>
			/// 中文区位码
			/// </summary>
			GetChsAt
		}

		#endregion

		#region 产生波形滤镜效果

		/// <summary>
		/// PI值
		/// <para>单倍</para>
		/// </summary>
		private const double PI1 = 3.1415926535897932384626433832795;
		/// <summary>
		/// PI值
		/// <para>双倍</para>
		/// </summary>
		private const double PI2 = 6.283185307179586476925286766559;
		/// <summary>
		/// 正弦曲线Wave扭曲图片
		/// </summary>
		/// <param name="srcBmp">源图像</param>
		/// <param name="bXDir">true 高度 / false 宽度，如果扭曲则选择为</param>
		/// <param name="dMultValue">波形的幅度倍数，越大扭曲的程度越高，一般为3</param>
		/// <param name="dPhase">波形的起始相位，取值区间[0-2*PI)</param>
		/// <param name="flgPI">PI值[true 单倍/false 双倍]</param>
		/// <returns>正弦曲线Wave扭曲图片结果</returns>
		private static Bitmap WaveformToImage(Bitmap srcBmp, bool bXDir, double dMultValue, double dPhase, bool flgPI) {
			Bitmap destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);
			// 将位图背景填充为白色 
			Graphics graph = Graphics.FromImage(destBmp);
			graph.FillRectangle(new SolidBrush(Color.White), 0, 0, destBmp.Width, destBmp.Height);
			graph.Dispose();
			double dBaseAxisLen = bXDir ? (double)destBmp.Height : (double)destBmp.Width;
			for (int i = 0; i < destBmp.Width; i++) {
				for (int j = 0; j < destBmp.Height; j++) {
					double dx = 0;
					if (flgPI) {
						dx = bXDir ? (PI1 * (double)j) / dBaseAxisLen : (PI1 * (double)i) / dBaseAxisLen;
					}
					else {
						dx = bXDir ? (PI2 * (double)j) / dBaseAxisLen : (PI2 * (double)i) / dBaseAxisLen;
					}
					dx += dPhase;
					double dy = Math.Sin(dx);
					//取得当前点的颜色 
					int nOldX = 0, nOldY = 0;
					nOldX = bXDir ? i + (int)(dy * dMultValue) : i;
					nOldY = bXDir ? j : j + (int)(dy * dMultValue);
					Color color = srcBmp.GetPixel(i, j);
					if (nOldX >= 0 && nOldX < destBmp.Width && nOldY >= 0 && nOldY < destBmp.Height) {
						destBmp.SetPixel(nOldX, nOldY, color);
					}
				}
			}
			return destBmp;
		}

		#endregion

		#region 生成验证码内存流

		/// <summary>
		/// 生成验证码内存流
		/// <para>高度固定28</para>
		/// </summary>
		/// <param name="checkCode">验证码字符串</param>
		/// <param name="isChs">是否为中文</param>
		/// <returns>验证码内存流</returns>
		private static MemoryStream CreateToStream(string checkCode, bool isChs) {
			if (string.IsNullOrEmpty(checkCode)) return null;
			int randAngle = 45; //随机转动角度范围
			int imgWidth = Convert.ToInt32(checkCode.Length * 23);
			Bitmap image = new Bitmap(imgWidth, 28); //创建图片背景
			Graphics graph = Graphics.FromImage(image);
			try {
				graph.Clear(Color.White); //清除画面，填充背景
				graph.DrawRectangle(new Pen(Color.Gainsboro), 0, 0, image.Width - 1, image.Height - 1); //画图片的边框线
				graph.SmoothingMode = SmoothingMode.AntiAlias; //图片的模式
				//生成随机生成器 
				Random random = new Random();
				//画图片的背景噪音线
				Pen noise = new Pen(Color.LightGray);
				for (int i = 0; i < 12; i++) {
					int x1 = random.Next(image.Width);
					int x2 = random.Next(image.Width);
					int y1 = random.Next(image.Height);
					int y2 = random.Next(image.Height);
					graph.DrawLine(noise, x1, y1, x2, y2);
				}
				//验证码旋转，防止机器识别
				char[] chars = checkCode.ToCharArray();//拆散字符串成单字符数组
				//文字居中
				StringFormat format = new StringFormat(StringFormatFlags.NoClip);
				format.Alignment = StringAlignment.Center;
				format.LineAlignment = StringAlignment.Center;
				//定义颜色
				Color[] colorStyle = { Color.Blue, Color.DarkRed, Color.DarkBlue, Color.MediumBlue };
				//定义字体
				string[] fontStyle = null;
				if (isChs) {
					fontStyle = new string[] { "Microsoft YaHei", "字体", "新字体" };
				}
				else {
					fontStyle = new string[] { "Arial", "Comic Sans MS", "Microsoft Sans Serif", "Courier", "Georgia", "Microsoft YaHei" };
				}
				Font font = null;
				LinearGradientBrush brush = null;
				for (int i = 0; i < chars.Length; i++) {
					if (isChs) {
						font = new Font(fontStyle[random.Next(fontStyle.Length)], 14);
					}
					else {
						font = new Font(fontStyle[random.Next(fontStyle.Length)], 14, FontStyle.Bold);
					}
					brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), colorStyle[random.Next(colorStyle.Length)], colorStyle[random.Next(colorStyle.Length)], 1.2F, true);
					Point dot = new Point(16, 16);
					//测试X坐标显示间距的
					graph.DrawString(dot.X.ToString(), font, new SolidBrush(Color.Black), 10, 150);
					float angle = random.Next(-randAngle, randAngle);//转动的度数
					graph.TranslateTransform(dot.X, dot.Y);//移动光标到指定位置
					graph.RotateTransform(angle);
					graph.DrawString(chars[i].ToString(), font, brush, 1, 1, format);
					graph.RotateTransform(-angle);//转回去
					graph.TranslateTransform(2, -dot.Y);//移动光标到指定位置
				}
				//画图片的前景噪音点
				for (int i = 0; i < 100; i++) {
					int x = random.Next(image.Width);
					int y = random.Next(image.Height);
					image.SetPixel(x, y, Color.FromArgb(random.Next()));
				}
				//产生波形滤镜效果
				image = WaveformToImage(image, true, 3, 2, true);
				//生成图片
				MemoryStream ms = new MemoryStream();
				image.Save(ms, ImageFormat.Jpeg);
				return ms;
			}
			finally {
				graph.Dispose();
				image.Dispose();
			}
		}
		/// <summary>
		/// 生成验证码内存流
		/// </summary>
		/// <param name="checkCode">验证码字符串</param>
		/// <param name="isChs">是否为中文</param>
		/// <returns>验证码内存流</returns>
		public static MemoryStream CreateToStreamAt(string checkCode, bool isChs) {
			if (string.IsNullOrEmpty(checkCode)) return null;
			int _length = checkCode.Length;
			int _fontSize = 40; //字体大小
			int _padding = 2; //空间间距
			if (isChs) _padding = 14;
			int _width = _fontSize + _padding; //目标宽度
			int _imageWidth = Convert.ToInt32(_length * _width) + 4 + _padding * 2; //图像宽度
			int _imageHeight = _fontSize * 2 + _padding; //图像高度
			Color _backgroundColor = Color.White; //背景颜色
			Color _chaosColor = Color.LightGray; //燥点的颜色
			//自定义随机颜色数组
			Color[] _colors = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
			string[] _fontChs = { "Microsoft YaHei", "字体", "新字体" }; //中文字体
			string[] _fontEng = { "Arial", "Comic Sans MS", "Microsoft Sans Serif", "Courier", "Georgia", "Microsoft YaHei" }; //英文字体
			Bitmap image = new Bitmap(_imageWidth, _imageHeight);
			Graphics graph = Graphics.FromImage(image);
			try {
				graph.Clear(_backgroundColor);
				Random rand = new Random();
				//给背景添加随机生成的燥点
				Pen pen = new Pen(_chaosColor, 0);
				int c = _length * 10;
				for (int i = 0; i < c; i++) {
					int x = rand.Next(image.Width);
					int y = rand.Next(image.Height);
					graph.DrawRectangle(pen, x, y, 1, 1);
				}
				int left = 0, top = 0, top1 = 1, top2 = 1;
				int n1 = (_imageHeight - _fontSize - _padding * 2);
				int n2 = n1 / 4;
				top1 = n2;
				top2 = n2 * 2;
				Font f;
				Brush b;
				int cindex, findex;
				//随机字体和颜色的验证码字符  
				for (int i = 0; i < _length; i++) {
					cindex = rand.Next(_colors.Length - 1);
					if (isChs) {
						findex = rand.Next(_fontEng.Length - 1);
						f = new Font(_fontEng[findex], _fontSize);
					}
					else {
						findex = rand.Next(_fontChs.Length - 1);
						f = new Font(_fontChs[findex], _fontSize, System.Drawing.FontStyle.Bold);
					}
					b = new SolidBrush(_colors[cindex]);
					if (i % 2 == 1) {
						top = top2;
					}
					else {
						top = top1;
					}
					left = i * _width;
					graph.DrawString(checkCode.Substring(i, 1), f, b, left, top);
				}
				//画一个边框 边框颜色为Color.Gainsboro  
				graph.DrawRectangle(new Pen(Color.Gainsboro, 0), 0, 0, image.Width - 1, image.Height - 1);
				graph.Dispose();
				//产生波形
				image = WaveformToImage(image, true, 8, 4, false);
				//生成图片
				MemoryStream ms = new MemoryStream();
				image.Save(ms, ImageFormat.Jpeg);
				return ms;
			}
			finally {
				graph.Dispose();
				image.Dispose();
			}
		}

		#endregion

	}
}
