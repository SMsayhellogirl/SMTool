using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTC_Help.Npoi
{
    public class ExcelNeed
    {
        //private static string GetCellValue(ICell cell)
        //{
        //    if (cell == null)
        //        return string.Empty;
        //    switch (cell.CellType)
        //    {
        //        case CellType.BLANK:
        //            return string.Empty;
        //        case CellType.BOOLEAN:
        //            return cell.BooleanCellValue.ToString();
        //        case CellType.ERROR:
        //            return cell.ErrorCellValue.ToString();
        //        case CellType.NUMERIC:
        //        case CellType.Unknown:
        //        default:
        //            return cell.ToString();//This is a trick to get the correct value of thecell. NumericCellValue will return a numeric value no matter the cell value isa date or a numbercase CellType.STRING:
        //            return cell.StringCellValue;
        //        case CellType.FORMULA:
        //            try
        //            {
        //                HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(cell.Sheet.Workbook);
        //                e.EvaluateInCell(cell);
        //                return cell.ToString();
        //            }
        //            catch
        //            {
        //                return cell.NumericCellValue.ToString();
        //            }
        //    }
        //}
    }
}
