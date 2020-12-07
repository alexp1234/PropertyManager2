using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertyManager.Services;

namespace PropertyManager.Controllers
{
    [Authorize]
    public class ExportController : Controller
    {
        private readonly IPropertyService _propertyService;
        public ExportController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }
        public async Task<IActionResult> DownloadPropertyReport()
        {
            var user = User.Identity.Name;
            var properties = _propertyService.GetUserProperties(user);
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "properties.xlsx";
            {
                using (var workbook = new XLWorkbook())
                {
                    await Task.Run(() =>
                    {
                        IXLWorksheet worksheet = workbook.Worksheets.Add("Properties");
                        worksheet.Cell(1, 1).Value = "Property Address";
                        worksheet.Cell(1, 2).Value = "City";
                        worksheet.Cell(1, 3).Value = "State";
                        worksheet.Cell(1, 4).Value = "Property Type";
                        worksheet.Cell(1, 5).Value = "Market Value";
                        worksheet.Cell(1, 6).Value = "Purchase Price";
                        worksheet.Cell(1, 7).Value = "Purchase Date";
                        worksheet.Cell(1, 8).Value = "Occupancy Status";
                        worksheet.Cell(1, 9).Value = "Current Rent Per Month";
                        worksheet.Cell(1, 10).Value = "Market Rent Per Month";

                        for (int i = 1; i < properties.Count; i++)
                        {
                            worksheet.Cell(i + 1, 1).Value = properties[i - 1].StreetAddress;
                            worksheet.Cell(i + 1, 2).Value = properties[i - 1].City;
                            worksheet.Cell(i + 1, 3).Value = properties[i - 1].State;
                            worksheet.Cell(i + 1, 4).Value = properties[i - 1].PropertyType;
                            worksheet.Cell(i + 1, 5).Value = properties[i - 1].CurrentMarketValue;
                            worksheet.Cell(i + 1, 6).Value = properties[i - 1].PurchasePrice;
                            worksheet.Cell(i + 1, 7).Value = properties[i - 1].PurchaseDate;
                            worksheet.Cell(i + 1, 8).Value = properties[i - 1].IsVacant.ToString();
                            worksheet.Cell(i + 1, 9).Value = properties[i - 1].CurrentRentPerMonth;
                            worksheet.Cell(i + 1, 10).Value = properties[i - 1].MarketRentPerMonth;
                        }
                        
                    });
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, contentType, fileName);
                    }
                }

            }
               
        }
    }
}
