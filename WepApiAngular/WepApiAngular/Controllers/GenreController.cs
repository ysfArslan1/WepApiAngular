﻿using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WepApiAngular.DBOperations;

using WepApiAngular.Entities;
using WepApiAngular.Common;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using FluentValidation.Results;
using FluentValidation;
using WepApiAngular.Aplication.GenresOperations.Commands.UpdateGenre;
using WepApiAngular.Aplication.GenresOperations.Queries.GetGenres;
using WepApiAngular.Aplication.GenresOperations.Queries.GetGenreDetail;
using WepApiAngular.Aplication.GenresOperations.Commands.CreateGenre;
using WepApiAngular.Aplication.GenresOperations.Commands.DeleteGenre;

namespace WepApiAngular.Controllers
{

    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly IAngularDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(IAngularDbContext bankDbContext, IMapper mapper)
        {
            _context = bankDbContext;
            _mapper = mapper;
        }

        // GET: get GetGenres
        [HttpGet]
        public IActionResult GetGenres()
        {
            // Genre verilerinin GenreViewModel alınması için kullanlan query sınıfı oluşturulur ve handle edilir
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            var _list = query.Handle();
            return Ok(_list);
        }

        // GET: get Genre from id
        [HttpGet("{id}")]
        public ActionResult<GenreDetailViewModel> GetGenreById([FromRoute] int id)
        {
            GenreDetailViewModel result;
           
            // GetGenreDetailQuery nesnesi oluşturulur
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
            query.Id = id;
            // Validation işlemi yapılır.
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            
            return Ok(result);
        }

        // Post: create a Genre
        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newModel)
        {
            // CreateGenreCommand nesnesi oluşturulur
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.Model = newModel;
            // validation yapılır.
            CreateGenreCommandValidator _validator=new CreateGenreCommandValidator();
            _validator.ValidateAndThrow(newModel);
            command.Handle();

            return Ok();
        }

        // PUT: update a Genre
        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updateGenre)
        {
            // CreateGenreCommand nesnesi oluşturulur
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.Id = id;
            command.Model = updateGenre;
            // validation yapılır.
            UpdateGenreCommandValidator validator  = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
           
            return Ok();
        }

        // DELETE: delete a Genre
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            // CreateGenreCommand nesnesi oluşturulur
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.Id = id;
            // validation yapılır.
            DeleteGenreCommandValidator _validator = new DeleteGenreCommandValidator();
            _validator.ValidateAndThrow(command);
            command.Handle();
           
            return Ok();
        }

    }
}
