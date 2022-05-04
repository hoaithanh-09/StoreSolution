using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Store.ViewModels.Export;
using System.Collections.Generic;
using Store.Data.Enums;

namespace Store.Services.ExportServices
{
    public interface IExportService
    {
        void CreateCell(IRow currentRow, int cellIndex, object value, XSSFCellStyle style);

        void MergeCell(ISheet sheet, int firstRow, int lastRow, int firstCol, int lastCol);

        void AddImage(IWorkbook workbook, ISheet sheet, int row, int col, byte[] image, double size);

        void SizeAllColumn(ISheet sheet);
    }

    public class ExportService
    {
        public void CreateCell(IRow currentRow, int cellIndex, object value, XSSFCellStyle style)
        {
            ICell cell = currentRow.CreateCell(cellIndex);
            if (value != null)
                cell.SetCellValue(value.ToString());
            else
                cell.SetCellValue("");

            cell.CellStyle = style;
        }

        public void MergeCell(ISheet sheet, int firstRow, int lastRow, int firstCol, int lastCol)
        {
            CellRangeAddress cellRangeAddress = new CellRangeAddress(firstRow, lastRow, firstCol, lastCol);
            sheet.AddMergedRegion(cellRangeAddress);

            RegionUtil.SetBorderTop((int)(int)BorderStyle.Thin, cellRangeAddress, sheet);
            RegionUtil.SetBorderBottom((int)BorderStyle.Thin, cellRangeAddress, sheet);
            RegionUtil.SetBorderLeft((int)BorderStyle.Thin, cellRangeAddress, sheet);
            RegionUtil.SetBorderRight((int)BorderStyle.Thin, cellRangeAddress, sheet);
        }

        public void AddImage(IWorkbook workbook, ISheet sheet, int row, int col, byte[] image, double size)
        {
            int pictureIndex = workbook.AddPicture(image, (PictureType)XSSFWorkbook.PICTURE_TYPE_PNG);
            XSSFCreationHelper helper = workbook.GetCreationHelper() as XSSFCreationHelper;
            XSSFDrawing drawing = sheet.CreateDrawingPatriarch() as XSSFDrawing;
            XSSFClientAnchor anchor = helper.CreateClientAnchor() as XSSFClientAnchor;
            anchor.Col1 = col;
            anchor.Row1 = row;
            XSSFPicture picture = drawing.CreatePicture(anchor, pictureIndex) as XSSFPicture;
            picture.Resize(1);
        }

        public void SizeAllColumn(ISheet sheet)
        {
            int lastColumNum = sheet.GetRow(0).LastCellNum;
            for (int i = 0; i <= lastColumNum; i++)
            {
                sheet.AutoSizeColumn(i);
                GC.Collect();
            }
        }

        public byte[] Export<T>(List<Column<T>> columns, List<T> data)
        {
            #region Repair
            XSSFWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Báo cáo");

            XSSFFont headerFont = (XSSFFont)workbook.CreateFont();
            headerFont.IsBold = true;
            headerFont.FontHeightInPoints = 14;
            headerFont.FontName = "Times New Roman";

            XSSFCellStyle headerCellStyle = (XSSFCellStyle)workbook.CreateCellStyle();
            headerCellStyle.SetFont(headerFont);
            headerCellStyle.BorderLeft = BorderStyle.Thin;
            headerCellStyle.BorderTop = BorderStyle.Thin;
            headerCellStyle.BorderRight = BorderStyle.Thin;
            headerCellStyle.BorderBottom = BorderStyle.Thin;
            headerCellStyle.VerticalAlignment = VerticalAlignment.Center;
            headerCellStyle.Alignment = HorizontalAlignment.Center;
            #endregion

            #region Create header
            IRow firstHeaderRow = sheet.CreateRow(0);
            for (var index = 0; index < columns.Count(); index++)
            {
                var style = headerCellStyle;
                if (columns[index].Label.IndexOf("\n") > -1)
                    style.WrapText = true;

                CreateCell(firstHeaderRow, index, columns[index].Label, style);
            }
            #endregion

            #region Insert data
            var rowCurrent = 1;
            for (var index = 0; index < data.Count(); index++)
            {
                var row = sheet.CreateRow(rowCurrent);
                for (var jndex = 0; jndex < columns.Count(); jndex++)
                {
                    string content;
                    try
                    {
                        object value = typeof(T).GetProperty(columns[jndex].Property).GetValue(data[index], null);
                        if (columns[jndex].Formatter != null)
                            content = columns[jndex].Formatter(data[index]);
                        else
                            content = value.ToString();
                    }
                    catch (Exception)
                    {
                        content = "";
                    }

                    XSSFFont cellFont = (XSSFFont)workbook.CreateFont();
                    cellFont.FontHeightInPoints = 13;
                    cellFont.FontName = "Times New Roman";

                    XSSFCellStyle cellStyle = (XSSFCellStyle) workbook.CreateCellStyle();
                    cellStyle.SetFont(cellFont);
                    cellStyle.BorderLeft = BorderStyle.Thin;
                    cellStyle.BorderTop = BorderStyle.Thin;
                    cellStyle.BorderRight = BorderStyle.Thin;
                    cellStyle.BorderBottom = BorderStyle.Thin;
                    cellStyle.VerticalAlignment = VerticalAlignment.Center;

                    if (columns[jndex].Style.Alignment == AlignmentTypes.Center)
                        cellStyle.Alignment = HorizontalAlignment.Center;
                    else if (columns[jndex].Style.Alignment == AlignmentTypes.Right)
                        cellStyle.Alignment = HorizontalAlignment.Right;

                    CreateCell(row, jndex, content, cellStyle);
                }
                /* Next row */
                rowCurrent++;
            }
            #endregion

            #region Resizing     
            SizeAllColumn(sheet);
            #endregion

            #region Save to ram
            using (var memoryStream = new MemoryStream())
            {
                workbook.Write(memoryStream);
                return memoryStream.ToArray();
            }
            #endregion
        }
    }
}

