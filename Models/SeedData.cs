using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "The RM",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Church",
                    Price = 7.99M,
                    Rating = "R",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/A-1.jpg/1024px-A-1.jpg"
                },
                new Movie
                {
                    Title = "Other Side of Heaven ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Church1",
                    Price = 8.99M,
                    Rating = "R",
                    Image = "https://commons.wikimedia.org/wiki/File:A-1J_6th_SOS_over_Vietnam_c1968.jpg"
                },
                new Movie
                {
                    Title = "Meet the Mormons",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Church",
                    Price = 9.99M,
                    Rating = "R",
                    Image = "https://upload.wikimedia.org/wikipedia/en/d/db/View_-1.jpg"
                },
                new Movie
                {
                    Title = "Meet the Mormons",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Church",
                    Price = 3.99M,
                    Rating = "R",
                    Image = "https://it.m.wikipedia.org/wiki/File:Torre_del_gallo.JPG"
                }
            );
            context.SaveChanges();
        }
    }
}
