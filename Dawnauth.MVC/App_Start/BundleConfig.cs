using System.Web;
using System.Web.Optimization;

namespace DawnXZ.Dawnauth.MVC
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            /*------------------------------------------------------------
            ----  JavaScript：JQuery
            ------------------------------------------------------------*/
            bundles.Add(new ScriptBundle("~/js/jquery").Include(
                        "~/JQuery/jquery-{version}.js",
                        "~/JQuery/jquery.cookie.js"
                    ));
            /*------------------------------------------------------------
            ----  JavaScript：JQuery UI
            ------------------------------------------------------------*/
            bundles.Add(new ScriptBundle("~/js/jqueryui").Include(
                        "~/JQuery/jquery.tipTip.js",
                        "~/JQuery/jquery-ui-{version}.js",
                        "~/JQuery/jquery-ui-timepicker-addon.js",
                        "~/JQuery/jquery-ui-timepicker-zh-CN.js",
                        "~/JQuery/jquery-ui-timepicker-slider.js"
                    ));
            /*------------------------------------------------------------
            ----  JavaScript：Modernizr
            ------------------------------------------------------------*/
            // 使用 Modernizr 的开发版本进行开发和了解信息。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/js/modernizr").Include(
                        "~/Scripts/private/modernizr-*"
                    ));
            /*------------------------------------------------------------
            ----  JavaScript：Login
            ------------------------------------------------------------*/
            bundles.Add(new ScriptBundle("~/js/login").Include(
                        "~/Scripts/public/login.js"
                    ));
            /*------------------------------------------------------------
            ----  JavaScript：Body
            ------------------------------------------------------------*/
            bundles.Add(new ScriptBundle("~/js/body").Include(
                        "~/Scripts/public/Global.js",
                        "~/Pager/PagerHelper.js",
                        "~/Scripts/public/body.js"                        
                    ));
            /*------------------------------------------------------------
            ----  JavaScript：Editor
            ------------------------------------------------------------*/
            bundles.Add(new ScriptBundle("~/js/editor").Include(
                        "~/Scripts/public/Global.js"
                    ));
            /*------------------------------------------------------------
            ----  JavaScript：Dialog
            ------------------------------------------------------------*/
            bundles.Add(new ScriptBundle("~/js/dialog").Include(
                        "~/Scripts/public/Dialog.js"
                    ));
            /*------------------------------------------------------------
            ----  Style：登录页样式表
            ------------------------------------------------------------*/
            bundles.Add(new StyleBundle("~/css/login").Include(
                        "~/Content/reset.css",
                        "~/Content/style.css",                        
                        "~/Content/login.css",
                        "~/Content/invalid.css"
                    ));
            /*------------------------------------------------------------
            ----  Style：列表页样式表
            ------------------------------------------------------------*/
            bundles.Add(new StyleBundle("~/css/body").Include(
                        "~/Content/reset.css",
                        "~/Content/style.css",
                        "~/Content/uimain.css",
                        "~/Pager/PagerHelper.css",
                        "~/Content/body.css",
                        "~/Content/invalid.css"
                    ));
            /*------------------------------------------------------------
            ----  Style：编辑页样式表
            ------------------------------------------------------------*/
            bundles.Add(new StyleBundle("~/css/editor").Include(
                        "~/Content/reset.css",
                        "~/Content/style.css",
                        "~/Content/uimain.css",
                        "~/Content/editor.css",
                        "~/Content/invalid.css"
                    ));
            /*------------------------------------------------------------
            ----  Style：弹出式编辑页样式表
            ------------------------------------------------------------*/
            bundles.Add(new StyleBundle("~/css/dialog").Include(
                        "~/Content/reset.css",
                        "~/Content/style.css",
                        "~/Content/uimain.css",
                        "~/Content/dialog.css",
                        "~/Content/invalid.css"
                    ));
            /*------------------------------------------------------------
            ----  Style：JQuery UI 样式
            ------------------------------------------------------------*/
            bundles.Add(new StyleBundle("~/css/jqueryui").Include(
                        "~/JQuery/skins/jquery.ui.all.css",
                        "~/JQuery/skins/jquery.ui.tipTip.css",
                        "~/JQuery/skins/jquery-ui-timepicker-addon.css"
                    ));
            /*------------------------------------------------------------
            ----  正则表达式值验证 - JavaScript
            ------------------------------------------------------------*/
            bundles.Add(new ScriptBundle("~/js/validate").Include(
                        "~/Validate/dawnxz.define.js",
                        "~/Validate/dawnxz.regular.js",
                        "~/Validate/dawnxz.tips.js",
                        "~/Validate/dawnxz.validator.js"
                    ));
            /*------------------------------------------------------------
            ----  弹出对话框 - JavaScript & Style
            ------------------------------------------------------------*/
            bundles.Add(new ScriptBundle("~/js/art").Include(
                        "~/ArtDialog/artdialog-{version}.js",
                        "~/ArtDialog/artdialog-tools.js",
                        "~/ArtDialog/artdialog-zindex.js"
                    ));
            //bundles.Add(new StyleBundle("~/css/art").Include(
            //            "~/ArtDialog/skins/aero.css"
            //        ));
            bundles.Add(new StyleBundle("~/css/art").Include(
                        "~/ArtDialog/skins/black.css"
                    ));
            //bundles.Add(new StyleBundle("~/css/art").Include(
            //            "~/ArtDialog/skins/blue.css"
            //        ));
            //bundles.Add(new StyleBundle("~/css/art").Include(
            //            "~/ArtDialog/skins/chrome.css"
            //        ));
            //bundles.Add(new StyleBundle("~/css/art").Include(
            //            "~/ArtDialog/skins/default.css"
            //        ));
            //bundles.Add(new StyleBundle("~/css/art").Include(
            //            "~/ArtDialog/skins/green.css"
            //        ));
            //bundles.Add(new StyleBundle("~/css/art").Include(
            //            "~/ArtDialog/skins/idialog.css"
            //        ));
            //bundles.Add(new StyleBundle("~/css/art").Include(
            //            "~/ArtDialog/skins/opera.css"
            //        ));
            //bundles.Add(new StyleBundle("~/css/art").Include(
            //            "~/ArtDialog/skins/simple.css"
            //        ));
            //bundles.Add(new StyleBundle("~/css/art").Include(
            //            "~/ArtDialog/skins/twitter.css"
            //        ));
        }
    }
}