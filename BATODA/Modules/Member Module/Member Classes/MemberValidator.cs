using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.Modules.MemberModule
{
    public static class MemberValidator
    {
        public static bool ValidateMember(MemberModel member)
        {
            if (string.IsNullOrWhiteSpace(member.FirstName))
            {
                MessageBox.Show("First Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(member.LastName))
            {
                MessageBox.Show("Last Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(member.MiddleInitial) || member.MiddleInitial.Length != 1)
            {
                MessageBox.Show("Middle Initial must be exactly 1 character.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(member.PlateNumber))
            {
                MessageBox.Show("Plate Number cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(member.EngineNumber))
            {
                MessageBox.Show("Engine Number cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(member.ChassisNumber))
            {
                MessageBox.Show("Chassis Number cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(member.ContactNumber) ||
                     member.ContactNumber.Length != 11 ||
                     !member.ContactNumber.StartsWith("09") ||
                     !member.ContactNumber.All(char.IsDigit))
            {
                MessageBox.Show("Contact Number must be 11 digits and start with 09.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(member.TricycleBrand))
            {
                MessageBox.Show("Tricycle Brand cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(member.TricycleModel))
            {
                MessageBox.Show("Tricycle Model cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(member.MembershipType))
            {
                MessageBox.Show("Membership Type cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
