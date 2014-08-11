using System;

namespace prep.collections
{
  public class Movie : IEquatable<Movie>
  {
    public string title { get; set; }
    public ProductionStudio production_studio { get; set; }
    public Genre genre { get; set; }
    public int rating { get; set; }
    public DateTime date_published { get; set; }
      public bool Equals(Movie other)
      {
          if (other == null) return false;

          if (ReferenceEquals(this, other)) return true;

          return title == other.title;
      }

      public override bool Equals(object obj)
      {
          return Equals(obj as Movie);
      }
  }
}