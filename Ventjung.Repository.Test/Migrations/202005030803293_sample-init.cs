namespace Ventjung.Repository.Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sampleinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SampleTables",
                c => new
                    {
                        SampleTableId = c.Int(nullable: false, identity: true),
                        SampleTableString = c.String(),
                    })
                .PrimaryKey(t => t.SampleTableId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SampleTables");
        }
    }
}
