using System;
using System.Collections.Generic;

namespace DynamicSqlQuery
{
    internal class NTree<T> where T : class
    {
        internal T Data;
        internal LinkedList<NTree<T>> Childrens;

        internal NTree(T data)
        {
            this.Data = data;
            this.Childrens = new LinkedList<NTree<T>>();
        }

        internal NTree<T> AddChild(NTree<T> childTree)
        {
            this.Childrens.AddLast(childTree);
            return this;
        }

        internal static T TraverseFor(NTree<T> nTree, Func<T, bool> searchFor, ICollection<T> result)
        {
            if (nTree.Childrens.Count == 0)
            {
                return nTree.Data;
            }

            foreach (var child in nTree.Childrens)
            {
                var data = TraverseFor(child, searchFor, result);
                if (searchFor(data)) 
                {
                    result.Add(data);
                }
            }

            if (searchFor(nTree.Data))
            {
                result.Add(nTree.Data);
            }

            return nTree.Data;
        }

        internal static T TraverseForTree(NTree<T> nTree, Func<T, bool> searchFor, ICollection<NTree<T>> result)
        {
            if (nTree.Childrens.Count == 0)
            {
                return nTree.Data;
            }

            foreach (var child in nTree.Childrens)
            {
                var data = TraverseForTree(child, searchFor, result);
                if (searchFor(data))
                {
                    result.Add(child);
                }
            }

            if (searchFor(nTree.Data))
            {
                result.Add(nTree);
            }

            return nTree.Data;
        }
    }
}
