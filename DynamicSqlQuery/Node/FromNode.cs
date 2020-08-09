using System;
using System.Collections.Generic;

namespace DynamicSqlQuery.Node
{
    internal class FromNode<T> : SqlNode
        where T : class, ISqlObject, new()
    {
        internal FromNode() : base("FROM") 
        {
            this.NodeObjectTypes.Add(new T());
        }

        internal override string ConvertToString(string clause)
        {
            return $" {this.NodeType} {this.NodeObjectTypes[0].GetFullObjectName()}";
        }
    }
}
