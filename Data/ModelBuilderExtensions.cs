using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Assignment2.Models;

namespace Assignment2.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            var pwd = "P@$$w0rd";
            var passwordHasher = new PasswordHasher<ApplicationUser>();

            // Seed Roles
            var adminRole = new IdentityRole("Admin");
            adminRole.NormalizedName = adminRole.Name!.ToUpper();
            var memberRole = new IdentityRole("Member");
            memberRole.NormalizedName = memberRole.Name!.ToUpper();
            List<IdentityRole> roles = new List<IdentityRole>() {
                adminRole,
                memberRole
                };
            builder.Entity<IdentityRole>().HasData(roles);

            // Seed Users
            var adminUser = new ApplicationUser
            {
                UserName = "aa@aa.aa",
                Email = "aa@aa.aa",
                EmailConfirmed = true,
                FirstName = "Adam",
                LastName = "Atkins",
                City = "Victoria",
                Province = "BC",
                Address = "1234 Elm St",
                PostalCode = "V8V3A4",
                PhoneNumber = "250-123-4567",
                ReservationId = "",
            };
            adminUser.NormalizedUserName = adminUser.UserName.ToUpper();
            adminUser.NormalizedEmail = adminUser.Email.ToUpper();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, pwd);

            var memberUser = new ApplicationUser
            {
                UserName = "mm@mm.mm",
                Email = "mm@mm.mm",
                EmailConfirmed = true,
                FirstName = "Mike",
                LastName = "Moore",
                City = "Victoria",
                Province = "BC",
                Address = "5678 Oak St",
                PostalCode = "V8V3A4",
                PhoneNumber = "250-123-4567",
                ReservationId = "",
            };
            memberUser.NormalizedUserName = memberUser.UserName.ToUpper();
            memberUser.NormalizedEmail = memberUser.Email.ToUpper();
            memberUser.PasswordHash = passwordHasher.HashPassword(memberUser, pwd);

            List<ApplicationUser> users = new List<ApplicationUser>() {
                adminUser,
                memberUser,
            };

            builder.Entity<ApplicationUser>().HasData(users);

            // Seed UserRoles
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Admin").Id
            });

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId = roles.First(q => q.Name == "Member").Id
            });


            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);

            // Seed Reservations
            List<Reservation> reservations = new List<Reservation>() {
                new Reservation {
                    Id = "1",
                    ReserverId = users[0].Id,
                    BookCodeNumber = "1",
                    ReservationDate = DateTime.Now,
                    EstimatedDeliveryDate = DateTime.Now.AddDays(1),
                    ReturnDate = DateTime.Now.AddMonths(1),
                    Fees = 0,
                    AdminComment = ""
                },
                // Sample late reservation
                new Reservation {
                    Id = "2",
                    ReserverId = users[1].Id,
                    BookCodeNumber = "2",
                    ReservationDate = DateTime.Now.AddMonths(-2),
                    EstimatedDeliveryDate = DateTime.Now.AddMonths(-2).AddDays(1),
                    ReturnDate = DateTime.Now.AddMonths(-1),
                    Fees = 0,
                    AdminComment = ""
                }
            };

            // Seed Books
            List<Book> books = new List<Book>() {
                new Book {
                    CodeNumber = "1",
                    Author = "Andrew Chevallier",
                    Title = "Encyclopedia of Herbal Medicine: 550 Herbs and Remedies for Common Ailments",
                    YearPublished = 2016,
                    Quantity = 0
                },
                new Book {
                    CodeNumber = "2",
                    Author = "Michael T. Murray M.D. and Joseph Pizzorno",
                    Title = "The Encyclopedia of Natural Medicine Third Edition",
                    YearPublished = 2012,
                    Quantity = 2
                },
                new Book {
                    CodeNumber = "3",
                    Author = "Thomas Easley and Steven Horne",
                    Title = "The Modern Herbal Dispensatory: A Medicine-Making Guide",
                    YearPublished = 2016,
                    Quantity = 1
                },
                new Book {
                    CodeNumber = "4",
                    Author = "Cat Ellis",
                    Title = "Prepper's Natural Medicine: Life-Saving Herbs, Essential Oils and Natural Remedies for When There is No Doctor",
                    YearPublished = 2015,
                    Quantity = 2
                },
                new Book {
                    CodeNumber = "5",
                    Author = "Rosemary Gladstar",
                    Title = "Rosemary Gladstar's Medicinal Herbs: A Beginner's Guide: 33 Healing Herbs to Know, Grow, and Use",
                    YearPublished = 2012,
                    Quantity = 1
                },
                new Book {
                    CodeNumber = "6",
                    Author = "Stephen King",
                    Title = "The Shining",
                    YearPublished = 1977,
                    Quantity = 3
                },
                new Book {
                    CodeNumber = "7",
                    Author = "J.R.R. Tolkien",
                    Title = "The Lord of the Rings",
                    YearPublished = 1954,
                    Quantity = 5
                },
                new Book {
                    CodeNumber = "8",
                    Author = "Jane Austen",
                    Title = "Pride and Prejudice",
                    YearPublished = 1813,
                    Quantity = 2
                },
                new Book {
                    CodeNumber = "9",
                    Author = "George Orwell",
                    Title = "1984",
                    YearPublished = 1949,
                    Quantity = 4
                },
                new Book {
                    CodeNumber = "10",
                    Author = "Harper Lee",
                    Title = "To Kill a Mockingbird",
                    YearPublished = 1960,
                    Quantity = 3
                },
                new Book {
                    CodeNumber = "11",
                    Author = "F. Scott Fitzgerald",
                    Title = "The Great Gatsby",
                    YearPublished = 1925,
                    Quantity = 2
                },
                new Book {
                    CodeNumber = "12",
                    Author = "Mark Twain",
                    Title = "Adventures of Huckleberry Finn",
                    YearPublished = 1884,
                    Quantity = 3
                },
                new Book {
                    CodeNumber = "13",
                    Author = "Emily Bronte",
                    Title = "Wuthering Heights",
                    YearPublished = 1847,
                    Quantity = 1
                },
                new Book {
                    CodeNumber = "14",
                    Author = "Leo Tolstoy",
                    Title = "War and Peace",
                    YearPublished = 1869,
                    Quantity = 5
                },
                new Book {
                    CodeNumber = "15",
                    Author = "Charles Dickens",
                    Title = "Great Expectations",
                    YearPublished = 1861,
                    Quantity = 2
                }
            };

            builder.Entity<Reservation>().HasData(reservations);
            builder.Entity<Book>().HasData(books);
        }
    }

}