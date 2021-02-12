//==================================================================== 
//*****                     晨曦小竹常用工具集                   *****
//====================================================================
//**   Copyright © DawnXZ.com 2014 -- QQ：6808240 -- 请保留此注释   **
//====================================================================
// 文件名称：PagerHelperCHS.cs
// 项目名称：数据分页展示工具集
// 创建时间：2010-11-09
// 创建人员：宋杰军
// 负 责 人：宋杰军
// 参与人员：宋杰军
// ===================================================================
// 修改日期：2010年11月—12月
// 修改人员：宋杰军
// 修改内容：修正完善相关方法体
// ===================================================================
// 修改日期：2013年元月03日
// 修改人员：宋杰军
// 修改内容：完善命名规范及格式规范
// ===================================================================
// 修改日期：2013年元月26日
// 修改人员：宋杰军
// 修改内容：归纳各数据分页方式，并改良之
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.Text;
using System.ComponentModel;

namespace DawnXZ.PagerUtility {
	/// <summary>
	/// 数据分页[HTML标签模式]
	/// <para>中文字样</para>
	/// </summary>
	public class PagerHelperCHS {

		#region 成员字段

		/// <summary>
		/// 当前页码
		/// </summary>
		private int FPageCurrent;

		#endregion

		#region 成员属性

