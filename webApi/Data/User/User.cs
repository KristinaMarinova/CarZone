using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
namespace WebCarsProject.Data
{
    public class User
    {
        public User()
        {
            this.Cars = new HashSet<Car>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserTypeID { get; set; } = 2;
        public string PicPath { get; set; }
        public string Phone { get; set; }
        public string Salt { get; set; }
        public DateTime LastLogin { get; set; }
        public UserType UserType { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}