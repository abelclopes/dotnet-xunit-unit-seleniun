using System;
using Bogus;
using Domain.Model;
using Domain.test._Builder;
using Domain.test._Util;
using Domain.Util;
using ExpectedObjects;
using Xunit;
using Xunit.Abstractions;


namespace Domain.test
{
    public class UsuarioTest : IDisposable
    {

        private readonly ITestOutputHelper _output;
        private readonly string _name;
        private readonly string _cpf;
        private readonly string _email;
        private readonly string _username;
        private readonly string _role;
        private readonly UserRole _userRole;
        private readonly string _password;

        public UsuarioTest(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Construtor foi executado");
            var userId = Guid.NewGuid();
            var roleId = Guid.NewGuid();

            var faker = new Faker();

            _name = faker.Person.FullName.Normalize();
            _cpf = "93306423068";
            _email = faker.Person.Email.Normalize();
            _username = faker.Person.UserName.Normalize();
            _role = "manager";
            _userRole = new UserRole() {UserId = userId, RoleId = roleId};
            _password = faker.Name.Random.Word();

            _output.WriteLine($"Nome testado foi: {_name}");
            _output.WriteLine($"User name testado foi: {_username}");
            _output.WriteLine($"Email testado foi: {_email}");
            _output.WriteLine($"Senha testado foi: {_password}");
        }
        public void Dispose()
        {
            _output.WriteLine("Dispose sendo executado");
        }

        [Fact]
        public void PostNewUserValid()
        {
            var userComp = new User(_name, _cpf, _email, _username, _password, _role, _userRole);
           
            var user = new User(userComp.Name, userComp.Cpf, userComp.Email,
                userComp.Username, _password, userComp.Role, userComp.UserRole)
            {
                DateCriation = userComp.DateCriation
            };

            userComp.ToExpectedObject().ShouldMatch(user);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void UserNameIsNotNullOrEmpyt(string nameIsInvalid)
        {
            Assert.Throws<ArgumentException>(() => 
                UserBuilder.NewUserBuilder().ComName(nameIsInvalid).Build()
            ).CompareMessage("Nome é inválido");
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void UserCpfIsNotNullOrEmpyt(string cpfIsInvalid)
        {
            Assert.Throws<ArgumentException>(() =>
                    UserBuilder.NewUserBuilder().ComCpf(cpfIsInvalid).Build()
                ).CompareMessage("Cpf é inválido");
        }
        [Theory]
        [InlineData("99999999999")]
        [InlineData("00000000000")]
        [InlineData("11111111111")]
        [InlineData("99999")]
        [InlineData("888888888888888")]
        [InlineData("123456789012")]
        public void UserCpfIsNotValid(string cpfIsInvalid)
        {
            Assert.Throws<ArgumentException>(() =>
                UserBuilder.NewUserBuilder().ComCpf(cpfIsInvalid).Build()
            ).CompareMessage("Cpf é inválido");
        }

    }
}
