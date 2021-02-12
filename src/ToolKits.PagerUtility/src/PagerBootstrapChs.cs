//==================================================================== 
//**   晨曦小竹常用工具集
//====================================================================
//**   Copyright © DawnXZ.com 2015 -- QQ：6808240 -- 请保留此注释
//====================================================================
// 文件名称：PagerBootstrapChs.cs
// 项目名称：数据分页展示工具集
// 创建时间：2015-05-31 18:58:14
// 创建人员：宋杰军
// 负 责 人：宋杰军
// 参与人员：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System.Text;

namespace DawnXZ.PagerUtility {
	/// <summary>
	/// 数据分页[HTML标签模式]
	/// <para>中文字样</para>
	/// </summary>
	public class PagerBootstrapChs {
		/// <summary>
		/// 构造函数
		/// </summary>
		public PagerBootstrapChs() {
			this.PageCurrent = 1;
			this.PageCount = 0;
			this.PageSize = 20;
			this.DigitalPageSize = 7;
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="digitalpagesize">数字分页—每页个数</param>
		public PagerBootstrapChs(int digitalpagesize) {
			this.PageCurrent = 1;
			this.PageCount = 0;
			this.PageSize = 20;
			this.DigitalPageSize = digitalpagesize;
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="pagesize">每页显示记录数</param>
		/// <param name="digitalpagesize">数字分页—每页个数</param>
		public PagerBootstrapChs(int pagesize, int digitalpagesize) {
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
		public PagerBootstrapChs(int pagecurrent, int pagecount, int pagesize, int digitalpagesize) {
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

		#region 成员变量

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

		#region 成员方法

		/// <summary>
		/// 恶意使用分页控件
		/// </summary>
		/// <returns>执行结果</returns>
		private string BalefulToPager() {
			var sb = new StringBuilder();
			if (this.RecordCount > 0 && this.PageCurrent > this.PageCount) {
				sb.Append("<nav class=\"text-center\">");
				sb.Append("<ul class=\"pagination\">");
				sb.Append("<li>");
				sb.Append("<span>请勿恶意使用本分页控件。（当前页码已大于总页码……）</span>");
				sb.Append("</li>");
				sb.Append("</ul>");
				sb.Append("</nav>");
			}
			return sb.ToString();
		}
		/// <summary>
		/// 输出分页HTML标记
		/// <para>基于Bootstrap数字分页功能</para>
		/// </summary>
		/// <param name="urlPath">URL路径（或页面名称）</param>
		/// <param name="parameter">URL参数，分页模式的特定格式，详见JS文件</param>
		/// <param name="outCount">是否输出实时页总条数，需要给PageRecordCount实时赋值</param>
		/// <param name="outGoto">是否输出分页跳转功能代码</param>
		/// <param name="controlName">控件ID名称</param>
		/// <returns>HTML标签</returns>
		public string ShowPager(string urlPath = @"/", string parameter = null, bool outCount = true, bool outGoto = true, string controlName = "panelPager") {
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
			sb.AppendFormat("<nav class=\"text-center\" id=\"{0}\">", controlName);
			sb.Append("<ul class=\"pagination\">");
			//分页数据信息
			sb.Append("<li>");
			if (outCount && this.PageRecordCount > 0 && this.PageRecordCount < this.PageSize) {
				sb.AppendFormat("<span>共{0}条，每页{1}/{2}条，第{3}/{4}页</span>", this.RecordCount, this.PageRecordCount, this.PageSize, this.PageCurrent, this.PageCount);
			}
			else {
				sb.AppendFormat("<span>共{0}条，每页{1}条，第{2}/{3}页</span>", this.RecordCount, this.PageSize, this.PageCurrent, this.PageCount);
			}
			sb.Append("</li>");
			//上一页
			if (this.PageCurrent > 1) {
				sb.Append("<li>");
				sb.AppendFormat("<a href=\"javascript:void(0);\" aria-label=\"Previous\" onclick=\"DawnPagination('{0}',{1},'{2}');\">", urlPath, this.PageCurrent - 1, parameter);
				sb.Append("<span aria-hidden=\"true\">&laquo;</span>");
				sb.Append("</a>");
				sb.Append("</li>");
			}
			else {
				sb.Append("<li class=\"disabled\">");
				sb.Append("<a href=\"javascript:void(0);\" aria-label=\"Previous\">");
				sb.Append("<span aria-hidden=\"true\">&laquo;</span>");
				sb.Append("</a>");
				sb.Append("</li>");
			}
			//首页
			if (this.PageCurrent > this.DigitalPageFlag + 1) {
				sb.Append("<li>");
				sb.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"DawnPagination('{0}',1,'{1}');\">1</a><span>...</span>", urlPath, parameter);
				sb.Append("</li>");
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
					sb.AppendFormat("<li class=\"active\"><a href=\"javascript:void(0);\">{0} <span class=\"sr-only\">(current)</span></a></li>", i);
				}
				else {
					sb.Append("<li>");
					sb.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"DawnPagination('{0}',{1},'{2}');\">{1}</a>", urlPath, i, parameter);
					sb.Append("</li>");
				}
			}
			//末页
			if (this.PageCurrent < this.PageCount - this.DigitalPageFlag && this.PageCurrent > this.DigitalPageSize) {
				sb.Append("<li>");
				sb.AppendFormat("<span>...</span><a href=\"javascript:void(0);\" onclick=\"DawnPagination('{0}',{1},'{2}');\">{1}</a>", urlPath, this.PageCount, parameter);
				sb.Append("</li>");
			}
			//下一页
			if (this.PageCurrent < this.PageCount) {
				sb.Append("<li>");
				sb.AppendFormat("<a href=\"javascript:void(0);\" aria-label=\"Next\" onclick=\"DawnPagination('{0}',{1},'{2}');\">", urlPath, this.PageCurrent + 1, parameter);
				sb.Append("<span aria-hidden=\"true\">&raquo;</span>");
				sb.Append("</a>");
				sb.Append("</li>");
			}
			else {
				sb.Append("<li class=\"disabled\">");
				sb.Append("<a href=\"javascript:void(0);\" aria-label=\"Next\">");
				sb.Append("<span aria-hidden=\"true\">&raquo;</span>");
				sb.Append("</a>");
				sb.Append("</li>");
			}
			//跳转功能
			if (outGoto) {
				sb.Append("<li>");
				sb.Append("<div class=\"input-group f-wfx12 pull-left\">");
				sb.AppendFormat("<input type=\"hidden\" id=\"hidPagerMax\" value=\"{0}\" />", this.PageCount);
				sb.AppendFormat("<input type=\"text\" class=\"form-control\" id=\"txtPagerIndex\" placeholder=\"跳转...\" value=\"{0}\" />", this.PageCurrent);
				sb.Append("<span class=\"input-group-btn\">");
				sb.AppendFormat("<button class=\"btn btn-default\" type=\"button\" onclick=\"DawnPagerGoto('{0}','{1}');\">Go!</button>", urlPath, parameter);
				sb.Append("</span>");
				sb.Append("</div>");
				sb.Append("</li>");
			}
			sb.Append("</ul>");
			sb.Append("</nav>");
			sb.Append("<div class=\"clearfix\"></div>");
			return sb.ToString();
		}

		#endregion

	}
}
