using System;

namespace prep.collections
{
    public class Movie
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

        protected bool Equals(Movie other)
        {
            return string.Equals(title, other.title) && Equals(production_studio, other.production_studio) &&
                   rating == other.rating && Equals(genre, other.genre) && date_published.Equals(other.date_published);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Movie) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (title != null ? title.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (production_studio != null ? production_studio.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ rating;
                hashCode = (hashCode*397) ^ (genre != null ? genre.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ date_published.GetHashCode();
                return hashCode;
            }
        }
    }
}