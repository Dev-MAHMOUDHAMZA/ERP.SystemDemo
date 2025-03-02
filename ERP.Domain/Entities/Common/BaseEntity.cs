
namespace ERP.Domain.Entities.Common;

//Common
public class BaseModel
{
    public int Id { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public string CreatedByUserId { get; set; } = null!;
    [ForeignKey(nameof(CreatedByUserId))]
    public virtual Employee? CreatedUser { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? UpdatedByUserId { get; set; }
    [ForeignKey(nameof(UpdatedByUserId))]
    public virtual Employee? UpdatedUser { get; set; }

    public bool IsActive { get; set; } = true;
}
public class FollowUp
{
    public int Id { get; set; }
    public string? IpAddress { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public string? Event { get; set; }
    /// <summary>
    /// Navigation Property
    /// </summary>
    public required string EmployeeId { get; set; }
    [ForeignKey(nameof(EmployeeId))]
    public virtual Employee? Employee { get; set; }
}
public class LoginUser
{
    public int Id { get; set; }
    public DateTime Login { get; set; }
    public DateTime? LogOut { get; set; }

    public string EmployeeId { get; set; } = null!;
    public Employee? Employee { get; set; }
}
//End Common

//Hierarchy
[Index(nameof(Name), IsUnique = true)]
public class Company : BaseModel
{
    [StringLength(250)]
    public string Name { get; set; } = null!;

    [StringLength(250)]
    public string CompanyActivity { get; set; } = null!;

    [StringLength(100)]
    public string TaxNumber { get; set; } = null!;

    [StringLength(100)]
    public string RecordNumber { get; set; } = null!;

    [StringLength(100)]
    public string Code { get; set; } = null!;

    [StringLength(100)]
    public string PhoneNumber { get; set; } = null!;

    [EmailAddress]
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
    public string Email { get; set; } = null!;

    [StringLength(250)]
    public string Address { get; set; } = null!;

    [StringLength(500)]
    public string Logo { get; set; } = null!;

    [StringLength(500)]
    public string Signature { get; set; } = null!;
}

[Index(nameof(Name), IsUnique = true)]
public class Branch : BaseModel
{
    [StringLength(150)]
    public string Name { get; set; } = null!;

    [StringLength(250)]
    public string Address { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    [EmailAddress]
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
    public string Email { get; set; } = null!;

    public bool IsMainBranch { get; set; }
}

public class Department : BaseModel
{
    public string Name { get; set; } = null!;

    public int BranchId { get; set; }
    [ForeignKey(nameof(BranchId))]
    public virtual Branch? Branch { get; set; }
}

[Index(nameof(FullName), IsUnique = true)]
public class Employee : IdentityUser
{
    [StringLength(250)]
    public string FullName { get; set; } = null!;
    public bool ISActive { get; set; }

    public bool IsUser { get; set; }

    public string? ImagePath { get; set; }

    public DateTime HireDate { get; set; }

    public int DepartmentId { get; set; }
    [ForeignKey(nameof(DepartmentId))]
    public virtual Department? Department { get; set; }
}
public class Salary
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    [ForeignKey(nameof(EmployeeId))]
    public Employee? Employee { get; set; }

    public decimal BasicSalary { get; set; }
    public decimal Bonus { get; set; }
    public decimal Deductions { get; set; }
    public DateTime SalaryDate { get; set; }
}
//End Hierarchy

//System Setting
public class Currency : BaseModel
{
    public string CurrencyName { get; set; } = null!;

    public string CurrencyCode { get; set; } = EnumHelper.eCurrency.EG.ToString();

    public decimal ConvertCurrency { get; set; }

    public int BranchId { get; set; }
    [ForeignKey(nameof(BranchId))]
    public virtual Branch? Branch { get; set; }
}
public class Unit : BaseModel
{
    [StringLength(100)]
    public string Name { get; set; } = string.Empty; // Pc , Mater , 

    [MaxLength(20), MinLength(1)]
    public decimal Quantity { get; set; } = 0;

    public int BranchId { get; set; }
    [ForeignKey(nameof(BranchId))]
    public virtual Branch? Branch { get; set; }
}
//End System Setting

public class Brand : BaseModel
{
    [StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [StringLength(100)]
    public string ImagePath { get; set; } = null!;

    public int BranchId { get; set; }
    [ForeignKey(nameof(BranchId))]
    public virtual Branch? Branch { get; set; }
}
public class Category : BaseModel
{
    [StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [StringLength(150)]
    public string ImagePath { get; set; } = null!;

    public int BranchId { get; set; }
    [ForeignKey(nameof(BranchId))]
    public virtual Branch? Branch { get; set; }

}
public class Product : BaseModel
{
    public string Name { get; set; } = string.Empty;

    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    public int BrandId { get; set; }
    [ForeignKey(nameof(BrandId))]
    public virtual Brand Brand { get; set; } = null!;

    public int CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public virtual Category Category { get; set; } = null!;

    public int UnitId { get; set; }
    [ForeignKey(nameof(UnitId))]
    public virtual Unit Unit { get; set; } = null!;
    public int BranchId { get; set; }
    [ForeignKey(nameof(BranchId))]
    public virtual Branch? Branch { get; set; }

}
public class Stock : BaseModel
{
    public int StoreId { get; set; }
    [ForeignKey(nameof(StoreId))]
    public virtual Store? Store { get; set; }

    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public virtual Product? Product { get; set; }

    public int Quantity { get; set; }
}
public class StockHistory 
{
    public int Id { get; set; }

    public int StockId { get; set; }
    [ForeignKey(nameof(StockId))]
    public virtual Stock? Stock { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow;

    public string Event { get; set; } = null!;

    public string CreatedByUserId { get; set; } = null!;
    [ForeignKey(nameof(CreatedByUserId))]
    public virtual Employee? CreatedUser { get; set; }
}
public class Store : BaseModel
{
    [StringLength(150)]
    public string Name { get; set; } = string.Empty;

    public int? AdministratorId { get; set; }
    [ForeignKey(nameof(AdministratorId))]
    public virtual Employee? Administrator { get; set; }

    [StringLength(100)]
    public string Phone { get; set; } = string.Empty;

    [EmailAddress]
    public string? Email { get; set; }


    [StringLength(150)]
    public string Address { get; set; } = string.Empty;


    public int BranchId { get; set; }
    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; } = null!;

}
public class StoreHistory 
{
    public int Id { get; set; }
    public int StoreId { get; set; }
    [ForeignKey(nameof(StoreId))]
    public virtual Store? Store { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow;

    public string Event { get; set; } = null!;

    public string CreatedByUserId { get; set; } = null!;
    [ForeignKey(nameof(CreatedByUserId))]
public virtual Employee? CreatedUser { get; set; }
}


public class Supplier : BaseModel
{
    public string Name { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public decimal? FirstBalance { get; set; } = 0;

    public int BranchId { get; set; }
    [ForeignKey(nameof(BranchId))]
    public virtual Branch? Branch { get; set; }


}
public class Customer : BaseModel
{
    public string Name { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public decimal? FirstBalance { get; set; } = 0;

    public int BranchId { get; set; }
    [ForeignKey(nameof(BranchId))]
    public virtual Branch? Branch { get; set; }
}
/// <summary>
/// ///////////////////////////////////////////////////////////
/// </summary>
//public class InvoiceType : BaseModel
//{
//    public string Name { get; set; } = null!; //
//}
public class PaymentMethod : BaseModel
{
    public string Name { get; set; } = null!;// "Credit Card", "Cash", "Bank Transfer","Delayed"  (Seeding)
}

public class SaleInvoice
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    [ForeignKey(nameof(CustomerId))]
    public Customer? Customer { get; set; }

    public decimal TotalAmount { get; set; }
    public DateTime InvoiceDate { get; set; }

    public int PaymentMethodId { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }

    public DateTime SystemDate { get; set; } = DateTime.Now; //System Date
}
public class InvoiceItem
{
    public int Id { get; set; }
    public int SaleInvoiceId { get; set; }
    [ForeignKey(nameof(SaleInvoiceId))]
    public SaleInvoice SaleInvoice { get; set; } = null!;

    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;

    public int StoreId { get; set; }
    [ForeignKey(nameof(StoreId))]
    public virtual Store? Store { get; set; }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

public class PurchaseInvoice
{
    public int Id { get; set; }
    public int SupplierId { get; set; }
    public Supplier? Supplier { get; set; }

    public decimal TotalAmount { get; set; }
    public DateTime InvoiceDate { get; set; }
    public int PaymentMethodId { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }
    public DateTime SystemDate { get; set; } = DateTime.Now;
}
public class PurchaseInvoiceItem
{
    public int Id { get; set; }
    public int PurchaseInvoiceId { get; set; }
    public PurchaseInvoice PurchaseInvoice { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int StoreId { get; set; }
    [ForeignKey(nameof(StoreId))]
    public virtual Store? Store { get; set; }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
public class Payment
{
    public int Id { get; set; }
    public int SupplierId { get; set; }
    public Supplier? Supplier { get; set; }
    public decimal AmountPaid { get; set; }
    public int PaymentMethodId { get; set; }  // "Credit Card", "Cash", "Bank Transfer"
    public PaymentMethod? PaymentMethod { get; set; }
    public DateTime PaymentDate { get; set; }
    public DateTime SystemDate { get; set; } = DateTime.Now;
}

public class Receipt
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public decimal AmountPaid { get; set; }
    public int PaymentMethodId { get; set; }  // "Credit Card", "Cash", "Bank Transfer"
    public PaymentMethod? PaymentMethod { get; set; }
    public DateTime PaymentDate { get; set; }
    public DateTime SystemDate { get; set; } = DateTime.Now;
}


public class CustomerAccount
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public string Item { get; set; } = null!;

    public decimal? Creditor { get; set; }
    public decimal? Debtor { get; set; }

    public DateTime Date { get; set; }

    public decimal Total { get; set; }
}
public class SupplierAccount
{
    public int Id { get; set; }

    public int ItemId { get; set; }

    public string Item { get; set; } = null!;

    public decimal? Creditor { get; set; }
    public decimal? Debtor { get; set; }

    public DateTime Date { get; set; }

    public decimal Total { get; set; }
}





//public class Currency
//{
//    public int CurrencyID { get; set; }
//    [MaxLength(100)]
//    public string CurrencyName { get; set; } = string.Empty;
//    public int Rate { get; set; }
//    public int DefaultCurrency { get; set; }

//    public virtual ICollection<Invoice>? Payments { get; set; } = new List<Invoice>();
//    public virtual ICollection<Expense>? Expenses { get; set; } = new List<Expense>();
//    public virtual ICollection<ERPTransiation>? ERPTransiations { get; set; } = new List<ERPTransiation>();

//}
//public class UserModel
//{
//    public string Id { get; set; } = null!;

//    public string FullName { get; set; } = null!;

//    public string RoleName { get; set; } = null!;

//    public int StateTypeUser { get; set; }

//    public string Email { get; set; } = null!;

//    public string? ImagePath { get; set; }

//    public bool ISActive { get; set; }

//    public DateTime CreatedOn { get; set; }
//    public DateTime? UpdatedOn { get; set; }

//    public int BranchId { get; set; }
//    public int CompanyId { get; set; }

//    public bool EmailConfirmed { get; set; }
//}

//ReturnSaleInvoice  فاتورة مرتجعات
//PurchaseInvoice  فاتورة مرتجعات




