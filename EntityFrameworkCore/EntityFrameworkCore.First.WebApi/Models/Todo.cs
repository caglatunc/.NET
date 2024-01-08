namespace EntityFrameworkCore.First.WebApi.Models;

public class Todo
{
    public int Id { get; set; } //int default değeri 0
    public string Work { get; set; } = string.Empty;//Null olmaması gereken alanlara default değer atadık.
    public DateTime DateToBeCompleted { get; set; }//DateTime default değeri 01.01.0001 00:00:00
    public DateTime CreationDate { get; set; }
    public DateTime? DateCompleted { get; set; }
    public bool IsCompleted { get; set; }//bool default değeri false
}
