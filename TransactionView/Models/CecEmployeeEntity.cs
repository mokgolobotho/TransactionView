using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionView.Models;

public class CecEmployeeEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public required int CecEmployeeId { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
}
