using FakeItEasy;
using UpSchool.Domain.Dtos;
using UpSchool.Domain.Utilities;

namespace UpSchool.Domain.Tests.Utilities
{
    public class PasswordGeneratorTests
    {
        [Fact]
        public void Generate_ShouldReturnEmptyString_WhenNoCharactersAreIncluded()
        {
            // Arrange 
            var passwordGenerator = new PasswordGenerator();

            var generatePasswordDto = new GeneratePasswordDto()
            {
                Length = 20,
                IncludeNumbers = false,
                IncludeLowercaseCharacters = false,
                IncludeUppercaseCharacters = false,
                IncludeSpecialCharacters = false
            };

            // Act
            var password = passwordGenerator.Generate(generatePasswordDto);

            // Assert
            Assert.Equal(string.Empty, password);
        }

        [Fact]
        public void Generate_ShouldReturnPasswordWithGivenLength()
        { 
            var ipHelper = A.Fake<IIPHelper>();

            A.CallTo(() => ipHelper.GetCurrentIPAddress()).Returns("195.142.70.227");

            var localDbMock = A.Fake<ILocalDB>();

            A.CallTo(() => localDbMock.IPs).Returns(new List<string>()
            {
                "192.168.1.11",
                "180.22.22.22",
                "155.166.177.188"
            });

            var passwordGenerator = new PasswordGenerator(ipHelper, localDbMock);

            var generatePasswordDto = new GeneratePasswordDto() // sadece bir alanın true olması da şartı sağlar
            {
                Length = 20,
                IncludeNumbers = true,
                IncludeLowercaseCharacters = true,
                IncludeUppercaseCharacters = true,
                IncludeSpecialCharacters = true
            };

            var password = passwordGenerator.Generate(generatePasswordDto);

            Assert.Equal(generatePasswordDto.Length, password.Length);
        }

        [Fact]
        public void Generate_ShouldIncludeNumbers_WhenIncludeNumbersIsTrue()
        {
            var passwordGenerator = new PasswordGenerator();

            var generatePasswordDto = new GeneratePasswordDto()
            {
                Length = 20,
                IncludeNumbers = true,
                IncludeLowercaseCharacters = false,
                IncludeUppercaseCharacters = false,
                IncludeSpecialCharacters = false
            };

            var password = passwordGenerator.Generate(generatePasswordDto);

            Assert.Contains(password, x => char.IsDigit(x));
        }

        [Fact]
        public void Generate_ShouldIncludeSpecialCharacters_WhenSpecialCharactersIsTrue()
        {
            var passwordGenerator = new PasswordGenerator();

            var generatePassworDto = new GeneratePasswordDto()
            {
                Length = 20,
                IncludeNumbers = true,
                IncludeLowercaseCharacters = true,
                IncludeUppercaseCharacters = true,
                IncludeSpecialCharacters = true,
            };

            var specialCharacters = "!@#$%^&*()";

            var password = passwordGenerator.Generate(generatePassworDto);

            Assert.Contains(password, x => specialCharacters.Contains(x));
        }
    }
}
