using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WepApiAngular.DBOperations;

using WepApiAngular.Entities;
using WepApiAngular.Common;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using FluentValidation.Results;
using FluentValidation;
using WepApiAngular.Aplication.BooksOperations.Commands.CreateBook;
using WepApiAngular.Aplication.BooksOperations.Commands.DeleteBook;
using WepApiAngular.Aplication.BooksOperations.Commands.UpdateBook;
using WepApiAngular.Aplication.BooksOperations.Queries.GetBooks;
using WepApiAngular.Aplication.BooksOperations.Queries.GetBookDetail;
using WepApiAngular.Aplication.BookOperations.Commands.UpdateBook;

namespace WepApiAngular.Controllers
{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly IAngularDbContext _context;
        private readonly IMapper _mapper;

        public BookController(IAngularDbContext bankDbContext, IMapper mapper)
        {
            _context = bankDbContext;
            _mapper = mapper;
        }

        // GET: get GetBooks
        [HttpGet]
        public IActionResult GetBooks()
        {
            // Book verilerinin BookViewModel alınması için kullanlan query sınıfı oluşturulur ve handle edilir
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var _list = query.Handle();
            return Ok(_list);
        }

        // GET: get Book from id
        [HttpGet("{id}")]
        public ActionResult<BookDetailViewModel> GetBookById([FromRoute] int id)
        {
            BookDetailViewModel result;
           
            // GetBookDetailQuery nesnesi oluşturulur
            GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
            query.Id = id;
            // Validation işlemi yapılır.
            GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            
            return Ok(result);
        }

        // Post: create a Book
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newModel)
        {
            // CreateBookCommand nesnesi oluşturulur
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = newModel;
            // validation yapılır.
            CreateBookCommandValidator _validator=new CreateBookCommandValidator();
            _validator.ValidateAndThrow(newModel);
            command.Handle();

            return Ok();
        }

        // PUT: update a Book
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updateBook)
        {
            // CreateBookCommand nesnesi oluşturulur
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.Id = id;
            command.Model = updateBook;
            // validation yapılır.
            UpdateBookCommandValidator validator  = new UpdateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
           
            return Ok();
        }

        // DELETE: delete a Book
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            // CreateBookCommand nesnesi oluşturulur
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.Id = id;
            // validation yapılır.
            DeleteBookCommandValidator _validator = new DeleteBookCommandValidator();
            _validator.ValidateAndThrow(command);
            command.Handle();
           
            return Ok();
        }

    }
}
