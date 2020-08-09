using System;
using DynamicSqlQuery.Node;

namespace DynamicSqlTest.Data
{
    public class Users : ISqlObject
    {
        public string Alias { get; set; }

        public Users()
        {
            Alias = null;
        }

        public Users(string alias)
        {
            Alias = alias;
        }

        public const string TableName = "Users";
        public string Id => GetObjectName() + ".Id";
        public string Name => GetObjectName() + ".Name";
        public string Age => GetObjectName() + ".Age";
        public string Place => GetObjectName() + ".Place";

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
