using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BATODA.Helpers.DataGrids;
using BATODA.Modules.Member_Module.Member_Classes;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;

namespace BATODA
{
    public partial class TransferRecordMemberUForm : UserControl
    {
        public TransferRecordMemberUForm()
        {
            InitializeComponent();
            
        }

        private void ManageMembersButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new MembersUForm());
        }

        private void TransferMembershipButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferMembershipUForm());
        }

        private void TransferRecordsButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferRecordMemberUForm());
        }

        private void TransferRecordMemberUForm_Load(object sender, EventArgs e)
        {
            DataGridCustom.ApplyCustomMemberHistoryGrid(TransferMembershipHistoryGrid);

            TransferMembershipHistoryRepository historyRepo = new TransferMembershipHistoryRepository();
            var table = historyRepo.GetAllTransferRecords();
            DataGridColumns.LoadMembershipTransferHistoryToGrid(TransferMembershipHistoryGrid, table);
        }

        /* WOP - NOT FINAL */
        private void ApplyFilterBtn_Click(object sender, EventArgs e)
        {
            var wordApp = new Word.Application();
            var doc = wordApp.Documents.Add();

            Word.Paragraph title = doc.Content.Paragraphs.Add();
            title.Range.Text = "Membership Transfer Report";
            title.Range.Font.Size = 16;
            title.Range.Font.Bold = 1;
            title.Range.InsertParagraphAfter();

            Word.Paragraph para = doc.Content.Paragraphs.Add();
            para.Range.Text = "Generated on: " + DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            para.Range.Font.Size = 12;
            para.Range.Font.Bold = 0;
            para.Range.InsertParagraphAfter();

            int rowCount = TransferMembershipHistoryGrid.Rows.Count + 1;
            int colCount = TransferMembershipHistoryGrid.Columns.Count;

            Word.Table table = doc.Tables.Add(doc.Range(0, 0), rowCount, colCount);
            table.Borders.Enable = 1; 
            table.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitWindow); 

            for (int c = 0; c < colCount; c++)
            {
                var cellRange = table.Cell(1, c + 1).Range;
                cellRange.Text = TransferMembershipHistoryGrid.Columns[c].HeaderText;
                cellRange.Bold = 1;
                cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }

            for (int r = 0; r < TransferMembershipHistoryGrid.Rows.Count; r++)
            {
                for (int c = 0; c < colCount; c++)
                {
                    var cellText = TransferMembershipHistoryGrid.Rows[r].Cells[c].Value?.ToString() ?? "";
                    var cellRange = table.Cell(r + 2, c + 1).Range;
                    cellRange.Text = cellText;
                    cellRange.Bold = 0; 
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                }
            }

            wordApp.Visible = true;

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Word Document (*.docx)|*.docx";
            saveDialog.FileName = "MembershipTransferReport.docx";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                doc.SaveAs2(saveDialog.FileName);
                MessageBox.Show("Document saved successfully!");
            }
        }



    }
}
