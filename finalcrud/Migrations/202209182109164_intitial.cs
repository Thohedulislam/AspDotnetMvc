namespace finalcrud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DeptID = c.Int(nullable: false, identity: true),
                        DeptName = c.String(),
                    })
                .PrimaryKey(t => t.DeptID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmpID = c.Int(nullable: false, identity: true),
                        EmpName = c.String(),
                        Email = c.String(),
                        Gender = c.String(),
                        date = c.DateTime(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Photo = c.String(),
                        DeptID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpID)
                .ForeignKey("dbo.Department", t => t.DeptID, cascadeDelete: true)
                .Index(t => t.DeptID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "DeptID", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "DeptID" });
            DropTable("dbo.Users");
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
        }
    }
}
