using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController: ControllerBase
    {
        private static List<Book> BookList=new List<Book>()
        {
            new Book{
                Id=1,
                Title="Lean Startup", //personal growth
                GenreId=1,
                PageCount=200,
                PublishDate=new System.DateTime(2001,6,12)
            },
            new Book{
                Id=2,
                Title="Herland", //science fiction
                GenreId=2,
                PageCount=250,
                PublishDate=new System.DateTime(2020,5,13)
            },
            new Book{
                Id=3,
                Title="Lean Startup",
                GenreId=2, // science fiction
                PageCount=500,
                PublishDate=new System.DateTime(2006,7,10)
            }
        };

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList=BookList.OrderBy(x=> x.Id).ToList();
            return bookList;
        }

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = BookList.Where(book => book.Id==id).SingleOrDefault();
            return book;
        }
        /* [HttpGet]
        public Book Get([FromQuery] string id)
        {
            var book = BookList.Where(book => book.Id==Convert.ToInt32(id)).SingleOrDefault();
            return book;
        } */

        [HttpGet("pageCountGreaterThanOrEqualTo/{pageCount}")]
        public List<Book> GetByPageCountGreaterThanOrEqualTo(int pageCount)
        {
            var book = BookList.Where(book=> book.PageCount>=pageCount).ToList();
            return book;
        }
    }
}