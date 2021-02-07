//==================================================================== 
//*****                    晨曦小竹常用工具集                    *****
//====================================================================
//**   Copyright © DawnXZ.com 2014 -- QQ：6808240 -- 请保留此注释   **
//====================================================================
// 文件名称：StringHelper.cs
// 项目名称：常用方法实用工具集
// 创建时间：2014年2月25日15时42分
// 创建人员：宋杰军
// 负 责 人：宋杰军
// 参与人员：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace DawnXZ.DawnUtility
{
    /// <summary>
    /// 字符串操作辅助类
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// 回车、换行符
        /// </summary>
        private static Regex RegexBr = new Regex(@"(\r\n)", RegexOptions.IgnoreCase);

        #region 常规方法

        /// <summary>
        /// 返回字符串真实长度, 1个汉字长度为2
        /// </summary>
        /// <returns>字符串真实长度</returns>
        public static int GetStringLength(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }
        /// <summary>
        /// 删除最后一个字符
        /// </summary>
        /// <param name="strValue">清理的字符串</param>
        /// <returns>清理后的字符串</returns>
        public static string ClearLastChar(string strValue)
        {
            return (string.IsNullOrEmpty(strValue)) ? null : strValue.Substring(0, strValue.Length - 1);
        }

        #endregion

        #region 常规检测

        /// <summary>
        /// 查找一个字符串在另一个字符串中出现的次数
        /// </summary>
        /// <param name="strSource">源数据</param>
        /// <param name="strFind">查找数据</param>
        /// <returns>出现次数，默认为 0</returns>
        public static int GetOccurrenceNumber(string strSource, string strFind)
        {
            if (strSource.Length <= 0 | strFind.Length <= 0) return 0;
            int intSum = 0, intTemp = 0;
            do
            {
                intTemp = strSource.IndexOf(strFind, intTemp);
                if (intTemp != -1)
                {
                    intSum++;
                    intTemp += strFind.Length;
                }
            }
            while (intTemp != -1);
            return intSum;
        }

        #endregion

        #region 检测字符串

        /// <summary>
        /// 检测字符串中是否存在指定的字符串
        /// </summary>
        /// <param name="str">要查找的字符串</param>
        /// <param name="stringarray">原字符串</param>
        /// <param name="strsplit">分隔标记</param>
        /// <returns>存在 / 不存在</returns>
        public static bool IsCompriseStr(string str, string stringarray, string strsplit)
        {
            if (string.IsNullOrEmpty(stringarray)) return false;
            str = str.ToLower();
            string[] stringArray = SplitString(stringarray.ToLower(), strsplit);
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (str.IndexOf(stringArray[i]) > -1) return true;
            }
            return false;
        }
        /// <summary>
        /// 判断指定字符串在指定字符串数组中的位置
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>字符串在指定字符串数组中的位置, 如不存在则返回-1</returns>
        public static int GetInArrayID(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (caseInsensetive)
                {
                    if (strSearch.ToLower() == stringArray[i].ToLower()) return i;
                }
                else if (strSearch == stringArray[i])
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// 判断指定字符串在指定字符串数组中的位置
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <returns>字符串在指定字符串数组中的位置, 如不存在则返回-1</returns>		
        public static int GetInArrayID(string strSearch, string[] stringArray)
        {
            return GetInArrayID(strSearch, stringArray, true);
        }
        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            return GetInArrayID(strSearch, stringArray, caseInsensetive) >= 0;
        }
        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">字符串数组</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string[] stringarray)
        {
            return InArray(str, stringarray, false);
        }
        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">内部以逗号分割单词的字符串</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string stringarray)
        {
            return InArray(str, SplitString(stringarray, ","), false);
        }
        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">内部以逗号分割单词的字符串</param>
        /// <param name="strsplit">分割字符串</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string stringarray, string strsplit)
        {
            return InArray(str, SplitString(stringarray, strsplit), false);
        }
        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">内部以逗号分割单词的字符串</param>
        /// <param name="strsplit">分割字符串</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string stringarray, string strsplit, bool caseInsensetive)
        {
            return InArray(str, SplitString(stringarray, strsplit), caseInsensetive);
        }

        #endregion

        #region 获取指定类型值

        /// <summary>
        /// 获取字符串中的数字
        /// </summary>
        /// <param name="strString">字符串</param>
        /// <returns></returns>
        public static int GetNumber(string strString)
        {
            int tmpVal = 0;
            try
            {
                Match m = Regex.Match(strString, @"\d+");
                if (m.Success) tmpVal = TypeHelper.TypeToInt32(m.Value, 0);
            }
            catch { }
            return tmpVal;
        }
        /// <summary>
        /// 获取字符串中的汉字
        /// </summary>
        /// <param name="strString">字符串</param>
        /// <returns></returns>
        public static string GetChinese(string strString)
        {
            string tmpVal = null;
            try
            {
                Match m = Regex.Match(strString, @"[\u0391-\uFFE5/]+");
                if (m.Success) tmpVal = m.Value;
            }
            catch { }
            return tmpVal;
        }
        /// <summary>
        /// 获取汉字第一个拼音
        /// 所有汉字
        /// </summary>
        /// <param name="strChinese">汉字</param>
        /// <returns></returns>
		public static string GetSpellingOfAcronymAll(string strChinese)
        {
            int len = strChinese.Length;
            string reVal = null;
            for (int i = 0; i < len; i++)
            {
				reVal += GetSpellingOfAcronymFirst(strChinese.Substring(i, 1));
            }
            return reVal;
        }
        /// <summary>
        /// 获取汉字第一个拼音
        /// 仅第一个
        /// </summary>
        /// <param name="strChinese">汉字</param>
        /// <returns></returns>
		public static string GetSpellingOfAcronymFirst(string strChinese)
        {
            byte[] arrCN = Encoding.Default.GetBytes(strChinese);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "?";
            }
            else
            {
                return strChinese;
            }
        }

		#region 汉字转拼音

		/// <summary>
		/// 定义拼音区编码数组
		/// </summary>
		private static int[] SpellingValue = new int[]
            {
                -20319,-20317,-20304,-20295,-20292,-20283,-20265,-20257,-20242,-20230,-20051,-20036,
                -20032,-20026,-20002,-19990,-19986,-19982,-19976,-19805,-19784,-19775,-19774,-19763,
                -19756,-19751,-19746,-19741,-19739,-19728,-19725,-19715,-19540,-19531,-19525,-19515,
                -19500,-19484,-19479,-19467,-19289,-19288,-19281,-19275,-19270,-19263,-19261,-19249,
                -19243,-19242,-19238,-19235,-19227,-19224,-19218,-19212,-19038,-19023,-19018,-19006,
                -19003,-18996,-18977,-18961,-18952,-18783,-18774,-18773,-18763,-18756,-18741,-18735,
                -18731,-18722,-18710,-18697,-18696,-18526,-18518,-18501,-18490,-18478,-18463,-18448,
                -18447,-18446,-18239,-18237,-18231,-18220,-18211,-18201,-18184,-18183, -18181,-18012,
                -17997,-17988,-17970,-17964,-17961,-17950,-17947,-17931,-17928,-17922,-17759,-17752,
                -17733,-17730,-17721,-17703,-17701,-17697,-17692,-17683,-17676,-17496,-17487,-17482,
                -17468,-17454,-17433,-17427,-17417,-17202,-17185,-16983,-16970,-16942,-16915,-16733,
                -16708,-16706,-16689,-16664,-16657,-16647,-16474,-16470,-16465,-16459,-16452,-16448,
                -16433,-16429,-16427,-16423,-16419,-16412,-16407,-16403,-16401,-16393,-16220,-16216,
                -16212,-16205,-16202,-16187,-16180,-16171,-16169,-16158,-16155,-15959,-15958,-15944,
                -15933,-15920,-15915,-15903,-15889,-15878,-15707,-15701,-15681,-15667,-15661,-15659,
                -15652,-15640,-15631,-15625,-15454,-15448,-15436,-15435,-15419,-15416,-15408,-15394,
                -15385,-15377,-15375,-15369,-15363,-15362,-15183,-15180,-15165,-15158,-15153,-15150,
                -15149,-15144,-15143,-15141,-15140,-15139,-15128,-15121,-15119,-15117,-15110,-15109,
                -14941,-14937,-14933,-14930,-14929,-14928,-14926,-14922,-14921,-14914,-14908,-14902,
                -14894,-14889,-14882,-14873,-14871,-14857,-14678,-14674,-14670,-14668,-14663,-14654,
                -14645,-14630,-14594,-14429,-14407,-14399,-14384,-14379,-14368,-14355,-14353,-14345,
                -14170,-14159,-14151,-14149,-14145,-14140,-14137,-14135,-14125,-14123,-14122,-14112,
                -14109,-14099,-14097,-14094,-14092,-14090,-14087,-14083,-13917,-13914,-13910,-13907,
                -13906,-13905,-13896,-13894,-13878,-13870,-13859,-13847,-13831,-13658,-13611,-13601,
                -13406,-13404,-13400,-13398,-13395,-13391,-13387,-13383,-13367,-13359,-13356,-13343,
                -13340,-13329,-13326,-13318,-13147,-13138,-13120,-13107,-13096,-13095,-13091,-13076,
                -13068,-13063,-13060,-12888,-12875,-12871,-12860,-12858,-12852,-12849,-12838,-12831,
                -12829,-12812,-12802,-12607,-12597,-12594,-12585,-12556,-12359,-12346,-12320,-12300,
                -12120,-12099,-12089,-12074,-12067,-12058,-12039,-11867,-11861,-11847,-11831,-11798,
                -11781,-11604,-11589,-11536,-11358,-11340,-11339,-11324,-11303,-11097,-11077,-11067,
                -11055,-11052,-11045,-11041,-11038,-11024,-11020,-11019,-11018,-11014,-10838,-10832,
                -10815,-10800,-10790,-10780,-10764,-10587,-10544,-10533,-10519,-10331,-10329,-10328,
                -10322,-10315,-10309,-10307,-10296,-10281,-10274,-10270,-10262,-10260,-10256,-10254
            };
		/// <summary>
		/// 定义拼音数组
		/// </summary>
		private static string[] SpellingName = new string[]
            {
                "A","Ai","An","Ang","Ao","Ba","Bai","Ban","Bang","Bao","Bei","Ben",
                "Beng","Bi","Bian","Biao","Bie","Bin","Bing","Bo","Bu","Ba","Cai","Can",
                "Cang","Cao","Ce","Ceng","Cha","Chai","Chan","Chang","Chao","Che","Chen","Cheng",
                "Chi","Chong","Chou","Chu","Chuai","Chuan","Chuang","Chui","Chun","Chuo","Ci","Cong",
                "Cou","Cu","Cuan","Cui","Cun","Cuo","Da","Dai","Dan","Dang","Dao","De",
                "Deng","Di","Dian","Diao","Die","Ding","Diu","Dong","Dou","Du","Duan","Dui",
                "Dun","Duo","E","En","Er","Fa","Fan","Fang","Fei","Fen","Feng","Fo",
                "Fou","Fu","Ga","Gai","Gan","Gang","Gao","Ge","Gei","Gen","Geng","Gong",
                "Gou","Gu","Gua","Guai","Guan","Guang","Gui","Gun","Guo","Ha","Hai","Han",
                "Hang","Hao","He","Hei","Hen","Heng","Hong","Hou","Hu","Hua","Huai","Huan",
                "Huang","Hui","Hun","Huo","Ji","Jia","Jian","Jiang","Jiao","Jie","Jin","Jing",
                "Jiong","Jiu","Ju","Juan","Jue","Jun","Ka","Kai","Kan","Kang","Kao","Ke",
                "Ken","Keng","Kong","Kou","Ku","Kua","Kuai","Kuan","Kuang","Kui","Kun","Kuo",
                "La","Lai","Lan","Lang","Lao","Le","Lei","Leng","Li","Lia","Lian","Liang",
                "Liao","Lie","Lin","Ling","Liu","Long","Lou","Lu","Lv","Luan","Lue","Lun",
                "Luo","Ma","Mai","Man","Mang","Mao","Me","Mei","Men","Meng","Mi","Mian",
                "Miao","Mie","Min","Ming","Miu","Mo","Mou","Mu","Na","Nai","Nan","Nang",
                "Nao","Ne","Nei","Nen","Neng","Ni","Nian","Niang","Niao","Nie","Nin","Ning",
                "Niu","Nong","Nu","Nv","Nuan","Nue","Nuo","O","Ou","Pa","Pai","Pan",
                "Pang","Pao","Pei","Pen","Peng","Pi","Pian","Piao","Pie","Pin","Ping","Po",
                "Pu","Qi","Qia","Qian","Qiang","Qiao","Qie","Qin","Qing","Qiong","Qiu","Qu",
                "Quan","Que","Qun","Ran","Rang","Rao","Re","Ren","Reng","Ri","Rong","Rou",
                "Ru","Ruan","Rui","Run","Ruo","Sa","Sai","San","Sang","Sao","Se","Sen",
                "Seng","Sha","Shai","Shan","Shang","Shao","She","Shen","Sheng","Shi","Shou","Shu",
                "Shua","Shuai","Shuan","Shuang","Shui","Shun","Shuo","Si","Song","Sou","Su","Suan",
                "Sui","Sun","Suo","Ta","Tai","Tan","Tang","Tao","Te","Teng","Ti","Tian",
                "Tiao","Tie","Ting","Tong","Tou","Tu","Tuan","Tui","Tun","Tuo","Wa","Wai",
                "Wan","Wang","Wei","Wen","Weng","Wo","Wu","Xi","Xia","Xian","Xiang","Xiao",
                "Xie","Xin","Xing","Xiong","Xiu","Xu","Xuan","Xue","Xun","Ya","Yan","Yang",
                "Yao","Ye","Yi","Yin","Ying","Yo","Yong","You","Yu","Yuan","Yue","Yun",
                "Za", "Zai","Zan","Zang","Zao","Ze","Zei","Zen","Zeng","Zha","Zhai","Zhan",
                "Zhang","Zhao","Zhe","Zhen","Zheng","Zhi","Zhong","Zhou","Zhu","Zhua","Zhuai","Zhuan",
                "Zhuang","Zhui","Zhun","Zhuo","Zi","Zong","Zou","Zu","Zuan","Zui","Zun","Zuo"
           };
		/// <summary>
		/// 汉字转换成全拼的拼音
		/// </summary>
		/// <param name="strChinese">汉字字符串</param>
		/// <returns>转换后的拼音字符串</returns>
		public static string GetSpelling(string strChinese) {
			Regex reg = new Regex("^[\u4e00-\u9fa5]$");//验证是否输入汉字
			byte[] arr = new byte[2];
			string pystr = "";
			int asc = 0, M1 = 0, M2 = 0;
			char[] mChar = strChinese.ToCharArray();//获取汉字对应的字符数组
			for (int j = 0; j < mChar.Length; j++) {
				//如果输入的是汉字
				if (reg.IsMatch(mChar[j].ToString())) {
					arr = System.Text.Encoding.Default.GetBytes(mChar[j].ToString());
					M1 = (short)(arr[0]);
					M2 = (short)(arr[1]);
					asc = M1 * 256 + M2 - 65536;
					if (asc > 0 && asc < 160) {
						pystr += mChar[j];
					}
					else {
						switch (asc) {
							case -9254:
								pystr += "Zhen"; break;
							case -8985:
								pystr += "Qian"; break;
							case -5463:
								pystr += "Jia"; break;
							case -8274:
								pystr += "Ge"; break;
							case -5448:
								pystr += "Ga"; break;
							case -5447:
								pystr += "La"; break;
							case -4649:
								pystr += "Chen"; break;
							case -5436:
								pystr += "Mao"; break;
							case -5213:
								pystr += "Mao"; break;
							case -3597:
								pystr += "Die"; break;
							case -5659:
								pystr += "Tian"; break;
							default:
								for (int i = (SpellingValue.Length - 1); i >= 0; i--) {
									if (SpellingValue[i] <= asc) //判断汉字的拼音区编码是否在指定范围内
                                    {
										pystr += SpellingName[i];//如果不超出范围则获取对应的拼音
										break;
									}
								}
								break;
						}
					}
				}
				else//如果不是汉字
                {
					pystr += mChar[j].ToString();//如果不是汉字则返回
				}
			}
			return pystr;//返回获取到的汉字拼音
		}

		#endregion

		#endregion

		#region 清除回车、换行、空格

		/// <summary>
        /// 删除字符串尾部的回车/换行/空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RTrim(string str)
        {
            for (int i = str.Length; i >= 0; i--)
            {
                if (str[i].Equals(" ") || str[i].Equals("\r") || str[i].Equals("\n"))
                {
                    str.Remove(i, 1);
                }
            }
            return str;
        }
        /// <summary>
        /// 清除给定字符串中的回车及换行符
        /// </summary>
        /// <param name="str">要清除的字符串</param>
        /// <returns>清除后返回的字符串</returns>
        public static string ClearBR(string str)
        {
            Match m = null;
            for (m = RegexBr.Match(str); m.Success; m = m.NextMatch())
            {
                str = str.Replace(m.Groups[0].ToString(), "");
            }
            return str;
        }

        #endregion

        #region 分割字符串

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">要分割的字符串</param>
        /// <param name="strSplit">分割标识</param>
        /// <returns>字符串数组</returns>
        public static string[] SplitString(string strContent, string strSplit)
        {
            if (!string.IsNullOrEmpty(strContent))
            {
                if (strContent.IndexOf(strSplit) < 0) return new string[] { strContent };
                return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
            }
            else
            {
                return new string[0] { };
            }
        }
        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">要分割的字符串</param>
        /// <param name="strSplit">分割标识</param>
        /// <param name="count">数组大小</param>
        /// <returns>字符串数组</returns>
        public static string[] SplitString(string strContent, string strSplit, int count)
        {
            string[] result = new string[count];
            string[] splited = SplitString(strContent, strSplit);
            for (int i = 0; i < count; i++)
            {
                if (i < splited.Length)
                {
                    result[i] = splited[i];
                }
                else
                {
                    result[i] = string.Empty;
                }
            }
            return result;
        }
        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">被分割的字符串</param>
        /// <param name="strSplit">分割符</param>
        /// <param name="ignoreRepeatItem">忽略重复项</param>
        /// <returns></returns>
        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem)
        {
            return SplitString(strContent, strSplit, ignoreRepeatItem, 0);
        }
        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">被分割的字符串</param>
        /// <param name="strSplit">分割符</param>
        /// <param name="ignoreRepeatItem">忽略重复项</param>
        /// <param name="maxElementLength">单个元素最大长度</param>
        /// <returns>字符串数组</returns>
        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem, int maxElementLength)
        {
            string[] result = SplitString(strContent, strSplit);
            return ignoreRepeatItem ? DistinctStringArray(result, maxElementLength) : result;
        }
        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">被分割的字符串</param>
        /// <param name="strSplit">分割符</param>
        /// <param name="ignoreRepeatItem">忽略重复项</param>
        /// <param name="minElementLength">单个元素最小长度</param>
        /// <param name="maxElementLength">单个元素最大长度</param>
        /// <returns>字符串数组</returns>
        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem, int minElementLength, int maxElementLength)
        {
            string[] result = SplitString(strContent, strSplit);
            if (ignoreRepeatItem) result = DistinctStringArray(result);
            return PadStringArray(result, minElementLength, maxElementLength);
        }

        #endregion

        #region 替换字符串

        /// <summary>
        /// 自定义的替换字符串函数
        /// </summary>
        /// <param name="SourceString">源字符串</param>
        /// <param name="SearchString">要查找的值</param>
        /// <param name="ReplaceString">替换字符串</param>
        /// <param name="IsCaseInsensetive">是否忽略大小写</param>
        /// <returns>字符串</returns>
        public static string ReplaceString(string SourceString, string SearchString, string ReplaceString, bool IsCaseInsensetive)
        {
            return Regex.Replace(SourceString, Regex.Escape(SearchString), ReplaceString, IsCaseInsensetive ? RegexOptions.IgnoreCase : RegexOptions.None);
        }

        #endregion

        #region 清除重复项

        /// <summary>
        /// 清除字符串数组中的重复项
        /// </summary>
        /// <param name="strArray">字符串数组</param>
        /// <returns>字符串数组</returns>
        public static string[] DistinctStringArray(string[] strArray)
        {
            return DistinctStringArray(strArray, 0);
        }
        /// <summary>
        /// 清除字符串数组中的重复项
        /// </summary>
        /// <param name="strArray">字符串数组</param>
        /// <param name="maxElementLength">字符串数组中单个元素的最大长度</param>
        /// <returns>字符串数组</returns>
        public static string[] DistinctStringArray(string[] strArray, int maxElementLength)
        {
            Hashtable h = new Hashtable();
            foreach (string s in strArray)
            {
                string k = s;
                if (maxElementLength > 0 && k.Length > maxElementLength)
                {
                    k = k.Substring(0, maxElementLength);
                }
                h[k.Trim()] = s;
            }
            string[] result = new string[h.Count];
            h.Keys.CopyTo(result, 0);
            return result;
        }

        #endregion

        #region 过滤数组元素

        /// <summary>
        /// 过滤字符串数组中每个元素为合适的大小
        /// 当长度小于minLength时，忽略掉,-1为不限制最小长度
        /// 当长度大于maxLength时，取其前maxLength位
        /// 如果数组中有null元素，会被忽略掉
        /// </summary>
        /// <param name="strArray">原始数组</param>
        /// <param name="minLength">单个元素最小长度</param>
        /// <param name="maxLength">单个元素最大长度</param>
        /// <returns>字符串数组</returns>
        public static string[] PadStringArray(string[] strArray, int minLength, int maxLength)
        {
            if (minLength > maxLength)
            {
                int t = maxLength;
                maxLength = minLength;
                minLength = t;
            }
            int iMiniStringCount = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (minLength > -1 && strArray[i].Length < minLength)
                {
                    strArray[i] = null;
                    continue;
                }
                if (strArray[i].Length > maxLength) strArray[i] = strArray[i].Substring(0, maxLength);
                iMiniStringCount++;
            }
            string[] result = new string[iMiniStringCount];
            for (int i = 0, j = 0; i < strArray.Length && j < result.Length; i++)
            {
                if (strArray[i] != null && strArray[i] != string.Empty)
                {
                    result[j] = strArray[i];
                    j++;
                }
            }
            return result;
        }

        #endregion

        #region Intercept 截取字符串

        #region 截取并替换

        /// <summary>
        /// 字符串如果操过指定长度则将超出的部分用指定字符串代替
        /// </summary>
        /// <param name="p_SrcString">要检查的字符串</param>
        /// <param name="p_Length">指定长度</param>
        /// <param name="p_TailString">用于替换的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string InterceptGetSubString(string p_SrcString, int p_Length, string p_TailString)
        {
            return InterceptGetSubString(p_SrcString, 0, p_Length, p_TailString);
        }
        /// <summary>
        /// 取指定长度的字符串超出的部分用指定字符串代替
        /// </summary>
        /// <param name="p_SrcString">要检查的字符串</param>
        /// <param name="p_StartIndex">起始位置</param>
        /// <param name="p_Length">指定长度</param>
        /// <param name="p_TailString">用于替换的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string InterceptGetSubString(string p_SrcString, int p_StartIndex, int p_Length, string p_TailString)
        {
            string myResult = p_SrcString;
            Byte[] bComments = Encoding.UTF8.GetBytes(p_SrcString);
            foreach (char c in Encoding.UTF8.GetChars(bComments))
            {    //当是日文或韩文时(注:中文的范围:\u4e00 - \u9fa5, 日文在\u0800 - \u4e00, 韩文为\xAC00-\xD7A3)
                if ((c > '\u0800' && c < '\u4e00') || (c > '\xAC00' && c < '\xD7A3'))
                {
                    //if (System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\u0800-\u4e00]+") || System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\xAC00-\xD7A3]+"))
                    //当截取的起始位置超出字段串长度时
                    if (p_StartIndex >= p_SrcString.Length)
                    {
                        return null;
                    }
                    else
                    {
                        return p_SrcString.Substring(p_StartIndex, ((p_Length + p_StartIndex) > p_SrcString.Length) ? (p_SrcString.Length - p_StartIndex) : p_Length);
                    }
                }
            }
            if (p_Length >= 0)
            {
                byte[] bsSrcString = Encoding.Default.GetBytes(p_SrcString);
                //当字符串长度大于起始位置
                if (bsSrcString.Length > p_StartIndex)
                {
                    int p_EndIndex = bsSrcString.Length;
                    //当要截取的长度在字符串的有效长度范围内
                    if (bsSrcString.Length > (p_StartIndex + p_Length))
                    {
                        p_EndIndex = p_Length + p_StartIndex;
                    }
                    else
                    {
                        //当不在有效范围内时,只取到字符串的结尾
                        p_Length = bsSrcString.Length - p_StartIndex;
                        p_TailString = "";
                    }
                    int nRealLength = p_Length;
                    int[] anResultFlag = new int[p_Length];
                    byte[] bsResult = null;
                    int nFlag = 0;
                    for (int i = p_StartIndex; i < p_EndIndex; i++)
                    {
                        if (bsSrcString[i] > 127)
                        {
                            nFlag++;
                            if (nFlag == 3) nFlag = 1;
                        }
                        else
                        {
                            nFlag = 0;
                        }
                        anResultFlag[i] = nFlag;
                    }
                    if ((bsSrcString[p_EndIndex - 1] > 127) && (anResultFlag[p_Length - 1] == 1)) nRealLength = p_Length + 1;
                    bsResult = new byte[nRealLength];
                    Array.Copy(bsSrcString, p_StartIndex, bsResult, 0, nRealLength);
                    myResult = Encoding.Default.GetString(bsResult);
                    myResult = myResult + p_TailString;
                }
            }
            return myResult;
        }
        /// <summary>
        /// 取指定长度的字符串超出的部分用指定字符串代替
        /// Unicode 字符集
        /// </summary>
        /// <param name="str">要检查的字符串</param>
        /// <param name="len">指定长度</param>
        /// <param name="p_TailString">用于替换的字符串</param>
        /// <returns>截取后的 Unicode 字符串</returns>
        public static string GetUnicodeSubString(string str, int len, string p_TailString)
        {
            string result = string.Empty;// 最终返回的结果
            int byteLen = System.Text.Encoding.Default.GetByteCount(str);// 单字节字符长度
            int charLen = str.Length;// 把字符平等对待时的字符串长度
            int byteCount = 0;// 记录读取进度
            int pos = 0;// 记录截取位置
            if (byteLen > len)
            {
                for (int i = 0; i < charLen; i++)
                {
                    if (Convert.ToInt32(str.ToCharArray()[i]) > 255)// 按中文字符计算加2
                    {
                        byteCount += 2;
                    }
                    else
                    {
                        byteCount += 1; // 按英文字符计算加1
                    }
                    if (byteCount > len)// 超出时只记下上一个有效位置
                    {
                        pos = i;
                        break;
                    }
                    else if (byteCount == len)// 记下当前位置
                    {
                        pos = i + 1;
                        break;
                    }
                }
                if (pos >= 0) result = str.Substring(0, pos) + p_TailString;
            }
            else
            {
                result = str;
            }
            return result;
        }

        #endregion

        #region 标题相关

        /// <summary>
        /// 截断过长标题，中英文通用
        /// </summary>
        public static string InterceptByTitles(string strTitle, int strLength)
        {
            string temp = strTitle;
            if (Regex.Replace(temp, "[\u4e00-\u9fa5]", "zz", RegexOptions.IgnoreCase).Length <= strLength) return temp;
            for (int i = temp.Length; i >= 0; i--)
            {
                temp = temp.Substring(0, i) + "...";
                if (Regex.Replace(temp, "[\u4e00-\u9fa5]", "zz", RegexOptions.IgnoreCase).Length <= strLength - 1) return temp + "";
            }
            return "";
        }
        /// <summary>
        /// 截断过长标题，默认以“...”代替
        /// </summary>
        public static string InterceptByTitle(string strTitle, int strLength)
        {
            return InterceptByTitle(strTitle, strLength, "...");
        }
        /// <summary>
        /// 截断过长标题，并以指定字符串替换
        /// </summary>
        public static string InterceptByTitle(string strTitle, int strLength, string strReplace)
        {
            if (strTitle.Length >= strLength + 1)
            {
                strTitle = strTitle.Substring(0, strLength) + strReplace;
                return strTitle;
            }
            else
            {
                return strTitle;
            }
        }

        #endregion

        #region 截取指定长度

        /// <summary>
        /// 从字符串的指定位置开始截取到字符串的结尾
        /// </summary>
        /// <param name="strValue">原字符串</param>
        /// <param name="startIndex">子字符串的起始位置</param>
        /// <returns>子字符串</returns>
        public static string InterceptCutString(string strValue, int startIndex)
        {
            return InterceptCutString(strValue, startIndex, strValue.Length);
        }
        /// <summary>
        /// 从字符串的指定位置截取指定长度的子字符串
        /// </summary>
        /// <param name="strValue">原字符串</param>
        /// <param name="startIndex">子字符串的起始位置</param>
        /// <param name="length">子字符串的长度</param>
        /// <returns>子字符串</returns>
        public static string InterceptCutString(string strValue, int startIndex, int length)
        {
            if (startIndex >= 0)
            {
                if (length < 0)
                {
                    length = length * -1;
                    if (startIndex - length < 0)
                    {
                        length = startIndex;
                        startIndex = 0;
                    }
                    else
                    {
                        startIndex = startIndex - length;
                    }
                }
                if (startIndex > strValue.Length) return "";
            }
            else
            {
                if (length < 0)
                {
                    return "";
                }
                else
                {
                    if (length + startIndex > 0)
                    {
                        length = length + startIndex;
                        startIndex = 0;
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            if (strValue.Length - startIndex < length) length = strValue.Length - startIndex;
            return strValue.Substring(startIndex, length);
        }

        #endregion

        #endregion Intercept 截取字符串

        #region 字符串转成整型数组

        /// <summary>
        /// 字符串转成整型数组
        /// </summary>
        /// <param name="idList">要转换的字符串</param>
        /// <returns>转换后的int类型结果</returns>
        public static int[] StringToIntArray(string idList)
        {
            return StringToIntArray(idList, -1);
        }
        /// <summary>
        /// 字符串转成整型数组
        /// </summary>
        /// <param name="idList">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int[] StringToIntArray(string idList, int defValue)
        {
            if (string.IsNullOrEmpty(idList)) return null;
            string[] strArr = StringHelper.SplitString(idList, ",");
            int[] intArr = new int[strArr.Length];
            for (int i = 0; i < strArr.Length; i++) intArr[i] = TypeHelper.TypeToInt32(strArr[i], defValue);
            return intArr;
        }

        #endregion

        #region SQL 相关

        /// <summary>
        /// 改正sql语句中的转义字符
        /// </summary>
        /// <param name="strvalues">输入值</param>
        public static string SqlMash(string strvalues)
        {
            return (string.IsNullOrEmpty(strvalues)) ? null : strvalues.Replace("\'", "'");
        }
        /// <summary>
        /// 替换sql语句中的有问题符号
        /// </summary>
        /// <param name="strvalues">输入值</param>
        public static string SqlSwitch(string strvalues)
        {
            return (string.IsNullOrEmpty(strvalues)) ? null : strvalues.Replace("'", "''");
        }

        #endregion

        #region 比较两个Byte[]是否相等

        /// <summary>
        /// 比较两个字节数组是否相等
        /// </summary>
        /// <param name="b1">byte数组1</param>
        /// <param name="b2">byte数组2</param>
        /// <returns>是否相等</returns>
        public static bool BytesEquals(byte[] b1, byte[] b2)
        {
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
        }

        #endregion

		#region 去掉字符串中的数字或非数字

		/// <summary>
		/// 去掉字符串中的数字
		/// </summary>
		/// <param name="strValue">需要排除的字符串</param>
		/// <returns>执行结果</returns>
		public static string RemoveNumber(string strValue) {
			return Regex.Replace(strValue, @"\d", "");
		}
		/// <summary>
		/// 去掉字符串中的非数字
		/// </summary>
		/// <param name="strValue">需要排除的字符串</param>
		/// <returns>执行结果</returns>
		public static string RemoveNotNumber(string strValue) {
			return Regex.Replace(strValue, @"[^\d]*", "");
		}

		#endregion

	}
}
