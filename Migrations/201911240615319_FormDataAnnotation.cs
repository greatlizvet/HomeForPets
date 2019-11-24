namespace HomeForPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FormDataAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Forms", "FormName", c => c.String(nullable: false));
            AlterColumn("dbo.Forms", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Forms", "Description", c => c.String());
            AlterColumn("dbo.Forms", "FormName", c => c.String());
        }
    }
}
