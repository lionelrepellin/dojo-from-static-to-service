using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public static class UserRepository
	{
		private const string Host = ".";
		private const string InstanceName = "SQLEXPRESS";
		private const string DbName = "DojoMoq";

		private static string _connectionString => $@"Data Source={Host}\{InstanceName};Initial Catalog={DbName};Integrated Security=SSPI;";


		public static int Add(User user)
		{
			return OpenCloseConnection<int>(command =>
			{
				command.CommandText = "INSERT utilisateurs(nom, acces_dataviv) VALUES(@name, @dataviv)";
				command.Parameters.Add(new SqlParameter("@name", user.Name));
				command.Parameters.Add(new SqlParameter("@dataviv", user.DatavivAccessAllowed));

				return command.ExecuteNonQuery();
			});
		}

		public static IEnumerable<User> GetAll()
		{
			return OpenCloseConnection<IEnumerable<User>>(command =>
			{
				var users = new List<User>();
				command.CommandText = "SELECT id, nom, acces_dataviv FROM utilisateurs";

				using (var dataReader = command.ExecuteReader())
				{
					while (dataReader.Read())
					{
						users.Add(CreateUserFromReader(dataReader));
					}
				}
				return users;
			});
		}

		public static User FindById(int id)
		{
			return OpenCloseConnection<User>(command =>
			{
				User user = null;

				command.CommandText = "SELECT id, nom, acces_dataviv FROM utilisateurs WHERE id = @id";
				command.Parameters.Add(new SqlParameter("@id", id));

				using (var dataReader = command.ExecuteReader())
				{
					if (dataReader.Read())
					{
						user = CreateUserFromReader(dataReader);
					}
				}
				return user;
			});
		}

		private static T OpenCloseConnection<T>(Func<SqlCommand, T> action)
		{
			using (var connection = new SqlConnection(_connectionString))
			using (var command = connection.CreateCommand())
			{
				connection.Open();
				T result = action(command);
				connection.Close();
				return result;
			}
		}

		private static User CreateUserFromReader(SqlDataReader dataReader)
		{
			return new User
			{
				Id = Convert.ToInt32(dataReader["id"].ToString()),
				Name = dataReader["nom"].ToString(),
				DatavivAccessAllowed = Convert.ToBoolean(dataReader["acces_dataviv"].ToString())
			};
		}
	}
}
