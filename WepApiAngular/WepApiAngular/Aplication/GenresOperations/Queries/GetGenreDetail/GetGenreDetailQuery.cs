using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WepApiAngular.Common;
using WepApiAngular.DBOperations;

namespace WepApiAngular.Aplication.GenresOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {

        private readonly IAngularDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public GetGenreDetailQuery(IAngularDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public GenreDetailViewModel Handle()
        {
            var item = _dbContext.Genres.Where(x => x.Id == Id).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("Bulunamadı");

            GenreDetailViewModel itemDetail = _mapper.Map<GenreDetailViewModel>(item);

            return itemDetail;
        }
    }

    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
