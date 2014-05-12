namespace DataBaseModel.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserProfile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProfiles", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserProfiles", new[] { "User_Id" });
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            DropTable("dbo.UserProfiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            CreateIndex("dbo.UserProfiles", "User_Id");
            AddForeignKey("dbo.UserProfiles", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
