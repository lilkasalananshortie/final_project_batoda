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
using BATODA.Helpers;
using BATODA.Helpers.DataGrids;
using BATODA.Modules.Assistance_Request_Module;
using BATODA.Modules.Assistance_Request_Module.Assistance_Classes;
using BATODA.UI_Displays;

namespace BATODA
{
    public partial class ARHUForm : UserControl
    {
        private int currentRow = 0;

        public ARHUForm()
        {
            InitializeComponent();
        }

        private void AssistanceHomeButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new AssistanceLogUForm());
        }

        private void AssistanceRequestButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new AssistanceRequestUForm());
        }

        private void ARHButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new ARHUForm());
        }
        private void ARHUForm_Load(object sender, EventArgs e)
        {
            AssistanceRepository loader = new AssistanceRepository();
            DataGridCustom.ApplyCustomGrid(AssistanceHistoryGrid);
            loader.LoadTicketHistory(AssistanceHistoryGrid);
            AssistanceHistoryGrid.Columns["TicketID"].HeaderText = "Ticket ID";
            AssistanceHistoryGrid.Columns["BodyNumber"].HeaderText = "Body No.";
            AssistanceHistoryGrid.Columns["FullName"].HeaderText = "Name";
            AssistanceHistoryGrid.Columns["ContactNumber"].HeaderText = "Contact No.";
            AssistanceHistoryGrid.Columns["TypeOfAid"].HeaderText = "Aid";
            AssistanceHistoryGrid.Columns["RequestedBy"].HeaderText = "Requested By";
            AssistanceHistoryGrid.Columns["RequestedAmount"].HeaderText = "Amount";
            AssistanceHistoryGrid.Columns["AssistanceThru"].HeaderText = "Transfer Thru";
            AssistanceHistoryGrid.Columns["GcashNumber"].HeaderText = "Gcash No.";
            AssistanceHistoryGrid.Columns["DateRequested"].HeaderText = "Date Req.";
            AssistanceHistoryGrid.Columns["RequestStatus"].HeaderText = "Status";
            AssistanceHistoryGrid.Columns["ActionDate"].HeaderText = "Update Date";

        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            if (AssistanceHistoryGrid.Rows.Count == 0)
            {
                ToastManager.Warning("No assistance record data to print.");
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
                ToastManager.Error($"Failed to print assistance records: {ex.Message}");
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
            string title = "BAMBANG TODA - Assistance Records";
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
            int columnCount = AssistanceHistoryGrid.Columns.Count;
            int totalWidth = e.MarginBounds.Width;
            int columnWidth = totalWidth / columnCount;
            int[] columnWidths = new int[columnCount];
            for (int i = 0; i < columnCount; i++)
                columnWidths[i] = columnWidth;

            int xPos = leftMargin;
            for (int i = 0; i < columnCount; i++)
            {
                e.Graphics.DrawRectangle(Pens.Black, xPos, yPos, columnWidths[i], rowHeight);
                e.Graphics.DrawString(AssistanceHistoryGrid.Columns[i].HeaderText, headerFont, Brushes.Black,
                    new RectangleF(xPos, yPos, columnWidths[i], rowHeight),
                    new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                xPos += columnWidths[i];
            }
            yPos += rowHeight;

            // Rows
            while (currentRow < AssistanceHistoryGrid.Rows.Count)
            {
                DataGridViewRow row = AssistanceHistoryGrid.Rows[currentRow];
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
