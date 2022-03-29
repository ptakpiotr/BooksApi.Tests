using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text.Json;
using WebAPI.Controllers;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Models.DTOs;
using Xunit;

namespace LibraryAPI.Tests
{
    public class BooksRepoTests
    {
        private readonly Mock<IBookRepo> _repo;
        private readonly IMapper _mockMapper;

        public BooksRepoTests()
        {
            _repo = new Mock<IBookRepo>();
            _mockMapper = new MapperConfiguration(opts =>
            {
                opts.CreateMap<BookAddDTO,BookModel>().ReverseMap();
                opts.CreateMap<BookModel, BookReadDTO>();
            }).CreateMapper();
        }

        [Fact]
        public void GetAllBooks_Should_Return()
        {
            //arrange
            _repo.Setup(x => x.GetAllBooks()).Returns(MockingHelpers.GetAllBooksMoq);
            BooksController bookController = new BooksController(null, _repo.Object, _mockMapper);
            //act
            IActionResult res = bookController.GetAllBooks();
            //assert
            Assert.IsType<OkObjectResult>(res);
        }

        [Theory]
        [InlineData("e57160b9-ee27-493d-a5ab-5ed045079cd6")]
        public void GetOneBook_Should_Return(Guid id)
        {
            //arrange
            _repo.Setup(x => x.GetOneBook(id)).Returns(MockingHelpers.GetOneBookMoq);
            BooksController booksController = new BooksController(null,_repo.Object, _mockMapper);
            //act 
            IActionResult res = booksController.GetOneBook(id);
            //assert
            Assert.IsType<NotFoundResult>(res);
        }

        [Fact]
        public void UpdateBook_Should_Return()
        {
            //arrange
            _repo.Setup(x => x.UpdateBook(MockingHelpers.testBook)).Verifiable();
            BooksController booksController = new BooksController(null, _repo.Object, _mockMapper);
            //act
            IActionResult res = booksController.EditBook(Guid.NewGuid(), new BookAddDTO());

            Assert.IsType<NotFoundResult>(res);
            
        }
    }
}
