using System;
using System.Collections.Generic;
using prep.infrastructure;
using prep.matching;

namespace prep.collections
{
  public class MovieLibrary
  {
    IList<Movie> movies;

    public MovieLibrary(IList<Movie> list_of_movies)
    {
      this.movies = list_of_movies;
    }

    public IEnumerable<Movie> all_movies()
    {
      return movies.one_at_a_time();
    }

    public void add(Movie movie)
    {
      if (already_contains(movie)) return;

      this.movies.Add(movie);
    }

    bool already_contains(Movie movie)
    {
      return movies.Contains(movie);
    }

    public IEnumerable<Movie> all_movies_published_by_pixar()
    {
      return filter(movie => movie.production_studio == ProductionStudio.Pixar);
    }

    public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
    {
      return
        filter(
          movie =>
            movie.production_studio == ProductionStudio.Pixar ||
            movie.production_studio == ProductionStudio.Disney);
    }

    public bool is_pixar_movie(Movie movie)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {
      return filter(movie => movie.production_studio != ProductionStudio.Pixar);
    }

    public IEnumerable<Movie> all_movies_published_after(int year)
    {
      return filter(movie => movie.date_published.Year > year);
    }

    public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
    {
      return
        filter(movie => movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear);
    }

    public IEnumerable<Movie> all_kid_movies()
    {
      return filter(movie => movie.genre == Genre.kids);
    }

    public IEnumerable<Movie> all_action_movies()
    {
      return filter(movie => movie.genre == Genre.action);
    }

    public IEnumerable<Movie> sort_all_movies_by_title_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_title_ascending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
    {
      throw new NotImplementedException();
    }

    IEnumerable<Movie> filter(MoviePredicate predicate)
    {
      return movies.filter(new MoviePredicateAdaptor(predicate));
    }
  }

    public class MoviePredicateAdaptor : IMatchA<Movie>
    {
        private MoviePredicate predicate;

        public MoviePredicateAdaptor(MoviePredicate predicate)
        {
            this.predicate = predicate;
        }

        public bool matches(Movie item)
        {
            return predicate(item);
        }
    }
}