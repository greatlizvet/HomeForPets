namespace HomeForPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        FormID = c.Int(nullable: false, identity: true),
                        FormName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Enable = c.Boolean(nullable: false),
                        Description = c.String(),
                        Age = c.String(),
                        ProfileID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        SpecieID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FormID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Species", t => t.SpecieID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.SpecieID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.ImageID);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        SpecieID = c.Int(nullable: false, identity: true),
                        SpecieName = c.String(),
                    })
                .PrimaryKey(t => t.SpecieID);
            
            CreateTable(
                "dbo.ImageForms",
                c => new
                    {
                        Image_ImageID = c.Int(nullable: false),
                        Form_FormID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Image_ImageID, t.Form_FormID })
                .ForeignKey("dbo.Images", t => t.Image_ImageID, cascadeDelete: true)
                .ForeignKey("dbo.Forms", t => t.Form_FormID, cascadeDelete: true)
                .Index(t => t.Image_ImageID)
                .Index(t => t.Form_FormID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Forms", "SpecieID", "dbo.Species");
            DropForeignKey("dbo.ImageForms", "Form_FormID", "dbo.Forms");
            DropForeignKey("dbo.ImageForms", "Image_ImageID", "dbo.Images");
            DropForeignKey("dbo.Forms", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Forms", new[] { "SpecieID" });
            DropIndex("dbo.ImageForms", new[] { "Form_FormID" });
            DropIndex("dbo.ImageForms", new[] { "Image_ImageID" });
            DropIndex("dbo.Forms", new[] { "CategoryID" });
            DropTable("dbo.ImageForms");
            DropTable("dbo.Species");
            DropTable("dbo.Images");
            DropTable("dbo.Forms");
            DropTable("dbo.Categories");
        }
    }
}
