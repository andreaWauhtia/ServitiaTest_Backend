using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Extensions.Options;
using MySqlConnector;
using ServitiaTest_Backend_Common.Configuration;
using ServitiaTest_Backend_Domain;
using ServitiaTest_Backend_Persistence.MappingConfiguration;
using System.Data;

namespace ServitiaTest_Backend_Persistence
{
    public class ServitiaTestContext: DbContext
    {
        private readonly PersistenceConfig _persistenceConfig;
        public ServitiaTestContext(IOptions<PersistenceConfig> options) : base()
        {
            _persistenceConfig = options.Value;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Session> Sessions { get; set; }   

        public IDbConnection GetDbConnection()
        {
            switch (_persistenceConfig.DatabaseProvider)
            {
                case "MySql":
                    return new MySqlConnection(_persistenceConfig.ConnectionString);
                    break;
                default:
                    return new SqlConnection(_persistenceConfig.ConnectionString);
                    break;

            }
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                switch (_persistenceConfig.DatabaseProvider)
                {
                    case "MySql":
                        optionsBuilder.UseMySql(_persistenceConfig.ConnectionString, new MySqlServerVersion(new Version(8, 0, 21)));
                        break;
                    default:
                        optionsBuilder.UseSqlServer(_persistenceConfig.ConnectionString);
                        break;
                }
            }
            
        }
    }
}