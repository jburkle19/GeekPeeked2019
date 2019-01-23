namespace GeekPeeked.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initialization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContestId = c.Int(nullable: false),
                        Title = c.String(),
                        PointValue = c.Int(nullable: false),
                        SortOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contest", t => t.ContestId, cascadeDelete: true)
                .Index(t => t.ContestId);
            
            CreateTable(
                "dbo.Contest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContestType = c.Int(nullable: false),
                        Title = c.String(),
                        Objective = c.String(),
                        Rules = c.String(),
                        Signup = c.DateTime(nullable: false),
                        SignupEnd = c.DateTime(nullable: false),
                        Start = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ReleaseDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nominee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        MovieId = c.Int(),
                        PersonId = c.Int(),
                        SongTitle = c.String(),
                        SortOrder = c.Int(nullable: false),
                        IsWinner = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .Index(t => t.CategoryId)
                .Index(t => t.MovieId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MovieCategory",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_Id, t.Category_Id })
                .ForeignKey("dbo.Movie", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.PersonCategory",
                c => new
                    {
                        Person_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Category_Id })
                .ForeignKey("dbo.Person", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Nominee", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Nominee", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.Nominee", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.PersonCategory", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.PersonCategory", "Person_Id", "dbo.Person");
            DropForeignKey("dbo.MovieCategory", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.MovieCategory", "Movie_Id", "dbo.Movie");
            DropForeignKey("dbo.Category", "ContestId", "dbo.Contest");
            DropIndex("dbo.PersonCategory", new[] { "Category_Id" });
            DropIndex("dbo.PersonCategory", new[] { "Person_Id" });
            DropIndex("dbo.MovieCategory", new[] { "Category_Id" });
            DropIndex("dbo.MovieCategory", new[] { "Movie_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Nominee", new[] { "PersonId" });
            DropIndex("dbo.Nominee", new[] { "MovieId" });
            DropIndex("dbo.Nominee", new[] { "CategoryId" });
            DropIndex("dbo.Category", new[] { "ContestId" });
            DropTable("dbo.PersonCategory");
            DropTable("dbo.MovieCategory");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Nominee");
            DropTable("dbo.Person");
            DropTable("dbo.Movie");
            DropTable("dbo.Contest");
            DropTable("dbo.Category");
        }
    }
}
