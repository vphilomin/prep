using System;
using System.Collections.Generic;

namespace prep.collections
{
    public class MovieLibrary
    {
        private IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            foreach (var movie in movies)
            {
                yield return movie;
            }
        }

        public void add(Movie movie)
        {
            if (!this.movies.Contains(movie))
                this.movies.Add(movie);
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            return Filter(movie => movie.production_studio == ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            return
                Filter(
                    movie =>
                        movie.production_studio == ProductionStudio.Pixar ||
                        movie.production_studio == ProductionStudio.Disney);
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            return Filter(movie => movie.production_studio != ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            return Filter(movie => movie.date_published.Year > year);
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            return
                Filter(movie => movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear);
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            return Filter(movie => movie.genre == Genre.kids);
        }

        public IEnumerable<Movie> all_action_movies()
        {
            return Filter(movie => movie.genre == Genre.action);
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

        private IEnumerable<Movie> Filter(Predicate<Movie> predicate)
        {
            foreach (var movie in movies)
            {
                if (predicate != null && predicate.Invoke(movie))
                    yield return movie;
            }
        }
    }
}
