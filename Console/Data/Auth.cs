using System;
using DynamicSqlQuery.Node;

namespace TestBench.Data
{
    public class Auth : ISqlObject
    {
        public string Alias { get; set; }

        public Auth()
        {
            Alias = null;
        }

        public Auth(string alias)
        {
            Alias = alias;
        }

        public const string TableName = "Auth";
        public string Id => GetObjectName() + "." + IdRaw;
        public string Password => GetObjectName() + "." + PasswordRaw;

        #region Raw Column Names

        public string IdRaw = "Id";
        public string PasswordRaw = "Password";

        #endregion Raw Column Names

        public string GetFullObjectName()
        {
            if (Alias != null)
            {
                return $"{TableName} {Alias}";
            }

            return $"{TableName}";
        }

        public string GetObjectName()
        {
            if (Alias != null)
            {
                return $"{Alias}";
            }
            return $"{TableName}";
        }
    }
}
