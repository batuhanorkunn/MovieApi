using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MoviesApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public UpdateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateMovieCommand command)
        {
            var value =await _context.Movies.FindAsync(command.MovieId);
            value.Rating = command.Rating;
            value.Title = command.Title;    
            value.Status = command.Status;
            value.Description = command.Description;
            value.CoverImageUrl = command.CoverImageUrl;
            value.Duration = command.Duration;  
            value.CreatedYear = command.CreatedYear;
            value.ReleaseDate = command.ReleaseDate;    
            await _context.SaveChangesAsync();
        }
    }
}
