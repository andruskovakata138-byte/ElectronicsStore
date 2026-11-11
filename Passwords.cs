using System.Security.Cryptography;
namespace ElectronicsStore.Services;
public static class Passwords {
 public static string Hash(string password){if(password.Length<8)throw new ArgumentException("Пароль должен содержать от 8 символов.");var salt=RandomNumberGenerator.GetBytes(16);return $"120000.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(Rfc2898DeriveBytes.Pbkdf2(password,salt,120000,HashAlgorithmName.SHA256,32))}";}
 public static bool Verify(string password,string hash){try{var p=hash.Split('.');if(p.Length!=3||!int.TryParse(p[0],out var n)||n!=120000)return false;var key=Rfc2898DeriveBytes.Pbkdf2(password,Convert.FromBase64String(p[1]),n,HashAlgorithmName.SHA256,32);return CryptographicOperations.FixedTimeEquals(key,Convert.FromBase64String(p[2]));}catch(FormatException){return false;}}
}
