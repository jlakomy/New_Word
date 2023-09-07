using N_WORD.Entities;
using System.Collections.Generic;
using System.Linq;

namespace N_WORD
{
    public class N_WordSeeder
    {
        private N_WordDbContext _dbContext;

        public N_WordSeeder(N_WordDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Categories.Any())
                {
                    var categories = GetCategories();
                    _dbContext.Categories.AddRange(categories);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Category> GetCategories()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Kitchen",
                    Description = "Food,drinks and kichen utensils",
                    Words = new List<Word>()
                    {
                        new Word()
                        {
                            PlMeaning = "Widelec",
                            EnMeaning = "Fork",
                            Description = "Smaller trident",
                            ExampleSentence = "I will stab you with this fork",
                        },
                        new Word()
                        {
                            PlMeaning = "Patelnia",
                            EnMeaning = "Pan",
                            Description = "Shallow utensil use for frying",
                            ExampleSentence = "This pan is unwashed",
                        },
                        new Word()
                        {
                            PlMeaning = "Baranina",
                            EnMeaning = "Lamb",
                            Description = "Meet obtained from sheeps",
                            ExampleSentence = "Kebabs are originaly made with lamb",
                        },
                    },
                },
                new Category()
                {
                    Name = "Animals",
                    Description = "Animals names and staff to take care of them",
                    Words = new List<Word>()
                    {
                        new Word()
                        {
                            PlMeaning = "Pies",
                            EnMeaning = "Dog",
                            Description = "Human's best friend",
                            ExampleSentence = "Dog is human best friend",
                        },
                        new Word()
                        {
                            PlMeaning = "Kot",
                            EnMeaning = "Cat",
                            Description = "Smaller and cuter lion",
                            ExampleSentence = "My cat broke the lamp yesterday",
                        },
                        new Word()
                        {
                            PlMeaning = "Smycz",
                            EnMeaning = "Lead",
                            Description = "You need it to take youe pet for a walk",
                            ExampleSentence = "I want to take my dog for a walk, but i cant find the lead",
                        },
                    },
                }
            };
            return categories;
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role
                {
                    Name = "User"
                },
                new Role
                {
                    Name = "Menager"
                },
                new Role
                {
                    Name = "Admin"
                },
            };
            return roles;
        }
    }
}
