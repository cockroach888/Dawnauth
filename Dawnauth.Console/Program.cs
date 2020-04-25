using System;
using System.IO;
using System.Text;
using System.Threading;
using DawnXZ.Dawnauth.BLL;
using DawnXZ.DawnUtility;
using DawnXZ.FileUtility;

namespace DawnXZ.Dawnauth.Builder
{
    /// <summary>
    /// 主程序
    /// </summary>
    class Program
    {
        /// <summary>
        /// 主函数
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Title = "晨曦小竹权限云管理系统";
            Console.WriteLine("****************************************");
            Console.WriteLine("**                                    **");
            Console.WriteLine("**     《晨曦小竹权限云管理系统》       **");
            Console.WriteLine("**                                    **");
            Console.WriteLine("**    模块信息、模块功能、状态机制    **");
            Console.WriteLine("**                                    **");
            Console.WriteLine("**       数据自动生成处理器 v1.0      **");
            Console.WriteLine("**                                    **");
            Console.WriteLine("**                                    **");
            Console.WriteLine("**        1、生成模块信息             **");
            Console.WriteLine("**        2、生成模块功能             **");
            Console.WriteLine("**        3、生成状态机制             **");
            Console.WriteLine("**        4、生成实时模块             **");
            Console.WriteLine("**        5、生成实时功能             **");
            Console.WriteLine("**        Q、退出并生成文件           **");
            Console.WriteLine("**                                    **");
            Console.WriteLine("**                                    **");
            Console.WriteLine("****************************************");
            ConsoleKey key;
            bool FFlg1 = false, FFlg2 = false, FFlg3 = false, FFlg4 = false, FFlg5 = false;
            StringBuilder sb = new StringBuilder();
            BuildHeader(ref sb);

            #region Do while

            do
            {
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.D1 && !FFlg1)
                {
                    FFlg1 = true;
                    Console.WriteLine("生成模块信息中，请稍等...");
                    BuildModule(ref sb);
                    Console.WriteLine("生成模块信息完成！");
                    Console.WriteLine();
                }
                else if (key == ConsoleKey.D2 && !FFlg2)
                {
                    FFlg2 = true;
                    Console.WriteLine("生成模块功能中，请稍等...");
                    BuildFunction(ref sb);
                    Console.WriteLine("生成模块功能完成！");
                    Console.WriteLine();
                }
                else if (key == ConsoleKey.D3 && !FFlg3)
                {
                    FFlg3 = true;
                    Console.WriteLine("生成状态机制中，请稍等...");
                    BuildStatus(ref sb);
                    Console.WriteLine("生成状态机制完成！");
                    Console.WriteLine();
                }
                else if (key == ConsoleKey.D4 && !FFlg4)
                {
                    FFlg4 = true;
                    Console.WriteLine("生成实时模块中，请稍等...");
                    BuildRealMoudle(ref sb);
                    Console.WriteLine("生成实时模块完成！");
                    Console.WriteLine();
                }
                else if (key == ConsoleKey.D5 && !FFlg5)
                {
                    FFlg5 = true;
                    Console.WriteLine("生成实时功能中，请稍等...");
                    BuildRealFunction(ref sb);
                    Console.WriteLine("生成实时功能完成！");
                    Console.WriteLine();
                }
            } while (key != ConsoleKey.Q);

            #endregion

