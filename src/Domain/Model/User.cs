using System;
using System.Collections.Generic;
using System.Text;
using Domain.Util;

namespace Domain.Model
{
    public class User : EntidadeBase
    {
        public User() { }
        public User(string name, string cpf, string email, string username, string password, 
            string role, UserRole userRole)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Nome é inválido");

            if (string.IsNullOrEmpty(cpf) || ValidDocIds.ValidCpf(cpf) == false)
                throw new ArgumentException("Cpf é inválido");

            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("E-mail é inválido");

            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("Nome de usuário é inválido");


            Name = name;
            Cpf = cpf;
            Email = email;
            Username = username;
            Role = role;
            UserRole = userRole;
            Password = HashManager.GetSha1HashData(password);
        }


        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public UserRole UserRole { get; set; }
    }
}
