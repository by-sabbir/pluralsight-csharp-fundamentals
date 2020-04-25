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
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var stat = book.GetStats();

            // assert
            Assert.Equal(85.6, stat.Average, 1);
            Assert.Equal(77.3, stat.Low);
            Assert.Equal(90.5, stat.High);
            Assert.Equal('F', stat.Letter);
        }
    }
}
