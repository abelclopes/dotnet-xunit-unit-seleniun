using System;

namespace Domain.Model
{
    public partial class UserRole : EntidadeBase
    {
        public UserRole()
        {

        }
        public UserRole(User User, Role role)
        {
            UserId = User.Id;
            RoleId = role.Id;
        }
        public UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}