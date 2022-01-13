using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTC_Help.Npoi
{
    public class SetWordHelp
    {
        //private void SetRunData(XWPFParagraph xwpfPara, string ReplaceTag, string ColumnValue)
        //{
        //    // 若有資料
        //    if (xwpfPara.Text.Length > 0)
        //    {
        //        string strRunText = "";
        //        IList<XWPFRun> xwpfRuns = xwpfPara.Runs;
        //        // 對所有的Runs處理
        //        for (int intTempI = 0; intTempI < xwpfRuns.Count; intTempI++)
        //        {
        //            strRunText = xwpfRuns[intTempI].ToString();
        //            if (strRunText.Contains(ReplaceTag))
        //            {
        //                // 2015/8/5 Lucien調整,將null換成空字串
        //                ColumnValue = ColumnValue.Replace("\0", string.Empty);

        //                strRunText = strRunText.Replace(ReplaceTag, ColumnValue);
        //                // 由於SetText只會附加新資料上去，因此要刪除原來的Run,新增Run
        //                xwpfPara.InsertNewRun(intTempI).SetText(strRunText);
        //                xwpfPara.RemoveRun(intTempI);
        //            }
        //        }

        //        // 若是Runs的Tag資料被切開，則必須先組合起來
        //        strRunText = "";
        //        for (int intTempI = 0; intTempI < xwpfRuns.Count; intTempI++)
        //            strRunText += xwpfRuns[intTempI].ToString();

        //        if (strRunText.Contains(ReplaceTag))
        //        {
        //            for (int intTempI = 0; intTempI < xwpfRuns.Count; intTempI++)
        //                xwpfRuns[intTempI].SetText("", 0);

        //            // 2015/8/5 Lucien調整,將null換成空字串,以避免檔案出現錯誤
        //            ColumnValue = ColumnValue.Replace("\0", string.Empty);

        //            strRunText = strRunText.Replace(ReplaceTag, ColumnValue);
        //            xwpfRuns[0].SetText(strRunText, 0);
        //        }
        //    }
        //}
        //public void SetFieldData(XWPFDocument docx, string ColumnName, string ColumnValue)
        //{
        //    //要取代的Tag
        //    string SearchTag = String.Format("#FLD_{0}#", ColumnName);

        //    //取得頁首、頁尾資訊
        //    XWPFHeaderFooterPolicy hfPolicy = docx.GetHeaderFooterPolicy();

        //    //取得頁首
        //    XWPFHeader header = hfPolicy.GetDefaultHeader();

        //    //取得頁首每個段落
        //    if (header != null)
        //    {
        //        foreach (XWPFParagraph para in header.Paragraphs)
        //        {
        //            //取得段落中的每一行，並取代指定Tag
        //            SetRunData(para, SearchTag, ColumnValue);
        //        }
        //    }

        //    //取得頁尾
        //    XWPFFooter footer = hfPolicy.GetDefaultFooter();

        //    //取得頁首每個段落
        //    if (footer != null)
        //    {
        //        foreach (XWPFParagraph para in footer.Paragraphs)
        //        {
        //            //取得段落中的每一行，並取代指定Tag
        //            SetRunData(para, SearchTag, ColumnValue);
        //        }
        //    }

        //    //取得內文每個段落
        //    foreach (XWPFParagraph para in docx.Paragraphs)
        //    {
        //        //取得段落中的每一行，並取代指定Tag
        //        //SetEachParagraph(para, SearchTag, ColumnValue, true);
        //        SetRunData(para, SearchTag, ColumnValue);

        //        // 設定CheckBox
        //        string SearchCheckTag = String.Format("#CHK_{0}#", ColumnName);

        //        //0x221A√  0x25A0■  0x25A1□  0x2713✓  0x2714✔ 0x2611☑
        //        string CheckSymbol = ((char)0x2611).ToString();
        //        string UnCheckSymbol = ((char)0x25A1).ToString();
        //        // Yes
        //        if (ColumnValue.ToUpper() == "Y")
        //        {
        //            SetRunData(para, SearchCheckTag, CheckSymbol);
        //        }
        //        else // No
        //        {
        //            SetRunData(para, SearchCheckTag, UnCheckSymbol);
        //        }

        //    }

        //    //取得每個Table
        //    foreach (XWPFTable xwpfTable in docx.Tables)
        //    {
        //        //列
        //        foreach (XWPFTableRow tblRow in xwpfTable.Rows)
        //        {
        //            #region 2015/08/2 Lucien調整,暫解Table中的Table資料
        //            // Sub Table
        //            for (int intTempK = 0; intTempK < tblRow.GetTableCells().Count; intTempK++)
        //            {
        //                foreach (XWPFTable tblSubTable in tblRow.GetCell(intTempK).Tables)
        //                {
        //                    foreach (XWPFTableRow tblSubRow in tblSubTable.Rows)
        //                    {
        //                        for (int intTempL = 0; intTempL < tblSubRow.GetTableCells().Count; intTempL++)
        //                            foreach (XWPFParagraph para in tblSubRow.GetCell(intTempL).Paragraphs)
        //                                SetRunData(para, SearchTag, ColumnValue);
        //                    }
        //                }
        //            }
        //            #endregion

        //            //欄
        //            for (int intTempK = 0; intTempK < tblRow.GetTableCells().Count; intTempK++)
        //            {
        //                foreach (XWPFParagraph para in tblRow.GetCell(intTempK).Paragraphs)
        //                {
        //                    SetRunData(para, SearchTag, ColumnValue);

        //                    // 設定CheckBox
        //                    string SearchCheckTagY = String.Format("#CHK_{0}_Y#", ColumnName);
        //                    string SearchCheckTagN = String.Format("#CHK_{0}_N#", ColumnName);

        //                    //0x221A√  0x25A0■  0x25A1□  0x2713✓  0x2714✔
        //                    string CheckSymbol = ((char)0x25A0).ToString();
        //                    string UnCheckSymbol = ((char)0x25A1).ToString();
        //                    // Yes
        //                    if (ColumnValue.ToUpper() == "Y")
        //                    {
        //                        SetRunData(para, SearchCheckTagY, CheckSymbol);
        //                        SetRunData(para, SearchCheckTagN, UnCheckSymbol);
        //                    }
        //                    else // No
        //                    {
        //                        SetRunData(para, SearchCheckTagY, UnCheckSymbol);
        //                        SetRunData(para, SearchCheckTagN, CheckSymbol);
        //                    }

        //                    #region 2015/07/27 joey調整
        //                    // 設定CheckBox
        //                    string SearchCheckTag = String.Format("#CHK_{0}#", ColumnName);

        //                    //0x221A√  0x25A0■  0x25A1□  0x2713✓  0x2714✔ 0x2611☑
        //                    string CheckSymbol2 = ((char)0x2611).ToString();
        //                    //string UnCheckSymbol2 = ((char)0x25A1).ToString();
        //                    string UnCheckSymbol2 = ((char)0x2610).ToString();
        //                    // Yes
        //                    if (ColumnValue.ToUpper() == "Y")
        //                    {
        //                        SetRunData(para, SearchCheckTag, CheckSymbol2);
        //                    }
        //                    else // No
        //                    {
        //                        SetRunData(para, SearchCheckTag, UnCheckSymbol2);
        //                    }
        //                    #endregion
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
