using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BATODA.User_Control_Forms
{
    public partial class ActivityassistanceLog : UserControl
    {
        public ActivityassistanceLog(string timestamp, string ActionTitle, string ActionInfo, string status)
        {
            InitializeComponent();

            LabelTimeStamp.Text = timestamp;
            LabelRequestAction.Text = ActionTitle;
            LabelRequestInfo.Text = ActionInfo;

            string normalizedStatus = (status ?? "").ToLower();

            switch (normalizedStatus)
            {
                case "success":
                case "approved": 
                    PictureBoxStatus.Image = Properties.Resources.ActivityLog_Approved;
                    break;
                case "failed":
                case "rejected":
                    PictureBoxStatus.Image = Properties.Resources.ActivityLog_rejected;
                    break;
                case "canceled":
                    PictureBoxStatus.Image = Properties.Resources.ActivityLog_canceled;
                    break;

            }

            this.BackColor = Color.White;
            this.Padding = new Padding(5);
            this.Margin = new Padding(0, 0, 0, 5);
            this.BorderStyle = BorderStyle.FixedSingle;
        }

    }
}