		/// <summary>
		/// 当前页码
		/// </summary>
		public int PageCurrent {
			get { return this.FPageCurrent; }
			set {
				if (value < 1) {
					this.FPageCurrent = 1;
					return;
				}
				this.FPageCurrent = value;
			}
		}
		/// <summary>
		/// 总页数
		/// </summary>
		public int PageCount { get; set; }
		/// <summary>
		/// 每页显示记录数
		/// </summary>
		public int PageSize { get; set; }
		/// <summary>
		/// 总记录数
		/// </summary>
		public int RecordCount { get; set; }
		/// <summary>
		/// 当前页总记录数
		/// </summary>
		public int PageRecordCount { get; set; }
		/// <summary>
		/// 数字分页—每页个数
		/// </summary>
		public int DigitalPageSize { get; set; }
		/// <summary>
		/// 数字分页—总页数
		/// </summary>
		public int DigitalPageCount { get; set; }
		/// <summary>
		/// 数字分页—翻页标记
		/// </summary>
		private int DigitalPageFlag {
			get { return this.DigitalPageSize / 2; }
		}
		/// <summary>
		/// 计算总页数
		/// （无总页数传入时需单独调用此方法）
		/// </summary>
		public void CalculatePageCount() {
			if (this.RecordCount % this.PageSize == 0) {
				this.PageCount = this.RecordCount / this.PageSize;
			}
			else {
				this.PageCount = this.RecordCount / this.PageSize + 1;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 构造函数
		/// </summary>
		public PagerHelperCHS() {
			this.PageCurrent = 1;
			this.PageCount = 0;
			this.PageSize = 100;
			this.DigitalPageSize = 9;
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="digitalpagesize">数字分页—每页个数</param>
		public PagerHelperCHS(int digitalpagesize) {
			this.PageCurrent = 1;
			this.PageCount = 0;
			this.PageSize = 40;
			this.DigitalPageSize = digitalpagesize;
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="pagesize">每页显示记录数</param>
		/// <param name="digitalpagesize">数字分页—每页个数</param>
		public PagerHelperCHS(int pagesize, int digitalpagesize) {
			this.PageCurrent = 1;
			this.PageCount = 0;
			this.PageSize = pagesize;
			this.DigitalPageSize = digitalpagesize;
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <remarks>
		/// <para>无数据时，传入-1</para>
		/// </remarks>
		/// <param name="pagecurrent">当前页码</param>
		/// <param name="pagecount">总页数</param>
		/// <param name="pagesize">每页显示记录数</param>
		/// <param name="digitalpagesize">数字分页—每页个数</param>
		public PagerHelperCHS(int pagecurrent, int pagecount, int pagesize, int digitalpagesize) {
			if (pagecurrent > -1) {
				this.PageCurrent = pagecurrent;
			}
			if (pagecount > -1) {
				this.PageCount = pagecount;
			}
			if (pagesize > -1) {
				this.PageSize = pagesize;
			}
			if (digitalpagesize > -1) {
				this.DigitalPageSize = digitalpagesize;
			}
		}

		#endregion

		#region 成员方法

		/// <summary>
		/// 恶意使用分页控件
		/// </summary>
		/// <returns>执行结果</returns>
		private string BalefulToPager() {
			var sb = new StringBuilder();
			if (this.RecordCount > 0 && this.PageCurrent > this.PageCount) {
				sb.Append("<div id=\"pagerList\">");
				sb.Append("<span class=\"tips\">请勿恶意使用本分页控件。（当前页码已大于总页码……）</span>");
				sb.Append("</div>");
			}
			return sb.ToString();
		}

		#region 方向链接分页[页面传参]

		/// <summary>
		/// 输出分页HTML标记
		/// <remarks>
		/// <para>方向链接分页[页面传参]</para>
		/// <para>格式：首页 上一页 下一页 末页</para>
		/// <para>引用 DawnPagerUI.css 文件</para>
		/// </remarks>
		/// </summary>
		/// <param name="urlPath">URL路径（或页面名称）</param>
		/// <param name="pagerName">数据分页标识名称</param>
		/// <param name="parameter">URL参数，分页模式的特定格式，详见JS文件</param>
		/// <param name="outPageCount">是否输出实时页总条数，需要给PageRecordCount实时赋值</param>
		/// <param name="showSelect">是否输出页码选择器</param>
		/// <param name="outPageGoto">是否输出分页跳转功能代码</param>
		/// <param name="outPageGotoFun">分页跳转功能函数名称</param>
		/// <returns>HTML</returns>
		public string ShowPagerByForward(string urlPath = @"/", string pagerName = "pager", string parameter = null, bool outPageCount = true, bool showSelect = false, bool outPageGoto = true, string outPageGotoFun = "DawnPagerGotoHref") {
			var tmpResult = this.BalefulToPager();
			if (!string.IsNullOrEmpty(tmpResult)) return tmpResult;
			if (string.IsNullOrEmpty(pagerName)) pagerName = "pager";
			StringBuilder sb = new StringBuilder();
			sb.Append("<div id=\"pagerList\">");
			//分页数据信息
			if (outPageCount) {
				if (this.PageRecordCount > 0 && this.PageRecordCount < this.PageSize) {
					sb.AppendFormat("共 {0} 条，每页 {1}/{2} 条，第 {3}/{4} 页　", this.RecordCount, this.PageRecordCount, this.PageSize, this.PageCurrent, this.PageCount);
				}
				else {
					sb.AppendFormat("共 {0} 条，每页 {1} 条，第 {2}/{3} 页　", this.RecordCount, this.PageSize, this.PageCurrent, this.PageCount);
				}
			}
			else {
				sb.AppendFormat("共 {0} 条，每页 {1} 条，第 {2}/{3} 页　", this.RecordCount, this.PageSize, this.PageCurrent, this.PageCount);
			}
			//首页
			if (this.PageCurrent == 1) {
				sb.Append("<span>首页</span>");
			}
			else {
				sb.AppendFormat("<a href=\"{0}?{1}=1{2}\">首页</a>", urlPath, pagerName, parameter);
			}
			//上一页
			if (this.PageCurrent <= 1) {
				sb.Append("&nbsp;&nbsp;<span>上一页</span>&nbsp;&nbsp;");
			}
			else {
				sb.AppendFormat("&nbsp;&nbsp;<a href=\"{0}?{1}={2}{3}\">上一页</a>&nbsp;&nbsp;", urlPath, pagerName, this.PageCurrent - 1, parameter);
			}
			//下一页
			if (this.PageCurrent >= this.PageCount) {
				sb.Append("<span>下一页</span>&nbsp;&nbsp;");
			}
			else {
				sb.AppendFormat("<a href=\"{0}?{1}={2}{3}\">下一页</a>&nbsp;&nbsp;", urlPath, pagerName, this.PageCurrent + 1, parameter);
			}
			//末页
			if (this.PageCurrent == this.PageCount | this.PageCount == 0) {
				sb.Append("<span>末页</span>");
			}
			else {
				sb.AppendFormat("<a href=\"{0}?{1}={2}{3}\">末页</a>", urlPath, pagerName, this.PageCount, parameter);
			}
			//页码选择器
			if (showSelect) {
				sb.AppendFormat("&nbsp;&nbsp;<select onchange=\"javascript:window.location.href='{0}?{1}='+this.value+'{2}'\">", urlPath, pagerName, parameter);
				for (int i = 1; i <= this.PageCount; i++) {
					if (i == this.PageCurrent) {
						sb.AppendFormat("<option value=\"{0}\" selected=\"selected\">{0}</option>", i);
					}
					else {
						sb.AppendFormat("<option value=\"{0}\">{0}</option>", i);
					}
				}
				sb.Append("</select>");
			}
			//跳转功能
			if (outPageGoto) {
				sb.AppendFormat("<span class=\"gotoarea\"><input type=\"hidden\" id=\"hidPagerMax\" value=\"{0}\" /><input type=\"text\" id=\"txtPagerIndex\" value=\"{5}\" /><label onclick=\"{1}('{2}?{3}=','{4}');\">跳转</label></span>", this.PageCount, outPageGotoFun, urlPath, pagerName, parameter, this.PageCurrent);
			}
			sb.Append("</div>");
			return sb.ToString();
		}

		#endregion

		#region 数字链接分页[页面传参]

		/// <summary>
		/// 输出分页HTML标记
		/// <remarks>
		/// <para>数字链接分页[页面传参]</para>
		/// <para>默认每页9链接，必须为单数</para>
		/// <para>格式：上一页 1 2...10 下一页</para>
		/// <para>引用 DawnPagerUI.css 文件</para>
		/// </remarks>
		/// </summary>
		/// <param name="urlPath">URL路径（或页面名称）</param>
		/// <param name="pagerName">数据分页标识名称</param>
		/// <param name="parameter">URL参数，分页模式的特定格式，详见JS文件</param>
		/// <param name="outPageCount">是否输出实时页总条数，需要给PageRecordCount实时赋值</param>
		/// <param name="outPageGoto">是否输出分页跳转功能代码</param>
		/// <param name="outPageGotoFun">分页跳转功能函数名称</param>
		/// <returns>HTML</returns>
		public string ShowPagerByNumeric(string urlPath = @"/", string pagerName = "pager", string parameter = null, bool outPageCount = true, bool outPageGoto = true, string outPageGotoFun = "DawnPagerGotoHref") {
			var tmpResult = this.BalefulToPager();
			if (!string.IsNullOrEmpty(tmpResult)) return tmpResult;
			//计算数字分页
			if (this.PageCount % this.DigitalPageSize == 0) {
				this.DigitalPageCount = this.PageCount / this.DigitalPageSize;
			}
			else {
				this.DigitalPageCount = this.PageCount / this.DigitalPageSize + 1;
			}
			StringBuilder sb = new StringBuilder();
			sb.Append("<div id=\"pagerList\">");
			//分页数据信息
			if (outPageCount) {
				if (this.PageRecordCount > 0 && this.PageRecordCount < this.PageSize) {
					sb.AppendFormat("共 {0} 条，每页 {1}/{2} 条，第 {3}/{4} 页　", this.RecordCount, this.PageRecordCount, this.PageSize, this.PageCurrent, this.PageCount);
				}
				else {
					sb.AppendFormat("共 {0} 条，每页 {1} 条，第 {2}/{3} 页　", this.RecordCount, this.PageSize, this.PageCurrent, this.PageCount);
				}
			}
			else {
				sb.AppendFormat("共 {0} 条，每页 {1} 条，第 {2}/{3} 页　", this.RecordCount, this.PageSize, this.PageCurrent, this.PageCount);
			}
			//上一页
			if (this.PageCurrent > 1) {
				sb.AppendFormat("<a href=\"{0}?{1}={2}{3}\">上一页</a>", urlPath, pagerName, this.PageCurrent - 1, parameter);
			}
			//首页
			if (this.PageCurrent > this.DigitalPageFlag + 1) {
				sb.AppendFormat("<a href=\"{0}?{1}=1{2}\">1</a>...", urlPath, pagerName, parameter);
			}
			//输出数字分页
			int number = 0;
			if (this.PageCurrent - this.DigitalPageFlag >= 1) {
				number = this.PageCurrent - this.DigitalPageFlag;
			}
			else {
				number = 1;
			}
			for (int i = number; i < number + this.DigitalPageSize && i <= this.PageCount; i++) {
				if (i == this.PageCurrent) {
					sb.AppendFormat("<span class=\"current\">{0}</span>", i);
				}
				else {
					sb.AppendFormat("<a href=\"{0}?{1}={2}{3}\">{2}</a>", urlPath, pagerName, i, parameter);
				}
			}
			//末页
			if (this.PageCurrent < this.PageCount - this.DigitalPageFlag && this.PageCurrent > this.DigitalPageSize) {
				sb.AppendFormat("...<a href=\"{0}?{1}={2}{3}\">{2}</a>", urlPath, pagerName, this.PageCount, parameter);
			}
			//下一页
			if (this.PageCurrent < this.PageCount) {
				sb.AppendFormat("<a href=\"{0}?{1}={2}{3}\">下一页</a>", urlPath, pagerName, this.PageCurrent + 1, parameter);

			}
			//跳转功能
			if (outPageGoto) {
				sb.AppendFormat("<span class=\"gotoarea\"><input type=\"hidden\" id=\"hidPagerMax\" value=\"{0}\" /><input type=\"text\" id=\"txtPagerIndex\" value=\"{5}\" /><label onclick=\"{1}('{2}?{3}=','{4}');\">跳转</label></span>", this.PageCount, outPageGotoFun, urlPath, pagerName, parameter, this.PageCurrent);
			}
			sb.Append("</div>");
			return sb.ToString();
		}

		#endregion

		#region 方向链接分页[Ajax、MVC、静态URL]

		/// <summary>
		/// 输出分页HTML标记
		/// <remarks>
		/// <para>方向链接分页[Ajax、MVC、静态URL]</para>
		/// <para>格式：首页 上一页 下一页 末页</para>
		/// <para>引用 DawnPagerUI.css 文件</para>
		/// <para>引用 DawnPagerJS.js 文件</para>
		/// </remarks>
		/// </summary>
		/// <param name="urlPath">URL路径（或页面名称）</param>
		/// <param name="parameter">URL参数，分页模式的特定格式，详见JS文件</param>
		/// <param name="outPageCount">是否输出实时页总条数，需要给PageRecordCount实时赋值</param>
		/// <param name="showSelect">是否输出页码选择器</param>
		/// <param name="pagerType">数据分页模式</param>
		/// <param name="outPageGoto">是否输出分页跳转功能代码</param>
		/// <param name="outPageGotoFun">分页跳转功能函数名称</param>
		/// <returns>HTML</returns>
		public string ShowPagerByScriptByForward(string urlPath = @"/", string parameter = null, bool outPageCount = true, bool showSelect = false, PagerType pagerType = PagerType.Mvc, bool outPageGoto = true, string outPageGotoFun = "DawnPagerGoto") {
			var tmpResult = this.BalefulToPager();
			if (!string.IsNullOrEmpty(tmpResult)) return tmpResult;
			StringBuilder sb = new StringBuilder();
			sb.Append("<div id=\"pagerList\">");
			//分页数据信息
			if (outPageCount) {
				if (this.PageRecordCount > 0 && this.PageRecordCount < this.PageSize) {
					sb.AppendFormat("共 {0} 条，每页 {1}/{2} 条，第 {3}/{4} 页　", this.RecordCount, this.PageRecordCount, this.PageSize, this.PageCurrent, this.PageCount);
				}
				else {
					sb.AppendFormat("共 {0} 条，每页 {1} 条，第 {2}/{3} 页　", this.RecordCount, this.PageSize, this.PageCurrent, this.PageCount);
				}
			}
			else {
				sb.AppendFormat("共 {0} 条，每页 {1} 条，第 {2}/{3} 页　", this.RecordCount, this.PageSize, this.PageCurrent, this.PageCount);
			}
			//判断并确认数据分页模式
			var jsFunName = "DawnPagerHandler";
			switch (pagerType) {
				case PagerType.Ajax:
					jsFunName = "DawnPagerHandler";
					break;
				case PagerType.Mvc:
					jsFunName = "DawnPagerMvc";
					break;
				case PagerType.Url:
					jsFunName = "DawnPagerUrl";
					break;
			}
			//首页
			if (this.PageCurrent == 1) {
				sb.Append("<span>首页</span>");
			}
			else {
				sb.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"{0}('{1}',1,'{2}');\">首页</a>", jsFunName, urlPath, parameter);
			}
			//上一页
			if (this.PageCurrent <= 1) {
				sb.Append("&nbsp;&nbsp;<span>上一页</span>&nbsp;&nbsp;");
			}
			else {
				sb.AppendFormat("&nbsp;&nbsp;<a href=\"javascript:void(0);\" onclick=\"{0}('{1}',{2},'{3}');\">上一页</a>&nbsp;&nbsp;", jsFunName, urlPath, this.PageCurrent - 1, parameter);
			}
			//下一页
			if (this.PageCurrent >= this.PageCount) {
				sb.Append("<span>下一页</span>&nbsp;&nbsp;");
			}
			else {
				sb.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"{0}('{1}',{2},'{3}');\">下一页</a>&nbsp;&nbsp;", jsFunName, urlPath, this.PageCurrent + 1, parameter);
			}
			//末页
			if (this.PageCurrent == this.PageCount | this.PageCount == 0) {
				sb.Append("<span>末页</span>");
			}
			else {
				sb.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"{0}('{1}',{2},'{3}');\">末页</a>", jsFunName, urlPath, this.PageCount, parameter);
			}
			//页码选择器
			if (showSelect) {
				sb.AppendFormat("&nbsp;&nbsp;<select onchange=\"{0}('{1}',this.value,'{2}');\">", jsFunName, urlPath, parameter);
				for (int i = 1; i <= this.PageCount; i++) {
					if (i == this.PageCurrent) {
						sb.AppendFormat("<option value=\"{0}\" selected=\"selected\">{0}</option>", i);
					}
					else {
						sb.AppendFormat("<option value=\"{0}\">{0}</option>", i);
					}
				}
				sb.Append("</select>");
			}
			//跳转功能
			if (outPageGoto) {
				sb.AppendFormat("<span class=\"gotoarea\"><input type=\"hidden\" id=\"hidPagerMax\" value=\"{0}\" /><input type=\"text\" id=\"txtPagerIndex\" value=\"{5}\" /><label onclick=\"{1}('{2}','{3}','{4}');\">跳转</label></span>", this.PageCount, outPageGotoFun, urlPath, jsFunName, parameter, this.PageCurrent);
			}
			sb.Append("</div>");
			return sb.ToString();
		}

		#endregion

		#region 数字链接分页[Ajax、MVC、静态URL]

		/// <summary>
		/// 输出分页HTML标记
		/// <remarks>
		/// <para>数字链接分页[Ajax、MVC、静态URL]</para>
		/// <para>默认每页9链接，必须为单数</para>
		/// <para>格式：上一页 1 2...10 下一页</para>
		/// <para>引用 DawnPagerUI.css 文件</para>
		/// <para>引用 DawnPagerJS.js 文件</para>
		/// </remarks>
		/// </summary>
		/// <param name="urlPath">URL路径（或页面名称）</param>
		/// <param name="parameter">URL参数，分页模式的特定格式，详见JS文件</param>
		/// <param name="outPageCount">是否输出实时页总条数，需要给PageRecordCount实时赋值</param>
		/// <param name="pagerType">数据分页模式</param>
		/// <param name="outPageGoto">是否输出分页跳转功能代码</param>
		/// <param name="outPageGotoFun">分页跳转功能函数名称</param>
		/// <returns>HTML</returns>
		public string ShowPagerByScriptByNumeric(string urlPath = @"/", string parameter = null, bool outPageCount = true, PagerType pagerType = PagerType.Mvc, bool outPageGoto = true, string outPageGotoFun = "DawnPagerGoto") {
			var tmpResult = this.BalefulToPager();
			if (!string.IsNullOrEmpty(tmpResult)) return tmpResult;
			//计算数字分页
			if (this.PageCount % this.DigitalPageSize == 0) {
				this.DigitalPageCount = this.PageCount / this.DigitalPageSize;
			}
			else {
				this.DigitalPageCount = this.PageCount / this.DigitalPageSize + 1;
			}
			StringBuilder sb = new StringBuilder();
			sb.Append("<div id=\"pagerList\">");
			//分页数据信息
			if (outPageCount) {
				if (this.PageRecordCount > 0 && this.PageRecordCount < this.PageSize) {
					sb.AppendFormat("共 {0} 条，每页 {1}/{2} 条，第 {3}/{4} 页　", this.RecordCount, this.PageRecordCount, this.PageSize, this.PageCurrent, this.PageCount);
				}
				else {
					sb.AppendFormat("共 {0} 条，每页 {1} 条，第 {2}/{3} 页　", this.RecordCount, this.PageSize, this.PageCurrent, this.PageCount);
				}
			}
			else {
				sb.AppendFormat("共 {0} 条，每页 {1} 条，第 {2}/{3} 页　", this.RecordCount, this.PageSize, this.PageCurrent, this.PageCount);
			}
			//判断并确认数据分页模式
			var jsFunName = "DawnPagerHandler";
			switch (pagerType) {
				case PagerType.Ajax:
					jsFunName = "DawnPagerHandler";
					break;
				case PagerType.Mvc:
					jsFunName = "DawnPagerMvc";
					break;
				case PagerType.Url:
					jsFunName = "DawnPagerUrl";
					break;
			}
			//上一页
			if (this.PageCurrent > 1) {
				sb.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"{0}('{1}',{2},'{3}');\">上一页</a>", jsFunName, urlPath, this.PageCurrent - 1, parameter);
			}
			//首页
			if (this.PageCurrent > this.DigitalPageFlag + 1) {
				sb.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"{0}('{1}',1,'{2}');\">1</a>...", jsFunName, urlPath, parameter);
			}
			//输出数字分页
			int number = 0;
			if (this.PageCurrent - this.DigitalPageFlag >= 1) {
				number = this.PageCurrent - this.DigitalPageFlag;
			}
			else {
				number = 1;
			}
			for (int i = number; i < number + this.DigitalPageSize && i <= this.PageCount; i++) {
				if (i == this.PageCurrent) {
					sb.AppendFormat("<span class=\"current\">{0}</span>", i);
				}
				else {
					sb.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"{0}('{1}',{2},'{3}');\">{2}</a>", jsFunName, urlPath, i, parameter);
				}
			}
			//末页
			if (this.PageCurrent < this.PageCount - this.DigitalPageFlag && this.PageCurrent > this.DigitalPageSize) {
				sb.AppendFormat("...<a href=\"javascript:void(0);\" onclick=\"{0}('{1}',{2},'{3}');\">{2}</a>", jsFunName, urlPath, this.PageCount, parameter);
			}
			//下一页
			if (this.PageCurrent < this.PageCount) {
				sb.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"{0}('{1}',{2},'{3}');\">下一页</a>", jsFunName, urlPath, this.PageCurrent + 1, parameter);
			}
			//跳转功能
			if (outPageGoto) {
				sb.AppendFormat("<span class=\"gotoarea\"><input type=\"hidden\" id=\"hidPagerMax\" value=\"{0}\" /><input type=\"text\" id=\"txtPagerIndex\" value=\"{5}\" /><label onclick=\"{1}('{2}','{3}','{4}');\">跳转</label></span>", this.PageCount, outPageGotoFun, urlPath, jsFunName, parameter, this.PageCurrent);
			}
			sb.Append("</div>");
			return sb.ToString();
		}

		#endregion

		#region 方向链接分页·无地址[Ajax、MVC、静态URL]

		/// <summary>
		/// 输出分页HTML标记
		/// <remarks>
		/// <para>方向链接分页·无地址[Ajax、MVC、静态URL]</para>
		/// <para>格式：首页 上一页 下一页 末页</para>
		/// <para>引用 DawnPagerUI.css 文件</para>
		/// <para>引用 DawnPagerJS.js 文件</para>
		/// </remarks>
		/// </summary>
		/// <param name="parameter">URL参数，分页模式的特定格式，详见JS文件</param>
		/// <param name="outPageCount">是否输出实时页总条数，需要给PageRecordCount实时赋值</param>
		/// <param name="showSelect">是否输出页码选择器</param>
		/// <param name="pagerType">数据分页模式</param>
		/// <param name="outPageGoto">是否输出分页跳转功能代码</param>
		/// <param name="outPageGotoFun">分页跳转功能函数名称</param>
		/// <returns>HTML</returns>
		public string ShowPagerByScriptByForwardOf(string parameter = null, bool outPageCount = true, bool showSelect = false, PagerType pagerType = PagerType.Mvc, bool outPageGoto = true, string outPageGotoFun = "DawnPagerGotoOf") {
			var tmpResult = this.BalefulToPager();
			if (!string.IsNullOrEmpty(tmpResult)) return tmpResult;
			StringBuilder sb = new StringBuilder();
			sb.Append("<div id=\"pagerList\">");
			//分页数据信息
			if (outPageCount) {
				if (this.PageRecordCount > 0 && this.PageRecordCount < this.PageSize) {
					sb.AppendFormat("共 {0} 条，每页 {1}/{2} 条，第 {3}/{4} 页　", this.RecordCount, this.PageRecordCount, this.PageSize, this.PageCurrent, this.PageCount);
				}
				else {
					sb.AppendFormat("共 {0} 条，每页 {1} 条，第 {2}/{3} 页　", this.RecordCount, this.PageSize, this.PageCurrent, this.PageCount);
				}
			}
			else {
				sb.AppendFormat("共 {0} 条，每页 {1} 条，第 {2}/{3} 页　", this.RecordCount, this.PageSize, this.PageCurrent, this.PageCount);
			}
			//判断并确认数据分页模式
			var jsFunName = "DawnPagerHandlerOf";
			switch (pagerType) {
				case PagerType.Ajax:
					jsFunName = "DawnPagerHandlerOf";
					break;
				case PagerType.Mvc:
					jsFunName = "DawnPagerMvcOf";
					break;
				case PagerType.Url:
					jsFunName = "DawnPagerUrlOf";
					break;
			}
			//首页
			if (this.PageCurrent == 1) {
				sb.Append("<span>首页</span>");
			}
			else {
				sb.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"{0}(1,'{1}');\">首页</a>", jsFunName, parameter);
			}
			//上一页
			if (this.PageCurrent <= 1) {
				sb.Append("&nbsp;&nbsp;<span>上一页</span>&nbsp;&nbsp;");
			}
			else {
				sb.AppendFormat("&nbsp;&nbsp;<a href=\"javascript:void(0);\" onclick=\"{0}({1},'{2}');\">上一页</a>&nbsp;&nbsp;", jsFunName, this.PageCurrent - 1, parameter);
			}
			//下一页
			if (this.PageCurrent >= this.PageCount) {
				sb.Append("<span>下一页</span>&nbsp;&nbsp;");
			}
			else {
				sb.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"{0}({1},'{2}');\">下一页</a>&nbsp;&nbsp;", jsFunName, this.PageCurrent + 1, parameter);
			}
			//末页
			if (this.PageCurrent == this.PageCount | this.PageCount == 0) {
				sb.Append("<span>末页</span>");
			}
			else {
				sb.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"{0}({1},'{2}');\">末页</a>", jsFunName, this.PageCount, parameter);
			}
			//页码选择器
			if (showSelect) {
				sb.AppendFormat("&nbsp;&nbsp;<select onchange=\"{0}(this.value,'{1}');\">", jsFunName, parameter);
				for (int i = 1; i <= this.PageCount; i++) {
					if (i == this.PageCurrent) {
						sb.AppendFormat("<option value=\"{0}\" selected=\"selected\">{0}</option>", i);
					}
					else {
						sb.AppendFormat("<option value=\"{0}\">{0}</option>", i);
					}
				}
				sb.Append("</select>");
			}
			//跳转功能
			if (outPageGoto) {
				sb.AppendFormat("<span class=\"gotoarea\"><input type=\"hidden\" id=\"hidPagerMax\" value=\"{0}\" /><input type=\"text\" id=\"txtPagerIndex\" value=\"{4}\" /><label onclick=\"{1}('{2}','{3}');\">跳转</label></span>", this.PageCount, outPageGotoFun, jsFunName, parameter, this.PageCurrent);
			}
			sb.Append("</div>");
			return sb.ToString();
		}

		#endregion

		#region 数字链接分页·无地址[Ajax、MVC、静态URL]

		/// <summary>
		/// 输出分页HTML标记
		/// <remarks>
		/// <para>数字链接分页·无地址[Ajax、MVC、静态URL]</para>
		/// <para>默认每页9链接，必须为单数</para>
		/// <para>格式：上一页 1 2...10 下一页</para>
		/// <para>引用 DawnPagerUI.css 文件</para>
		/// <para>引用 DawnPagerJS.js 文件</para>
		/// </remarks>
		/// </summary>
		/// <param name="parameter">URL参数，分页模式的特定格式，详见JS文件</param>
		/// <param name="outPageCount">是否输出实时页总条数，需要给PageRecordCount实时赋值</param>
		/// <param name="pagerType">数据分页模式</param>
		/// <param name="outPageGoto">是否输出分页跳转功能代码</param>
		/// <param name="outPageGotoFun">分页跳转功能函数名称</param>
		/// <returns>HTML</returns>
		public string ShowPagerByScriptByNumericOf(string parameter = null, bool outPageCount = true, PagerType pagerType = PagerType.Mvc, bool outPageGoto = true, string outPageGotoFun = "DawnPagerGotoOf") {
			var tmpResult = this.BalefulToPager();
			if (!string.IsNullOrEmpty(tmpResult)) return tmpResult;
			//计算数字分页
			if (this.PageCount % this.DigitalPageSize == 0) {
				this.DigitalPageCount = this.PageCount / this.DigitalPageSize;
			}
			else {
				this.DigitalPageCount = this.PageCount / this.DigitalPageSize + 1;
			}
			StringBuilder sb = new StringBuilder();
			sb.Append("<div id=\"pagerList\">");
			//分页数据信息
			if (outPageCount) {
				if (this.PageRecordCount > 0 && this.PageRecordCount < this.PageSize) {
					sb.AppendFormat("共 {0} 条，每页 {1}/{2} 条，第 {3}/{4} 页　", this.RecordCount, this.PageRecordCount, this.PageSize, this.PageCurrent, this.PageCount);
				}
				else {
					sb.AppendFormat("共 {0} 条，每页 {1} 条，第 {2}/{3} 页　", this.RecordCount, this.PageSize, this.PageCurrent, this.PageCount);
				}
			}
			else {
				sb.AppendFormat("共 {0} 条，每页 {1} 条，第 {2}/{3} 页　", this.RecordCount, this.PageSize, this.PageCurrent, this.PageCount);
			}
			//判断并确认数据分页模式
			var jsFunName = "DawnPagerHandlerOf";
			switch (pagerType) {
				case PagerType.Ajax:
					jsFunName = "DawnPagerHandlerOf";
					break;
				case PagerType.Mvc:
					jsFunName = "DawnPagerMvcOf";
					break;
				case PagerType.Url:
					jsFunName = "DawnPagerUrlOf";
					break;
			}
			//上一页
			if (this.PageCurrent > 1) {
				sb.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"{0}({1},'{2}');\">上一页</a>", jsFunName, this.PageCurrent - 1, parameter);
			}
			//首页
			if (this.PageCurrent > this.DigitalPageFlag + 1) {
				sb.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"{0}(1,'{1}');\">1</a>...", jsFunName, parameter);
			}
			//输出数字分页
			int number = 0;
			if (this.PageCurrent - this.DigitalPageFlag >= 1) {
				number = this.PageCurrent - this.DigitalPageFlag;
			}
			else {
				number = 1;
			}
			for (int i = number; i < number + this.DigitalPageSize && i <= this.PageCount; i++) {
				if (i == this.PageCurrent) {
					sb.AppendFormat("<span class=\"current\">{0}</span>", i);
				}
				else {
					sb.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"{0}({1},'{2}');\">{1}</a>", jsFunName, i, parameter);
				}
			}
			//末页
			if (this.PageCurrent < this.PageCount - this.DigitalPageFlag && this.PageCurrent > this.DigitalPageSize) {
				sb.AppendFormat("...<a href=\"javascript:void(0);\" onclick=\"{0}({1},'{2}');\">{1}</a>", jsFunName, this.PageCount, parameter);
			}
			//下一页
			if (this.PageCurrent < this.PageCount) {
				sb.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"{0}({1},'{2}');\">下一页</a>", jsFunName, this.PageCurrent + 1, parameter);
			}
			//跳转功能
			if (outPageGoto) {
				sb.AppendFormat("<span class=\"gotoarea\"><input type=\"hidden\" id=\"hidPagerMax\" value=\"{0}\" /><input type=\"text\" id=\"txtPagerIndex\" value=\"{4}\" /><label onclick=\"{1}('{2}','{3}');\">跳转</label></span>", this.PageCount, outPageGotoFun, jsFunName, parameter, this.PageCurrent);
			}
			sb.Append("</div>");
			return sb.ToString();
		}

		#endregion

		#region 数字链接分页·自定义前端函数[Ajax、MVC、静态URL]

		/// <summary>
		/// 输出分页HTML标记
		/// <remarks>
		/// <para>函数：funName(currentIndex,parameter)</para>
		/// <para>数字链接分页·无地址[Ajax、MVC、静态URL]</para>
		/// <para>默认每页9链接，必须为单数</para>
		/// <para>格式：上一页 1 2...10 下一页</para>
		/// <para>引用 DawnPagerUI.css 文件</para>
		/// <para>引用 DawnPagerJS.js 文件</para>
		/// </remarks>
		/// </summary>
		/// <param name="functionName">前端调用函数名称</param>
		/// <param name="parameter">URL参数，分页模式的特定格式，详见JS文件</param>
		/// <param name="outPageCount">是否输出实时页总条数，需要给PageRecordCount实时赋值</param>
		/// <param name="outPageGoto">是否输出分页跳转功能代码</param>
		/// <param name="outPageGotoFun">分页跳转功能函数名称</param>
		/// <returns>HTML</returns>
		public string ShowPagerByScriptByCustomAt(string functionName = "DawnPagerHandlerOf", string parameter = null, bool outPageCount = true, bool outPageGoto = true, string outPageGotoFun = "DawnPagerGotoOf") {
			var tmpResult = this.BalefulToPager();
			if (!string.IsNullOrEmpty(tmpResult)) return tmpResult;
			//计算数字分页
			if (this.PageCount % this.DigitalPageSize == 0) {
				this.DigitalPageCount = this.PageCount / this.DigitalPageSize;
			}
			else {
				this.DigitalPageCount = this.PageCount / this.DigitalPageSize + 1;
			}
			StringBuilder sb = new StringBuilder();
			sb.Append("<div id=\"pagerList\">");
			//分页数据信息
			if (outPageCount) {
				if (this.PageRecordCount > 0 && this.PageRecordCount < this.PageSize) {
					sb.AppendFormat("共 {0} 条，每页 {1}/{2} 条，第 {3}/{4} 页　", this.RecordCount, this.PageRecordCount, this.PageSize, this.PageCurrent, this.PageCount);
				}
				else {
					sb.AppendFormat("共 {0} 条，每页 {1} 条，第 {2}/{3} 页　", this.RecordCount, this.PageSize, this.PageCurrent, this.PageCount);
				}
			}
			else {
				sb.AppendFormat("共 {0} 条，每页 {1} 条，第 {2}/{3} 页　", this.RecordCount, this.PageSize, this.PageCurrent, this.PageCount);
			}
			//判断并确认数据分页模式
			var jsFunName = "DawnPagerHandlerOf";
			if (!string.IsNullOrEmpty(functionName)) jsFunName = functionName;
			//上一页
			if (this.PageCurrent > 1) {
				sb.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"{0}({1},'{2}');\">上一页</a>", jsFunName, this.PageCurrent - 1, parameter);
			}
			//首页
			if (this.PageCurrent > this.DigitalPageFlag + 1) {
				sb.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"{0}(1,'{1}');\">1</a>...", jsFunName, parameter);
			}
			//输出数字分页
			int number = 0;
			if (this.PageCurrent - this.DigitalPageFlag >= 1) {
				number = this.PageCurrent - this.DigitalPageFlag;
			}
			else {
				number = 1;
			}
			for (int i = number; i < number + this.DigitalPageSize && i <= this.PageCount; i++) {
				if (i == this.PageCurrent) {
					sb.AppendFormat("<span class=\"current\">{0}</span>", i);
				}
				else {
					sb.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"{0}({1},'{2}');\">{1}</a>", jsFunName, i, parameter);
				}
			}
			//末页
			if (this.PageCurrent < this.PageCount - this.DigitalPageFlag && this.PageCurrent > this.DigitalPageSize) {
				sb.AppendFormat("...<a href=\"javascript:void(0);\" onclick=\"{0}({1},'{2}');\">{1}</a>", jsFunName, this.PageCount, parameter);
			}
			//下一页
			if (this.PageCurrent < this.PageCount) {
				sb.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"{0}({1},'{2}');\">下一页</a>", jsFunName, this.PageCurrent + 1, parameter);
			}
			//跳转功能
			if (outPageGoto) {
				sb.AppendFormat("<span class=\"gotoarea\"><input type=\"hidden\" id=\"hidPagerMax\" value=\"{0}\" /><input type=\"text\" id=\"txtPagerIndex\" value=\"{4}\" /><label onclick=\"{1}('{2}','{3}');\">跳转</label></span>", this.PageCount, outPageGotoFun, jsFunName, parameter, this.PageCurrent);
			}
			sb.Append("</div>");
			return sb.ToString();
		}

		#endregion

		#endregion

	}
}
