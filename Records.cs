namespace ElectronicsStore.Models;
public sealed record User(int Id,string Name,string Role,string Email);
public sealed record Choice(int Id,string Name){public override string ToString()=>Name;}
public sealed record Product(int Id,string Title,string Category,string Brand,string Supplier,decimal Price,int Stock,int CategoryId,int ManufacturerId,int SupplierId){public override string ToString()=>$"{Title} — {Price:N2} ₽ (остаток {Stock})";}
public sealed record CartLine(Product Product,int Quantity,decimal Discount){public decimal Total=>Services.PriceRules.Total(Product.Price,Quantity,Discount);public override string ToString()=>$"{Product.Title}: {Quantity} × {Product.Price:N2}; скидка {Discount}% = {Total:N2} ₽";}
