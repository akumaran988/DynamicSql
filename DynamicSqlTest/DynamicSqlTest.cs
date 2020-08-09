using System;
using Xunit;
using DynamicSqlQuery;
using DynamicSqlTest.Data;

namespace DynamicSqlTest
{
    public class DynamicSqlTest
    {
        [Fact]
        public void SimpleSql()
        {
            var builder = new SqlQueryBuilder();

            builder.From<Users>()
                .InnerJoin<Users, Auth>((users, auth) => $"{users.Id} = {auth.Id}")
                .Where<Users, Auth>((users, auth) => $"{users.Id} = {auth.Id}")
                .Select<Users, Auth>((users, auth) => $"{users.Id}, {auth.Password}");

            var query = builder.GetSqlQuery();

            Assert.NotNull(query);
        }
    }
}
