using System.Collections;
using System.Collections.Generic;

namespace prep.collections
{
  public class ReadOnlySet<T> : IEnumerable<T>
  {
    IEnumerable<T> items;

    public ReadOnlySet(IEnumerable<T> items)
    {
      this.items = items;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
      return items.GetEnumerator();
    }
  }
}