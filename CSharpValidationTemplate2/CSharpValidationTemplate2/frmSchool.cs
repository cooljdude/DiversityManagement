using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using teamProject;
using System.Data.OleDb;
using System.IO;
using System.Configuration;


namespace teamProject
{
    public partial class frmSchool : Form
    {
        frmMain home;

        public frmSchool(frmMain incoming)
        {
            home = incoming;
            InitializeComponent();
        }
        // Let's set our class scope variables
        private ArrayList mSchool = new ArrayList();
        private string mSchoolFile = "";
        private OleDbConnection mDB;

        // Exit button. 
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // When the clear button is clicked, erase the input and output form objects and position the cursor in the first input field.
        private void btnClear_Click(object sender, EventArgs e)
        {
            eraseInputFields();
            lstSchool.Items.Clear();
            // erase all the data in the arrays
            mSchool.Clear();
            txtSchool.Focus();
        }

        // This helper method is used to open a connection to the database.
        private void openDatabaseConnection()
        {
            string connectionString =
                ConfigurationManager.AppSettings["DBConnectionString"] + mSchoolFile;
            mDB = new OleDbConnection(connectionString);
        }

        // This helper method releases the DB connection.
        private void closeDatabaseConnection()
        {
            if (mDB != null)
            {
                mDB.Close();
            }
        }

        // The validateInput helper methods handles the existence check, type check, and range check for a given input form
        // object and assigns the equivalent value to its corresponding variable.

        // Validation helper method for integer data types
        private bool validateInput(TextBox txtInput, int min, int max, out int userInput)
        {
            string fieldName;
            fieldName = txtInput.Name.Substring(3);
            userInput = 0;
            if (txtInput.Text == "")
            {
                ShowMessage("Please enter a value for " + fieldName);
                txtInput.Focus();
                return false;
            }
            if (int.TryParse(txtInput.Text, out userInput) == false)
            {
                ShowMessage("Only numbers are allowed for " + fieldName + ". Please re-enter:");
                txtInput.Focus();
                return false;
            }
            if (userInput < min || userInput > max)
            {
                ShowMessage(fieldName + " must be between " + min.ToString() + " and " + max.ToString());
                txtInput.Focus();
                return false;
            }
            return true;
        }

        // Validation helper method for double data types
        private bool validateInput(TextBox txtInput, double min, double max, out double userInput)
        {
            string fieldName;
            fieldName = txtInput.Name.Substring(3);
            userInput = 0D;
            if (txtInput.Text == "")
            {
                ShowMessage("Please enter a value for " + fieldName);
                txtInput.Focus();
                return false;
            }
            if (double.TryParse(txtInput.Text, out userInput) == false)
            {
                ShowMessage("Only numbers are allowed for " + fieldName + ". Please re-enter:");
                txtInput.Focus();
                return false;
            }
            if (userInput < min || userInput > max)
            {
                ShowMessage(fieldName + " must be between " + min.ToString() + " and " + max.ToString());
                txtInput.Focus();
                return false;
            }
            return true;
        }

        // Validation helper method for decimal data types
        private bool validateInput(TextBox txtInput, decimal min, decimal max, out decimal userInput)
        {
            string fieldName;
            fieldName = txtInput.Name.Substring(3);
            userInput = 0M;
            if (txtInput.Text == "")
            {
                ShowMessage("Please enter a value for " + fieldName);
                txtInput.Focus();
                return false;
            }
            if (decimal.TryParse(txtInput.Text, out userInput) == false)
            {
                ShowMessage("Only numbers are allowed for " + fieldName + ". Please re-enter:");
                txtInput.Focus();
                return false;
            }
            if (userInput < min || userInput > max)
            {
                ShowMessage(fieldName + " must be between " + min.ToString() + " and " + max.ToString());
                txtInput.Focus();
                return false;
            }
            return true;
        }

        // The overloaded validateInput helper method handles the existence check for a given string input form object 
        // and assigns the equivalent value to its corresponding variable. 
        private bool validateInput(TextBox txtInput, out string userInput)
        {
            string fieldName;
            fieldName = txtInput.Name.Substring(3);
            userInput = "";
            if (txtInput.Text == "")
            {
                ShowMessage("Please enter a value for " + fieldName);
                txtInput.Focus();
                return false;
            }
            userInput = txtInput.Text;
            return true;
        }

