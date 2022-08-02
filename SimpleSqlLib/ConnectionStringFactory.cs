using Microsoft.Data.SqlClient;

namespace SimpleSqlLib {
    public class ConnectionStringFactory {

        private readonly string _source;
        private readonly string _catalog;
        private readonly string _conString;

        public ConnectionStringFactory(string source, string catalog) {
            this._source = source;
            this._catalog = catalog;
            this._conString = this.GetConnectionString();
        }

        private string GetConnectionString() {
            SqlConnectionStringBuilder builder = new() {
                DataSource = this._source,
                InitialCatalog = this._catalog,
                IntegratedSecurity = true,
                TrustServerCertificate = true,
            };
            return builder.ToString();
        }

        public string ConnectionString => this._conString;
    }
}
