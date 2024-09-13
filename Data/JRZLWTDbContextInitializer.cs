using CsvHelper;
using CsvHelper.Configuration;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using WebWinMVC.Models;
using ClosedXML.Excel;

namespace WebWinMVC.Data
{
    public class JRZLWTDbContextInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider,bool iftrue=false)
        {
           if(iftrue)
            using (var context = new JRZLWTDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<JRZLWTDbContext>>()))
            {
                // Initialize each DbSet
                InitializeDailyQualityIssueChecklist(context, 5000, DataOperation.Replace);
                InitializeDailyQualityIssueChecklistV91(context, 5000, DataOperation.Replace);
                InitializeDailyQualityIssueChecklistV91Queries(context, 5000, DataOperation.Replace);
                //InitializeDailyServiceReviewForm(context);
                // InitializeDailyServiceReviewFormQuery(context);
                InitializeDailyServiceReviewFormQuery(context, 5000, DataOperation.Update);

            }
        }


        private static void InitializeDailyQualityIssueChecklistV91(JRZLWTDbContext context, int batchSize, DataOperation operation)
        {
            switch (operation)
            {
                case DataOperation.Replace:
                    // 如果数据库中已有数据，则清空
                    if (context.DailyQualityIssueChecklistV91s.Any())
                    {
                        context.DailyQualityIssueChecklistV91s.RemoveRange(context.DailyQualityIssueChecklistV91s);
                        context.SaveChanges();
                    }
                    break;

                case DataOperation.Update:
                    // 保持现有数据，无需清空
                    break;

                default:
                    throw new ArgumentException("Invalid operation type");
            }

            var filePath = "C:\\Users\\Administrator\\Desktop\\HYQE\\DailyQualityIssueChecklistV91.csv";
            var recordsBatch = new List<DailyQualityIssueChecklistV91>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<DailyQualityIssueChecklistV91Map>();

                // Read the CSV file row by row
                while (csv.Read())
                {
                    var record = csv.GetRecord<DailyQualityIssueChecklistV91>();
                    recordsBatch.Add(record);

                    // Check if we've reached the batch size
                    if (recordsBatch.Count >= batchSize)
                    {
                        // Save the current batch to the database
                        context.DailyQualityIssueChecklistV91s.AddRange(recordsBatch);
                        context.SaveChanges();

                        // Clear the list for the next batch
                        recordsBatch.Clear();
                    }
                }

                // Save any remaining records
                if (recordsBatch.Count > 0)
                {
                    context.DailyQualityIssueChecklistV91s.AddRange(recordsBatch);
                    context.SaveChanges();
                }
            }
        }
        private static void InitializeDailyQualityIssueChecklistV91Queries(JRZLWTDbContext context, int batchSize, DataOperation operation)
        {
            switch (operation)
            {
                case DataOperation.Replace:
                    // 如果数据库中已有数据，则清空
                    if (context.DailyQualityIssueChecklistV91Queries.Any())
                    {
                        context.DailyQualityIssueChecklistV91Queries.RemoveRange(context.DailyQualityIssueChecklistV91Queries);
                        context.SaveChanges();
                    }
                    break;

                case DataOperation.Update:
                    // 保持现有数据，无需清空
                    break;

                default:
                    throw new ArgumentException("Invalid operation type");
            }

            var filePath = "C:\\Users\\Administrator\\Desktop\\HYQE\\DailyQualityIssueChecklistV91Queries.csv";
            var recordsBatch = new List<DailyQualityIssueChecklistV91Query>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<DailyQualityIssueChecklistV91QueryMap>();

                // Read the CSV file row by row
                while (csv.Read())
                {
                    var record = csv.GetRecord<DailyQualityIssueChecklistV91Query>();
                    recordsBatch.Add(record);

                    // Check if we've reached the batch size
                    if (recordsBatch.Count >= batchSize)
                    {
                        // Save the current batch to the database
                        context.DailyQualityIssueChecklistV91Queries.AddRange(recordsBatch);
                        context.SaveChanges();

                        // Clear the list for the next batch
                        recordsBatch.Clear();
                    }
                }

                // Save any remaining records
                if (recordsBatch.Count > 0)
                {
                    context.DailyQualityIssueChecklistV91Queries.AddRange(recordsBatch);
                    context.SaveChanges();
                }
            }
        }
        private static void InitializeDailyServiceReviewForm(JRZLWTDbContext context, int batchSize, DataOperation operation)
        {
            switch (operation)
            {
                case DataOperation.Replace:
                    // 如果数据库中已有数据，则清空
                    if (context.DailyServiceReviewForms.Any())
                    {
                        context.DailyServiceReviewForms.RemoveRange(context.DailyServiceReviewForms);
                        context.SaveChanges();
                    }
                    break;

                case DataOperation.Update:
                    // 保持现有数据，无需清空
                    break;

                default:
                    throw new ArgumentException("Invalid operation type");
            }

            var filePath = "C:\\Users\\Administrator\\Desktop\\HYQE\\DailyServiceReviewForm.csv";
            var recordsBatch = new List<DailyServiceReviewForm>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Optional: Configure CSV reading behavior
                //csv.Context.RegisterClassMap<DailyServiceReviewFormMap>();

                // Read the CSV file row by row
                while (csv.Read())
                {
                    var record = csv.GetRecord<DailyServiceReviewForm>();
                    recordsBatch.Add(record);

                    // Check if we've reached the batch size
                    if (recordsBatch.Count >= batchSize)
                    {
                        // Save the current batch to the database
                        context.DailyServiceReviewForms.AddRange(recordsBatch);
                        context.SaveChanges();

                        // Clear the list for the next batch
                        recordsBatch.Clear();
                    }
                }

                // Save any remaining records
                if (recordsBatch.Count > 0)
                {
                    context.DailyServiceReviewForms.AddRange(recordsBatch);
                    context.SaveChanges();
                }
            }
        }
        private static void InitializeDailyServiceReviewFormQuery(JRZLWTDbContext context, int size, DataOperation operation)
        {
            switch (operation)
            {
                case DataOperation.Replace:
                    // 如果数据库中已有数据，则清空
                    if (context.DailyServiceReviewFormQueries.Any())
                    {
                        context.DailyServiceReviewFormQueries.RemoveRange(context.DailyServiceReviewFormQueries);
                        context.SaveChanges();
                    }
                    break;

                case DataOperation.Update:
                    // 不执行任何操作，保持现有数据
                    break;

                default:
                    throw new ArgumentException("Invalid operation type");
            }

            var filePath = "C:\\Users\\Administrator\\Desktop\\HYQE\\DailyServiceReviewFormQueries.csv";
            var batchSize = size; // 每批处理的记录数
            var recordsBatch = new List<DailyServiceReviewFormQuery>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<DailyServiceReviewFormQueryMap>();

                // Read the CSV file row by row
                while (csv.Read())
                {
                    var record = csv.GetRecord<DailyServiceReviewFormQuery>();
                    recordsBatch.Add(record);

                    // Check if we've reached the batch size
                    if (recordsBatch.Count >= batchSize)
                    {
                        // Save the current batch to the database
                        context.DailyServiceReviewFormQueries.AddRange(recordsBatch);
                        context.SaveChanges();

                        // Clear the list for the next batch
                        recordsBatch.Clear();
                    }
                }

                // Save any remaining records
                if (recordsBatch.Count > 0)
                {
                    context.DailyServiceReviewFormQueries.AddRange(recordsBatch);
                    context.SaveChanges();
                }
            }
        }
        private static void InitializeDailyServiceReviewFormQuery(JRZLWTDbContext context, bool xlsx)
        {
            if (context.DailyServiceReviewFormQueries.Count() > 600)
            {
                return; // 数据库中已有足够的数据，退出初始化
            }
            else if (context.DailyServiceReviewFormQueries.Count() <= 600)
            {
                context.DailyServiceReviewFormQueries.RemoveRange(context.DailyServiceReviewFormQueries);
                context.SaveChanges(); // 清空数据库中的现有数据
            }

            var filePath = "C:\\Users\\Administrator\\Desktop\\HYQE\\DailyServiceReviewFormQueries.xlsx";
            var batchSize = 1000; // 每次处理的记录数
            var records = new List<DailyServiceReviewFormQuery>();

            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {

                    var worksheet = workbook.Worksheet(1);
                    var headerRow = worksheet.Row(1);
                    var rowCount = worksheet.RowsUsed().Count();
                    Console.WriteLine("+++++++++++++++++++++++++++++++++" + rowCount);

                    for (int row = 2; row <= rowCount; row++) // 从第2行开始，跳过表头
                    {
                        var rowData = worksheet.Row(row);
                        var record = ExcelMapper.MapRowToEntity<DailyServiceReviewFormQuery>(rowData, headerRow);
                        records.Add(record);

                        if (records.Count >= batchSize)
                        {
                            context.DailyServiceReviewFormQueries.AddRange(records);
                            context.SaveChanges();
                            records.Clear(); // 清空列表以便处理下一批数据
                        }
                    }

                    // 处理剩余的记录
                    if (records.Any())
                    {
                        context.DailyServiceReviewFormQueries.AddRange(records);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception-------------------------------------------------: {ex.Message}");
            }
        }
        private static void InitializeDailyQualityIssueChecklist(JRZLWTDbContext context, int batchSize, DataOperation operation)
        {
            switch (operation)
            {
                case DataOperation.Replace:
                    // 如果数据库中已有数据，则清空
                    if (context.DailyQualityIssueChecklists.Any())
                    {
                        context.DailyQualityIssueChecklists.RemoveRange(context.DailyQualityIssueChecklists);
                        context.SaveChanges();
                    }
                    break;

                case DataOperation.Update:
                    // 保持现有数据，无需清空
                    break;

                default:
                    throw new ArgumentException("Invalid operation type");
            }

            var filePath = "C:\\Users\\Administrator\\Desktop\\HYQE\\DailyQualityIssueChecklist.csv";
            var recordsBatch = new List<DailyQualityIssueChecklist>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<DailyQualityIssueChecklistMap>();

                // Read the CSV file row by row
                while (csv.Read())
                {
                    var record = csv.GetRecord<DailyQualityIssueChecklist>();
                    recordsBatch.Add(record);

                    // Check if we've reached the batch size
                    if (recordsBatch.Count >= batchSize)
                    {
                        // Save the current batch to the database
                        context.DailyQualityIssueChecklists.AddRange(recordsBatch);
                        context.SaveChanges();

                        // Clear the list for the next batch
                        recordsBatch.Clear();
                    }
                }

                // Save any remaining records
                if (recordsBatch.Count > 0)
                {
                    context.DailyQualityIssueChecklists.AddRange(recordsBatch);
                    context.SaveChanges();
                }
            }
        }
    }
}
