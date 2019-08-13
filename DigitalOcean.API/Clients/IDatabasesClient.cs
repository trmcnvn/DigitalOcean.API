using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IDatabasesClient {
        /// <summary>
        /// Create a database cluster
        /// </summary>
        Task<DatabaseCluster> Create(Models.Requests.DatabaseCluster database);

        /// <summary>
        /// Retreive information about an existing database cluster
        /// </summary>
        Task<DatabaseCluster> Get(string databaseId);

        /// <summary>
        /// Retreive all database clusters on your account
        /// </summary>
        Task<IReadOnlyList<DatabaseCluster>> GetAll();

        /// <summary>
        /// Retreive all database clusters on your account by tag
        /// </summary>
        Task<IReadOnlyList<DatabaseCluster>> GetAllByTag(string tag);

        /// <summary>
        /// Resize a database cluster
        /// </summary>
        Task Resize(string databaseId, Models.Requests.ResizeDatabase resize);

        /// <summary>
        /// Migrate a database cluster to a new region
        /// </summary>
        Task Migrate(string databaseId, Models.Requests.MigrateDatabase migrate);

        /// <summary>
        /// Configure the window when automatic maintenance should be performed
        /// </summary>
        Task Maintenance(string databaseId, Models.Requests.MaintenanceWindow window);

        /// <summary>
        /// Retreive all backups associated with a database cluster
        /// </summary>
        Task<IReadOnlyList<DatabaseBackup>> GetBackups(string databaseId);

        /// <summary>
        /// Create a new database cluster based on a backup of an existing cluster
        /// </summary>
        Task<DatabaseCluster> Restore(Models.Requests.DatabaseBackup backup);

        /// <summary>
        /// Delete a database cluster
        /// </summary>
        Task Delete(string databaseId);

        /// <summary>
        /// Create a new read-only replica
        /// </summary>
        Task<DatabaseReplica> CreateReplica(string databaseId, Models.Requests.DatabaseReplica replica);

        /// <summary>
        /// Retreive an existing read-only replica associated with a database cluster
        /// </summary>
        Task<DatabaseReplica> GetReplica(string databaseId, string replicaName);

        /// <summary>
        /// Retreive all read-only replicas associated with a database cluster
        /// </summary>
        Task<IReadOnlyList<DatabaseReplica>> GetAllReplicas(string databaseId);

        /// <summary>
        /// Delete a specific read-only replica
        /// </summary>
        Task DeleteReplica(string databaseId, string replicaName);

        /// <summary>
        /// Add a new user to a database cluster
        /// </summary>
        Task<DatabaseUser> AddUser(string databaseId, Models.Requests.DatabaseUser user);

        /// <summary>
        /// Retreive an existing user for your database cluster
        /// </summary>
        Task<DatabaseUser> GetUser(string databaseId, string username);

        /// <summary>
        /// Retreive all users for your database cluster
        /// </summary>
        Task<IReadOnlyList<DatabaseUser>> GetAllUsers(string databaseId);

        /// <summary>
        /// Remove a specific database user
        /// </summary>
        Task RemoveUser(string databaseId, string username);

        /// <summary>
        /// Add a new database to an existing cluster
        /// </summary>
        Task<Database> AddDatabase(string databaseId, Models.Requests.Database database);

        /// <summary>
        /// Retreive information about an existing database
        /// </summary>
        Task<Database> GetDatabase(string databaseId, string databaseName);

        /// <summary>
        /// List all of the databases in a cluster
        /// </summary>
        Task<IReadOnlyList<Database>> GetAllDatabases(string databaseId);

        /// <summary>
        /// Delete a specific database
        /// </summary>
        Task DeleteDatabase(string databaseId, string databaseName);

        /// <summary>
        /// Add a new connection pool to a PostgreSQL database cluster,
        /// </summary>
        Task<ConnectionPool> AddConnectionPool(string databaseId, Models.Requests.ConnectionPool pool);

        /// <summary>
        /// Retreive all of the connection pools available to a database cluster
        /// </summary>
        Task<IReadOnlyList<ConnectionPool>> GetAllConnectionPools(string databaseId);

        /// <summary>
        /// Retreieve information about an existing connection pool for a PostgreSQL database cluster
        /// </summary>
        Task<ConnectionPool> GetConnectionPool(string databaseId, string poolName);

        /// <summary>
        /// Delete a specific connection pool
        /// </summary>
        Task DeleteConnectionPool(string databaseId, string poolName);
    }
}
