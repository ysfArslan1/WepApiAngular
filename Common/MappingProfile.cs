using AutoMapper;
using WepApi.Entities;
using WepApi.Aplication.BooksOperations.Queries.GetBooks;
using WepApi.Aplication.BooksOperations.Queries.GetBookDetail;
using WepApi.Aplication.BooksOperations.Commands.CreateBook;
using WepApi.Aplication.GenresOperations.Queries.GetGenres;
using WepApi.Aplication.GenresOperations.Queries.GetGenreDetail;
using WepApi.Aplication.GenresOperations.Commands.CreateGenre;
using Ab_pk_task_AuthorController.Entities;
using WepApi.Aplication.AuthorsOperations.Commands.CreateAuthor;
using WepApi.Aplication.AuthorsOperations.Queries.GetAuthors;
using WepApi.Aplication.AuthorsOperations.Queries.GetAuthorDetail;


namespace WepApi.Common
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