            BuildFooter(ref sb);
            BuildFile(ref sb);
        }

        #region 生成文件

        /// <summary>
        /// 生成文件
        /// </summary>
        /// <param name="sb">字段串</param>
        static void BuildFile(ref StringBuilder sb)
        {
            string filePath = Path.Combine(FileHelper.AppPath, "DawnDefine.cs");
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(sb.ToString());
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
                fs.Dispose();
            }
            sb.Clear();
            sb = null;
        }

        #endregion

        #region 生成文件头

        /// <summary>
        /// 生成文件头
        /// </summary>
        /// <param name="sb">字段串</param>
        static void BuildHeader(ref StringBuilder sb)
        {
            sb.Append("using System;\n");
            sb.Append("\n");
            sb.Append("namespace DawnXZ.Dawnauth.Libraries\n");
            sb.Append("{\n");
            sb.Append("/// <summary>\n");
            sb.Append("/// 晨曦小竹权限云管理系统\n");
            sb.Append("/// <para>模块及功能定义</para>\n");
            sb.Append("/// </summary>\n");
            sb.Append("public class DawnAuthdef\n");
            sb.Append("{\n");
        }

        #endregion

        #region 生成文件尾

        /// <summary>
        /// 生成文件尾
        /// </summary>
        /// <param name="sb">字段串</param>
        static void BuildFooter(ref StringBuilder sb)
        {
            sb.Append("\n");
            sb.Append("}\n");
            sb.Append("}\n");
        }

        #endregion

        #region 生成模块信息

        /// <summary>
        /// 生成模块信息
        /// </summary>
        /// <param name="sb">字符串</param>
        static void BuildModule(ref StringBuilder sb)
        {
            var mdlList = DawnAuthModuleBLL.ISelect("mdl_ident<1", "mdl_rank");
            if (mdlList.Count > 0)
            {
                sb.Append("\n");
                sb.Append("#region 模块列表\n");
                sb.Append("\n");
                foreach (var item in mdlList)
                {
                    sb.Append("/// <summary>\n");
                    sb.AppendFormat("/// {0}\n", item.MdlName);
                    if (!string.IsNullOrEmpty(item.MdlDesc))
                    {
                        sb.Append("/// <remarks>\n");
                        sb.AppendFormat("/// {0}\n", item.MdlDesc);
                        sb.Append("/// </remarks>\n");
                    }
                    sb.Append("/// </summary>\n");
                    sb.AppendFormat("public const string ModuleBy{0} = \"{0}\";\n", item.MdlCode);
                }
                sb.Append("\n");
                sb.Append("#endregion\n");
            }
        }

        #endregion

        #region 生成模块功能

        /// <summary>
        /// 生成模块功能
        /// </summary>
        /// <param name="sb">字符串</param>
        static void BuildFunction(ref StringBuilder sb)
        {
            var mdlList = DawnAuthModuleBLL.ISelect("mdl_ident<1", "mdl_rank");
            if (mdlList.Count > 0)
            {
                foreach (var mdlInfo in mdlList)
                {
                    var funList = DawnAuthFunctionBLL.ISelect(string.Format("mdl_id='{0}' and fun_ident < 1", mdlInfo.MdlId), "fun_mark");
                    if (funList.Count > 0)
                    {
                        sb.Append("\n");
                        sb.AppendFormat("#region {0}\n", mdlInfo.MdlName);
                        sb.Append("\n");
                        sb.Append("/// <summary>\n");
                        sb.AppendFormat("/// {0}\n", mdlInfo.MdlName);
                        if (!string.IsNullOrEmpty(mdlInfo.MdlDesc))
                        {
                            sb.Append("/// <remarks>\n");
                            sb.AppendFormat("/// {0}\n", mdlInfo.MdlDesc);
                            sb.Append("/// </remarks>\n");
                        }
                        sb.Append("/// </summary>\n");
                        sb.AppendFormat("public enum {0} : int\n", mdlInfo.MdlCode);
                        sb.Append("{\n");
                        int funCount = funList.Count;
                        foreach (var funInfo in funList)
                        {
                            funCount--;
                            sb.Append("/// <summary>\n");
                            sb.AppendFormat("/// {0}\n", funInfo.FunName);
                            sb.Append("/// </summary>\n");
                            if (funCount > 0)
                            {
                                sb.AppendFormat("{0}={1},\n", funInfo.FunCode, funInfo.FunMark);
                            }
                            else
                            {
                                sb.AppendFormat("{0}={1}\n", funInfo.FunCode, funInfo.FunMark);
                            }
                        }
                        sb.Append("}\n");
                        sb.Append("\n");
                        sb.Append("#endregion\n");
                    }
                }
            }
        }

        #endregion

        #region 生成状态机制

        /// <summary>
        /// 生成状态机制
        /// </summary>
        /// <param name="sb"></param>
        static void BuildStatus(ref StringBuilder sb)
        {
            var mdlList = DawnAuthModuleBLL.ISelect("mdl_ident<1", "mdl_rank");
            if (mdlList.Count > 0)
            {
                foreach (var mdlInfo in mdlList)
                {
                    var statList = DawnAuthStatusBLL.ISelect(string.Format("mdl_id='{0}'", mdlInfo.MdlId), "stat_mark");
                    if (statList.Count > 0)
                    {
                        sb.Append("\n");
                        sb.AppendFormat("#region 状态机制·{0}\n", mdlInfo.MdlName);
                        sb.Append("\n");
                        sb.Append("/// <summary>\n");
                        sb.AppendFormat("/// 状态机制·{0}\n", mdlInfo.MdlName);
                        if (!string.IsNullOrEmpty(mdlInfo.MdlDesc))
                        {
                            sb.Append("/// <remarks>\n");
                            sb.AppendFormat("/// {0}\n", mdlInfo.MdlDesc);
                            sb.Append("/// </remarks>\n");
                        }
                        sb.Append("/// </summary>\n");
                        sb.AppendFormat("public enum StatusOf{0} : int\n", mdlInfo.MdlCode);
                        sb.Append("{\n");
                        int statCount = statList.Count;
                        foreach (var statInfo in statList)
                        {
                            statCount--;
                            sb.Append("/// <summary>\n");
                            sb.AppendFormat("/// {0}\n", statInfo.StatName);
                            sb.Append("/// </summary>\n");
                            if (statCount > 0)
                            {
                                sb.AppendFormat("{0}={1},\n", statInfo.StatCode, statInfo.StatMark);
                            }
                            else
                            {
                                sb.AppendFormat("{0}={1}\n", statInfo.StatCode, statInfo.StatMark);
                            }
                        }
                        sb.Append("}\n");
                        sb.Append("\n");
                        sb.Append("#endregion\n");
                    }
                }
            }
        }

        #endregion

        #region 生成实时模块

        /// <summary>
        /// 生成实时模块
        /// </summary>
        /// <param name="sb">字符串</param>
        static void BuildRealMoudle(ref StringBuilder sb)
        {
            var mdlList = DawnAuthModuleBLL.ISelect("mdl_ident > 0", "mdl_rank");
            if (mdlList.Count > 0)
            {
                sb.Append("\n");
                sb.Append("#region 实时验证模块列表\n");
                sb.Append("\n");
                sb.Append("/// <summary>\n");
                sb.Append("/// 实时验证模块列表\n");
                sb.Append("/// </summary>\n");
                sb.Append("public enum RealMoudle: int\n");
                sb.Append("{\n");
                int mdlCount = mdlList.Count;
                foreach (var item in mdlList)
                {
                    mdlCount--;
                    sb.Append("/// <summary>\n");
                    sb.AppendFormat("/// {0}\n", item.MdlName);
                    if (!string.IsNullOrEmpty(item.MdlDesc))
                    {
                        sb.Append("/// <remarks>\n");
                        sb.AppendFormat("/// {0}\n", item.MdlDesc);
                        sb.Append("/// </remarks>\n");
                    }
                    sb.Append("/// </summary>\n");
                    if (mdlCount > 0)
                    {
                        sb.AppendFormat("{0}={1},\n", item.MdlCode, item.MdlIdent);
                    }
                    else
                    {
                        sb.AppendFormat("{0}={1}\n", item.MdlCode, item.MdlIdent);
                    }
                }
                sb.Append("}\n");
                sb.Append("\n");
                sb.Append("#endregion\n");
            }            
        }

        #endregion

        #region 生成实时功能

        /// <summary>
        /// 生成实时功能
        /// </summary>
        /// <param name="sb">字符串</param>
        static void BuildRealFunction(ref StringBuilder sb)
        {
            var funList = DawnAuthFunctionBLL.ISelect("fun_ident > 0", "fun_mark");
            if (funList.Count > 0)
            {
                sb.Append("\n");
                sb.Append("#region 实时验证功能列表\n");
                sb.Append("\n");
                sb.Append("/// <summary>\n");
                sb.Append("/// 实时验证功能列表\n");
                sb.Append("/// </summary>\n");
                sb.Append("public enum RealFunction: int\n");
                sb.Append("{\n");
                int funCount = funList.Count;
                foreach (var item in funList)
                {
                    funCount--;
                    sb.Append("/// <summary>\n");
                    sb.AppendFormat("/// {0}\n", item.FunName);
                    if (!string.IsNullOrEmpty(item.FunDesc))
                    {
                        sb.Append("/// <remarks>\n");
                        sb.AppendFormat("/// {0}\n", item.FunDesc);
                        sb.Append("/// </remarks>\n");
                    }
                    sb.Append("/// </summary>\n");
                    if (funCount > 0)
                    {
                        sb.AppendFormat("{0}={1},\n", item.FunCode, item.FunIdent);
                    }
                    else
                    {
                        sb.AppendFormat("{0}={1}\n", item.FunCode, item.FunIdent);
                    }
                }
                sb.Append("}\n");
                sb.Append("\n");
                sb.Append("#endregion\n");
            }
        }

        #endregion
    }
}
