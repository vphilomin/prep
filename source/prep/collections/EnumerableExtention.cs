using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using prep.matching;

namespace prep.collections
{
	public static class EnumerableExtention
	{
		public static IAttributeEnumerator<ItemType, AttributeType> where<ItemType, AttributeType>(this IEnumerable<ItemType> collection, IGetTheValueOfAnAttribute<ItemType, AttributeType>  attributeGetterr )
		{
			return new IAttributeEnumerator<ItemType, AttributeType>(collection, attributeGetterr);
		}	
   }


	public class IAttributeEnumerator<ItemType, AttributeType>
	{
		private IGetTheValueOfAnAttribute<ItemType, AttributeType> attributeGetter;
		private IEnumerable<ItemType> collection;

		public IAttributeEnumerator(IEnumerable<ItemType> collection, IGetTheValueOfAnAttribute<ItemType, AttributeType> attributeGetterr)
		{
			this.collection = collection;
			this.attributeGetter = attributeGetterr;
		}

		public IEnumerable<ItemType> whereAttribute(IMatchA<AttributeType> attributeMathcer)
		{
			foreach (var c in collection)
			{
				var attr = attributeGetter(c);

				if (attributeMathcer.matches(attr))
					yield return c;
			}
		}
	}

	public static class AttributeEnumeratorExtention
	{
		public static IEnumerable<ItemType> greater_than<ItemType>(this IAttributeEnumerator<ItemType, DateTime> attributeEnumerator, int year)
		{
			return attributeEnumerator.whereAttribute(Match<DateTime>.with_attribute(x => x.Year).greater_than(year));
		}
	}
}
