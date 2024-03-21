using NUnit.Framework;
using Moq;
using LibraryCataloger.Data;
using LibraryCataloger.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Text;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryCatalogerTests;


[TestFixture]
public class BookNUnitTests
{
    private readonly Mock<IBookRepository> _bookRepositoryMock;

    List<BookEntity> books = new List<BookEntity>
        {
            new BookEntity { BookID = 1, Title = "TestBook1", Author = "TestAuthor", Description = "Test", InLibrary = true, ToBeReadList = true, Isbn = "12345678910" },
            new BookEntity { BookID = 2, Title = "TestBook2", Author = "TestAuthor", Description = "Test", InLibrary = true, ToBeReadList = true, Isbn = "12345678910" },
           
        };

    public BookNUnitTests()
    {

        _bookRepositoryMock = new Mock<IBookRepository>();
       
    }

    [Test]
    public void GetInLibraryBooks_ShouldReturnExpectedNumber()
    {
        //Arrange
        var expected = 2;

        _bookRepositoryMock.Setup(u => u.GetInLibraryBooks()).Returns(books);


        //Act
        List<BookEntity> result = _bookRepositoryMock.Object.GetInLibraryBooks();

        //Assert
        Assert.That(result.Count, Is.EqualTo(expected));
     }

}
        
    
