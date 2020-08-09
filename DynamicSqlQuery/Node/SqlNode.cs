using System;
using System.Collections.Generic;

namespace DynamicSqlQuery.Node
{
    internal class SqlNode
    {
        internal string NodeType;

        internal List<ISqlObject> NodeObjectTypes;

        internal SqlNode(string nodeType)
        {
            this.NodeType = nodeType;
            this.NodeObjectTypes = new List<ISqlObject>();
        }

        internal virtual string ConvertToString(string clause)
        {
            return string.Empty;
        }
    }
}
