using DataAccess.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace DataAccess.Helper
{
    public static class ExtentionMethods
    {
        public static IList WithDefaultItem(this IList list)
        {
            var item = new { Value = "-1", Text = "Por favor Seleccionar" };

            list.Insert(0, item);

            return list;
        }

        public static List<LookupDO> WithDefaultItem(this List<LookupDO> list)
        {
            var item = new LookupDO { Text = "Por favor Seleccionar", Value = -1, Selected = true };

            list.Insert(0, item);

            return list;
        }

        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition,
            Expression<Func<TSource, bool>> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }

        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition,
            Func<TSource, bool> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }

       
        public static IQueryable<TSource> Between<TSource, TKey>
            (this IQueryable<TSource> source,
                Expression<Func<TSource, TKey>> keySelector,
                TKey low, TKey high) where TKey : IComparable<TKey>
        {
            Expression key = Expression.Invoke(keySelector,
                keySelector.Parameters.ToArray());
            Expression lowerBound = Expression.LessThanOrEqual
                (Expression.Constant(low), key);
            Expression upperBound = Expression.LessThanOrEqual
                (key, Expression.Constant(high));
            Expression and = Expression.AndAlso(lowerBound, upperBound);
            Expression<Func<TSource, bool>> lambda =
                Expression.Lambda<Func<TSource, bool>>(and, keySelector.Parameters);
            return source.Where(lambda);
        }

        public static IQueryable<TSource> BetweenIf<TSource, TKey>
            (this IQueryable<TSource> source, bool condition,
                Expression<Func<TSource, TKey>> keySelector,
                TKey low, TKey high) where TKey : IComparable<TKey>
        {
            if (condition)
            {
                Expression key = Expression.Invoke(keySelector,
                    keySelector.Parameters.ToArray());
                Expression lowerBound = Expression.LessThanOrEqual
                    (Expression.Constant(low), key);
                Expression upperBound = Expression.LessThanOrEqual
                    (key, Expression.Constant(high));
                Expression and = Expression.AndAlso(lowerBound, upperBound);
                Expression<Func<TSource, bool>> lambda =
                    Expression.Lambda<Func<TSource, bool>>(and, keySelector.Parameters);
                return source.Where(lambda);

            }
            else
                return source;
        }
    }

    #region License and Terms
//
// MoreLINQ - Extensions to LINQ to Objects
// Copyright (c) 2008-9 Jonathan Skeet. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
    #endregion

    public static partial class MoreEnumerable
    {
        /// <summary>
        /// Returns the set of elements in the first sequence which aren't
        /// in the second sequence, according to a given key selector.
        /// </summary>
        /// <remarks>
        /// This is a set operation; if multiple elements in <paramref name="first"/> have
        /// equal keys, only the first such element is returned.
        /// This operator uses deferred execution and streams the results, although
        /// a set of keys from <paramref name="second"/> is immediately selected and retained.
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements in the input sequences.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <param name="first">The sequence of potentially included elements.</param>
        /// <param name="second">The sequence of elements whose keys may prevent elements in
        /// <paramref name="first"/> from being returned.</param>
        /// <param name="keySelector">The mapping from source element to key.</param>
        /// <returns>A sequence of elements from <paramref name="first"/> whose key was not also a key for
        /// any element in <paramref name="second"/>.</returns>
        public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            Func<TSource, TKey> keySelector)
        {
            return ExceptBy(first, second, keySelector, null);
        }

        /// <summary>
        /// Returns the set of elements in the first sequence which aren't
        /// in the second sequence, according to a given key selector.
        /// </summary>
        /// <remarks>
        /// This is a set operation; if multiple elements in <paramref name="first"/> have
        /// equal keys, only the first such element is returned.
        /// This operator uses deferred execution and streams the results, although
        /// a set of keys from <paramref name="second"/> is immediately selected and retained.
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements in the input sequences.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <param name="first">The sequence of potentially included elements.</param>
        /// <param name="second">The sequence of elements whose keys may prevent elements in
        /// <paramref name="first"/> from being returned.</param>
        /// <param name="keySelector">The mapping from source element to key.</param>
        /// <param name="keyComparer">The equality comparer to use to determine whether or not keys are equal.
        /// If null, the default equality comparer for <c>TSource</c> is used.</param>
        /// <returns>A sequence of elements from <paramref name="first"/> whose key was not also a key for
        /// any element in <paramref name="second"/>.</returns>
        public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> keyComparer)
        {
            //first.ThrowIfNull("first");
            //second.ThrowIfNull("second");
            //keySelector.ThrowIfNull("keySelector");
            return ExceptByImpl(first, second, keySelector, keyComparer);
        }

        private static IEnumerable<TSource> ExceptByImpl<TSource, TKey>(this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> keyComparer)
        {
            HashSet<TKey> keys = new HashSet<TKey>(second.Select(keySelector), keyComparer);
            foreach (var element in first)
            {
                TKey key = keySelector(element);
                if (keys.Contains(key))
                {
                    continue;
                }
                yield return element;
                keys.Add(key);
            }
        }
    }
}