        // The ShowMessage helper method displays an error message with a standard title and an OK button.
        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, "Problem found", MessageBoxButtons.OK);
        }

        // This helper method just produces the column headers in the listbox
        private void showHeaders()
        {
            string outputLine;
            // start with a blank listbox
            lstSchool.Items.Clear();

            // construct the column headers
            outputLine = "      SCHOOL NAME       " + "  " + "                   ADDRESS                    " + "  " + "          CITY         " + "  " + "    STATE    " + "  " + "  CONTACT NAME   " + "  " + "     PHONE     ";
            lstSchool.Items.Add(outputLine);
            outputLine = "=======================" + "  " + "============================================" + "  " + "========================" + "  " + "=============" + "  " + "=============" + "  " + "===============";
            lstSchool.Items.Add(outputLine);

        }

        // This helper method displays the data in the arrays in the listbox.
        private void displayData()
        {
            string outputLine;

            // if there are no clients, display a message
            if (mSchool.Count == 0)
            {
                ShowMessage("There are currently no Schools. Please add schools.");
                txtSchool.Focus();
                return;
            }

            showHeaders();

            // show the detailed client information
            foreach (clsSchool school in mSchool)
            {
                outputLine = school.dispSchool();
                lstSchool.Items.Add(outputLine);
            }
        }

        // When Add is clicked, the input fileds are validated. If all are acceptable and there is room
        // to add schools, the school is added to the next available spot in the arrays.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Define all variables.

            string sql;

            // Validate the user's input.
            if (txtSchool.Text == "")
            {
                ShowMessage("Please enter the school name.");
                txtSchool.Focus();
                return;
            }
            if (txtAddress.Text == "")
            {
                ShowMessage("Please enter the address.");
                txtAddress.Focus();
                return;
            }
            if (txtCity.Text == "")
            {
                ShowMessage("Please enter the city.");
                txtAddress.Focus();
                return;
            }
            if (txtContactName.Text == "")
            {
                ShowMessage("Please enter the contact name.");
                txtAddress.Focus();
                return;
            }
            if (txtPhone.Text == "")
            {
                ShowMessage("Please enter phone number.");
                txtAddress.Focus();
                return;
            }


            // Data is valid and more clients can be added, so update the DB and then load the data rom the DB
            try
            {
                // Add a record into the Clients table.
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                sql = "INSERT INTO School (SchoolName, Address, City, State, ContactName, Phone) VALUES (" +
                    clsSQL.ToSql(txtSchool.Text) + ", " +
                    clsSQL.ToSql(txtAddress.Text) + ", " +
                    clsSQL.ToSql(txtCity.Text) + ", " +
                    clsSQL.ToSql(cboState.Text) + ", " +
                    clsSQL.ToSql(txtContactName.Text) + ", " +
                    clsSQL.ToSql(txtPhone.Text) + ")";
                cmd = new OleDbCommand(sql, mDB);
                cmd.ExecuteNonQuery();

                // Lookup ID of school record just added to get ID.
                sql = "SELECT * FROM School WHERE SchoolName = " + clsSQL.ToSql(txtSchool.Text);
                OleDbDataReader rdr;
                cmd = new OleDbCommand(sql, mDB);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                int staffID = (int)rdr["SchoolID"];
                rdr.Close();
            }
            catch (Exception ex)
            {
                ShowMessage("There was an unexpected problem: " + ex.Message);
            }
            finally
            {
                closeDatabaseConnection();
            }

            // Erase the input values and display the current client roster
            eraseInputFields();
            loadSchool("SELECT * FROM School");
            displayData();
        }

        // This helper method erases the input textboxes and positions the cursor in the first textbox.
        private void eraseInputFields()
        {
            txtSchool.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtContactName.Text = "";
            txtPhone.Text = "";
            cboState.SelectedIndex = -1;
            txtSchool.Focus();
        }

        // This method removes the selected school from the roster
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql;
            int selectedSchool = lstSchool.SelectedIndex - 2;

            // Make sure a valid school was selected.
            if (selectedSchool < 0 || selectedSchool >= mSchool.Count)
            {
                ShowMessage("Please select a valid school in the listbox.");
                lstSchool.SelectedIndex = -1;
                return;
            }

            // Get the ID of the selected client to fill in the input boxes
            clsSchool temp = (clsSchool)mSchool[selectedSchool];

            // Delete the selected client and remove the corresponding record in the ClientPlan table
            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                sql = "DELETE FROM School WHERE SchoolID = " + clsSQL.ToSql(temp.SchoolID);
                cmd = new OleDbCommand(sql, mDB);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ShowMessage("There was an unexpected problem when deleting the school: " + ex.Message);
            }
            finally
            {
                closeDatabaseConnection();
            }

            // Erase the input values, notify the user, and display the current school roster
            eraseInputFields();
            ShowMessage(temp.SchoolName + "'s record has been deleted.");
            loadSchool("SELECT * FROM School");
            displayData();

        }

        // When the Update button is clicked, the user is able to modify the data
        // for the selected staff member.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Define all variables.

            string sql;

            int selectedSchool = lstSchool.SelectedIndex - 2;

            // Make sure a valid client was selected.
            if (selectedSchool < 0 || selectedSchool >= mSchool.Count)
            {
                ShowMessage("Please select a valid staff member in the listbox.");
                lstSchool.SelectedIndex = -1;
                return;
            }

            // Get the ID of the selected client to fill in the input boxes
            clsSchool temp = (clsSchool)mSchool[selectedSchool];

            // Validate the user's input.
            if (txtSchool.Text == "")
            {
                ShowMessage("Please enter the school name.");
                txtSchool.Focus();
                return;
            }
            if (txtAddress.Text == "")
            {
                ShowMessage("Please enter the address.");
                txtAddress.Focus();
                return;
            }
            if (txtCity.Text == "")
            {
                ShowMessage("Please enter the city.");
                txtAddress.Focus();
                return;
            }
            if (txtContactName.Text == "")
            {
                ShowMessage("Please enter the contact name.");
                txtAddress.Focus();
                return;
            }
            if (txtPhone.Text == "")
            {
                ShowMessage("Please enter phone number.");
                txtAddress.Focus();
                return;
            }

            // Data is valid so modify the school and reload the data from the DB
            try
            {
                // Change a record in the School table.
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                sql = "UPDATE School SET SchoolName = " + clsSQL.ToSql(txtSchool.Text) +
                    ", Address = " + clsSQL.ToSql(txtAddress.Text) +
                    ", City = " + clsSQL.ToSql(txtCity.Text) +
                    ", State = " + clsSQL.ToSql(cboState.Text) +
                    ", ContactName = " + clsSQL.ToSql(txtContactName.Text) +
                    ", Phone = " + clsSQL.ToSql(txtPhone.Text) +
                    " WHERE SchoolID = " + clsSQL.ToSql(temp.SchoolID);
                cmd = new OleDbCommand(sql, mDB);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                ShowMessage("There was an unexpected problem: " + ex.Message);
            }
            finally
            {
                closeDatabaseConnection();
            }

            // Erase the input values, notify the user, and display the current client roster
            eraseInputFields();
            ShowMessage(temp.SchoolName + "'s record has been updated.");
            loadSchool("SELECT * FROM School");
            displayData();

        }

        // When File-Open is clicked, the user is able to select the staff file to open.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Database file to open";
            ofd.Filter = "Staff (*.accdb)|*.accdb|All files (*.*)|*.*";
            ofd.InitialDirectory = Path.Combine(Application.StartupPath, @"Databases");

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Assign the filename
                mSchoolFile = ofd.FileName;
            }
            loadSchool("SELECT * FROM School");

            displayData();
        }

        // The loadSchool helper method reads the data from the specified file and copies
        // to the staff array.
        private void loadSchool(string sql)
        {
            clsSchool member;
            // Clear out the array before handling the file data.
            mSchool.Clear();

            // Read the data from the specified file.

            if (File.Exists(mSchoolFile) == false)
            {
                ShowMessage(mSchoolFile + " does not exist. Please open another DB file.");
                return;
            }
            openDatabaseConnection();
            mDB.Open();
            OleDbCommand cmd;
            OleDbDataReader rdr;
            try
            {
                cmd = new OleDbCommand(sql, mDB);
                rdr = cmd.ExecuteReader();
                while (rdr.Read() == true)
                {
                    // Add the data from the line just read to the next array element, making sure to get the ID.
                    member = new clsSchool((int)rdr["SchoolID"],
                        (string)rdr["SchoolName"],
                        (string)rdr["Address"],
                        (string)rdr["City"],
                        (string)rdr["State"],
                        (string)rdr["ContactName"],
                        (string)rdr["Phone"]);
                    mSchool.Add(member);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                ShowMessage("There was an unexpected problem: " + ex.Message);
            }
            finally
            {
                closeDatabaseConnection();
            }
        }

        // Search for the selected school
        private void btnFind_Click(object sender, EventArgs e)
        {
            // Validate the user's input.
            if ((txtSchool.Text == ""))
            {
                ShowMessage("Please enter the school to perform a search.");
                txtSchool.Focus();
                return;
            }

            // If both first and last names are given, sort the names and then do a binary search.
            if ((txtSchool.Text != "") && (txtAddress.Text != ""))
            {
                loadSchool("SELECT * FROM Staff WHERE FirstName=" + clsSQL.ToSql(txtSchool.Text) + " AND LastName=" + clsSQL.ToSql(txtAddress.Text));
                displayData();
            }
            else if (txtAddress.Text != "")
            {
                loadSchool("SELECT * FROM Staff WHERE LastName=" + clsSQL.ToSql(txtAddress.Text));
                displayData();
            }
            else if (txtSchool.Text != "")
            {
                loadSchool("SELECT * FROM Staff WHERE FirstName=" + clsSQL.ToSql(txtSchool.Text));
                displayData();
            }
            else // search is for title
            {
                loadSchool("SELECT * FROM Staff WHERE Title=" + clsSQL.ToSql(txtCity.Text));
                displayData();
            }

        }

        // Terminate the program when File-Exit is selected.
        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        //// When View-Lastname is clicked, the data appears sorted by lastname
        //private void mnuViewLastName_Click(object sender, EventArgs e)
        //{
        //    clsSortLName comparer = new clsSortLName();
        //    mSchool.Sort(comparer);
        //    displayData();
        //}

        //// When View-Firstname is clicked, the data appears sorted by firstname
        //private void mnuViewFirstName_Click(object sender, EventArgs e)
        //{
        //    clsSortFName comparer = new clsSortFName();
        //    mSchool.Sort(comparer);
        //    displayData();
        //}

        //// When View-Title is clicked, the data appears sorted by starting weight
        //private void mnuViewTitle_Click_1(object sender, EventArgs e)
        //{
        //    clsSortTitle comparer = new clsSortTitle();
        //    mSchool.Sort(comparer);
        //    displayData();
        //}
        //// When View-Email is clicked, the data appears sorted by goal weight
        //private void mnuViewEmail_Click(object sender, EventArgs e)
        //{
        //    clsSortEmail comparer = new clsSortEmail();
        //    mSchool.Sort(comparer);
        //    displayData();
        //}

        //// When View-Weeks is clicked, the data appears sorted by weeks to train
        //private void mnuViewPhone_Click(object sender, EventArgs e)
        //{
        //    clsSortPhone comparer = new clsSortPhone();
        //    mSchool.Sort(comparer);
        //    displayData();

        //}

        // Revise the selected items in the two combo boxes when a name is selected.
        private void lstStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedSchool = lstSchool.SelectedIndex - 2;

            // Make sure a valid client was selected.
            if (selectedSchool < 0 || selectedSchool >= mSchool.Count)
            {
                ShowMessage("Please select a school in the listbox.");
                lstSchool.SelectedIndex = -1;
                return;
            }
            // Get the ID of the selected client to fill in the input boxes
            clsSchool temp = (clsSchool)mSchool[selectedSchool];
            txtSchool.Text = temp.SchoolName;
            txtAddress.Text = temp.Address;
            txtCity.Text = temp.City;
            cboState.Text = temp.State;
            txtContactName.Text = temp.ContactName;
            txtPhone.Text = temp.Phone;

            // Notify the user of the possible actions 
            ShowMessage("To delete " + temp.SchoolName + " as a school, press the delete key. \n" +
                "To modify " + temp.SchoolName + "'s data, edit the data in the input fields and click Update.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            home.Show();
            this.Hide();
        }
    }
}
