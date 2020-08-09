using System;

namespace DynamicSqlQuery.Node
{
    public interface ISqlObject
    {
        string Alias { get; set; }

        string GetObjectName();

        string GetFullObjectName();
    }
}
