using System;
using System.Collections.Generic;
using GR.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GR.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Input_PipeDelimitedShouldParseSuccessfully()
        {
            // Arrange

            string input = "Roberts | George | Male | Purple | 1973-04-11";
            Person expected = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };

            // Act

            var factory = new PersonFactory();
            var actual = factory.ParseLine(input);

            // Assert

            Assert.AreEqual<Person>(expected, (Person)actual);
        }

        [TestMethod]
        public void Input_CommaDelimitedShouldParseSuccessfully()
        {
            // Arrange

            string input = "Roberts, George, Male, Purple, 1973-04-11";
            Person expected = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };

            // Act

            var factory = new PersonFactory();
            var actual = factory.ParseLine(input);

            // Assert

            Assert.AreEqual<Person>(expected, (Person)actual);
        }

        [TestMethod]
        public void Input_SpaceDelimitedShouldParseSuccessfully()
        {
            // Arrange

            string input = "Roberts George Male Purple 1973-04-11";
            Person expected = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };

            // Act

            var factory = new PersonFactory();
            var actual = factory.ParseLine(input);

            // Assert

            Assert.AreEqual<Person>(expected, (Person)actual);
        }

        [TestMethod]
        public void Input_UnknownLineFormat()
        {
            // Arrange

            string input = "Roberts-George-Male-Purple-1973-04-11";
            Person expected = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };

            // Act

            var factory = new PersonFactory();


            // Assert
            Assert.ThrowsException<FormatException>(() => factory.ParseLine(input));
        }

        [TestMethod]
        public void Person_BlankFirstName()
        {
            // Arrange
            string input = "Roberts, , Male, Purple, 1973-04-11";
            Person expected = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };

            // Act
            var factory = new PersonFactory();

            // Assert

            Assert.ThrowsException<FormatException>(() => factory.ParseLine(input));
        }

        [TestMethod]
        public void Person_BlankLastName()
        {
            // Arrange
            string input = ", George, Male, Purple, 1973-04-11";
            Person expected = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };

            // Act
            var factory = new PersonFactory();

            // Assert

            Assert.ThrowsException<FormatException>(() => factory.ParseLine(input));
        }

        [TestMethod]
        public void Person_BlankColor()
        {
            // Arrange
            string input = "Roberts, George, Male, , 1973-04-11";
            Person expected = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };

            // Act
            var factory = new PersonFactory();

            // Assert

            Assert.ThrowsException<FormatException>(() => factory.ParseLine(input));
        }

        [TestMethod]
        public void Person_BlankGender()
        {
            // Arrange
            string input = "Roberts, George, Male, , 1973-04-11";
            Person expected = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };

            // Act
            var factory = new PersonFactory();

            // Assert

            Assert.ThrowsException<FormatException>(() => factory.ParseLine(input));
        }

        [TestMethod]
        public void Person_BlankBirthdate()
        {
            // Arrange
            string input = "Roberts, George, Male, Purple, ";
            Person expected = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };

            // Act
            var factory = new PersonFactory();

            // Assert

            Assert.ThrowsException<FormatException>(() => factory.ParseLine(input));
        }

        [TestMethod]
        public void Person_InvalidGender()
        {
            // Arrange
            string input = "Roberts, George, Human, Purple, 1973-04-11";
            Person expected = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };

            // Act
            var factory = new PersonFactory();

            // Assert

            Assert.ThrowsException<FormatException>(() => factory.ParseLine(input));
        }

        [TestMethod]
        public void Person_InvalidDate()
        {
            // Arrange
            string input = "Roberts, George, Male, Purple, 1973-44-11";
            Person expected = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };

            // Act
            var factory = new PersonFactory();

            // Assert

            Assert.ThrowsException<FormatException>(() => factory.ParseLine(input));
        }


        [TestMethod]
        public void Person_TestToString()
        {
            // Arrange

            Person input = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };
            string expected = "Roberts,George,Male,Purple,4/11/1973";

            // Act

            var factory = new PersonFactory();

            // Assert

            Assert.AreEqual<string>(expected, input.ToString());
        }

        [TestMethod]
        public void Output_TestTypeCorrect()
        {
            int input = 2;
            OutputType expected = OutputType.Birthdate;

            var actual = Output.GetOutputType(input);

            Assert.AreEqual<OutputType>(expected, actual);
        }

        [TestMethod]
        public void Output_TestTypeInvalid()
        {
            int input = 4;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Output.GetOutputType(input));
        }

        [TestMethod]
        public void Output_TestFullOutput_Gender()
        {
            string expected = "Black,Betty,Female,Green,6/13/1971\r\nJohnson,Nancy,Female,Red,7/26/1982\r\nRoberts,George,Male,Purple,4/11/1973\r\nSmith,John,Male,Yellow,1/13/1984\r\n";

            List<Record> records = new List<Record>();
            records.Add(new Person() { LastName = "Roberts", FirstName = "George", DateOfBirth = new DateTime(1973, 4, 11), FavoriteColor = "Purple", Gender = Gender.Male });
            records.Add(new Person() { LastName = "Smith", FirstName = "John", DateOfBirth = new DateTime(1984, 1, 13), FavoriteColor = "Yellow", Gender = Gender.Male });
            records.Add(new Person() { LastName = "Johnson", FirstName = "Nancy", DateOfBirth = new DateTime(1982, 7, 26), FavoriteColor = "Red", Gender = Gender.Female });
            records.Add(new Person() { LastName = "Black", FirstName = "Betty", DateOfBirth = new DateTime(1971, 6, 13), FavoriteColor = "Green", Gender = Gender.Female });

            string actual = Output.Format(records, OutputType.Gender);

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void Output_TestFullOutput_Birthdate()
        {
            string expected = "Black,Betty,Female,Green,6/13/1971\r\nRoberts,George,Male,Purple,4/11/1973\r\nJohnson,Nancy,Female,Red,7/26/1982\r\nSmith,John,Male,Yellow,1/13/1984\r\n";

            List<Record> records = new List<Record>();
            records.Add(new Person() { LastName = "Roberts", FirstName = "George", DateOfBirth = new DateTime(1973, 4, 11), FavoriteColor = "Purple", Gender = Gender.Male });
            records.Add(new Person() { LastName = "Smith", FirstName = "John", DateOfBirth = new DateTime(1984, 1, 13), FavoriteColor = "Yellow", Gender = Gender.Male });
            records.Add(new Person() { LastName = "Johnson", FirstName = "Nancy", DateOfBirth = new DateTime(1982, 7, 26), FavoriteColor = "Red", Gender = Gender.Female });
            records.Add(new Person() { LastName = "Black", FirstName = "Betty", DateOfBirth = new DateTime(1971, 6, 13), FavoriteColor = "Green", Gender = Gender.Female });

            string actual = Output.Format(records, OutputType.Birthdate);

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void Output_TestFullOutput_Name()
        {
            string expected = "Smith,John,Male,Yellow,1/13/1984\r\nRoberts,George,Male,Purple,4/11/1973\r\nJohnson,Nancy,Female,Red,7/26/1982\r\nBlack,Betty,Female,Green,6/13/1971\r\n";

            List<Record> records = new List<Record>();
            records.Add(new Person() { LastName = "Roberts", FirstName = "George", DateOfBirth = new DateTime(1973, 4, 11), FavoriteColor = "Purple", Gender = Gender.Male });
            records.Add(new Person() { LastName = "Smith", FirstName = "John", DateOfBirth = new DateTime(1984, 1, 13), FavoriteColor = "Yellow", Gender = Gender.Male });
            records.Add(new Person() { LastName = "Johnson", FirstName = "Nancy", DateOfBirth = new DateTime(1982, 7, 26), FavoriteColor = "Red", Gender = Gender.Female });
            records.Add(new Person() { LastName = "Black", FirstName = "Betty", DateOfBirth = new DateTime(1971, 6, 13), FavoriteColor = "Green", Gender = Gender.Female });

            string actual = Output.Format(records, OutputType.Lastname);

            Assert.AreEqual<string>(expected, actual);
        }

    }
}