using BC = BCrypt.Net.BCrypt;

namespace Api.Services;

public class PasswordService {
   public string Hash(string password) {
      return BC.HashPassword(password);
   }

   public bool Verify(string password, string hash) {
      return BC.Verify(password, hash);
   }
}