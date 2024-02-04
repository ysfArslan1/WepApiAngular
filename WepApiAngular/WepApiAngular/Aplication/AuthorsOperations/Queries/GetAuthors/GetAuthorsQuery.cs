using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepApiAngular.Common;
using WepApiAngular.DBOperations;
using WepApiAngular.Entities;

namespace WepApiAngular.Aplication.AuthorsOperations.Queries.GetAuthors;
public class GetAuthorsQuery
{
    private readonly IAngularDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetAuthorsQuery(IAngularDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public List<AuthorViewModel> Handle()
    {

        var _list = _dbContext.Authors.OrderBy(x => x.Id).ToList();

        List<AuthorViewModel> result = _mapper.Map<List<AuthorViewModel>>(_list);
        return result;
    }
}

public class AuthorViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Birthdate { get; set; }
}

