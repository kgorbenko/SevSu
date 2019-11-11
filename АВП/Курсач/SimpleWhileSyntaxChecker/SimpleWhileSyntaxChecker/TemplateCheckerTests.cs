using System;
using static WhileSyntaxChecker.TemplateChecker;
using NUnit.Framework;

namespace WhileSyntaxChecker
{
    class TemplateCheckerTests
    {
        [Test]
        public void ManagesOperatorWithWhitespaces()
        {
            var operation = "while ( name1 < 50 ) { name1 += 10; name2 := name1; }";
            TryCheck(operation, out string message);

            Assert.That(message.Contains("Entered operator seems to be valid"));
        }

        [Test]
        public void ManagesOperatorWithoutWhitespaces()
        {
            var operation = "while(name1<50){name1+=10;name2:=name1;}";
            TryCheck(operation, out string message);

            Assert.That(message.Contains("Entered operator seems to be valid"));
        }

        [Test]
        public void ThrowsExceptionWhenGivingTooLongOperator()
        {
            var operation = new string('a', 81);

            Assert.Throws<ArgumentException>(() => TryCheck(operation, out string message));
        }

        [Test]
        public void ThrowsExceptionWhenGivingWhiteSpaceOperator()
        {
            var operation = new string(' ', 81);

            Assert.Throws<ArgumentNullException>(() => TryCheck(operation, out string message));
        }

        [Test]
        public void ThrowsExceptionWhenGivingNullOperator()
        {
            Assert.Throws<ArgumentNullException>(() => TryCheck(null, out string message));
        }

        [Test]
        public void GivesAMessageWhenNotAWhileLoop()
        {
            var operation = "for(name1<50){name1+=10;name2:=name1;}";
            TryCheck(operation, out string message);

            Assert.That(message.Contains("There has been some issues"));
            Assert.That(message.Contains("Operator should be while loop"));
        }

        [Test]
        public void GivesAMessageWhenName2IsNotValid()
        {
            var operation = "while(name1<50){name1+=10;nam^e2:=name1;}";
            TryCheck(operation, out string message);

            Assert.That(message.Contains("There has been some issues"));
            Assert.That(message.Contains("Name nam^e2 is not valid"));
        }

        [Test]
        public void GivesMessageWhenName1OnFirstPositionIsNotValid()
        {
            var operation = "while(na@me1<50){name1+=10;name2:=name1;}";
            TryCheck(operation, out string message);

            Assert.That(message.Contains("There has been some issues"));
            Assert.That(message.Contains("Name na@me1 is not valid"));
        }

        [Test]
        public void GivesMessageWhenName1OnSecondPositionIsNotValid()
        {
            var operation = "while(name1<50){na@me1+=10;name2:=name1;}";
            TryCheck(operation, out string message);

            Assert.That(message.Contains("There has been some issues"));
            Assert.That(message.Contains("Name na@me1 is not valid"));
        }

        [Test]
        public void GivesMessageWhenName1OnThirdPositionIsNotValid()
        {
            var operation = "while(name1<50){name1+=10;name2:=na@me1;}";
            TryCheck(operation, out string message);

            Assert.That(message.Contains("There has been some issues"));
            Assert.That(message.Contains("Name na@me1 is not valid"));
        }

        [Test]
        public void GivesAMessageWhenNames1DoesntMatch()
        {
            var operation = "while(name1<50){notname1+=10;name2:=notname1;}";
            TryCheck(operation, out string message);

            Assert.That(message.Contains("There has been some issues"));
            Assert.That(message.Contains("Names name1, notname1 and notname1 should match"));
        }

        [Test]
        public void GivesAMessageWhenBrokenParenthesesBalance()
        {
            var operation = "while((name1<50){name1+=10;name2:=name1;}";
            TryCheck(operation, out string message);

            Assert.That(message.Contains("There has been some issues"));
            Assert.That(message.Contains("Broken parentheses balance"));
        }

        [Test]
        public void GivesAMessageWhenBrokenBracesBalance()
        {
            var operation = "while(name1<50){{{name1+=10;name2:=name1;}}";
            TryCheck(operation, out string message);

            Assert.That(message.Contains("There has been some issues"));
            Assert.That(message.Contains("Broken braces balance"));
        }
    }
}
//while(name1<50){name1+=10;name2:=name1;}
//"Entered operator seems to be valid"
//"Entered operation doesn't match the required template"
//"Operator length should be less than 80"
//"number {identifier} is not valid"
//"Name {identifier} is not valid"
//"Names {namesAndNumbers[1]}, {namesAndNumbers[3]} and {namesAndNumbers[6]} should match"
//"Operator should be while loop"
//"Broken parentheses balance"
//"Broken braces balance"
//"There has been some issues"