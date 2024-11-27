using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionView.Models;

public class AdminTransactionsEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public required int id { get; set; }
    public required int cec_client_id { get; set; }
    public required int transaction_by { get; set; }
    public required string transaction_name { get; set; }
    public string? changed_value { get; set; }
    public required DateTime timestamp { get; set; }
    public string? changed_to { get; set; }
    public required string policy_reference { get; set; }
}
