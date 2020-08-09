﻿using System;
using System.Collections.Generic;

namespace DynamicSqlQuery.Node
{
    internal class SelectNode<T> : SqlNode 
        where T : class, ISqlObject, new()
    {
        private object _expression;

        internal SelectNode(Func<T, string> expr) : base("SELECT")
        {
            NodeObjectTypes.Add(new T());
            _expression = expr;
        }

        internal override string ConvertToString(string clause)
        {
            var expression = (Func<T, string>)_expression;

            return $"{clause} {expression(NodeObjectTypes[0] as T)}";
        }
    }

    internal class SelectNode<T, T1> : SqlNode 
        where T : class, ISqlObject, new()
        where T1 : class, ISqlObject, new()
    {
        private object _expression;

        internal SelectNode(Func<T, T1, string> expr) : base("SELECT")
        {
            NodeObjectTypes.Add(new T());
            NodeObjectTypes.Add(new T1());
            _expression = expr;
        }

        internal override string ConvertToString(string clause)
        {
            var expression = (Func<T, T1, string>)_expression;
            return $"{clause} {expression(NodeObjectTypes[0] as T, NodeObjectTypes[1] as T1)}";
        }
    }

    internal class SelectNode<T, T1, T2> : SqlNode
        where T : class, ISqlObject, new()
        where T1 : class, ISqlObject, new()
        where T2 : class, ISqlObject, new()
    {
        private object _expression;

        internal SelectNode(Func<T, T1, T2, string> expr) : base("SELECT")
        {
            NodeObjectTypes.Add(new T());
            NodeObjectTypes.Add(new T1());
            NodeObjectTypes.Add(new T2());
            _expression = expr;
        }

        internal override string ConvertToString(string clause)
        {
            var expression = (Func<object, object, object, string>)_expression;
            return $"{clause} {expression(NodeObjectTypes[0] as T, NodeObjectTypes[1] as T1, NodeObjectTypes[1] as T2)}";
        }
    }
}
