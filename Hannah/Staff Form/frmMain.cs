using System;
using System.Windows.Forms;
using System.IO;                     // Kept to use file dialogs
using System.Collections;            // Added to be able to use ArrayLists
using System.Data.OleDb;             // Added to connect to Access DB
using System.Configuration;          // Added to access app.config data

// Name:   CIT255ProjectStaffFormByHannah Helterbran based on CIT255Lab10DBAddByAlkaHarriger
// Author: Hannah Helterbran
// Date:   11/13/14
//
// This application gets the Diversity office's staff data from an Access DB table and stores in an ArrayList. 
// Each staff record includes first name, last name, title, email, phone, fax, and office. Once read, the summary table of all staff and their data 
// values are displayed. The user can add, delete and update records in the database.

public partial class frmMain : Form
{
    [STAThread]

    public static void Main()
    {
        frmMain main = new frmMain();
        Application.Run(main);
    }

    public frmMain()
    {
        InitializeComponent();
    }

    // Class scope variables
    private ArrayList mStaff = new ArrayList();
    private string mStaffFile = "";
    private OleDbConnection mDB;

    // When the Exit button is clicked, terminate the program.
    private void btnExit_Click(object sender, EventArgs e)
    {
        Close();
    }

    // When the clear button is clicked, erase the input and output form objects and position the cursor in the first input field.
    private void btnClear_Click(object sender, EventArgs e)
    {
        eraseInputFields();
        lstStaff.Items.Clear();
        // erase all the data in the arrays
        mStaff.Clear();
        txtFirstName.Focus();
    }

    // This helper method is used to open a connection to the database.
    private void openDatabaseConnection()
    {
        string connectionString =
            ConfigurationManager.AppSettings["DBConnectionString"] + mStaffFile;
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
        lstStaff.Items.Clear();

        // construct the column headers
        outputLine = "         STAFF NAME          " + "  " + "                      TITLE                       " + "  " + "             Email            " + "  " + "    PHONE    " + "  " + "     FAX     " + "  " + "       OFFICE       ";
        lstStaff.Items.Add(outputLine);
        outputLine = "=============================" + "  " + "==================================================" + "  " + "==============================" + "  " + "=============" + "  " + "=============" + "  " + "====================";
        lstStaff.Items.Add(outputLine);

    }

    // This helper method displays the data in the arrays in the listbox.
    private void displayData()
    {
        string outputLine;

        // if there are no clients, display a message
        if (mStaff.Count == 0)
        {
            ShowMessage("There are currently no Staff Members. Please add staff.");
            txtFirstName.Focus();
            return;
        }

        showHeaders();

        // show the detailed client information
        foreach (clsStaff staff in mStaff)
        {
            outputLine = staff.ShowStaff();
            lstStaff.Items.Add(outputLine);
        }
    }

