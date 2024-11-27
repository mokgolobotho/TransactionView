using System.Diagnostics;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using TransactionView.Data;
using TransactionView.Models;

namespace TransactionView.Controllers;

public class ViewDataController : Controller
{
    private ApplicationDbContext _db;

    public ViewDataController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public IActionResult UploadFile(IFormFile file)
    {
        try
        {
            List<AdminTransactionsEntity> transactions = FileToBeUploaded(file);
            return View("ViewFile", transactions);
        }
        catch (Exception e)
        {
            return View("NoFile");
        }
    }

    private List<AdminTransactionsEntity> FileToBeUploaded(IFormFile file)
    {
        string extension = Path.GetExtension(file.FileName);
        List<AdminTransactionsEntity> transactions = new List<AdminTransactionsEntity>();
        if (extension.Equals(".xls") || extension.Equals(".csv"))
        {
            string fileName = Guid.NewGuid().ToString() + extension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "files");
            using FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);

            file.CopyTo(stream);
            transactions = SaveTransactions(file, fileName);
        }
        else
        {
            //return RedirectToAction("NoFile");
        }
        return transactions;
    }

    private List<AdminTransactionsEntity> SaveTransactions(IFormFile file, String fileName)
    {
        var transactions = new List<AdminTransactionsEntity>();
        Console.WriteLine("debug1");
        using (var stream = new MemoryStream())
        {
            file.CopyTo(stream);
            stream.Position = 0;

            using (var reader = new StreamReader(stream))
            using (
                var csv = new CsvReader(
                    reader,
                    new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = true,
                        HeaderValidated = null,
                        MissingFieldFound = null,
                        Delimiter = ",",
                    }
                )
            )
            {
                Console.WriteLine("debug2");
                Console.WriteLine(fileName);
                transactions = csv.GetRecords<AdminTransactionsEntity>().ToList();
            }
            Console.WriteLine(transactions.Count);
        }
        _db.admin_transactions.AddRange(transactions);
        _db.SaveChanges();

        return transactions;
    }
}
