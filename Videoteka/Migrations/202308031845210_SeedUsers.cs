namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Adresa], [Telefon], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'01c0b6c6-dd16-44fd-85f2-f180056dbf2b', N'Testna bb', N'38267123456', N'new@videoteka.me', 0, N'AB6AALDvrLz4cotuhsK6sCIMP5Tj11cU0gJkdgDvOgT9B3EKErfJMDt5Oq6d6Bpqtg==', N'5f36a3b8-85c3-43e2-94e4-af7b574e7eaa', NULL, 0, 0, NULL, 1, 0, N'new@videoteka.me')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Adresa], [Telefon], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'12ced9d4-4502-4662-bee5-5691d4723027', N'Testna bb', N'38267456789', N'admin@videoteka.me', 0, N'AHjnIqloPVa2oTVOE8HlqqFjjmzp1GyqqIr5BrX7+oQjC71DC5lRXg215xIssmg60Q==', N'b9fde763-8328-4e1f-bea1-7da78a457465', NULL, 0, 0, NULL, 1, 0, N'admin@videoteka.me')
");
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ca22c995-4105-46c1-a428-7885af2342b7', N'Administrator')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'79c9a4e3-d720-4355-9ed5-6a4f5e5b0efe', N'NewUser')
");
            Sql(@"
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'01c0b6c6-dd16-44fd-85f2-f180056dbf2b', N'79c9a4e3-d720-4355-9ed5-6a4f5e5b0efe')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'12ced9d4-4502-4662-bee5-5691d4723027', N'ca22c995-4105-46c1-a428-7885af2342b7')
");
        }
        
        public override void Down()
        {
        }
    }
}
