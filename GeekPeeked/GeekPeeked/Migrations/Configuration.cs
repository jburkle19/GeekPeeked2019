namespace GeekPeeked.Migrations
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<GeekPeekedDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GeekPeekedDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            #region admin role

            if (!roleManager.RoleExists("ADMIN"))
                roleManager.Create(new IdentityRole("ADMIN"));

            #endregion admin role

            #region burkle

            var adminUser = userManager.FindByEmail("jburkle19@gmail.com");
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = "jburkle19@gmail.com",
                    Email = "jburkle19@gmail.com",
                    FirstName = "John",
                    LastName = "Burkle",
                    PhoneNumber = "330.400.8169",
                };

                userManager.Create(adminUser, "password");
                userManager.AddToRole(adminUser.Id, "ADMIN");
            }

            #endregion burkle

            if (!context.Movies.Any())
            {
                var movies = new List<Movie>()
                {
                    new Movie() { Title = "A Star Is Born" },
                    new Movie() { Title = "Roma" },
                    new Movie() { Title = "Green Book" },
                    new Movie() { Title = "The Favourite" },
                    new Movie() { Title = "BlacKkKlansman" },
                    new Movie() { Title = "Black Panther" },
                    new Movie() { Title = "Vice" },
                    new Movie() { Title = "Bohemian Rhapsody" },
                    new Movie() { Title = "Cold War" },
                    new Movie() { Title = "The Wife" },
                    new Movie() { Title = "Can You Ever Forgive Me?" },
                    new Movie() { Title = "Bohemian Rhapsody" },
                    new Movie() { Title = "At Eternity's Gate" },
                    new Movie() { Title = "If Beale Street Could Talk" },
                    new Movie() { Title = "The Ballad of Buster Scruggs" },
                    new Movie() { Title = "First Reformed" },
                    new Movie() { Title = "Never Look Away" },
                    new Movie() { Title = "Mary Poppins Return" },
                    new Movie() { Title = "Mary Queen of Scots" },
                    new Movie() { Title = "Border" },
                    new Movie() { Title = "First Man" },
                    new Movie() { Title = "Isle of Dogs" },
                    new Movie() { Title = "RBG" },
                    new Movie() { Title = "A Quiet Place" },
                    new Movie() { Title = "Avengers: Infinity War" },
                    new Movie() { Title = "Ready Player One" },
                    new Movie() { Title = "Christopher Robin" },
                    new Movie() { Title = "Solo: A Star Wars Story" },
                    new Movie() { Title = "Incredibles 2" },
                    new Movie() { Title = "Spider-Man: Into the Spider-Verse" },
                    new Movie() { Title = "Ralph Breaks the Internet" },
                    new Movie() { Title = "Mirai" },
                    new Movie() { Title = "Free Solo" },
                    new Movie() { Title = "Of Fathers and Sons" },
                    new Movie() { Title = "Minding the Gap" },
                    new Movie() { Title = "Hale County This Morning, This Evening" },
                    new Movie() { Title = "Shoplifters" },
                    new Movie() { Title = "Capernaum" },
                    new Movie() { Title = "Bao" },
                    new Movie() { Title = "Late Afternoon" },
                    new Movie() { Title = "One Small Step" },
                    new Movie() { Title = "Weekends" },
                    new Movie() { Title = "Animal Behaviour" },
                    new Movie() { Title = "Black Sheep" },
                    new Movie() { Title = "End Game" },
                    new Movie() { Title = "Life Boat" },
                    new Movie() { Title = "A Night at the Garden" },
                    new Movie() { Title = "Period. End of Sentence." },
                    new Movie() { Title = "Mother" },
                    new Movie() { Title = "Marguerite" },
                    new Movie() { Title = "Detainment" },
                    new Movie() { Title = "Skin" },
                    new Movie() { Title = "Fauve" }
                };

                movies.ForEach(m => context.Movies.Add(m));
                context.SaveChanges();
            }

            #region movies

            #endregion movies

            #region people

            if (!context.People.Any())
            {
                var people = new List<Person>()
                {
                    new Person() { Name = "Alfonso Cuaron" },
                    new Person() { Name = "Spike Lee" },
                    new Person() { Name = "Pawel Pawlikowski" },
                    new Person() { Name = "Yorgos Lanthimos" },
                    new Person() { Name = "Adam McKay" },
                    new Person() { Name = "Glenn Close" },
                    new Person() { Name = "Lady Gaga" },
                    new Person() { Name = "Olivia Colman" },
                    new Person() { Name = "Melissa McCarthy" },
                    new Person() { Name = "Yalitza Aparicio" },
                    new Person() { Name = "Christian Bale" },
                    new Person() { Name = "Bradley Cooper" },
                    new Person() { Name = "Rami Malek" },
                    new Person() { Name = "Willem DaFoe" },
                    new Person() { Name = "Viggo Mortensen" },
                    new Person() { Name = "Regina King" },
                    new Person() { Name = "Amy Adams" },
                    new Person() { Name = "Rachel Weisz" },
                    new Person() { Name = "Emma Stone" },
                    new Person() { Name = "Marina De Tavira" },
                    new Person() { Name = "Mahershala Ali" },
                    new Person() { Name = "Richard E. Grant" },
                    new Person() { Name = "Sam Elliott" },
                    new Person() { Name = "Sam Rockwell" },
                    new Person() { Name = "Adam Driver" }
                };

                people.ForEach(p => context.People.Add(p));
                context.SaveChanges();
            }

            #endregion people

            #region contests

            if (!context.Contests.Any())
                context.Contests.Add(new Contest()
                {
                    ContestType = ContestType.AcademyAwardsBallot,
                    Title = "91st Academy Awards Ballot",
                    Objective = "Fill out your ballot.<br />Pick the winners.<br />Have the most points.<br />Profit!",
                    Rules = "Best Picture, Best Director, Best Actress, Best Actor, Best Supporting Actress, and Best Supporting Actor categories are worth 3 points.<br />Best Adapted Screenplay, Best Original Screenplay, Best Cinematography, Best Costume Design, Best Film Editing, Best Makeup and Hairstyling, Best Production Design, Best Score, and Best Song categories are worth 2 points.<br />Best Sound Editing, Best Sound Mixing, Best Visual Effects, Best Animated Feature, Best Documentary Feature, Best Foreign Language Film, Best Animated Short, Best Documentary Short, and Best Live Action Short categories are worth 1 point.",
                    Signup = new DateTime(2019, 2, 1, 0, 0, 0),
                    SignupEnd = new DateTime(2019, 2, 24, 18, 0, 0),
                    Start = new DateTime(2019, 2, 24, 18, 0, 0)
                });

            #endregion contests

            #region categories

            if (!context.Categories.Any())
            {
                var contest = context.Contests.FirstOrDefault(c => c.Title == "91st Academy Awards Ballot");

                if (contest != null)
                {
                    var categories = new List<Category>()
                    {
                        new Category() { ContestId = contest.Id, Title = "Best Picture", PointValue = 3, SortOrder = 1 },
                        new Category() { ContestId = contest.Id, Title = "Best Director", PointValue = 3, SortOrder = 2 },
                        new Category() { ContestId = contest.Id, Title = "Best Actress", PointValue = 3, SortOrder = 3 },
                        new Category() { ContestId = contest.Id, Title = "Best Actor", PointValue = 3, SortOrder = 4 },
                        new Category() { ContestId = contest.Id, Title = "Best Supporting Actress", PointValue = 3, SortOrder = 5 },
                        new Category() { ContestId = contest.Id, Title = "Best Supporting Actor", PointValue = 3, SortOrder = 6 },
                        new Category() { ContestId = contest.Id, Title = "Best Adapted Screenplay", PointValue = 2, SortOrder = 7 },
                        new Category() { ContestId = contest.Id, Title = "Best Original Screenplay", PointValue = 2, SortOrder = 8 },
                        new Category() { ContestId = contest.Id, Title = "Best Cinematography", PointValue = 2, SortOrder = 9 },
                        new Category() { ContestId = contest.Id, Title = "Best Costume Design", PointValue = 2, SortOrder = 10 },
                        new Category() { ContestId = contest.Id, Title = "Best Film Editing", PointValue = 2, SortOrder = 11 },
                        new Category() { ContestId = contest.Id, Title = "Best Makeup and Hairstyling", PointValue = 2, SortOrder = 12 },
                        new Category() { ContestId = contest.Id, Title = "Best Production Design", PointValue = 2, SortOrder = 13 },
                        new Category() { ContestId = contest.Id, Title = "Best Score", PointValue = 2, SortOrder = 14 },
                        new Category() { ContestId = contest.Id, Title = "Best Song", PointValue = 2, SortOrder = 15 },
                        new Category() { ContestId = contest.Id, Title = "Best Sound Editing", PointValue = 1, SortOrder = 16 },
                        new Category() { ContestId = contest.Id, Title = "Best Sound Mixing", PointValue = 1, SortOrder = 17 },
                        new Category() { ContestId = contest.Id, Title = "Best Visual Effects", PointValue = 1, SortOrder = 18 },
                        new Category() { ContestId = contest.Id, Title = "Best Animated Feature", PointValue = 1, SortOrder = 19 },
                        new Category() { ContestId = contest.Id, Title = "Best Documentary Feature", PointValue = 1, SortOrder = 20 },
                        new Category() { ContestId = contest.Id, Title = "Best Foreign Language Film", PointValue = 1, SortOrder = 21 },
                        new Category() { ContestId = contest.Id, Title = "Best Animated Short", PointValue = 1, SortOrder = 22 },
                        new Category() { ContestId = contest.Id, Title = "Best Documentary Short", PointValue = 1, SortOrder = 23 },
                        new Category() { ContestId = contest.Id, Title = "Best Live Action Short", PointValue = 1, SortOrder = 24 }
                    };

                    categories.ForEach(c => context.Categories.Add(c));
                    context.SaveChanges();
                }
            }

            #endregion categories

            #region nominees

            var category = context.Categories.FirstOrDefault(c => c.Title == "Best Picture");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "A Star Is Born")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Roma")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Green Book")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "The Favourite")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "BlacKkKlansman")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Black Panther")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Vice")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Bohemian Rhapsody")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Director");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Roma")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Alfonso Cuaron")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "BlacKkKlansman")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Spike Lee")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Cold War")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Pawel Pawlikowski")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "The Favourite")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Yorgos Lanthimos")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Vice")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Adam McKay")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Actress");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "The Wife")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Glenn Close")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "A Star Is Born")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Lady Gaga")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "The Favourite")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Olivia Colman")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Can You Ever Forgive Me?")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Melissa McCarthy")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Roma")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Yalitza Aparicio")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Actor");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Vice")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Christian Bale")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "A Star Is Born")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Bradley Cooper")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Bohemian Rhapsody")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Rami Malek")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "At Eternity's Gate")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Willem DaFoe")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Green Book")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Viggo Mortensen")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Supporting Actress");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "If Beale Street Could Talk")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Regina King")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Vice")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Amy Adams")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "The Favourite")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Rachel Weisz")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "The Favourite")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Emma Stone")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Roma")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Marina De Tavira")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Supporting Actor");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Green Book")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Mahershala Ali")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Can You Ever Forgive Me?")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Richard E. Grant")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "A Star Is Born")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Sam Elliott")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Vice")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Sam Rockwell")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "BlacKkKlansman")?.Id), PersonId = (context.People.FirstOrDefault(p => p.Name == "Adam Driver")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Adapted Screenplay");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "The Ballad of Buster Scruggs")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "BlacKkKlansman")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "If Beale Street Could Talk")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Can You Ever Forgive Me?")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "A Star Is Born")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Original Screenplay");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "The Favourite")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Roma")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Green Book")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Vice")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "First Reformed")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Cinematography");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Roma")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "The Favourite")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "A Star Is Born")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Cold War")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Never Look Away")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Costume Design");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "The Ballad of Buster Scruggs")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "The Favourite")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Black Panther")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Mary Poppins Return")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Mary Queen of Scots")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Film Editing");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "The Favourite")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Vice")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Bohemian Rhapsody")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "BlacKkKlansman")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Green Book")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Makeup and Hairstyling");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Vice")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Mary Queen of Scots")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Border")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Production Design");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "The Favourite")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Black Panther")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Mary Poppins Return")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "First Man")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Roma")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Score");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "If Beale Street Could Talk")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Black Panther")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Mary Poppins Return")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Isle of Dogs")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "BlacKkKlansman")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Song");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "A Star Is Born")?.Id), SongTitle = "Shallow", SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Black Panther")?.Id), SongTitle = "All the Stars", SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "RBG")?.Id), SongTitle = "I’ll Fight", SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Mary Poppins Return")?.Id), SongTitle = "The Place Where Lost Things Go", SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "The Ballad of Buster Scruggs")?.Id), SongTitle = "When a Cowboy Trades His Spurs for Wings", SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Sound Editing");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "First Man")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Bohemian Rhapsody")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Black Panther")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "A Quiet Place")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Roma")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Sound Mixing");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "A Star Is Born")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "First Man")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Black Panther")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Roma")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Bohemian Rhapsody")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Visual Effects");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Avengers: Infinity War")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Ready Player One")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Christopher Robin")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Solo: A Star Wars Story")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Animated Feature");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Incredibles 2")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Spider-Man: Into the Spider-Verse")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Isle of Dogs")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Ralph Breaks the Internet")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Mirai")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Documentary Feature");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Free Solo")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Of Fathers and Sons")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "RBG")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Minding the Gap")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Hale County This Morning, This Evening")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Foreign Language Film");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Roma")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Cold War")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Shoplifters")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Capernaum")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Never Look Away")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Animated Short");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Bao")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Late Afternoon")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "One Small Step")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Weekends")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Animal Behaviour")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Documentary Short");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Black Sheep")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "End Game")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Life Boat")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "A Night at the Garden")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Period. End of Sentence.")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            category = context.Categories.FirstOrDefault(c => c.Title == "Best Live Action Short");

            if (category != null && !context.Nominees.Where(n => n.CategoryId == category.Id).Any())
            {
                var nominees = new List<Nominee>()
                {
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Mother")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Marguerite")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Detainment")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Skin")?.Id), SortOrder = 0, IsWinner = false },
                    new Nominee() { CategoryId = category.Id, MovieId = (context.Movies.FirstOrDefault(m => m.Title == "Fauve")?.Id), SortOrder = 0, IsWinner = false }
                };

                nominees.ForEach(n => context.Nominees.Add(n));
                context.SaveChanges();
            }

            #endregion nominees
        }
    }
}
