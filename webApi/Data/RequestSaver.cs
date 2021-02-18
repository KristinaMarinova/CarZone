using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
namespace WebCarsProject.Data
{
    public class RequestSaver
    {
        public int Id { get; set; }
        public string Verb { get; set; }
        public string Path { get; set; }
        public string Protocol { get; set; }
        public DateTime Time { get; set; }
    }

    public class RequestSaverConfiguration : IEntityTypeConfiguration<RequestSaver>
    {
        public void Configure(EntityTypeBuilder<RequestSaver> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}