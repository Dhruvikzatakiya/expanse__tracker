using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Expense_Tracker.Models
{
    public class Transaction
    {
        [Key]
        [Column(TypeName ="int")]
        public int TransactionId { get; set; }
        
        [Range(1, int.MaxValue,ErrorMessage="Please Select a Category.")]
        public int CategoryId { get; set; }


        public Category? Category { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Amount Should Be greater than 0.")]
        public int Amount { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string? description { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [NotMapped]
        public string? CategoryTitleWhithIcon
        {
            get
            {
                return Category == null ? "" : Category.Icon + " " + Category.Title;
            }
        }
        [NotMapped]
        public string? FromattedAmount
        {
            get
            {
                return ((Category == null || Category.Type=="Expense") ? "- " :"+ ")+ Amount.ToString("C0");
            }
        }


    }
}

