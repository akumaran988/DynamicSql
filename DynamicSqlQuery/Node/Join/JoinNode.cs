using System;
using System.Collections.Generic;

namespace DynamicSqlQuery.Node.Join
{
    internal class JoinNode<T, T1> : SqlNode
        where T : class, ISqlObject, new()
        where T1 : class, ISqlObject, new()
    {
        private object _expression;
        private const string _joinClause = " JOIN";

        internal JoinNode(Func<T, T1, string> expr, string alias, string joinType) : base(joinType + _joinClause)
        {
            NodeObjectTypes.Add(new T());
            NodeObjectTypes.Add(new T1());
            NodeObjectTypes[1].Alias = alias;
            _expression = expr;
        }

        internal override string ConvertToString(string clause)
        {
            var expression = (Func<T, T1, string>)_expression;
            return $" {clause} {(NodeObjectTypes[1] as T1).GetFullObjectName()} ON ({expression(NodeObjectTypes[0] as T, NodeObjectTypes[1] as T1)})";
        }
    }
}
