using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class AuthEntity : IBaseEntity
    {
        public int Id { get; set; }
        public Guid? UserID { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string HashedKey { get; set; }
        public string SaltKey { get; set; }
        public string Role { get; set; }
    }
}
