﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepApiAngular.Common;
using WepApiAngular.DBOperations;
using WepApiAngular.Entities;

namespace WepApiAngular.Aplication.BooksOperations.Queries.GetBooks;
public class GetBooksQuery
{
    private readonly IAngularDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetBooksQuery(IAngularDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public List<BookViewModel> Handle()
    {
        var _list = _dbContext.Books.Include(x=>x.Genre).Include(x=>x.Author).OrderBy(x => x.Id).ToList();

        List<BookViewModel> result = _mapper.Map<List<BookViewModel>>(_list);
        return result;
    }
}

public class BookViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Author { get; set; }
    public string PageCount { get; set; }
    public string PublishDate { get; set; }
}

 