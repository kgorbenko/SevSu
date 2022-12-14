using System;
using System.Linq;
using NUnit.Framework;
using static Testing.Model.MatrixOperations;

namespace NUnitTests
{
    public class MatrixOperationsTests
    {
        [Test]
        public void PassingNullIssuesException()
        {
            Assert.Throws<ArgumentNullException>(() => GetSumsOfPositiveElementsInColumns(null));
        }

        [Test]
        public void PassingNonSquareMatrixIssuesException()
        {
            var matrix = new[,] {{1, 3, 5}, {2, 3, 4}};
            
            Assert.Throws<ArgumentException>(() => GetSumsOfPositiveElementsInColumns(matrix));
        }

        [Test]
        public void SingleNegativeItem()
        {
            var matrix = new[,] {{-15}};
            var expected = new[]{0};
            
            var actual = GetSumsOfPositiveElementsInColumns(matrix);

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void SinglePositiveItem()
        {
            var matrix = new[,] {{3}};
            var expected = new[] {3};

            var actual = GetSumsOfPositiveElementsInColumns(matrix);
            
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void SquareMatrixWithoutNegativeElements()
        {
            var matrix = new[,]
            {
                {15, 10, 36},
                {13, 0, 14},
                {62, 15, 1235}
            };
            var expected = new[] {90, 25, 1285};

            var actual = GetSumsOfPositiveElementsInColumns(matrix);

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void SquareMatrixWithNegativeElements()
        {
            var matrix = new[,]
            {
                {-30, 10, 36},
                {13, 0, 14},
                {62, -5, 1235}
            };
            var expected = new[] {75, 10, 1285};

            var actual = GetSumsOfPositiveElementsInColumns(matrix);

            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}