using System;
using System.Collections.Generic;
using System.Text;
using Domain.Model;

namespace Domain.test._Builder
{
    public class UserBuilder
    {

        private static Guid userId = Guid.NewGuid();
        private static Guid roleId = Guid.NewGuid();
        private string _name = "Abel Lopes";
        private string _cpf = "93306423068";
        private string _email = "abellopes@gmail.com";
        private string _username = "abellopes";
        private string _role = "manager";
        private UserRole _userRole = new UserRole(userId, roleId);
        private string _password = "teste123";
        public static UserBuilder NewUserBuilder()
        {
            return new UserBuilder();
        }

        public UserBuilder ComName(string name)
        {
            _name = name;
            return this;
        }
        public UserBuilder ComCpf(string cpf)
        {
            _cpf = cpf;
            return this;
        }
        public UserBuilder ComEmail(string email)
        {
            _email = email;
            return this;
        }
        public UserBuilder ComUserName(string userName)
        {
            _username = userName;
            return this;
        }
        public UserBuilder ComRole(string role)
        {
            _role = role;
            return this;
        }
        public UserBuilder ComUserRole(UserRole userRole)
        {
            _userRole = userRole;
            return this;
        }

        public User Build()
        {
            return new User(_name, _cpf, _email, _username, _password, _role, _userRole);
        }
    }
}
