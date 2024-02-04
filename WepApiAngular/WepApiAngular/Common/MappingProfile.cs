using AutoMapper;
using WepApiAngular.Entities;
using WepApiAngular.Aplication.BooksOperations.Queries.GetBooks;
using WepApiAngular.Aplication.BooksOperations.Queries.GetBookDetail;
using WepApiAngular.Aplication.BooksOperations.Commands.CreateBook;
using WepApiAngular.Aplication.GenresOperations.Queries.GetGenres;
using WepApiAngular.Aplication.GenresOperations.Queries.GetGenreDetail;
using WepApiAngular.Aplication.GenresOperations.Commands.CreateGenre;
using Ab_pk_task_AuthorController.Entities;
using WepApiAngular.Aplication.AuthorsOperations.Commands.CreateAuthor;
using WepApiAngular.Aplication.AuthorsOperations.Queries.GetAuthors;
using WepApiAngular.Aplication.AuthorsOperations.Queries.GetAuthorDetail;


namespace WepApiAngular.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {

            CreateMap<Book, BookViewModel>().ForMember(dest=>dest.Genre, opt=>opt.MapFrom(src=>src.Genre.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name+ " " + src.Author.Surname));
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.Surname));
            CreateMap<CreateBookModel, Book>();

            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<CreateGenreModel, Genre>();

            CreateMap<Author, AuthorViewModel>();
            CreateMap<Author, AuthorDetailViewModel>();
            CreateMap<CreateAuthorModel, Author>();
        }
    }
}
