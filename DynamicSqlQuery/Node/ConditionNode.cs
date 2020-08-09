using System;
using System.Collections.Generic;

namespace DynamicSqlQuery.Node
{
    internal class ConditionNode<T> : SqlNode 
        where T : class, ISqlObject, new()
    {
        private object _expression;

        internal ConditionNode(Func<T, string> expr) : base("WHERE")
        {
            NodeObjectTypes.Add(new T());
            _expression = expr;
        }

        internal override string ConvertToString(string clause)
        {
            var expression = (Func<T, string>)_expression;

            return $"{Environment.NewLine} {clause} {expression(NodeObjectTypes[0] as T)}";
        }
    }

    internal class ConditionNode<T, T1> : SqlNode 
        where T : class, ISqlObject, new()
        where T1 : class, ISqlObject, new()
    {
        private object _expression;

        internal ConditionNode(Func<T, T1, string> expr) : base("WHERE")
        {
            NodeObjectTypes.Add(new T());
            NodeObjectTypes.Add(new T1()); 
            _expression = expr;
        }

        internal override string ConvertToString(string clause)
        {
            var expression = (Func<T, T1, string>)_expression;
            return $"{Environment.NewLine} {clause} {expression(NodeObjectTypes[0] as T, NodeObjectTypes[1] as T1)}";
        }
    }

    internal class ConditionNode<T, T1, T2> : SqlNode
        where T : class, ISqlObject, new()
        where T1 : class, ISqlObject, new()
        where T2 : class, ISqlObject, new()
    {
        private object _expression;

        internal ConditionNode(Func<T, T1, T2, string> expr) : base("WHERE")
        {
            NodeObjectTypes.Add(new T());
            NodeObjectTypes.Add(new T1());
            NodeObjectTypes.Add(new T2());
            _expression = expr;
        }

        internal override string ConvertToString(string clause)
        {
            var expression = (Func<object, object, object, string>)_expression;
            return $"{Environment.NewLine} {clause} {expression(NodeObjectTypes[0] as T, NodeObjectTypes[1] as T1, NodeObjectTypes[2] as T2)}";
        }
    }

    internal class ConditionNode<T, T1, T2, T3> : SqlNode
        where T : class, ISqlObject, new()
        where T1 : class, ISqlObject, new()
        where T2 : class, ISqlObject, new()
        where T3 : class, ISqlObject, new()
    {
        private object _expression;

        internal ConditionNode(Func<T, T1, T2, string> expr) : base("WHERE")
        {
            NodeObjectTypes.Add(new T());
            NodeObjectTypes.Add(new T1());
            NodeObjectTypes.Add(new T2());
            NodeObjectTypes.Add(new T3());
            _expression = expr;
        }

        internal override string ConvertToString(string clause)
        {
            var expression = (Func<object, object, object, object, string>)_expression;
            return $"{Environment.NewLine} {clause} {expression(NodeObjectTypes[0] as T, NodeObjectTypes[1] as T1, NodeObjectTypes[2] as T2, NodeObjectTypes[3] as T3)}";
        }
    }

    internal class ConditionNode<T, T1, T2, T3, T4> : SqlNode
        where T : class, ISqlObject, new()
        where T1 : class, ISqlObject, new()
        where T2 : class, ISqlObject, new()
        where T3 : class, ISqlObject, new()
        where T4 : class, ISqlObject, new()
    {
        private object _expression;

        internal ConditionNode(Func<T, T1, T2, string> expr) : base("WHERE")
        {
            NodeObjectTypes.Add(new T());
            NodeObjectTypes.Add(new T1());
            NodeObjectTypes.Add(new T2());
            NodeObjectTypes.Add(new T3());
            NodeObjectTypes.Add(new T4());
            _expression = expr;
        }

        internal override string ConvertToString(string clause)
        {
            var expression = (Func<object, object, object, object, object, string>)_expression;
            return $"{Environment.NewLine} {clause} {expression(NodeObjectTypes[0] as T, NodeObjectTypes[1] as T1, NodeObjectTypes[2] as T2, NodeObjectTypes[2] as T3, NodeObjectTypes[2] as T4)}";
        }
    }
}
