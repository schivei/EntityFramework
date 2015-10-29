// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Data.Entity.Metadata.Conventions;
using Xunit;

namespace Microsoft.Data.Entity.MySql.Metadata.Builders
{
    public class MySqlBuilderExtensionsTest
    {
        [Fact]
        public void Can_set_column_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Name)
                .ForMySqlHasColumnName("MyNameIs")
                .Metadata;

            Assert.Equal("MyNameIs", property.MySql().ColumnName);
        }

        [Fact]
        public void Can_set_column_name_non_generic()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property<string>("Name")
                .ForMySqlHasColumnName("MyNameIs")
                .Metadata;

            Assert.Equal("MyNameIs", property.MySql().ColumnName);
        }

        [Fact]
        public void Can_set_column_type()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Name)
                .ForMySqlHasColumnType("nvarchar(DA)")
                .Metadata;

            Assert.Equal("nvarchar(DA)", property.MySql().ColumnType);
        }

        [Fact]
        public void Can_set_column_type_non_generic()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property<string>("Name")
                .ForMySqlHasColumnType("nvarchar(DA)")
                .Metadata;

            Assert.Equal("nvarchar(DA)", property.MySql().ColumnType);
        }

        [Fact]
        public void Can_set_column_default_expression()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Name)
                .ForMySqlHasDefaultValueSql("VanillaCoke")
                .Metadata;

            Assert.Equal("VanillaCoke", property.MySql().GeneratedValueSql);
        }

        [Fact]
        public void Can_set_column_default_expression_non_generic()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property<string>("Name")
                .ForMySqlHasDefaultValueSql("VanillaCoke")
                .Metadata;

            Assert.Equal("VanillaCoke", property.MySql().GeneratedValueSql);
        }

        [Fact]
        public void Can_set_key_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var key = modelBuilder
                .Entity<Customer>()
                .HasKey(e => e.Id)
                .ForMySqlHasName("LemonSupreme")
                .Metadata;

            Assert.Equal("LemonSupreme", key.MySql().Name);
        }

        [Fact]
        public void Can_set_foreign_key_name_for_one_to_many()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var foreignKey = modelBuilder
                .Entity<Customer>().HasMany(e => e.Orders).WithOne(e => e.Customer)
                .ForMySqlHasConstraintName("ChocolateLimes")
                .Metadata;

            Assert.Equal("ChocolateLimes", foreignKey.MySql().Name);
        }

        [Fact]
        public void Can_set_foreign_key_name_for_one_to_many_non_generic()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var foreignKey = modelBuilder
                .Entity<Customer>().HasMany(typeof(Order)).WithOne()
                .ForMySqlHasConstraintName("ChocolateLimes")
                .Metadata;

            Assert.Equal("ChocolateLimes", foreignKey.MySql().Name);
        }

        [Fact]
        public void Can_set_foreign_key_name_for_many_to_one()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var foreignKey = modelBuilder
                .Entity<Order>().HasOne(e => e.Customer).WithMany(e => e.Orders)
                .ForMySqlHasConstraintName("ChocolateLimes")
                .Metadata;

            Assert.Equal("ChocolateLimes", foreignKey.MySql().Name);
        }

        [Fact]
        public void Can_set_foreign_key_name_for_many_to_one_non_generic()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var foreignKey = modelBuilder
                .Entity<Order>().HasOne(typeof(Customer)).WithMany()
                .ForMySqlHasConstraintName("ChocolateLimes")
                .Metadata;

            Assert.Equal("ChocolateLimes", foreignKey.MySql().Name);
        }

        [Fact]
        public void Can_set_foreign_key_name_for_one_to_one()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var foreignKey = modelBuilder
                .Entity<Order>().HasOne(e => e.Details).WithOne(e => e.Order)
                .ForMySqlHasConstraintName("ChocolateLimes")
                .Metadata;

            Assert.Equal("ChocolateLimes", foreignKey.MySql().Name);
        }

        [Fact]
        public void Can_set_foreign_key_name_for_one_to_one_non_generic()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var foreignKey = modelBuilder
                .Entity<Order>().HasOne(typeof(OrderDetails)).WithOne()
                .ForMySqlHasConstraintName("ChocolateLimes")
                .Metadata;

            Assert.Equal("ChocolateLimes", foreignKey.MySql().Name);
        }

        [Fact]
        public void Can_set_index_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var index = modelBuilder
                .Entity<Customer>()
                .HasIndex(e => e.Id)
                .ForMySqlHasName("Dexter")
                .Metadata;

            Assert.Equal("Dexter", index.MySql().Name);
        }

        [Fact]
        public void Can_set_table_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var entityType = modelBuilder
                .Entity<Customer>()
                .ForMySqlToTable("Custardizer")
                .Metadata;

            Assert.Equal("Custardizer", entityType.MySql().TableName);
        }

        [Fact]
        public void Can_set_table_name_non_generic()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var entityType = modelBuilder
                .Entity("Customer")
                .ForMySqlToTable("Custardizer")
                .Metadata;

            Assert.Equal("Custardizer", entityType.MySql().TableName);
        }

        private class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public IEnumerable<Order> Orders { get; set; }
        }

        private class Order
        {
            public Customer Customer { get; set; }
            public OrderDetails Details { get; set; }
        }

        private class OrderDetails
        {
            public Order Order { get; set; }
        }
    }
}
