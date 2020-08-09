using System;
using System.Collections.Generic;

namespace DynamicSqlQuery.Node.Join
{
    internal class LeftJoinNode<T, T1> : JoinNode<T, T1>
        where T : class, ISqlObject, new()
        where T1 : class, ISqlObject, new()
    {
        internal LeftJoinNode(Func<T, T1, string> expr, string alias) : base(expr, alias, "LEFT")
        {
        }
    }
}
