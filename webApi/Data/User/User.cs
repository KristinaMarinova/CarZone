using System;
using System.Collections.Generic;
namespace CarZone.Data
{
    public class User
    {
        public User()
        {
            this.Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        public Role Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PicPath { get; set; }
        public string Phone { get; set; }
        public string Salt { get; set; }
        public DateTime LastLogin { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}