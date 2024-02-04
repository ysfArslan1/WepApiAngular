using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepApiAngular.Common;
using WepApiAngular.DBOperations;
using WepApiAngular.Entities;

namespace WepApiAngular.Aplication.GenresOperations.Queries.GetGenres;
public class GetGenresQuery
{
    private readonly IAngularDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetGenresQuery(IAngularDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public List<GenreViewModel> Handle()
    {

        var _list = _dbContext.Genres.OrderBy(x => x.Id).ToList();

        List<GenreViewModel> result = _mapper.Map<List<GenreViewModel>>(_list);
        return result;
    }
}

public class GenreViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}

