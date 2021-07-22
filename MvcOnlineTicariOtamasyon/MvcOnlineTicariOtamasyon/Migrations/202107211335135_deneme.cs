namespace MvcOnlineTicariOtamasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deneme : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carilers", "CariAd", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AlterColumn("dbo.Carilers", "CariSoyad", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AlterColumn("dbo.Carilers", "CariSehir", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AlterColumn("dbo.Carilers", "CariMail", c => c.String(nullable: false, maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carilers", "CariMail", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.Carilers", "CariSehir", c => c.String(maxLength: 13, unicode: false));
            AlterColumn("dbo.Carilers", "CariSoyad", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.Carilers", "CariAd", c => c.String(maxLength: 30, unicode: false));
        }
    }
}
