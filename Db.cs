using System.Data; using Microsoft.Data.SqlClient;
namespace ElectronicsStore.Data;
public static class Db {
 public static async Task<SqlConnection> Open(){var path=Path.Combine(AppContext.BaseDirectory,"connection.txt");if(!File.Exists(path))throw new IOException("Не найден connection.txt рядом с приложением.");var c=new SqlConnection((await File.ReadAllTextAsync(path)).Trim());try{await c.OpenAsync();return c;}catch{await c.DisposeAsync();throw;}}
 public static SqlCommand Command(SqlConnection c,string sql,SqlTransaction? transaction=null,params (string,object?)[] args){var cmd=new SqlCommand(sql,c,transaction);foreach(var (k,v) in args)cmd.Parameters.AddWithValue(k,v??DBNull.Value);return cmd;}
 public static async Task<DataTable> Query(string sql,params (string,object?)[] args){await using var c=await Open();using var cmd=Command(c,sql,null,args);using var reader=await cmd.ExecuteReaderAsync();var t=new DataTable();t.Load(reader);return t;}
 public static async Task<int> Execute(string sql,params (string,object?)[] args){await using var c=await Open();using var cmd=Command(c,sql,null,args);return await cmd.ExecuteNonQueryAsync();}
}
