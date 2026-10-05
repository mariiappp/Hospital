using Dapper;
using Hospital.Model;
using Microsoft.Data.SqlClient;

namespace Hospital.DataAccessLayer.Dapper
{
    public class DapperRepository<T> : IRepository<T>
        where T : class, IDomainObject
    {
        public T Add(T entity)
        {
            using var connection =
                new SqlConnection(DatabaseSettings.ConnectionString);

            connection.Open();

            const string sql = """
                INSERT INTO Doctors
                    (FullName, Specialization, Experience, Phone, Office)
                OUTPUT INSERTED.Id
                VALUES
                    (@FullName, @Specialization, @Experience, @Phone, @Office);
                """;

            int id = connection.ExecuteScalar<int>(sql, entity);

            entity.Id = id;

            return entity;
        }

        public bool Delete(int id)
        {
            using var connection =
                new SqlConnection(DatabaseSettings.ConnectionString);

            connection.Open();

            const string sql =
                "DELETE FROM Doctors WHERE Id = @Id;";

            int rowsAffected = connection.Execute(
                sql,
                new { Id = id });

            return rowsAffected > 0;
        }

        public List<T> ReadAll()
        {
            using var connection =
                new SqlConnection(DatabaseSettings.ConnectionString);

            connection.Open();

            const string sql = """
                SELECT Id,
                       FullName,
                       Specialization,
                       Experience,
                       Phone,
                       Office
                FROM Doctors;
                """;

            return connection.Query<T>(sql).ToList();
        }

        public T? ReadById(int id)
        {
            using var connection =
                new SqlConnection(DatabaseSettings.ConnectionString);

            connection.Open();

            const string sql = """
                SELECT Id,
                       FullName,
                       Specialization,
                       Experience,
                       Phone,
                       Office
                FROM Doctors
                WHERE Id = @Id;
                """;

            return connection.QueryFirstOrDefault<T>(
                sql,
                new { Id = id });
        }

        public bool Update(T entity)
        {
            using var connection =
                new SqlConnection(DatabaseSettings.ConnectionString);

            connection.Open();

            const string sql = """
                UPDATE Doctors
                SET FullName = @FullName,
                    Specialization = @Specialization,
                    Experience = @Experience,
                    Phone = @Phone,
                    Office = @Office
                WHERE Id = @Id;
                """;

            int rowsAffected = connection.Execute(sql, entity);

            return rowsAffected > 0;
        }
    }
}