    // When Add is clicked, the input fileds are validated. If all are acceptable and there is room
    // to add clients, the client is added to the next available spot in the arrays.
    private void btnAdd_Click(object sender, EventArgs e)
    {
        // Define all variables.
        string title;
        string email;
        string phone;
        string fax;
        string office;
        string sql;

        // Validate the user's input.
        if (txtFirstName.Text == "")
        {
            ShowMessage("Please enter the staff member's first name");
            txtFirstName.Focus();
            return;
        }
        if (txtLastName.Text == "")
        {
            ShowMessage("Please enter the staff members's last name");
            txtLastName.Focus();
            return;
        }
        if (validateInput(txtTitle, out title) == false)
        {
            return;
        }
        if (validateInput(txtEmail, out email) == false)
        {
            return;
        }
        if (validateInput(txtPhone, out phone) == false)
        {
            return;
        }
        if (validateInput(txtFax, out fax) == false)
        {
            return;
        }
        if (validateInput(txtOffice, out office) == false)
        {
            return;
        }
        

        // Data is valid and more clients can be added, so update the DB and then load the data rom the DB
        try
        {
            // Add a record into the Clients table.
            openDatabaseConnection();
            mDB.Open();
            OleDbCommand cmd;
            sql = "INSERT INTO Staff (First Name, Last Name, Title, Email, Phone, Fax, Office) VALUES (" +
                clsSQL.ToSql(txtFirstName.Text) + ", " +
                clsSQL.ToSql(txtLastName.Text) + ", " +
                clsSQL.ToSql(title) + ", " +
                clsSQL.ToSql(email) + ", " +
                clsSQL.ToSql(phone) + ", " +
                clsSQL.ToSql(fax) + ", " +
                clsSQL.ToSql(office) + ")";
            cmd = new OleDbCommand(sql, mDB);
            cmd.ExecuteNonQuery();

            // Lookup ID of client record just added to get ID.
            sql = "SELECT * FROM Staff WHERE First Name = " + clsSQL.ToSql(txtFirstName.Text) +
                " AND Last Name = " + clsSQL.ToSql(txtLastName.Text);
            OleDbDataReader rdr;
            cmd = new OleDbCommand(sql, mDB);
            rdr = cmd.ExecuteReader();
            rdr.Read();
            int staffID = (int)rdr["ID"];
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
        loadStaff("SELECT * FROM Staff");
        displayData();
    }

    // This helper method erases the input textboxes and positions the cursor in the first textbox.
    private void eraseInputFields()
    {
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtTitle.Text = "";
        txtEmail.Text = "";
        txtPhone.Text = "";
        txtFax.Text = "";
        txtOffice.Text = "";
        txtFirstName.Focus();
    }

    // This method removes the selected staff member from the roster
    private void btnDelete_Click(object sender, EventArgs e)
    {
        string sql;
        int selectedStaff = lstStaff.SelectedIndex - 2;

        // Make sure a valid client was selected.
        if (selectedStaff < 0 || selectedStaff >= mStaff.Count)
        {
            ShowMessage("Please select a valid Staff Member in the listbox.");
            lstStaff.SelectedIndex = -1;
            return;
        }

        // Get the ID of the selected client to fill in the input boxes
        clsStaff temp = (clsStaff)mStaff[selectedStaff];

        // Delete the selected client and remove the corresponding record in the ClientPlan table
        try
        {
            openDatabaseConnection();
            mDB.Open();
            OleDbCommand cmd;
            sql = "DELETE FROM Staff WHERE ID = " + clsSQL.ToSql(temp.ID);
            cmd = new OleDbCommand(sql, mDB);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            ShowMessage("There was an unexpected problem when deleting the Staff member: " + ex.Message);
        }
        finally
        {
            closeDatabaseConnection();
        }

        // Erase the input values, notify the user, and display the current client roster
        eraseInputFields();
        ShowMessage(temp.FirstName + "'s record has been deleted.");
        loadStaff("SELECT * FROM Staff");
        displayData();

    }

    // When the Update button is clicked, the user is able to modify the data
    // for the selected staff member.
    private void btnUpdate_Click(object sender, EventArgs e)
    {
        // Define all variables.
        string title;
        string email;
        string phone;
        string fax;
        string office;
        string sql;

        int selectedStaff = lstStaff.SelectedIndex - 2;

        // Make sure a valid client was selected.
        if (selectedStaff < 0 || selectedStaff >= mStaff.Count)
        {
            ShowMessage("Please select a valid staff member in the listbox.");
            lstStaff.SelectedIndex = -1;
            return;
        }

        // Get the ID of the selected client to fill in the input boxes
        clsStaff temp = (clsStaff)mStaff[selectedStaff];

        // Validate the user's input.
        if (txtFirstName.Text == "")
        {
            ShowMessage("Please enter the staff member's first name");
            txtFirstName.Focus();
            return;
        }
        if (txtLastName.Text == "")
        {
            ShowMessage("Please enter the staff member's last name");
            txtLastName.Focus();
            return;
        }
        if (validateInput(txtTitle, out title) == false)
        {
            return;
        }
        if (validateInput(txtEmail, out email) == false)
        {
            return;
        }
        if (validateInput(txtPhone, out phone) == false)
        {
            return;
        }
        if (validateInput(txtFax, out fax) == false)
        {
            return;
        }
        if (validateInput(txtOffice, out office) == false)
        {
            return;
        }

        // Data is valid so modify the staff and reload the data from the DB
        try
        {
            // Change a record in the Staff table.
            openDatabaseConnection();
            mDB.Open();
            OleDbCommand cmd;
            sql = "UPDATE Staff SET First Name = " + clsSQL.ToSql(txtFirstName.Text) +
                ", Last Name = " + clsSQL.ToSql(txtLastName.Text) +
                ", Title = " + clsSQL.ToSql(title) +
                ", Email = " + clsSQL.ToSql(email) +
                ", Phone = " + clsSQL.ToSql(phone) +
                ", Fax = " + clsSQL.ToSql(fax) +
                ", Office = " + clsSQL.ToSql(office) +
                " WHERE ID = " + clsSQL.ToSql(temp.ID);
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
        ShowMessage(temp.FirstName + "'s record has been updated.");
        loadStaff("SELECT * FROM Staff");
        displayData();

    }

    // When File-Open is clicked, the user is able to select the staff file to open.
    private void mnuFileOpen_Click(object sender, EventArgs e)
    {
        OpenFileDialog ofd = new OpenFileDialog();
        ofd.Title = "Select Staff DB file to open";
        ofd.Filter = "Staff (*.accdb)|*.accdb|All files (*.*)|*.*";
        ofd.InitialDirectory = Path.Combine(Application.StartupPath, @"Databases");

        if (ofd.ShowDialog() == DialogResult.OK)
        {
            // Assign the filename
            mStaffFile = ofd.FileName;
        }
        loadStaff("SELECT * FROM Staff");

        displayData();
    }

    // The loadStaff helper method reads the data from the specified file and copies
    // to the staff array.
    private void loadStaff(string sql)
    {
        clsStaff member;
        // Clear out the array before handling the file data.
        mStaff.Clear();

        // Read the data from the specified file.

        if (File.Exists(mStaffFile) == false)
        {
            ShowMessage(mStaffFile + " does not exist. Please open another DB file.");
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
                member = new clsStaff((int)rdr["ID"],
                    (string)rdr["First Name"],
                    (string)rdr["Last Name"],
                    (string)rdr["Title"],
                    (string)rdr["Email"],
                    (string)rdr["Phone"],
                    (string)rdr["Fax"],
                    (string)rdr["Office"]);
                mStaff.Add(member);
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

    // Search for the selected staff member.
    private void btnFind_Click(object sender, EventArgs e)
    {
        // Validate the user's input.
        if ((txtFirstName.Text == "") && (txtLastName.Text == "") && (txtOffice.Text == ""))
        {
            ShowMessage("Please enter the staff memeber's first name, last name, or title to perform a search");
            txtFirstName.Focus();
            return;
        }

        // If both first and last names are given, sort the names and then do a binary search.
        if ((txtFirstName.Text != "") && (txtLastName.Text != ""))
        {
            loadStaff("SELECT * FROM Staff WHERE First Name=" + clsSQL.ToSql(txtFirstName.Text) + " AND Last Name=" + clsSQL.ToSql(txtLastName.Text));
            displayData();
        }
        else if (txtLastName.Text != "")
        {
            loadStaff("SELECT * FROM Staff WHERE Last Name=" + clsSQL.ToSql(txtLastName.Text));
            displayData();
        }
        else if (txtFirstName.Text != "")
        {
            loadStaff("SELECT * FROM Staff WHERE First Name=" + clsSQL.ToSql(txtFirstName.Text));
            displayData();
        }
        else // search is for title
        {
            loadStaff("SELECT * FROM Staff WHERE Title=" + clsSQL.ToSql(txtTitle.Text));
            displayData();
        }

    }

    // Terminate the program when File-Exit is selected.
    private void mnuFileExit_Click(object sender, EventArgs e)
    {
        Close();
    }

    // When View-Lastname is clicked, the data appears sorted by lastname
    private void mnuViewLastName_Click(object sender, EventArgs e)
    {
        clsSortLName comparer = new clsSortLName();
        mStaff.Sort(comparer);
        displayData();
    }

    // When View-Firstname is clicked, the data appears sorted by firstname
    private void mnuViewFirstName_Click(object sender, EventArgs e)
    {
        clsSortFName comparer = new clsSortFName();
        mStaff.Sort(comparer);
        displayData();
    }

    // When View-Title is clicked, the data appears sorted by starting weight
    private void mnuViewTitle_Click_1(object sender, EventArgs e)
    {
        clsSortTitle comparer = new clsSortTitle();
        mStaff.Sort(comparer);
        displayData();
    }
    // When View-Email is clicked, the data appears sorted by goal weight
    private void mnuViewEmail_Click(object sender, EventArgs e)
    {
        clsSortEmail comparer = new clsSortEmail();
        mStaff.Sort(comparer);
        displayData();
    }

    // When View-Weeks is clicked, the data appears sorted by weeks to train
    private void mnuViewPhone_Click(object sender, EventArgs e)
    {
        clsSortPhone comparer = new clsSortPhone();
        mStaff.Sort(comparer);
        displayData();

    }

    // Revise the selected items in the two combo boxes when a name is selected.
    private void lstStaff_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedStaff = lstStaff.SelectedIndex - 2;

        // Make sure a valid client was selected.
        if (selectedStaff < 0 || selectedStaff >= mStaff.Count)
        {
            ShowMessage("Please select a valid staff nmember in the listbox.");
            lstStaff.SelectedIndex = -1;
            return;
        }
        // Get the ID of the selected client to fill in the input boxes
        clsStaff temp = (clsStaff)mStaff[selectedStaff];
        txtFirstName.Text = temp.FirstName;
        txtLastName.Text = temp.LastName;
        txtTitle.Text = temp.Title;
        txtEmail.Text = temp.Email;
        txtPhone.Text = temp.Phone;
        txtFax.Text = temp.Fax;
        txtOffice.Text = temp.Office;

        // Notify the user of the possible actions 
        ShowMessage("To delete " + temp.FirstName + " " + temp.LastName + " as a staff member, press the delete key. \n" +
            "To modify " + temp.FirstName + "'s data, edit the data in the input fields and click Update.");
    }

    

}