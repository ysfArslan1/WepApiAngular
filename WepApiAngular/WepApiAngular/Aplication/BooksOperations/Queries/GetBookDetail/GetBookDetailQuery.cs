using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WepApiAngular.Common;
using WepApiAngular.DBOperations;

namespace WepApiAngular.Aplication.BooksOperations.Queries.GetBookDetail
{
    public class GetBookDetailQuery
    {

        private readonly IAngularDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public GetBookDetailQuery(IAngularDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public BookDetailViewModel Handle()
        {
            var item = _dbContext.Books.Include(x => x.Genre).Include(x => x.Author).Where(x => x.Id == Id ).SingleOrDefault();
            if (item is null)
                throw new InvalidOperationException("Bulunamadı");

            BookDetailViewModel itemDetail = _mapper.Map<BookDetailViewModel>(item);

            return itemDetail;
        }
    }
    public class BookDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string PageCount { get; set; }
        public string PublishDate { get; set; }
    }

}
