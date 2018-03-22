using System;
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

            Person actual = Input.ParseLine(input);

            // Assert

            Assert.AreEqual<Person>(expected, actual);
        }

        [TestMethod]
        public void Input_CommaDelimitedShouldParseSuccessfully()
        {
            // Arrange

            string input = "Roberts, George, Male, Purple, 1973-04-11";
            Person expected = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };

            // Act

            Person actual = Input.ParseLine(input);

            // Assert

            Assert.AreEqual<Person>(expected, actual);
        }

        [TestMethod]
        public void Input_SpaceDelimitedShouldParseSuccessfully()
        {
            // Arrange

            string input = "Roberts George Male Purple 1973-04-11";
            Person expected = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };

            // Act

            Person actual = Input.ParseLine(input);

            // Assert

            Assert.AreEqual<Person>(expected, actual);
        }

        [TestMethod]
        public void Input_UnknownLineFormat()
        {
            // Arrange

            string input = "Roberts-George-Male-Purple-1973-04-11";
            Person expected = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };

            // Act


            // Assert
            Assert.ThrowsException<FormatException>(() => Input.ParseLine(input));
        }

        [TestMethod]
        public void Person_BlankFirstName()
        {
            // Arrange
            string input = "Roberts, , Male, Purple, 1973-04-11";
            Person expected = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };

            // Act

            // Assert

            Assert.ThrowsException<FormatException>(() => Input.ParseLine(input));
        }

        [TestMethod]
        public void Person_BlankLastName()
        {
            // Arrange
            string input = ", George, Male, Purple, 1973-04-11";
            Person expected = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };

            // Act

            // Assert

            Assert.ThrowsException<FormatException>(() => Input.ParseLine(input));
        }

        [TestMethod]
        public void Person_BlankColor()
        {
            // Arrange
            string input = "Roberts, George, Male, , 1973-04-11";
            Person expected = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };

            // Act

            // Assert

            Assert.ThrowsException<FormatException>(() => Input.ParseLine(input));
        }

        [TestMethod]
        public void Person_BlankGender()
        {
            // Arrange
            string input = "Roberts, George, Male, , 1973-04-11";
            Person expected = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };

            // Act

            // Assert

            Assert.ThrowsException<FormatException>(() => Input.ParseLine(input));
        }

        [TestMethod]
        public void Person_BlankBirthdate()
        {
            // Arrange
            string input = "Roberts, George, Male, Purple, ";
            Person expected = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };

            // Act

            // Assert

            Assert.ThrowsException<FormatException>(() => Input.ParseLine(input));
        }

        [TestMethod]
        public void Person_InvalidGender()
        {
            // Arrange
            string input = "Roberts, George, Human, Purple, 1973-04-11";
            Person expected = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };

            // Act

            // Assert

            Assert.ThrowsException<FormatException>(() => Input.ParseLine(input));
        }

        [TestMethod]
        public void Person_InvalidDate()
        {
            // Arrange
            string input = "Roberts, George, Male, Purple, 1973-44-11";
            Person expected = new Person() { LastName = "Roberts", FirstName = "George", Gender = Gender.Male, FavoriteColor = "Purple", DateOfBirth = new DateTime(1973, 4, 11) };

            // Act

            // Assert

            Assert.ThrowsException<FormatException>(() => Input.ParseLine(input));
        }

    }
}
