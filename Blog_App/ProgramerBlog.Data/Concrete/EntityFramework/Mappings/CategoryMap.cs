using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgramerBlog.Entities.Conreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramerBlog.Data.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
              builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(70);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.CreatedByName).IsRequired();
            builder.Property(c => c.CreatedByName).HasMaxLength(50);
            builder.Property(c => c.ModifiedByName).IsRequired();
            builder.Property(c => c.ModifiedByName).HasMaxLength(50);
            builder.Property(c => c.CreateDate).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.Note).HasMaxLength(500);
            builder.ToTable("Categpries");
            builder.HasData(new Category
            {

                Id = 1,
                Name = "C#",
                Description = "C# Programla Dilinde bildiğiniz bilgerin güncel hali",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreateDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "C# Blog Kategorisi",

            },
                new Category
                {


                    Id = 2,
                    Name = "Ruby",
                    Description = "Ruby Programla Dilinde Türkçe kayankla beraber",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreateDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Ruby Blog Kategorisi",

                },

                 new Category
                 {
                     Id = 3,
                     Name = "Fizik",
                     Description = "Fizik Bilim ve Teoremleri ",
                     IsActive = true,
                     IsDeleted = false,
                     CreatedByName = "InitialCreate",
                     CreateDate = DateTime.Now,
                     ModifiedByName = "InitialCreate",
                     ModifiedDate = DateTime.Now,
                     Note = "Fizik Dersi Blog Kategorisi",
                 },

                 new Category
                 {
                     Id = 4,
                     Name = "JavaScript",
                     Description = "JavaScript Ara Programlama Web Dili",
                     IsActive = true,
                     IsDeleted = false,
                     CreatedByName = "InitialCreate",
                     CreateDate = DateTime.Now,
                     ModifiedByName = "InitialCreate",
                     ModifiedDate = DateTime.Now,
                     Note = "JavaScript Blog Kategorisi",


                 });
                


              
            
          


        }
    }
}
