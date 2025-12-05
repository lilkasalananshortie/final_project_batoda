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
using BATODA.Helpers.DataGrids;
using BATODA.Modules.Tricycle_Module.Tricycle_Classes;
using BATODA.UI_Displays;

namespace BATODA
{
    public partial class TransferRecordVehicleUForm : UserControl
    {
        private int currentRow = 0;

        public TransferRecordVehicleUForm()
        {
            InitializeComponent();
            LoadTransferHistoryToGrid();
        }

        private void LoadTransferHistoryToGrid()
        {
            TricycleRepository repo = new TricycleRepository();
            DataTable history = repo.LoadTransferHistory();

            if (!history.Columns.Contains("BodyNumberDisplay"))
                history.Columns.Add("BodyNumberDisplay", typeof(string));

            foreach (DataRow row in history.Rows)
            {
                row["BodyNumberDisplay"] = Convert.ToInt32(row["BodyNumber"]).ToString("D3");
            }

            TransferTricHistoryGrid.DataSource = history;

            if (TransferTricHistoryGrid.Columns.Contains("BodyNumberDisplay"))
            {
                TransferTricHistoryGrid.Columns["BodyNumberDisplay"].HeaderText = "Body No.";
                TransferTricHistoryGrid.Columns["BodyNumberDisplay"].DisplayIndex = 0;
            }

            DataGridColumns.LoadTransferHistoryToGrid(TransferTricHistoryGrid, history);
            DataGridCustom.ApplyCustomGrid(TransferTricHistoryGrid);
        }

        private void TransferRecordVehicleUForm_Load(object sender, EventArgs e)
        {
            
        }

        private void RegisteredVehicleButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TricycleUForm());
        }

        private void TransferVehicleButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferVehicleUForm());
        }

        private void TransferRecordButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferRecordVehicleUForm());
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            if (TransferTricHistoryGrid.Rows.Count == 0)
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
            string title = "BAMBANG TODA - Vehicle Transfer Records";
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
            int columnCount = TransferTricHistoryGrid.Columns.Count;
            int totalWidth = e.MarginBounds.Width;
            int columnWidth = totalWidth / columnCount;
            int[] columnWidths = new int[columnCount];
            for (int i = 0; i < columnCount; i++)
                columnWidths[i] = columnWidth;

            int xPos = leftMargin;
            for (int i = 0; i < columnCount; i++)
            {
                e.Graphics.DrawRectangle(Pens.Black, xPos, yPos, columnWidths[i], rowHeight);
                e.Graphics.DrawString(TransferTricHistoryGrid.Columns[i].HeaderText, headerFont, Brushes.Black,
                    new RectangleF(xPos, yPos, columnWidths[i], rowHeight),
                    new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                xPos += columnWidths[i];
            }
            yPos += rowHeight;

            // Rows
            while (currentRow < TransferTricHistoryGrid.Rows.Count)
            {
                DataGridViewRow row = TransferTricHistoryGrid.Rows[currentRow];
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

                // Check for next page
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
