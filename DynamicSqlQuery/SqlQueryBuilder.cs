using System;
using System.Collections.Generic;
using DynamicSqlQuery.Node;
using DynamicSqlQuery.Node.Join;

namespace DynamicSqlQuery
{
    public class SqlQueryBuilder
    {
        private object _root;

        #region From

        public SqlQueryBuilder From<T>() 
            where T : class, ISqlObject, new()
        {
            _root = new NTree<SqlNode>(new FromNode<T>());
            return this;
        }

        #endregion From

        #region Joins

        public SqlQueryBuilder InnerJoin<T, T1>(Func<T, T1, string> func, string alias = null)
            where T : class, ISqlObject, new() 
            where T1 : class, ISqlObject, new()
        {
            ((NTree<SqlNode>)_root).AddChild(new NTree<SqlNode>(new InnerJoinNode<T, T1>(func, alias)));
            return this;
        }

        public SqlQueryBuilder LeftJoin<T, T1>(Func<T, T1, string> func, string alias = null)
            where T : class, ISqlObject, new()
            where T1 : class, ISqlObject, new()
        {
            ((NTree<SqlNode>)_root).AddChild(new NTree<SqlNode>(new LeftJoinNode<T, T1>(func, alias)));
            return this;
        }

        public SqlQueryBuilder RightJoin<T, T1>(Func<T, T1, string> func, string alias = null)
            where T : class, ISqlObject, new()
            where T1 : class, ISqlObject, new()
        {
            ((NTree<SqlNode>)_root).AddChild(new NTree<SqlNode>(new RightJoinNode<T, T1>(func, alias)));
            return this;
        }

        #endregion Joins

        #region Where

        public SqlQueryBuilder Where<T>(Func<T, string> func) 
            where T : class, ISqlObject, new()
        {
            var whereNode = new ConditionNode<T>(func);
            _root = ((NTree<SqlNode>)_root).AddChild(new NTree<SqlNode>(whereNode));
            return this;
        }

        public SqlQueryBuilder Where<T, T1>(Func<T, T1, string> func) 
            where T : class, ISqlObject, new() 
            where T1 : class, ISqlObject, new()
        {
            var whereNode = new ConditionNode<T, T1>(func);
            _root = ((NTree<SqlNode>)_root).AddChild(new NTree<SqlNode>(whereNode));
            return this;
        }

        #endregion Where

        #region Select

        public SqlQueryBuilder Select<T>(Func<T, string> func) 
            where T : class, ISqlObject, new()
        {
            var selectNode = new SelectNode<T>(func);
            _root = ((NTree<SqlNode>)_root).AddChild(new NTree<SqlNode>(selectNode));
            return this;
        }

        public SqlQueryBuilder Select<T, T1>(Func<T, T1, string> func) 
            where T : class, ISqlObject, new() 
            where T1 : class, ISqlObject, new()
        {
            var selectNode = new SelectNode<T, T1>(func);
            _root = ((NTree<SqlNode>)_root).AddChild(new NTree<SqlNode>(selectNode));
            return this;
        }

        #endregion Select

        public string GetSqlQuery()
        {
            var selectNodes = new List<SqlNode>();
            var fromNodes = new List<SqlNode>();
            var joinNodes = new List<SqlNode>();
            var whereNodes = new List<SqlNode>();

            var query = string.Empty;

            #region FROM

            // Get the FROM clause construct first
            NTree<SqlNode>.TraverseFor((NTree<SqlNode>)_root, (node) => node.NodeType == "FROM", fromNodes);
            query += fromNodes[0].ConvertToString(null);

            #endregion FROM

            #region JOIN
            // Get the Join clause construct
            NTree<SqlNode>.TraverseFor((NTree<SqlNode>)_root, (node) => node.NodeType == "INNER JOIN", joinNodes);

            foreach (var item in joinNodes)
            {
                query += item.ConvertToString("INNER JOIN");
            }

            joinNodes.Clear();
            // Get the Join clause construct
            NTree<SqlNode>.TraverseFor((NTree<SqlNode>)_root, (node) => node.NodeType == "LEFT JOIN", joinNodes);

            foreach (var item in joinNodes)
            {
                query += item.ConvertToString("LEFT JOIN");
            }

            joinNodes.Clear();
            // Get the Join clause construct
            NTree<SqlNode>.TraverseFor((NTree<SqlNode>)_root, (node) => node.NodeType == "RIGHT JOIN", joinNodes);

            foreach (var item in joinNodes)
            {
                query += item.ConvertToString("RIGHT JOIN");
            }

            #endregion JOIN

            #region WHERE
            // Get the WHERE clause construct
            NTree<SqlNode>.TraverseFor((NTree<SqlNode>)_root, (node) => node.NodeType == "WHERE", whereNodes);

            var itemIndex = 0;
            foreach (var item in whereNodes)
            {
                query += item.ConvertToString(itemIndex > 0 ? " AND " : " WHERE ");
                itemIndex++;
            }

            #endregion WHERE

            #region SELECT
            // Get the SELECT clause construct
            NTree<SqlNode>.TraverseFor((NTree<SqlNode>)_root, (node) => node.NodeType == "SELECT", selectNodes);

            foreach (var item in selectNodes)
            {
                query = item.ConvertToString("SELECT") + query;
            }

            #endregion SELECT

            return query;
        }
    }
}
