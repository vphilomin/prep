using System;
using prep.matching;

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
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      if (other.GetType() != this.GetType()) return false;

      return String.Equals(title, other.title) && Equals(production_studio, other.production_studio) &&
             rating == other.rating && Equals(genre, other.genre) && date_published.Equals(other.date_published);
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as Movie);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        var hashCode = (title != null ? title.GetHashCode() : 0);
        hashCode = (hashCode*397) ^ (production_studio != null ? production_studio.GetHashCode() : 0);
        hashCode = (hashCode*397) ^ rating;
        hashCode = (hashCode*397) ^ (genre != null ? genre.GetHashCode() : 0);
        hashCode = (hashCode*397) ^ date_published.GetHashCode();
        return hashCode;
      }
    }

    public static IMatchA<Movie> published_by(ProductionStudio studio)
    {
      return new IsPublishedBy(studio);
    }

    public static IMatchA<Movie> in_genre(Genre genre)
    {
      return new IsInGenre(genre);
    }

    public static IMatchA<Movie> published_by_pixar_or_disney()
    {
      return published_by(ProductionStudio.Pixar)
        .or(published_by(ProductionStudio.Disney));
    }
  }
}