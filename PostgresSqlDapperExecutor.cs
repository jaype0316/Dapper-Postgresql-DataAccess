using Dapper;
using System.Data;

namespace SqlDapper
{
    public class PostgreSqlDapperExecutor
    {
        public static int Execute(string connectionString, ISqlOperation operation)
        {
            using var connection = PostgreSqlConnectionFactory.Create(connectionString);
            return Execute(connection, operation);
        }

        public static int Execute(IDbConnection connection, ISqlOperation operation) => 
            connection.Execute(operation.Text, operation.Parameters, commandTimeout:operation.Timeout, commandType:operation.CommandType);

        public static async Task<int> ExecuteAsync(string connectionString, ISqlOperation operation)
        {
            using var connection = PostgreSqlConnectionFactory.Create(connectionString);
            return await ExecuteAsync(connection, operation);
        }

        public static async Task<int> ExecuteAsync(IDbConnection connection, ISqlOperation operation) =>
            await connection.ExecuteAsync(operation.Text, operation.Parameters,
                commandTimeout: operation.Timeout, commandType: operation.CommandType);

        public static T ExecuteScalar<T>(string connectionString, ISqlOperation operation)
        {
            using var connection = PostgreSqlConnectionFactory.Create(connectionString);
            return ExecuteScalar<T>(connection, operation);
        }

        public static T ExecuteScalar<T>(IDbConnection connection, ISqlOperation operation) =>
         connection.ExecuteScalar<T>(operation.Text, operation.Parameters,
             commandTimeout: operation.Timeout, commandType: operation.CommandType);

        public static async Task<T> ExecuteScalarAsync<T>(string connectionString, ISqlOperation operation)
        {
            using var connection = PostgreSqlConnectionFactory.Create(connectionString);
            return await ExecuteScalarAsync<T>(connection, operation);
        }

        public static async Task<T> ExecuteScalarAsync<T>(IDbConnection connection, ISqlOperation operation) =>
          await connection.ExecuteScalarAsync<T>(operation.Text, operation.Parameters,
              commandTimeout: operation.Timeout, commandType: operation.CommandType);

        public static IEnumerable<T> Query<T>(string connectionString, ISqlOperation operation)
        {
            using var connection = PostgreSqlConnectionFactory.Create(connectionString);
            return Query<T>(connection, operation);
        }

        public static IEnumerable<T> Query<T>(IDbConnection connection, ISqlOperation operation) =>
        connection.Query<T>(operation.Text, operation.Parameters,
            commandTimeout: operation.Timeout, commandType: operation.CommandType);

        public static async Task<IEnumerable<T>> QueryAsync<T>(string connectionString, ISqlOperation operation)
        {
            using var connection = PostgreSqlConnectionFactory.Create(connectionString);
            return await QueryAsync<T>(connection, operation);
        }

        public static async Task<IEnumerable<T>> QueryAsync<T>(IDbConnection connection, ISqlOperation operation) =>
         await connection.QueryAsync<T>(operation.Text, operation.Parameters,
             commandTimeout: operation.Timeout, commandType: operation.CommandType);


        public static T QueryFirstOrDefault<T>(string connectionString, ISqlOperation operation)
        {
            using var connection = PostgreSqlConnectionFactory.Create(connectionString);
            return QueryFirstOrDefault<T>(connection, operation);
        }


        public static T QueryFirstOrDefault<T>(IDbConnection connection, ISqlOperation operation) =>
            connection.QueryFirstOrDefault<T>(operation.Text, operation.Parameters,
                commandTimeout: operation.Timeout, commandType: operation.CommandType);


        public static async Task<T> QueryFirstOrDefaultAsync<T>(string connectionString, ISqlOperation operation)
        {
            using var connection = PostgreSqlConnectionFactory.Create(connectionString);
            return await QueryFirstOrDefaultAsync<T>(connection, operation);
        }

        public static async Task<T> QueryFirstOrDefaultAsync<T>(IDbConnection connection, ISqlOperation operation) =>
          await connection.QueryFirstOrDefaultAsync<T>(operation.Text, operation.Parameters,
              commandTimeout: operation.Timeout, commandType: operation.CommandType);


        public static void QueryMultiple(string connectionString, ISqlOperation operation, Action<SqlMapper.GridReader> action)
        {
            using var connection = PostgreSqlConnectionFactory.Create(connectionString);
            QueryMultiple(connection, operation, action);
        }


        public static void QueryMultiple(IDbConnection connection, ISqlOperation operation, Action<SqlMapper.GridReader> action)
        {
            var query = connection.QueryMultiple(operation.Text, operation.Parameters,
                commandTimeout: operation.Timeout, commandType: operation.CommandType);

            action(query);
        }


        public static async Task QueryMultipleAsync(string connectionString, ISqlOperation operation, Action<SqlMapper.GridReader> action)
        {
            using var connection = PostgreSqlConnectionFactory.Create(connectionString);
            await QueryMultipleAsync(connection, operation, action);
        }

        public static async Task QueryMultipleAsync(IDbConnection connection, ISqlOperation operation, Action<SqlMapper.GridReader> action)
        {
            var query = await connection.QueryMultipleAsync(operation.Text, operation.Parameters,
                commandTimeout: operation.Timeout, commandType: operation.CommandType);

            action(query);
        }

    }
}