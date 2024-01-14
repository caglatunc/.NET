namespace EntityFrameworkCore.Relational.WebApi.DTOs;

public sealed record CreateProductDto(
    string ProductName,
    string ProductDescription,
    decimal ProductPrice, 
    string CategoryName);



//{
//    public CreateProductDto(string productName, string productDescription, decimal productPrice, string categoryName)
//    {
//        ProductName = productName;
//        ProductDescription = productDescription;
//        ProductPrice = productPrice;
//        CategoryName = categoryName;
//    }
//    public string ProductName { get; init; }
//    public string ProductDescription { get; init; }
//    public decimal ProductPrice { get; init; }
//    public string CategoryName { get; init; }
//}
