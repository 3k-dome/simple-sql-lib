using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace SimpleSqlLib {

    public class QueryExecutor {

        private readonly string _conString;

        public QueryExecutor(string connectionString) {
            this._conString = connectionString;
        }

        public SqlDataReader Execute(SqlCommand command) {
            SqlConnection connection = new(this._conString);
            command.Connection = connection;
            using (command) {
                command.Connection.Open();
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        public IEnumerable<IDataRecord> GetRecords(SqlCommand command) {
            using (SqlDataReader reader = this.Execute(command)) {
                while (reader.Read()) {
                    yield return reader;
                }
            }
        }
    }
}
