﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using WebWinMVC.Data;
using OfficeOpenXml;
using Microsoft.Extensions.Logging;
using WebWinMVC.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace WebWinMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly JRZLWTDbContext _dbContext;
        private readonly ILogger<FileUploadController> _logger;
        private readonly string _logFilePath;
        private readonly string _folderPath; // 新增字段

        // 定义默认批次大小
        private const int BATCH_SIZE = 5000;

        public FileUploadController(JRZLWTDbContext dbContext, ILogger<FileUploadController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _dbContext = dbContext;


            // 从配置中读取上传文件夹路径
            _folderPath = configuration["FileUpload:FolderPath"] ?? "C:\\ASP.NET\\Uploads"; // 您可以根据需要修改默认路径
            // 从配置中读取日志文件路径
            _logFilePath = configuration["Logging:LogFilePath"] ?? "C:\\ASP.NET\\Logs\\DailyServerLogs.txt";

            // 确保上传目录存在
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
                _logger.LogInformation($"已创建上传文件夹目录: {_folderPath}");
            }

            // 确保日志目录存在
            var logDirectory = Path.GetDirectoryName(_logFilePath) ?? "C:\\ASP.NET\\Logs";
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
                _logger.LogInformation($"已创建日志目录: {logDirectory}");
            }

        }

        // 添加所有对应的映射路由方法

        // 1. 上传 BreakpointAnalysisTable
        [HttpPost("uploadBreakpointAnalysisTable")]
        public async Task<IActionResult> UploadBreakpointAnalysisTable(IFormFile file, [FromQuery] DataOperation operation)
        {
            return await UploadFile<BreakpointAnalysisTable>(file, operation, _dbContext.BreakpointAnalysisTables, new BreakpointAnalysisTableMapXLSX());
        }

        // 2. 上传 DailyServiceReviewForm
        [HttpPost("uploadDailyServiceReviewForms")]
        public async Task<IActionResult> UploadDailyServiceReviewForms(IFormFile file, [FromQuery] DataOperation operation)
        {
            return await UploadFile<DailyServiceReviewForm>(file, operation, _dbContext.DailyServiceReviewForms, new DailyServiceReviewFormMapXLSX());
        }

        // 3. 上传 DailyServiceReviewFormQuery
        [HttpPost("uploadDailyServiceReviewFormQueries")]
        public async Task<IActionResult> UploadDailyServiceReviewFormQueries(IFormFile file, [FromQuery] DataOperation operation)
        {
            return await UploadFile<DailyServiceReviewFormQuery>(file, operation, _dbContext.DailyServiceReviewFormQueries, new DailyServiceReviewFormQueryMapXLSX());
        }

        // 4. 上传 DailyQualityIssueChecklistV91
        [HttpPost("uploadDailyQualityIssueChecklistV91s")]
        public async Task<IActionResult> UploadDailyQualityIssueChecklistV91s(IFormFile file, [FromQuery] DataOperation operation)
        {
            return await UploadFile<DailyQualityIssueChecklistV91>(file, operation, _dbContext.DailyQualityIssueChecklistV91s, new DailyQualityIssueChecklistV91MapXLSX());
        }

        // 5. 上传 DailyQualityIssueChecklistV91Query
        [HttpPost("uploadDailyQualityIssueChecklistV91Queries")]
        public async Task<IActionResult> UploadDailyQualityIssueChecklistV91Queries(IFormFile file, [FromQuery] DataOperation operation)
        {
            return await UploadFile<DailyQualityIssueChecklistV91Query>(file, operation, _dbContext.DailyQualityIssueChecklistV91Queries, new DailyQualityIssueChecklistV91QueryMapXLSX());
        }

        // 6. 上传 VehicleBasicInfo
        [HttpPost("uploadVehicleBasicInfos")]
        public async Task<IActionResult> UploadVehicleBasicInfos(IFormFile file, [FromQuery] DataOperation operation)
        {
            return await UploadFile<VehicleBasicInfo>(file, operation, _dbContext.VehicleBasicInfos, new VehicleBasicInfoMapXLSX());
        }

        // 通用的 UploadFile 方法
        private async Task<IActionResult> UploadFile<T>(IFormFile file, DataOperation operation, DbSet<T> dbSet, IExcelMapping<T> mapXLSX) where T : class, new()
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("未选择文件。");
            }

            if (string.IsNullOrEmpty(_folderPath) || !Directory.Exists(_folderPath))
            {
                return BadRequest("无效的文件夹路径。");
            }

            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(_folderPath, fileName);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // 根据操作类型处理数据库
                switch (operation)
                {
                    case DataOperation.Replace:
                        if (dbSet.Any())
                        {
                            dbSet.RemoveRange(dbSet);
                            await _dbContext.SaveChangesAsync();
                        }
                        break;

                    case DataOperation.Update:
                        // 保持现有数据，无需清空
                        break;

                    default:
                        return BadRequest("无效的操作类型。");
                }

                // 处理上传的文件，例如更新数据库
                await ProcessFile(filePath, file, dbSet, mapXLSX);

                return Ok("文件上传成功！");
            }
            catch (Exception ex)
            {
                _logger.LogError($"上传文件时出错: {ex.Message}");
                return StatusCode(500, "文件上传失败。");
            }
            finally
            {
                // 删除文件
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                    _logger.LogInformation("已删除上传的文件。");
                }
            }
        }

        private async Task ProcessFile<T>(string filePath, IFormFile file, DbSet<T> dbSet, IExcelMapping<T> mapXLSX) where T : class, new()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;
                var colCount = worksheet.Dimension.Columns;

                _logger.LogInformation($"行数: {rowCount}, 列数: {colCount}");

                var recordsBatch = new List<T>();

                var columnMappings = mapXLSX.GetColumnMappings();

                // 创建列头与列索引的映射
                var headerIndexMapping = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                for (int col = 1; col <= colCount; col++)
                {
                    var header = worksheet.Cells[1, col].Text;
                    if (columnMappings.ContainsKey(header))
                    {
                        headerIndexMapping[header] = col;
                    }
                }

                for (int row = 2; row <= rowCount; row++)
                {
                    var record = new T();

                    foreach (var mapping in columnMappings)
                    {
                        var header = mapping.Key;
                        var propName = mapping.Value;

                        if (headerIndexMapping.TryGetValue(header, out int colIndex))
                        {
                            var cellValue = worksheet.Cells[row, colIndex].Text;
                            var property = record.GetType().GetProperty(propName);
                            if (property != null)
                            {
                                property.SetValue(record, cellValue);
                            }
                        }
                        else
                        {
                            _logger.LogWarning($"在工作表中未找到列: {header}");
                        }
                    }

                    recordsBatch.Add(record);

                    if (recordsBatch.Count >= BATCH_SIZE)
                    {
                        await dbSet.AddRangeAsync(recordsBatch);
                        await _dbContext.SaveChangesAsync();

                        _logger.LogInformation($"已插入 {recordsBatch.Count} 条记录到数据库。");

                        recordsBatch.Clear();
                    }
                }

                if (recordsBatch.Count > 0)
                {
                    await dbSet.AddRangeAsync(recordsBatch);
                    await _dbContext.SaveChangesAsync();

                    _logger.LogInformation($"已插入 {recordsBatch.Count} 条记录到数据库。");
                }
            }

            await LogUploadDetails(file);
            _logger.LogInformation("文件处理成功。");
        }

        private async Task LogUploadDetails(IFormFile file)
        {
            if (string.IsNullOrEmpty(_logFilePath))
            {
                _logger.LogWarning("日志文件路径未配置。");
                return;
            }

            var requestPath = HttpContext.Request.Path;

            var logEntry = $"{DateTime.Now}: Uploaded file '{file.FileName}', Size: {file.Length} bytes, Source IP: {HttpContext.Connection.RemoteIpAddress}, Request Path: {requestPath}\n";

            try
            {
                var logDirectory = Path.GetDirectoryName(_logFilePath) ?? "C:\\ASP.NET\\Logs";
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                await System.IO.File.AppendAllTextAsync(_logFilePath, logEntry);
                _logger.LogInformation("日志信息已成功写入。" + logEntry);
            }
            catch (Exception ex)
            {
                _logger.LogError($"写入日志时出错: {ex.Message}");
            }
        }
    }
}
