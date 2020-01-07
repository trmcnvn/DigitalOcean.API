using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class DatabasesClient : IDatabasesClient {
        private readonly IConnection _connection;

        public DatabasesClient(IConnection connection) {
            _connection = connection;
        }

        #region IDatabasesClient Members

        /// <summary>
        /// Add a new connection pool to a PostgreSQL database cluster,
        /// </summary>
        public Task<ConnectionPool> AddConnectionPool(string databaseId, Models.Requests.ConnectionPool pool) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<ConnectionPool>("databases/{id}/pools", parameters, pool, "pool", Method.POST);
        }

        /// <summary>
        /// Add a new database to an existing cluster
        /// </summary>
        public Task<Database> AddDatabase(string databaseId, Models.Requests.Database database) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<Database>("databases/{id}/dbs", parameters, database, "db", Method.POST);
        }

        /// <summary>
        /// Add a new user to a database cluster
        /// </summary>
        public Task<DatabaseUser> AddUser(string databaseId, Models.Requests.DatabaseUser user) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<DatabaseUser>("databases/{id}/users", parameters, user, "user", Method.POST);
        }

        /// <summary>
        /// Create a database cluster
        /// </summary>
        public Task<DatabaseCluster> Create(Models.Requests.DatabaseCluster database) {
            return _connection.ExecuteRequest<DatabaseCluster>("databases", null, database, "database", Method.POST);
        }

        /// <summary>
        /// Create a new read-only replica
        /// </summary>
        public Task<DatabaseReplica> CreateReplica(string databaseId, Models.Requests.DatabaseReplica replica) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<DatabaseReplica>("databases/{id}/replicas", parameters, replica, "replica", Method.POST);
        }

        /// <summary>
        /// Delete a database cluster
        /// </summary>
        public Task Delete(string databaseId) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRaw("databases/{id}", parameters, null, Method.DELETE);
        }

        /// <summary>
        /// Delete a specific connection pool
        /// </summary>
        public Task DeleteConnectionPool(string databaseId, string poolName) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment),
                new Parameter("name", poolName, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRaw("databases/{id}/pools/{name}", parameters, null, Method.DELETE);
        }

        /// <summary>
        /// Delete a specific database
        /// </summary>
        public Task DeleteDatabase(string databaseId, string databaseName) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment),
                new Parameter("name", databaseName, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRaw("databases/{id}/dbs/{name}", parameters, null, Method.DELETE);
        }

        /// <summary>
        /// Delete a specific read-only replica
        /// </summary>
        public Task DeleteReplica(string databaseId, string replicaName) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment),
                new Parameter("name", replicaName, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRaw("databases/{id}/replicas/{name}", parameters, null, Method.DELETE);
        }

        /// <summary>
        /// Retreive information about an existing database cluster
        /// </summary>
        public Task<DatabaseCluster> Get(string databaseId) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<DatabaseCluster>("databases/{id}", parameters, null, "database");
        }

        /// <summary>
        /// Retreive all database clusters on your account
        /// </summary>
        public Task<IReadOnlyList<DatabaseCluster>> GetAll() {
            return _connection.GetPaginated<DatabaseCluster>("databases", null, "databases");
        }

        /// <summary>
        /// Retreive all database clusters on your account by tag
        /// </summary>
        public Task<IReadOnlyList<DatabaseCluster>> GetAllByTag(string tag) {
            var parameters = new List<Parameter> {
                new Parameter("tag_name", tag, ParameterType.QueryString)
            };
            return _connection.GetPaginated<DatabaseCluster>("databases", parameters, "databases");
        }

        /// <summary>
        /// Retreive all read-only replicas associated with a database cluster
        /// </summary>
        public Task<IReadOnlyList<DatabaseReplica>> GetAllReplicas(string databaseId) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment)
            };
            return _connection.GetPaginated<DatabaseReplica>("databases/{id}/replicas", parameters, "replicas");
        }

        /// <summary>
        /// Retreive all of the connection pools available to a database cluster
        /// </summary>
        public Task<IReadOnlyList<ConnectionPool>> GetAllConnectionPools(string databaseId) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment)
            };
            return _connection.GetPaginated<ConnectionPool>("databases/{id}/pools", parameters, "pools");
        }

        /// <summary>
        /// List all of the databases in a cluster
        /// </summary>
        public Task<IReadOnlyList<Database>> GetAllDatabases(string databaseId) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment)
            };
            return _connection.GetPaginated<Database>("databases/{id}/dbs", parameters, "dbs");
        }

        /// <summary>
        /// Retreive all users for your database cluster
        /// </summary>
        public Task<IReadOnlyList<DatabaseUser>> GetAllUsers(string databaseId) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment)
            };
            return _connection.GetPaginated<DatabaseUser>("databases/{id}/users", parameters, "users");
        }

        /// <summary>
        /// Retreive all backups associated with a database cluster
        /// </summary>
        public Task<IReadOnlyList<DatabaseBackup>> GetBackups(string databaseId) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment)
            };
            return _connection.GetPaginated<DatabaseBackup>("databases/{id}/backups", parameters, "backups");
        }

        /// <summary>
        /// Retreieve information about an existing connection pool for a PostgreSQL database cluster
        /// </summary>
        public Task<ConnectionPool> GetConnectionPool(string databaseId, string poolName) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment),
                new Parameter("name", poolName, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<ConnectionPool>("databases/{id}/pools/{name}", parameters, null, "pool");
        }

        /// <summary>
        /// Retreive information about an existing database
        /// </summary>
        public Task<Database> GetDatabase(string databaseId, string databaseName) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment),
                new Parameter("name", databaseName, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<Database>("databases/{id}/dbs/{name}", parameters, null, "db");
        }

        /// <summary>
        /// Retreive an existing read-only replica associated with a database cluster
        /// </summary>
        public Task<DatabaseReplica> GetReplica(string databaseId, string replicaName) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment),
                new Parameter("name", replicaName, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<DatabaseReplica>("databases/{id}/replicas/{name}", parameters, null, "replica");
        }

        /// <summary>
        /// Retreive an existing user for your database cluster
        /// </summary>
        public Task<DatabaseUser> GetUser(string databaseId, string username) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment),
                new Parameter("name", username, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<DatabaseUser>("databases/{id}/users/{name}", parameters, null, "user");
        }

        /// <summary>
        /// Configure the window when automatic maintenance should be performed
        /// </summary>
        public Task Maintenance(string databaseId, Models.Requests.MaintenanceWindow window) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRaw("databases/{id}/maintenance", parameters, window, Method.POST);
        }

        /// <summary>
        /// Migrate a database cluster to a new region
        /// </summary>
        public Task Migrate(string databaseId, Models.Requests.MigrateDatabase migrate) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRaw("databases/{id}/migrate", parameters, migrate, Method.POST);
        }

        /// <summary>
        /// Remove a specific database user
        /// </summary>
        public Task RemoveUser(string databaseId, string username) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment),
                new Parameter("name", username, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRaw("databases/{id}/users/{name}", parameters, null, Method.DELETE);
        }

        /// <summary>
        /// Resize a database cluster
        /// </summary>
        public Task Resize(string databaseId, Models.Requests.ResizeDatabase resize) {
            var parameters = new List<Parameter> {
                new Parameter("id", databaseId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRaw("databases/{id}/resize", parameters, resize, Method.POST);
        }

        /// <summary>
        /// Create a new database cluster based on a backup of an existing cluster
        /// </summary>
        public Task<DatabaseCluster> Restore(Models.Requests.DatabaseBackup backup) {
            return _connection.ExecuteRequest<DatabaseCluster>("databases", null, backup, "database", Method.POST);
        }

        #endregion
    }
}
