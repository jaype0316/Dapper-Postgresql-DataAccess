using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDapper
{
    public class PostgreSqlConnectionFactory
    {
        public static NpgsqlConnection Create(string connectionString)
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            return new NpgsqlConnection(connectionString);
        }
    }
}
