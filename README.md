
一、	部署《晨曦小竹云权限管理系统》，并规划所有的功能点，于系统中添加完成；

二、	用《晨曦小竹云权限管理系统》中的控制台程序生成“DawnDefine.cs”文件，并把这个文件复制到MVC4项目的“Models”文件夹中；

三、	在MVC项目的配置文件中确保有权限管理系统的数据访问连接字符串：
<add name="AuthorityConnection" providerName="System.Data.SqlClient" connectionString="加密串" />
加密串为工具集中的通用版生成，原型为：
Data Source=(local);
Initial Catalog=DawnAuthority;
Persist Security Info=True;
User ID=sa;
Password=sa

四、	在MVC项目中建立“Filters”文件夹，并建立相应的权限或展示处理文件；如：
1、	异常集中处理：ExceptionFilter.cs
2、	动作记录处理：ActionExecutFilter.cs
3、	登录验证处理：LoginedFilter.cs
4、	模块验证处理：ModuledFilter.cs
5、	状态机制处理：StatusedFilter.cs

五、	在MVC项目中的“App_Start”文件夹中，建立或修改“FilterConfig.cs”文件，并在文件注册“Filters”文件夹相应的过滤器；如：
filters.Add(new ActionExecutFilter());
filters.Add(new ExceptionFilter());
filters.Add(new LoginedFilter());

六、	在MVC项目中的“Controllers”文件夹中，于需要进行权限控制的控制器中增加对应的设置即可，如果不需要控制的地方一定要加上“[AllowAnonymous]”，否则必须通过验证方可访问；控制器的类上面加上“[Authorize]”表示需要权限验证；如：

#region 数据删除

        /// <summary>
        /// 处理设施类型数据删除
        /// </summary>
        /// <param name="id">设施类型编号</param>
        /// <returns>执行结果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ModuledFilter(DawnAuthdef.ModuleByHdwhFacytype, (int)DawnAuthdef.HdwhFacytype.Delete, tipsMode: 3)]
        [ExceptionFilter(tipsMode: 3)]
        public string TypeDelete(string id)
        {
            var stateInfo = DawnAuthlib.StateSuccess;
            // ******
            return stateInfo;
        }

        #endregion

七、	简单书写，如有不明之处，可群留言，或给我留言，或电我，一切皆有可能。

