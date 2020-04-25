using System;
using System.Collections.Generic;
using System.Text;

namespace System.Web.Mvc
{
    /// <summary>
    /// 复选框列表控件扩展
    /// </summary>
    public static class CheckBoxListExtensions
    {
        /// <summary>
        /// 复选框列表控件
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        /// <param name="name">控件名称</param>
        /// <param name="isSelected">是否全部选中</param>
        /// <param name="selectList">选定项集合</param>
        /// <returns>复选框列表控件</returns>
        public static MvcHtmlString CheckBoxList(this HtmlHelper helper, string name, bool isSelected, IEnumerable<SelectListItem> selectList)
        {
            return CheckBoxList(helper, name, isSelected, selectList, new { });
        }
        /// <summary>
        /// /// 复选框列表控件
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        /// <param name="name">控件名称</param>
        /// <param name="isSelected">是否全部选中</param>
        /// <param name="selectList">选定项集合</param>
        /// <param name="htmlAttributes">Http 属性</param>
        /// <returns>复选框列表控件</returns>
        public static MvcHtmlString CheckBoxList(this HtmlHelper helper, string name, bool isSelected, IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            IDictionary<string, object> HtmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            HtmlAttributes.Add("type", "checkbox");
            HtmlAttributes.Add("id", name);
            HtmlAttributes.Add("name", name);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (SelectListItem selectItem in selectList)
            {
                IDictionary<string, object> newHtmlAttributes = HtmlAttributes.DeepCopy();
                newHtmlAttributes.Add("value", selectItem.Value);
                newHtmlAttributes.Add("texts", selectItem.Text);
                if (selectItem.Selected || isSelected)
                {
                    newHtmlAttributes.Add("checked", "checked");
                }
                TagBuilder tagBuilder = new TagBuilder("input");
                tagBuilder.MergeAttributes<string, object>(newHtmlAttributes);
                string inputAllHtml = tagBuilder.ToString(TagRenderMode.SelfClosing);
                stringBuilder.AppendFormat(@"<p> {0}  {1}</p>", inputAllHtml, selectItem.Text);
            }
            return MvcHtmlString.Create(stringBuilder.ToString());
        }
        /// <summary>
        /// 深度复制
        /// </summary>
        /// <param name="ht">键/值对泛型集合</param>
        /// <returns>键/值对泛型集合</returns>
        private static IDictionary<string, object> DeepCopy(this IDictionary<string, object> ht)
        {
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            foreach (var p in ht)
            {
                _ht.Add(p.Key, p.Value);
            }
            return _ht;
        }
    }
}