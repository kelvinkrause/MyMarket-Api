using FluentMigrator;

namespace MyMarket.Infrastructure.Migrations.Versions
{
    [Migration(DatabaseVersion.TABLE_PRODUCT, "Create table to save product's information")]
    public class Version0000001 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Create.Table("products")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Active").AsBoolean().NotNullable().WithDefaultValue(true)
                .WithColumn("CreatedOn").AsDateTime().NotNullable()
                .WithColumn("UpdatedOn").AsDateTime().Nullable()
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Description").AsString(1000).NotNullable()
                .WithColumn("Price").AsDecimal(18, 2).NotNullable()
                .WithColumn("StockQuantity").AsInt32().NotNullable()
                .WithColumn("Category").AsString(255).NotNullable()
                .WithColumn("Barcode").AsString(255).NotNullable().Unique();
        }
    }
}
