using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using prep.collections;
using prep.matching_core;

namespace prep.sort
{
    public class Sort<Item>
    {
        public static IComparer<Item> by<AttributeType>(IGetTheValueOfAnAttribute<Item, AttributeType> accessor,
            SortOrders orders = SortOrders.ascending) where AttributeType : IComparable<AttributeType>
        {
            return new SortComparer<Item, AttributeType>(accessor, orders);
        }

        public static IComparer<Item> by<AttributeType>(IGetTheValueOfAnAttribute<Item, AttributeType> accessor,
            params AttributeType[] sort_by_list)
        {
            return new SpecificSortComparer<Item, AttributeType>(accessor, sort_by_list);
        }
    }

    public static class Extensions
    {
        public static IComparer<Item> then_by<Item, AttributeType>(this IComparer<Item> firstLevelComparer,
            IGetTheValueOfAnAttribute<Item, AttributeType> accessor) where AttributeType : IComparable<AttributeType>
        {
            var comparer = Sort<Item>.@by(accessor);

            // Concat the comparers
            return new CompositeComparer<Item>(firstLevelComparer, comparer);
        }
    }

    public class CompositeComparer<Item> : IComparer<Item>
    {
        IComparer<Item> first;
        IComparer<Item> second;

        public CompositeComparer(IComparer<Item> first, IComparer<Item> second)
        {
            this.first = first;
            this.second = second;
        }

        public int Compare(Item x, Item y)
        {
            var firstLevel = first.Compare(x, y);
            var secondLevel = second.Compare(x, y);
            return Math.Sign(firstLevel + 0.1*secondLevel);
        }
    }

    public class SpecificSortComparer<Item, AttributeType> : IComparer<Item>
    {
        readonly IGetTheValueOfAnAttribute<Item, AttributeType> _accessor;
        readonly AttributeType[] _sortByList;

        public SpecificSortComparer(IGetTheValueOfAnAttribute<Item, AttributeType> accessor, AttributeType[] sortByList)
        {
            _accessor = accessor;
            _sortByList = sortByList;
        }

        public int Compare(Item x, Item y)
        {
            var xIndex = Array.IndexOf(_sortByList, _accessor(x));
            var yIndex = Array.IndexOf(_sortByList, _accessor(y));

            return Comparer<int>.Default.Compare(xIndex, yIndex);
        }
    }

    public class SortComparer<Item, AttributeType> : IComparer<Item> where AttributeType : IComparable<AttributeType>
    {
        readonly IGetTheValueOfAnAttribute<Item, AttributeType> _accessor;
        readonly SortOrders _orders;

        public SortComparer(IGetTheValueOfAnAttribute<Item, AttributeType> accessor, SortOrders orders)
        {
            _accessor = accessor;
            _orders = orders;
        }

        public int Compare(Item x, Item y)
        {
            return _orders == SortOrders.ascending
                ? _accessor(x).CompareTo(_accessor(y))
                : _accessor(y).CompareTo(_accessor(x));
        }
    }

    public enum SortOrders
    {
        ascending,
        descending
    };
}

  
