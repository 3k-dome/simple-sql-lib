﻿using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SimpleSqlLib {
    public class QueryExecutorAsync {

        private readonly string _conString;

        public QueryExecutorAsync(string connectionString) {
            this._conString = connectionString;
        }

        public async Task<SqlDataReader> ExecuteAsync(SqlCommand command) {
            using (SqlConnection connection = new(this._conString)) {
                command.Connection = connection;
                await command.Connection.OpenAsync();
                return await command.ExecuteReaderAsync();
            }
        }

        public async IAsyncEnumerable<IDataRecord> GetRecordsAsync(SqlCommand command) {
            using (SqlDataReader reader = await this.ExecuteAsync(command)) {
                while (await reader.ReadAsync()) {
                    yield return reader;
                }
            }
        }
    }
}
