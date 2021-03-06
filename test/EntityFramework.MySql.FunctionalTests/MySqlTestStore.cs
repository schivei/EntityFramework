// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Microsoft.Data.Entity.FunctionalTests;
using MySql.Data.MySqlClient;

namespace Microsoft.Data.Entity.MySql.FunctionalTests
{
    public class MySqlTestStore : RelationalTestStore
    {
        private static int _scratchCount;

        public static MySqlTestStore GetOrCreateShared(string name, Action initializeDatabase = null) =>
            new MySqlTestStore(name).CreateShared(initializeDatabase);

        public static MySqlTestStore CreateScratch(bool sharedCache = false)
        {
            string name;
            do
            {
                name = "scratch-" + Interlocked.Increment(ref _scratchCount);
            }
            while (File.Exists(name + ".db"));

            return new MySqlTestStore(name).CreateTransient(sharedCache);
        }

        private MySqlConnection _connection;
        private MySqlTransaction _transaction;
        private readonly string _name;
        private bool _deleteDatabase;
        public const int CommandTimeout = 30;

        private MySqlTestStore(string name)
        {
            _name = name;
        }

        private MySqlTestStore CreateShared(Action initializeDatabase)
        {
            CreateShared(typeof(MySqlTestStore).Name + _name, initializeDatabase);

            CreateAndOpenConnection();

            _transaction = _connection.BeginTransaction();

            return this;
        }

        private MySqlTestStore CreateTransient(bool sharedCache)
        {
            CreateAndOpenConnection(sharedCache);

            return AsTransient();
        }

        private void CreateAndOpenConnection(bool sharedCache = false)
        {
            _connection = new MySqlConnection(CreateConnectionString(_name, sharedCache));

            _connection.Open();

            var command = _connection.CreateCommand();
            command.CommandText = "PRAGMA foreign_keys=ON;";
            command.ExecuteNonQuery();
        }

        public MySqlTestStore AsTransient()
        {
            _deleteDatabase = true;
            return this;
        }

        public int ExecuteNonQuery(string sql, params object[] parameters)
        {
            using (var command = CreateCommand(sql, parameters))
            {
                return command.ExecuteNonQuery();
            }
        }

        private DbCommand CreateCommand(string commandText, object[] parameters)
        {
            var command = _connection.CreateCommand();

            if (_transaction != null)
            {
                command.Transaction = _transaction;
            }

            command.CommandText = commandText;
            command.CommandTimeout = CommandTimeout;

            for (var i = 0; i < parameters.Length; i++)
            {
                command.Parameters.AddWithValue("@p" + i, parameters[i]);
            }

            return command;
        }

        public override DbConnection Connection => _connection;
        public override DbTransaction Transaction => _transaction;

        public override void Dispose()
        {
            Transaction?.Dispose();
            Connection?.Dispose();

            if (_deleteDatabase)
            {
                using (var connection = new MySqlConnection(CreateConnectionString(_name)))
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = $"DROP DATABASE `{_name}`;";
                    cmd.ExecuteNonQuery();
                }
            }

            base.Dispose();
        }

        public static string CreateConnectionString(string name, bool sharedCache = false) =>
            new MySqlConnectionStringBuilder
            {
                Database = name,
                TableCaching = sharedCache
            }.ToString();
    }
}
