namespace DataBaseModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeysToMessage : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Messages", name: "Receiver_Id", newName: "ReceiverId");
            RenameColumn(table: "dbo.Messages", name: "Sender_Id", newName: "SenderId");
            RenameIndex(table: "dbo.Messages", name: "IX_Sender_Id", newName: "IX_SenderId");
            RenameIndex(table: "dbo.Messages", name: "IX_Receiver_Id", newName: "IX_ReceiverId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Messages", name: "IX_ReceiverId", newName: "IX_Receiver_Id");
            RenameIndex(table: "dbo.Messages", name: "IX_SenderId", newName: "IX_Sender_Id");
            RenameColumn(table: "dbo.Messages", name: "SenderId", newName: "Sender_Id");
            RenameColumn(table: "dbo.Messages", name: "ReceiverId", newName: "Receiver_Id");
        }
    }
}
