using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using BATODA.Helpers.DataGrids;
using BATODA.Modules.Member_Module.Member_Classes;
using BATODA.UI_Displays;
using Word = Microsoft.Office.Interop.Word;

namespace BATODA
{
    public partial class TransferRecordMemberUForm : UserControl
    {
        private int currentRow = 0;
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
            DataGridCustom.ApplyCustomHistoryGrid(TransferMembershipHistoryGrid);

            TransferMembershipHistoryRepository historyRepo = new TransferMembershipHistoryRepository();
            var table = historyRepo.GetAllTransferRecords();
            DataGridColumns.LoadMembershipTransferHistoryToGrid(TransferMembershipHistoryGrid, table);
        }

        private void ApplyFilterBtn_Click(object sender, EventArgs e)
        {
            if (TransferMembershipHistoryGrid.Rows.Count == 0)
            {
                ToastManager.Warning("No transfer record data to print.");
                return;
            }

            try
            {
                currentRow = 0;
                PrintDocument printDoc = new PrintDocument();
                printDoc.DefaultPageSettings.Landscape = true;
                printDoc.PrintPage += PrintDoc_PrintPage;

                PrintPreviewDialog previewDialog = new PrintPreviewDialog
                {
                    Document = printDoc,
                    Width = 1000,
                    Height = 800
                };

                previewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                ToastManager.Error($"Failed to print transfer records: {ex.Message}");
            }
        }
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            Font dateFont = new Font("Arial", 10, FontStyle.Regular);
            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            Font rowFont = new Font("Arial", 10, FontStyle.Regular);

            int leftMargin = e.MarginBounds.Left;
            int topMargin = e.MarginBounds.Top;
            int rowHeight = 25;
            int yPos = topMargin;

            // Title
            string title = "BAMBANG TODA - Transfer Records";
            SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
            e.Graphics.DrawString(title, titleFont, Brushes.Black,
                e.MarginBounds.Left + (e.MarginBounds.Width - titleSize.Width) / 2, yPos);
            yPos += (int)titleSize.Height + 10;

            // Print Date
            string printDate = $"Print Date: {DateTime.Now:MMMM dd, yyyy}";
            SizeF dateSize = e.Graphics.MeasureString(printDate, dateFont);
            e.Graphics.DrawString(printDate, dateFont, Brushes.Black,
                e.MarginBounds.Right - dateSize.Width, topMargin);
            yPos += 20;

            // Column headers
            int columnCount = TransferMembershipHistoryGrid.Columns.Count;
            int totalWidth = e.MarginBounds.Width;
            int columnWidth = totalWidth / columnCount;
            int[] columnWidths = new int[columnCount];
            for (int i = 0; i < columnCount; i++)
                columnWidths[i] = columnWidth;

            int xPos = leftMargin;
            for (int i = 0; i < columnCount; i++)
            {
                e.Graphics.DrawRectangle(Pens.Black, xPos, yPos, columnWidths[i], rowHeight);
                e.Graphics.DrawString(TransferMembershipHistoryGrid.Columns[i].HeaderText, headerFont, Brushes.Black,
                    new RectangleF(xPos, yPos, columnWidths[i], rowHeight),
                    new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                xPos += columnWidths[i];
            }
            yPos += rowHeight;

            while (currentRow < TransferMembershipHistoryGrid.Rows.Count)
            {
                DataGridViewRow row = TransferMembershipHistoryGrid.Rows[currentRow];
                if (row.IsNewRow) { currentRow++; continue; }

                xPos = leftMargin;
                for (int i = 0; i < columnCount; i++)
                {
                    e.Graphics.DrawRectangle(Pens.Black, xPos, yPos, columnWidths[i], rowHeight);
                    string cellText = row.Cells[i].Value?.ToString() ?? "";
                    e.Graphics.DrawString(cellText, rowFont, Brushes.Black,
                        new RectangleF(xPos, yPos, columnWidths[i], rowHeight),
                        new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    xPos += columnWidths[i];
                }

                yPos += rowHeight;
                currentRow++;

                if (yPos + rowHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            e.HasMorePages = false;
        }
    }
}
