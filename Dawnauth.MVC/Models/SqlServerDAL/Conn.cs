using System;
using DawnXZ.DawnUtility;
using DawnXZ.DBUtility;

namespace DawnXZ.Dawnauth.SqlServerDAL
{
    /// <summary>
    /// 数据库连接字符串
    /// </summary>
    internal class Conn
    {

        #region 数据库连接字符串

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
		public static readonly string SqlConn = CryptoHelper.Decrypt(MssqlConnectionString.ConnectionString("AuthorityConnection"));

        #endregion

    }
}
