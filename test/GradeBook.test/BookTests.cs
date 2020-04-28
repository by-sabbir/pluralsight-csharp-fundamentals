using System;
using Xunit;

namespace GradeBook.test
{
    public class BookTests
    {
        [Fact]
        public void BookCalculateStats()
        {
            // arrange
            var book = new Book("New Book");
            book.AddGrade(11);
            book.AddGrade(12);
            book.AddGrade(13);

            // act
            var stat = book.GetStats();

            // assert
            // Assert.Equal(12, stat.Average, 1);
            // Assert.Equal(11, stat.Low);
            // Assert.Equal(13, stat.High);
            // Assert.Equal('F', stat.Letter);
        }
    }
}
