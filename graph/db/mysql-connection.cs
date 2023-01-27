using System.Data;
using System.Text;
using System.Text.Json;
using MySqlConnector;

namespace School.DB;

public class MySqlConnectionManager
{
  private MySqlConnectionStringBuilder builder;
  public MySqlConnectionManager(string server, string user, string password, string database)
  {
    builder = new MySqlConnectionStringBuilder
    {
      Server = server,
      UserID = user,
      Password = password,
      Database = database,
    };
  }

  public async Task<DatabaseResponse<T>> Execute<T>(string query, Dictionary<string, object> parameters)
  {
    try
    {
      Console.WriteLine("Executing query: " + query);
      using var connection = new MySqlConnection(builder.ConnectionString);
      await connection.OpenAsync();
      using var command = connection.CreateCommand();
      command.CommandText = query;
      command.CommandType = CommandType.StoredProcedure;
      command.Parameters.AddRange(DictionaryToParameters(parameters));

      using var reader = await command.ExecuteReaderAsync();
      var response = new StringBuilder();
      while (reader.Read())
      {
        response.Append(reader.GetString(0));
      }
      await connection.CloseAsync();
      var xd = response.ToString();
      return DeserializeResponse<T>(xd);
    }
    catch (System.Exception e)
    {
      Console.WriteLine(e.Message);
      throw;
    }
  }

  private MySqlParameter[] DictionaryToParameters(Dictionary<string, object> parameters)
  {
    var list = new List<MySqlParameter>();

    foreach (KeyValuePair<string, object> parametro in parameters)
    {
      MySqlParameter sqlPar = new MySqlParameter("@" + parametro.Key, parametro.Value)
      {
        Direction = ParameterDirection.Input
      };
      list.Add(sqlPar);
    }

    return list.ToArray();
  }

  private DatabaseResponse<T> DeserializeResponse<T>(string response)
  {
    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    var deserialized = JsonSerializer.Deserialize<DatabaseResponse<T>>(response, options);
    return deserialized ?? DatabaseResponse<T>.Default();
  }
}
