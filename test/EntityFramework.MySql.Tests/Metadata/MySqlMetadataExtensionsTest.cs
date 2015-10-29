// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Conventions;
using Xunit;

namespace Microsoft.Data.Entity.MySql.Metadata
{
    public class MySqlMetadataExtensionsTest
    {
        [Fact]
        public void Can_get_and_set_column_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Name)
                .Metadata;

            Assert.Equal("Name", property.MySql().ColumnName);
            Assert.Equal("Name", ((IProperty)property).MySql().ColumnName);

            property.Relational().ColumnName = "Eman";

            Assert.Equal("Eman", property.MySql().ColumnName);
            Assert.Equal("Eman", ((IProperty)property).MySql().ColumnName);

            property.MySql().ColumnName = "MyNameIs";

            Assert.Equal("MyNameIs", property.MySql().ColumnName);
            Assert.Equal("MyNameIs", ((IProperty)property).MySql().ColumnName);

            property.MySql().ColumnName = null;

            Assert.Equal("Eman", property.MySql().ColumnName);
            Assert.Equal("Eman", ((IProperty)property).MySql().ColumnName);
        }

        [Fact]
        public void Can_get_and_set_table_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var entityType = modelBuilder
                .Entity<Customer>()
                .Metadata;

            Assert.Equal("Customer", entityType.MySql().TableName);
            Assert.Equal("Customer", ((IEntityType)entityType).MySql().TableName);

            entityType.Relational().TableName = "Customizer";

            Assert.Equal("Customizer", entityType.MySql().TableName);
            Assert.Equal("Customizer", ((IEntityType)entityType).MySql().TableName);

            entityType.MySql().TableName = "Custardizer";

            Assert.Equal("Custardizer", entityType.MySql().TableName);
            Assert.Equal("Custardizer", ((IEntityType)entityType).MySql().TableName);

            entityType.MySql().TableName = null;

            Assert.Equal("Customizer", entityType.MySql().TableName);
            Assert.Equal("Customizer", ((IEntityType)entityType).MySql().TableName);
        }

        [Fact]
        public void Can_get_schema_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var entityType = modelBuilder
                .Entity<Customer>()
                .Metadata;

            Assert.Null(entityType.MySql().Schema);
            Assert.Null(((IEntityType)entityType).MySql().Schema);

            entityType.Relational().Schema = "db0";

            Assert.Equal("db0", entityType.MySql().Schema);
            Assert.Equal("db0", ((IEntityType)entityType).MySql().Schema);
        }

        [Fact]
        public void Can_get_and_set_column_type()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Name)
                .Metadata;

            Assert.Null(property.MySql().ColumnType);
            Assert.Null(((IProperty)property).MySql().ColumnType);

            property.Relational().ColumnType = "nvarchar(max)";

            Assert.Equal("nvarchar(max)", property.MySql().ColumnType);
            Assert.Equal("nvarchar(max)", ((IProperty)property).MySql().ColumnType);

            property.MySql().ColumnType = "nvarchar(verstappen)";

            Assert.Equal("nvarchar(verstappen)", property.MySql().ColumnType);
            Assert.Equal("nvarchar(verstappen)", ((IProperty)property).MySql().ColumnType);

            property.MySql().ColumnType = null;

            Assert.Equal("nvarchar(max)", property.MySql().ColumnType);
            Assert.Equal("nvarchar(max)", ((IProperty)property).MySql().ColumnType);
        }

        [Fact]
        public void Can_get_and_set_column_default_expression()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Name)
                .Metadata;

            Assert.Null(property.MySql().GeneratedValueSql);
            Assert.Null(((IProperty)property).MySql().GeneratedValueSql);

            property.Relational().GeneratedValueSql = "newsequentialid()";

            Assert.Equal("newsequentialid()", property.MySql().GeneratedValueSql);
            Assert.Equal("newsequentialid()", ((IProperty)property).MySql().GeneratedValueSql);

            property.MySql().GeneratedValueSql = "expressyourself()";

            Assert.Equal("expressyourself()", property.MySql().GeneratedValueSql);
            Assert.Equal("expressyourself()", ((IProperty)property).MySql().GeneratedValueSql);

            property.MySql().GeneratedValueSql = null;

            Assert.Equal("newsequentialid()", property.MySql().GeneratedValueSql);
            Assert.Equal("newsequentialid()", ((IProperty)property).MySql().GeneratedValueSql);
        }

        [Fact]
        public void Can_get_and_set_column_key_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var key = modelBuilder
                .Entity<Customer>()
                .HasKey(e => e.Id)
                .Metadata;

            Assert.Equal("PK_Customer", key.MySql().Name);
            Assert.Equal("PK_Customer", ((IKey)key).MySql().Name);

            key.Relational().Name = "PrimaryKey";

            Assert.Equal("PrimaryKey", key.MySql().Name);
            Assert.Equal("PrimaryKey", ((IKey)key).MySql().Name);

            key.MySql().Name = "PrimarySchool";

            Assert.Equal("PrimarySchool", key.MySql().Name);
            Assert.Equal("PrimarySchool", ((IKey)key).MySql().Name);

            key.MySql().Name = null;

            Assert.Equal("PrimaryKey", key.MySql().Name);
            Assert.Equal("PrimaryKey", ((IKey)key).MySql().Name);
        }

        [Fact]
        public void Can_get_and_set_column_foreign_key_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            modelBuilder
                .Entity<Customer>()
                .HasKey(e => e.Id);

            var foreignKey = modelBuilder
                .Entity<Order>()
                .HasOne<Customer>()
                .WithOne()
                .HasForeignKey<Order>(e => e.CustomerId)
                .Metadata;

            Assert.Equal("FK_Order_Customer_CustomerId", foreignKey.MySql().Name);
            Assert.Equal("FK_Order_Customer_CustomerId", ((IForeignKey)foreignKey).MySql().Name);

            foreignKey.Relational().Name = "FK";

            Assert.Equal("FK", foreignKey.MySql().Name);
            Assert.Equal("FK", ((IForeignKey)foreignKey).MySql().Name);

            foreignKey.MySql().Name = "KFC";

            Assert.Equal("KFC", foreignKey.MySql().Name);
            Assert.Equal("KFC", ((IForeignKey)foreignKey).MySql().Name);

            foreignKey.MySql().Name = null;

            Assert.Equal("FK", foreignKey.MySql().Name);
            Assert.Equal("FK", ((IForeignKey)foreignKey).MySql().Name);
        }

        [Fact]
        public void Can_get_and_set_index_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var index = modelBuilder
                .Entity<Customer>()
                .HasIndex(e => e.Id)
                .Metadata;

            Assert.Equal("IX_Customer_Id", index.MySql().Name);
            Assert.Equal("IX_Customer_Id", ((IIndex)index).MySql().Name);

            index.Relational().Name = "MyIndex";

            Assert.Equal("MyIndex", index.MySql().Name);
            Assert.Equal("MyIndex", ((IIndex)index).MySql().Name);

            index.MySql().Name = "DexKnows";

            Assert.Equal("DexKnows", index.MySql().Name);
            Assert.Equal("DexKnows", ((IIndex)index).MySql().Name);

            index.MySql().Name = null;

            Assert.Equal("MyIndex", index.MySql().Name);
            Assert.Equal("MyIndex", ((IIndex)index).MySql().Name);
        }

        [Fact]
        public void Can_get_and_set_sequence()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());
            var model = modelBuilder.Model;

            Assert.Null(model.Relational().FindSequence("Foo"));
            Assert.Null(model.MySql().FindSequence("Foo"));
            Assert.Null(((IModel)model).MySql().FindSequence("Foo"));

            var sequence = model.MySql().GetOrAddSequence("Foo");

            Assert.Null(model.Relational().FindSequence("Foo"));
            Assert.Equal("Foo", model.MySql().FindSequence("Foo").Name);
            Assert.Equal("Foo", ((IModel)model).MySql().FindSequence("Foo").Name);

            Assert.Equal("Foo", sequence.Name);
            Assert.Null(sequence.Schema);
            Assert.Equal(1, sequence.IncrementBy);
            Assert.Equal(1, sequence.StartValue);
            Assert.Null(sequence.MinValue);
            Assert.Null(sequence.MaxValue);
            Assert.Same(typeof(long), sequence.ClrType);

            Assert.Null(model.Relational().FindSequence("Foo"));

            var sequence2 = model.MySql().FindSequence("Foo");

            sequence.StartValue = 1729;
            sequence.IncrementBy = 11;
            sequence.MinValue = 2001;
            sequence.MaxValue = 2010;
            sequence.ClrType = typeof(int);

            Assert.Equal("Foo", sequence.Name);
            Assert.Null(sequence.Schema);
            Assert.Equal(11, sequence.IncrementBy);
            Assert.Equal(1729, sequence.StartValue);
            Assert.Equal(2001, sequence.MinValue);
            Assert.Equal(2010, sequence.MaxValue);
            Assert.Same(typeof(int), sequence.ClrType);

            Assert.Equal(sequence2.Name, sequence.Name);
            Assert.Equal(sequence2.Schema, sequence.Schema);
            Assert.Equal(sequence2.IncrementBy, sequence.IncrementBy);
            Assert.Equal(sequence2.StartValue, sequence.StartValue);
            Assert.Equal(sequence2.MinValue, sequence.MinValue);
            Assert.Equal(sequence2.MaxValue, sequence.MaxValue);
            Assert.Same(sequence2.ClrType, sequence.ClrType);
        }

        [Fact]
        public void Can_get_multiple_sequences()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());
            var model = modelBuilder.Model;

            model.Relational().GetOrAddSequence("Fibonacci");
            model.MySql().GetOrAddSequence("Golomb");

            var sequences = model.MySql().Sequences;

            Assert.Equal(2, sequences.Count);
            Assert.Contains(sequences, s => s.Name == "Fibonacci");
            Assert.Contains(sequences, s => s.Name == "Golomb");
        }

        private class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private class Order
        {
            public int CustomerId { get; set; }
        }
    }
}
