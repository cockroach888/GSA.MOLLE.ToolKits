//==================================================================== 
//*****                    晨曦小竹常用工具集                    *****
//====================================================================
//**   Copyright © DawnXZ.com 2014 -- QQ：6808240 -- 请保留此注释   **
//====================================================================
// 文件名称：TypeHelper.cs
// 项目名称：常用方法实用工具集
// 创建时间：2014年2月25日11时46分
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
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace DawnXZ.DawnUtility {
	/// <summary>
	/// 数据类型转换操作辅助类
	/// </summary>
	public static class TypeHelper {

		#region Boolean

		/// <summary>
		/// 将对象转换为 Boolean 类型
		/// <para>1 | true, 0 | false</para>
		/// </summary>
		/// <param name="objValue">要转换的值</param>
		/// <param name="defValue">缺省值</param>
		/// <returns>转换后的 Boolean 类型结果</returns>
		public static bool TypeToBoolean(object objValue, bool defValue) {
			if (objValue != null) {
				var _val = TypeToInt32(objValue, -1);
				if (-1 != _val) {
					return _val == 1 ? true : defValue;
				}
				else {
					var _tmpVal = objValue.ToString();
					var _len = _tmpVal.Length;
					if (_len == 4 || _len == 5) {
						var _result = defValue;
						bool.TryParse(_tmpVal, out _result);
						return _result;
					}
				}
			}
			return defValue;
		}

		#endregion

		#region TinyInt

		/// <summary>
		/// 将对象转换为 TinyInt 类型
		/// 默认返回 0
		/// 范围：0 — 255
		/// </summary>
		/// <param name="objValue">要转换的值</param>
		/// <returns>转换后的 TinyInt 类型结果</returns>
		public static byte TypeToTinyInt(object objValue) {
			return TypeToTinyInt(objValue, 0);
		}
		/// <summary>
		/// 将对象转换为 TinyInt 类型
		/// 范围：0 — 255
		/// </summary>
		/// <param name="objValue">要转换的值</param>
		/// <param name="defValue">缺省值</param>
		/// <returns>转换后的 TinyInt 类型结果</returns>
		public static byte TypeToTinyInt(object objValue, byte defValue) {
			if (objValue != null) return TypeToTinyInt(objValue.ToString(), defValue);
			return defValue;
		}
		/// <summary>
		/// 将对象转换为 TinyInt 类型
		/// 默认返回 0
		/// 范围：0 — 255
		/// </summary>
		/// <param name="strValue">要转换的值</param>
		/// <returns>转换后的 TinyInt 类型结果</returns>
		public static byte TypeToTinyInt(string strValue) {
			return TypeToTinyInt(strValue, 0);
		}
		/// <summary>
		/// 将对象转换为 TinyInt 类型
		/// 范围：0 — 255
		/// </summary>
		/// <param name="strValue">要转换的值</param>
		/// <param name="defValue">缺省值</param>
		/// <returns>转换后的 TinyInt 类型结果</returns>
		public static byte TypeToTinyInt(string strValue, byte defValue) {
			if (string.IsNullOrEmpty(strValue) || strValue.Trim().Length > 3 || !NumIsByteTinyint(strValue)) return defValue;
			byte rv;
			if (Byte.TryParse(strValue, out rv)) return rv;
			//return Convert.ToTinyInt(TypeToFloat(strValue, defValue));
			try {
				return Convert.ToByte(strValue);
			}
			catch {
				return defValue;
			}
		}
		/// <summary>
		/// 判断对象是否为0-255数据
		/// </summary>
		/// <param name="objVerify">需要验证的对象</param>
		/// <returns>True/False，是/否</returns>
		internal static bool NumIsByteTinyint(object objVerify) {
			if (objVerify == null) return false;
			return Regex.IsMatch(objVerify.ToString(), @"((^[0-9]{1,2})|(^[1][0-9]{1,2})|(^[2][0-5][0-5]))$");
		}

		#endregion

		#region Int16

		/// <summary>
		/// 将对象转换为 Int16 类型
		/// 默认返回 0
		/// 范围：-32,768 — 32,767
		/// </summary>
		/// <param name="objValue">要转换的值</param>
		/// <returns>转换后的 Int16 类型结果</returns>
		public static short TypeToInt16(object objValue) {
			return TypeToInt16(objValue, 0);
		}
		/// <summary>
		/// 将对象转换为 Int16 类型
		/// 范围：-32,768 — 32,767
		/// </summary>
		/// <param name="objValue">要转换的值</param>
		/// <param name="defValue">缺省值</param>
		/// <returns>转换后的 Int16 类型结果</returns>
		public static short TypeToInt16(object objValue, short defValue) {
			if (objValue != null) return TypeToInt16(objValue.ToString(), defValue);
			return defValue;
		}
		/// <summary>
		/// 将对象转换为 Int16 类型
		/// 默认返回 0
		/// 范围：-32,768 — 32,767
		/// </summary>
		/// <param name="strValue">要转换的值</param>
		/// <returns>转换后的 Int16 类型结果</returns>
		public static short TypeToInt16(string strValue) {
			return TypeToInt16(strValue, 0);
		}
		/// <summary>
		/// 将对象转换为 Int16 类型
		/// 范围：-32,768 — 32,767
		/// </summary>
		/// <param name="strValue">要转换的值</param>
		/// <param name="defValue">缺省值</param>
		/// <returns>转换后的 Int16 类型结果</returns>
		public static short TypeToInt16(string strValue, short defValue) {
			if (string.IsNullOrEmpty(strValue) || strValue.Trim().Length > 6 || !Regex.IsMatch(strValue.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$")) return defValue;
			short rv;
			if (Int16.TryParse(strValue, out rv)) return rv;
			//return Convert.ToInt16(TypeToFloat(strValue, defValue));
			try {
				return Convert.ToInt16(strValue);
			}
			catch {
				return defValue;
			}
		}

		#endregion

		#region Int32

		/// <summary>
		/// 将对象转换为 Int32 类型
		/// 默认返回 0
		/// 范围：-2,147,483,648 — 2,147,483,647
		/// </summary>
		/// <param name="objValue">要转换的值</param>
		/// <returns>转换后的 Int32 类型结果</returns>
		public static int TypeToInt32(object objValue) {
			return TypeToInt32(objValue, 0);
		}
		/// <summary>
		/// 将对象转换为 Int32 类型
		/// 范围：-2,147,483,648 — 2,147,483,647
		/// </summary>
		/// <param name="objValue">要转换的值</param>
		/// <param name="defValue">缺省值</param>
		/// <returns>转换后的 Int32 类型结果</returns>
		public static int TypeToInt32(object objValue, int defValue) {
			if (objValue != null) return TypeToInt32(objValue.ToString(), defValue);
			return defValue;
		}
		/// <summary>
		/// 将对象转换为 Int32 类型
		/// 默认返回 0
		/// 范围：-2,147,483,648 — 2,147,483,647
		/// </summary>
		/// <param name="strValue">要转换的值</param>
		/// <returns>转换后的 Int32 类型结果</returns>
		public static int TypeToInt32(string strValue) {
			return TypeToInt32(strValue, 0);
		}
		/// <summary>
		/// 将对象转换为 Int32 类型
		/// 范围：-2,147,483,648 — 2,147,483,647
		/// </summary>
		/// <param name="strValue">要转换的值</param>
		/// <param name="defValue">缺省值</param>
		/// <returns>转换后的 Int32 类型结果</returns>
		public static int TypeToInt32(string strValue, int defValue) {
			if (string.IsNullOrEmpty(strValue) || strValue.Trim().Length > 11 || !Regex.IsMatch(strValue.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$")) return defValue;
			int rv;
			if (Int32.TryParse(strValue, out rv)) return rv;
			return Convert.ToInt32(TypeToFloat(strValue, defValue));
		}

		#endregion

		#region Int64

		/// <summary>
		/// 将对象转换为 Int64 类型
		/// 默认返回 0
		/// 范围：-9,223,372,036,854,775,808 — 9,223,372,036,854,775,807
		/// </summary>
		/// <param name="objValue">要转换的值</param>
		/// <returns>转换后的 Int64 类型结果</returns>
		public static long TypeToInt64(object objValue) {
			return TypeToInt64(objValue, 0);
		}
		/// <summary>
		/// 将对象转换为 Int64 类型
		/// 范围：-9,223,372,036,854,775,808 — 9,223,372,036,854,775,807
		/// </summary>
		/// <param name="objValue">要转换的值</param>
		/// <param name="defValue">缺省值</param>
		/// <returns>转换后的 Int64 类型结果</returns>
		public static long TypeToInt64(object objValue, long defValue) {
			if (objValue != null) return TypeToInt64(objValue.ToString(), defValue);
			return defValue;
		}
		/// <summary>
		/// 将对象转换为 Int64 类型
		/// 默认返回 0
		/// 范围：-9,223,372,036,854,775,808 — 9,223,372,036,854,775,807
		/// </summary>
		/// <param name="strValue">要转换的值</param>
		/// <returns>转换后的 Int64 类型结果</returns>
		public static long TypeToInt64(string strValue) {
			return TypeToInt64(strValue, 0);
		}
		/// <summary>
		/// 将对象转换为 Int64 类型
		/// 范围：-9,223,372,036,854,775,808 — 9,223,372,036,854,775,807
		/// </summary>
		/// <param name="strValue">要转换的值</param>
		/// <param name="defValue">缺省值</param>
		/// <returns>转换后的 Int64 类型结果</returns>
		public static long TypeToInt64(string strValue, long defValue) {
			if (string.IsNullOrEmpty(strValue) || strValue.Trim().Length > 20 || !Regex.IsMatch(strValue.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$")) return defValue;
			long rv;
			if (Int64.TryParse(strValue, out rv)) return rv;
			//return Convert.ToInt64(TypeToFloat(strValue, defValue));
			try {
				return Convert.ToInt64(strValue);
			}
			catch {
				return defValue;
			}
		}

		#endregion

		#region Float

		/// <summary>
		/// 将对象转换为 Float 类型
		/// 范围：- 1.79E+308 to -2.23E-308, 0 and 2.23E-308 to 1.79E+308
		/// </summary>
		/// <param name="objValue">要转换的值</param>
		/// <param name="defValue">缺省值</param>
		/// <returns>转换后的 Float 类型结果</returns>
		public static float TypeToFloat(object objValue, float defValue) {
			if ((objValue == null)) return defValue;
			return TypeToFloat(objValue.ToString(), defValue);
		}
		/// <summary>
		/// 将对象转换为 Float 类型
		/// 默认返回 0
		/// 范围：- 1.79E+308 to -2.23E-308, 0 and 2.23E-308 to 1.79E+308
		/// </summary>
		/// <param name="objValue">要转换的值</param>
		/// <returns>转换后的 Float 类型结果</returns>
		public static float TypeToFloat(object objValue) {
			return TypeToFloat(objValue.ToString(), 0);
		}
		/// <summary>
		/// 将对象转换为 Float 类型
		/// 默认返回 0
		/// 范围：- 1.79E+308 to -2.23E-308, 0 and 2.23E-308 to 1.79E+308
		/// </summary>
		/// <param name="strValue">要转换的值</param>
		/// <returns>转换后的 Float 类型结果</returns>
		public static float TypeToFloat(string strValue) {
			if ((strValue == null)) return 0;
			return TypeToFloat(strValue, 0);
		}
		/// <summary>
		/// 将对象转换为 Float 类型
		/// 范围：- 1.79E+308 to -2.23E-308, 0 and 2.23E-308 to 1.79E+308
		/// </summary>
		/// <param name="strValue">要转换的值</param>
		/// <param name="defValue">缺省值</param>
		/// <returns>转换后的 Float 类型结果</returns>
		public static float TypeToFloat(string strValue, float defValue) {
			if ((strValue == null) || (strValue.Length < 1)) return defValue;
			float result = defValue;
			if (strValue != null) {
				bool IsFloat = Regex.IsMatch(strValue, @"^([-]|[0-9])[0-9]*(\.\w*)?$");
				if (IsFloat) float.TryParse(strValue, out result);
			}
			return result;
		}

		#endregion

		#region Double

		/// <summary>
		/// 将对象转换为 Double 类型
		/// <para>范围：±5.0 × 10−324 到 ±1.7 × 10308</para>
		/// <para>15 到 16 位</para>
		/// </summary>
		/// <param name="objValue">要转换的值</param>
		/// <param name="defValue">缺省值</param>
		/// <returns>转换后的 Double 类型结果</returns>
		public static double TypeToDouble(object objValue, double defValue) {
			if ((objValue == null)) return defValue;
			return TypeToDouble(objValue.ToString(), defValue);
		}
		/// <summary>
		/// 将对象转换为 Double 类型
		/// 默认返回 0
		/// <para>范围：±5.0 × 10−324 到 ±1.7 × 10308</para>
		/// <para>15 到 16 位</para>
		/// </summary>
		/// <param name="objValue">要转换的值</param>
		/// <returns>转换后的 Double 类型结果</returns>
		public static double TypeToDouble(object objValue) {
			return TypeToDouble(objValue.ToString(), 0);
		}
		/// <summary>
		/// 将对象转换为 Double 类型
		/// 默认返回 0
		/// <para>范围：±5.0 × 10−324 到 ±1.7 × 10308</para>
		/// <para>15 到 16 位</para>
		/// </summary>
		/// <param name="strValue">要转换的值</param>
		/// <returns>转换后的 Double 类型结果</returns>
		public static double TypeToDouble(string strValue) {
			if ((strValue == null)) return 0;
			return TypeToDouble(strValue, 0);
		}
		/// <summary>
		/// 将对象转换为 Double 类型
		/// <para>范围：±5.0 × 10−324 到 ±1.7 × 10308</para>
		/// <para>15 到 16 位</para>
		/// </summary>
		/// <param name="strValue">要转换的值</param>
		/// <param name="defValue">缺省值</param>
		/// <returns>转换后的 Double 类型结果</returns>
		public static double TypeToDouble(string strValue, double defValue) {
			if ((strValue == null) || (strValue.Length < 1)) return defValue;
			double result = defValue;
			if (strValue != null) {
				bool IsDouble = Regex.IsMatch(strValue, @"^([-]|[0-9])[0-9]*(\.\w*)?$");
				if (IsDouble) double.TryParse(strValue, out result);
			}
			return result;
		}

		#endregion

		#region Decimal

		/// <summary>
		/// 将对象转换为 Decimal 类型
		/// </summary>
		/// <param name="objValue">要转换的值</param>
		/// <param name="defValue">缺省值</param>
		/// <returns>转换后的 Decimal 类型结果</returns>
		public static decimal TypeToDecimal(object objValue, decimal defValue) {
			if ((objValue == null)) return defValue;
			return TypeToDecimal(objValue.ToString(), defValue);
		}
		/// <summary>
		/// 将对象转换为 Decimal 类型
		/// <remarks>
		/// 默认返回 0
		/// </remarks>
		/// </summary>
		/// <param name="objValue">要转换的值</param>
		/// <returns>转换后的 Decimal 类型结果</returns>
		public static decimal TypeToDecimal(object objValue) {
			return TypeToDecimal(objValue.ToString(), 0);
		}
		/// <summary>
		/// 将对象转换为 Decimal 类型
		/// <remarks>
		/// 默认返回 0
		/// </remarks>
		/// </summary>
		/// <param name="strValue">要转换的值</param>
		/// <returns>转换后的 Decimal 类型结果</returns>
		public static decimal TypeToDecimal(string strValue) {
			if ((strValue == null)) return 0;
			return TypeToDecimal(strValue, 0);
		}
		/// <summary>
		/// 将对象转换为 Decimal 类型
		/// </summary>
		/// <param name="strValue">要转换的值</param>
		/// <param name="defValue">缺省值</param>
		/// <returns>转换后的 Decimal 类型结果</returns>
		public static decimal TypeToDecimal(string strValue, decimal defValue) {
			if ((strValue == null) || (strValue.Length > 10)) return defValue;
			decimal result = defValue;
			if (strValue != null) {
				bool IsDecimal = Regex.IsMatch(strValue, @"^([-]|[0-9])[0-9]*(\.\w*)?$");
				if (IsDecimal) decimal.TryParse(strValue, out result);
			}
			return result;
		}

		#endregion

		#region DateTime

		/// <summary>
		/// 将对象转换为 DateTime 类型
		/// </summary>
		/// <param name="year">年份</param>
		/// <returns></returns>
		public static DateTime StrToDateTime(int year) {
			return new DateTime(year, 1, 1);
		}
		/// <summary>
		/// 将对象转换为 DateTime 类型
		/// </summary>
		/// <param name="year">年份</param>
		/// <param name="month">月份</param>
		/// <returns></returns>
		public static DateTime StrToDateTime(int year, int month) {
			return new DateTime(year, month, 1);
		}
		/// <summary>
		/// 将对象转换为 DateTime 类型
		/// </summary>
		/// <param name="year">年份</param>
		/// <param name="month">月份</param>
		/// <param name="day">日期</param>
		/// <returns></returns>
		public static DateTime StrToDateTime(int year, int month, int day) {
			return new DateTime(year, month, day);
		}
		/// <summary>
		/// 将对象转换为 DateTime 类型
		/// </summary>
		/// <param name="strValue">要转换的值</param>
		/// <param name="defValue">缺省值</param>
		/// <returns>转换后的 DateTime 类型结果</returns>
		public static DateTime StrToDateTime(string strValue, DateTime defValue) {
			if (!string.IsNullOrEmpty(strValue)) {
				DateTime dateTime;
				if (DateTime.TryParse(strValue, out dateTime)) return dateTime;
			}
			return defValue;
		}
		/// <summary>
		/// 将对象转换为 DateTime 类型
		/// 默认返回 当前时间
		/// </summary>
		/// <param name="strValue">要转换的值</param>
		/// <returns>转换后的 DateTime 类型结果</returns>
		public static DateTime StrToDateTime(string strValue) {
			return StrToDateTime(strValue, DateTime.Now);
		}
		/// <summary>
		/// 将对象转换为 DateTime 类型
		/// 默认返回 当前时间
		/// </summary>
		/// <param name="objValue">要转换的值</param>
		/// <returns>转换后的 DateTime 类型结果</returns>
		public static DateTime ObjectToDateTime(object objValue) {
			return StrToDateTime(objValue.ToString());
		}
		/// <summary>
		/// 将对象转换为 DateTime 类型
		/// </summary>
		/// <param name="objValue">要转换的值</param>
		/// <param name="defValue">缺省值</param>
		/// <returns>转换后的 DateTime 类型结果</returns>
		public static DateTime ObjectToDateTime(object objValue, DateTime defValue) {
			return StrToDateTime(objValue.ToString(), defValue);
		}

		#endregion

		#region Color

		/// <summary>
		/// 将字符串转换为Color
		/// </summary>
		/// <param name="strColor">颜色字符串</param>
		/// <returns></returns>
		public static Color ToColor(string strColor) {
			int red, green, blue = 0;
			char[] rgb;
			strColor = strColor.TrimStart('#');
			strColor = Regex.Replace(strColor.ToLower(), "[g-zG-Z]", "");
			switch (strColor.Length) {
				case 3:
					rgb = strColor.ToCharArray();
					red = Convert.ToInt32(rgb[0].ToString() + rgb[0].ToString(), 16);
					green = Convert.ToInt32(rgb[1].ToString() + rgb[1].ToString(), 16);
					blue = Convert.ToInt32(rgb[2].ToString() + rgb[2].ToString(), 16);
					return Color.FromArgb(red, green, blue);
				case 6:
					rgb = strColor.ToCharArray();
					red = Convert.ToInt32(rgb[0].ToString() + rgb[1].ToString(), 16);
					green = Convert.ToInt32(rgb[2].ToString() + rgb[3].ToString(), 16);
					blue = Convert.ToInt32(rgb[4].ToString() + rgb[5].ToString(), 16);
					return Color.FromArgb(red, green, blue);
				default:
					return Color.FromName(strColor);
			}
		}

		#endregion

		#region 特殊数值转换

		/// <summary>
		/// 将long型数值转换为Int32类型
		/// </summary>
		/// <param name="objNum"></param>
		/// <returns></returns>
		public static int SafeInt32(object objNum) {
			if (objNum == null) return 0;
			string strNum = objNum.ToString();
			if (NumIsNumeric(strNum)) {
				if (strNum.ToString().Length > 9) {
					if (strNum.StartsWith("-")) {
						return int.MinValue;
					}
					else {
						return int.MaxValue;
					}
				}
				return Int32.Parse(strNum);
			}
			else {
				return 0;
			}
		}
		/// <summary>
		/// 将全角数字转换为数字
		/// </summary>
		/// <param name="SBCCase"></param>
		/// <returns></returns>
		public static string SBCCaseToNumberic(string SBCCase) {
			char[] c = SBCCase.ToCharArray();
			for (int i = 0; i < c.Length; i++) {
				byte[] b = System.Text.Encoding.Unicode.GetBytes(c, i, 1);
				if (b.Length == 2) {
					if (b[1] == 255) {
						b[0] = (byte)(b[0] + 32);
						b[1] = 0;
						c[i] = System.Text.Encoding.Unicode.GetChars(b)[0];
					}
				}
			}
			return new string(c);
		}
		/// <summary>
		/// 格式化字节数字符串
		/// </summary>
		/// <param name="bytes"></param>
		/// <returns></returns>
		public static string FormatBytesStr(int bytes) {
			if (bytes > 1073741824) return ((double)(bytes / 1073741824)).ToString("0") + "G";
			if (bytes > 1048576) return ((double)(bytes / 1048576)).ToString("0") + "M";
			if (bytes > 1024) return ((double)(bytes / 1024)).ToString("0") + "K";
			return bytes.ToString() + "Bytes";
		}
		/// <summary>
		/// 判断对象是否为Int32类型
		/// </summary>
		/// <param name="objVerify">需要验证的对象</param>
		/// <returns>True/False，是/否</returns>
		internal static bool NumIsNumeric(object objVerify) {
			if (objVerify == null) return false;
			string strTmp = objVerify.ToString();
			if (strTmp.Length > 0 && strTmp.Length <= 11 && Regex.IsMatch(strTmp, @"^[-]?[0-9]*[.]?[0-9]*$")) {
				if ((strTmp.Length < 10) || (strTmp.Length == 10 && strTmp[0] == '1') || (strTmp.Length == 11 && strTmp[0] == '-' && strTmp[1] == '1')) {
					return true;
				}
			}
			return false;
		}

		#endregion

		#region 简、繁体转换

		/// <summary>
		/// 转换为简体中文
		/// </summary>
		public static string ToSChinese(string str) {
			return Strings.StrConv(str, VbStrConv.SimplifiedChinese, 0);
		}
		/// <summary>
		/// 转换为繁体中文
		/// </summary>
		public static string ToTChinese(string str) {
			return Strings.StrConv(str, VbStrConv.TraditionalChinese, 0);
		}

		#endregion

		#region Base64

		/// <summary>
		/// 将普通字符串转换为Base64字符串
		/// </summary>
		/// <param name="theStr">待转换字符串</param>
		/// <returns>Base64字符串</returns>
		public static string ToBase64Encode(string theStr) {
			return Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(theStr)).Replace("+", "%2B");
		}
		/// <summary>
		/// 将Base64字符串转换为普通字符串
		/// </summary>
		/// <param name="theStr">待转换字符串</param>
		/// <returns>普通字符串</returns>
		public static string ToBase64Decode(string theStr) {
			return System.Text.Encoding.Default.GetString(Convert.FromBase64String(theStr.Replace("%2B", "+")));
		}

		#endregion

		#region Hex & 十六进制

		/// <summary>
		/// <para>将字符串内容转化为16进制数据编码，其逆过程是Decode</para>
		/// <para>参数说明：</para>
		/// <para>strEncode 需要转化的原始字符串</para>
		/// <para>转换的过程是直接把字符转换成Unicode字符,比如数字"3"-->0033,汉字"我"-->U+6211</para>
		/// <para>函数decode的过程是encode的逆过程.</para>
		/// </summary>
		/// <param name="strEncode">待转换字符串</param>
		/// <returns>十六进制</returns>
		public static string ToHexOfEncode(string strEncode) {
			string strReturn = "";//  存储转换后的编码
			foreach (short shortx in strEncode.ToCharArray()) {
				strReturn += shortx.ToString("X4");
			}
			return strReturn;
		}
		/// <summary>
		/// 作用：将16进制数据编码转化为字符串，是Encode的逆过程
		/// </summary>
		/// <param name="strDecode">待转换字符串</param>
		/// <returns>十六进制</returns>
		public static string ToHexOfDecode(string strDecode) {
			string sResult = "";
			for (int i = 0; i < strDecode.Length / 4; i++) {
				sResult += (char)short.Parse(strDecode.Substring(i * 4, 4), global::System.Globalization.NumberStyles.HexNumber);
			}
			return sResult;
		}

		#endregion

		#region 时间分钟数取整

		/// <summary>
		/// 时间分钟数取整
		/// </summary>
		/// <param name="takeTime">需要取整的时间</param>
		/// <param name="interval">时间间隔</param>
		/// <param name="takeFlag">
		/// 取整标记
		/// <para>1 向上取整[1.2 -> 2]</para>
		/// <para>2 向下取整[1.2 -> 1]</para>
		/// </param>
		/// <returns></returns>
		public static DateTime TakeTheTime(DateTime takeTime, int interval, byte takeFlag = 2) {
			if (takeTime == DateTime.MinValue || takeTime == DateTime.MaxValue) return takeTime;
			var min = takeTime.Minute;
			if (min > interval) min = min % interval;
			switch (takeFlag) {
				case 1:
					min = interval - min;
					takeTime = takeTime.AddMinutes(min);
					break;
				case 2:
					takeTime = takeTime.AddMinutes(-min);
					break;
			}
			return takeTime;
		}

		#endregion

		#region DateTime Convert

		/// <summary>
		/// 时间转换器
		/// <para>字符串拆分法</para>
		/// <para>20140705102000</para>
		/// </summary>
		/// <param name="times">需要转换的时间</param>
		/// <returns>时间</returns>
		public static DateTime ValToDate(string times) {
			if (string.IsNullOrEmpty(times)) return DateTime.MinValue;
			DateTime result = DateTime.MinValue;
			if (times.Length >= 12) {
				try {
					int year = int.Parse(times.Substring(0, 4));
					int month = int.Parse(times.Substring(4, 2));
					int day = int.Parse(times.Substring(6, 2));
					int hour = int.Parse(times.Substring(8, 2));
					int min = int.Parse(times.Substring(10, 2));
					result = new DateTime(year, month, day, hour, min, 0);
				}
				catch { }
			}
			return result;
		}
		/// <summary>
		/// 时间转换器
		/// <para>DateTime.TryParse</para>
		/// <para>2014-07-05 10:20:00</para>
		/// </summary>
		/// <param name="dateString">需要转换的时间</param>
		/// <returns>时间</returns>
		public static DateTime ValToDateTry(string dateString) {
			if (string.IsNullOrEmpty(dateString)) return DateTime.MinValue;
			var date = DateTime.MinValue;
			try {
				DateTime.TryParse(dateString, out date);
			}
			catch { ; }
			return date;
		}
		/// <summary>
		/// 时间转换器
		/// <para>DateTime.ParseExact</para>
		/// <para>20140705102000</para>
		/// </summary>
		/// <param name="dateString">需要转换的时间</param>
		/// <returns>时间</returns>
		public static DateTime ValToDateAt(string dateString) {
			if (string.IsNullOrEmpty(dateString)) return DateTime.MinValue;
			try {
				var timeFormat = "yyyyMMddHHmmss";
				switch (dateString.Length) {
					case 8:
						timeFormat = "yyyyMMdd";
						break;
					case 10:
						timeFormat = "yyyyMMddHH";
						break;
					case 12:
						timeFormat = "yyyyMMddHHmm";
						break;
					case 16:
						timeFormat = "yyyyMMddHHmmss";
						break;
					case 19:
						timeFormat = "yyyyMMddHHmmssfff";
						break;
				}
				return DateTime.ParseExact(dateString, timeFormat, System.Globalization.CultureInfo.CurrentCulture);
			}
			catch {
				return DateTime.MinValue;
			}
		}

		#endregion

	}
}
