using ElectronicsStore.Models;
namespace ElectronicsStore.Services;
public static class Session {
 public static User? Current{get;private set;}
 public static string Role=>Current?.Role??"Гость";
 public static bool Staff=>Role is "Продавец" or "Менеджер" or "Администратор";
 public static bool Manage=>Role is "Менеджер" or "Администратор";
 public static bool Admin=>Role=="Администратор";
 public static void Login(User user)=>Current=user;
 public static void Logout()=>Current=null;
 public static void RequireLogin(){if(Current==null)throw new InvalidOperationException("Сначала войдите в систему.");}
 public static void RequireManage(){if(!Manage)throw new InvalidOperationException("Операция доступна менеджеру и администратору.");}
 public static void RequireAdmin(){if(!Admin)throw new InvalidOperationException("Операция доступна администратору.");}
}
