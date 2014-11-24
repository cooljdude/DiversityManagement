using System;
using System.Windows.Forms;
using System.IO;                     // Kept to use file dialogs
using System.Collections;            // Added to be able to use ArrayLists
using System.Data.OleDb;             // Added to connect to Access DB
using System.Configuration;          // Added to access app.config data

// Name:   CIT255Lab10DBAddByAlkaHarriger
// Author: Alka Harriger
// Date:   11/13/14
//
// This application gets the trainer's clientel data from an Access DB table and stores in an ArrayList. 
// Each client record includes first name, last name, age, height, current weight, goal weight, and number of 
// weeks to achieve the goal. Once read, the summary table of all clients and their data and computed BMI 
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
    private ArrayList mClients = new ArrayList();
    private string mClientFile = "";
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
        lstClients.Items.Clear();
        // erase all the data in the arrays
        mClients.Clear();
        txtName.Focus();
    }

    // This helper method is used to open a connection to the database.
    private void openDatabaseConnection()
    {
        string connectionString =
            ConfigurationManager.AppSettings["DBConnectionString"] + mClientFile;
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
        lstClients.Items.Clear();

        // construct the column headers
        outputLine = "  PROGRAM NAME   " + "                        " + "DATE" + "                  " + "AUDIENCE" + "         " + "ATTENDANCE";
        lstClients.Items.Add(outputLine);
        outputLine = "================" + "                        " + "======" + "               " + "============" + "       " + "==========";
        lstClients.Items.Add(outputLine);

    }

    // This helper method displays the data in the arrays in the listbox.
    private void displayData()
    {
        // Define all variables.
        string outputLine;

        // if there are no clients, display a message
        if (mClients.Count == 0)
        {
            ShowMessage("You either have no programs listed or none were found.");
            txtName.Focus();
            return;
        }

        showHeaders();

        // show the detailed client information
        foreach (clsClients client in mClients)
        {
            outputLine = client.ShowClient();
            lstClients.Items.Add(outputLine);
        }

       

        // display the stats
      
    }

    // When Add is clicked, the input fileds are validated. If all are acceptable and there is room
    // to add clients, the client is added to the next available spot in the arrays.
    private void btnAdd_Click(object sender, EventArgs e)
    {
        // Define all variables.
        int Number;
        string sql;

        // Validate the user's input.
        if (txtName.Text == "")
        {
            ShowMessage("Please enter a program name.");
            txtName.Focus();
            return;
        }
        if (txtDate.Text == "")
        {
            ShowMessage("Please enter a date for the program.");
            txtDate.Focus();
            return;
        }
        if (txtAudience.Text == "")
        {
            ShowMessage("Please enter a target audience for the program.");
            txtDate.Focus();
            return;
        }
        if (validateInput(txtNumber, 0, 1000, out Number) == false)
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
            sql = "INSERT INTO DiversityProgram (NameofProgram, DateofProgram, TargetAudience, NumberinAttendance) VALUES (" +
                clsSQL.ToSql(txtName.Text) + ", " +
                clsSQL.ToSql(txtDate.Text) + ", " +
                clsSQL.ToSql(txtAudience.Text) + ", " +
                clsSQL.ToSql(Number) + ");";
            cmd = new OleDbCommand(sql, mDB);
            cmd.ExecuteNonQuery();

            /*// Lookup ID of client record just added to get ID.
            sql = "SELECT * FROM Clients WHERE FirstName = " + clsSQL.ToSql(txtFirstName.Text) +
                " AND LastName = " + clsSQL.ToSql(txtLastName.Text);
            OleDbDataReader rdr;
            cmd = new OleDbCommand(sql, mDB);
            rdr = cmd.ExecuteReader();
            rdr.Read();
            int clientID = (int)rdr["ID"];
            rdr.Close();

            // Insert record into ClientPlan table.
            sql = "INSERT INTO ClientPlan (ClientID, PlanID) VALUES (" +
                clsSQL.ToSql(clientID) + ", " +
                clsSQL.ToSql(planID) + ")";
            cmd = new OleDbCommand(sql, mDB);
            cmd.ExecuteNonQuery();*/
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
        loadClients("SELECT * FROM DiversityProgram");
        displayData();
    }

    // This helper method erases the input textboxes and positions the cursor in the first textbox.
    private void eraseInputFields()
    {
        txtName.Text = "";
        txtDate.Text = "";
        txtAudience.Text = "";
        txtNumber.Text = "";
        txtName.Focus();
    }

    // Revise the selected items in the two combo boxes when a name is selected.
   /*/ private void lstClients_Click(object sender, EventArgs e)
    {
        ArrayList planID = new ArrayList();
        int selectedClient = lstClients.SelectedIndex - 2;

        // Make sure a valid client was selected.
        if (selectedClient < 0 || selectedClient >= mClients.Count)
        {
            ShowMessage("Please select a valid client in the listbox.");
            lstClients.SelectedIndex = -1;
            return;
        }
        // Get the ID of the selected client to fill in the input boxes
        clsClients temp = (clsClients)mClients[selectedClient];
        txtFirstName.Text = temp.FirstName;
        txtLastName.Text = temp.LastName;
        txtAge.Text = temp.Age.ToString();
        txtHeight.Text = temp.Height.ToString();
        txtCurrentWeight.Text = temp.StartWeight.ToString();
        txtGoalWeight.Text = temp.GoalWeight.ToString();
        txtTotalWeeks.Text = temp.Weeks.ToString();

        // Search for the matching plan of the selected client
        string sql = "SELECT * FROM ClientPlan WHERE ClientID=" + clsSQL.ToSql(temp.ID);
        try
        {
            openDatabaseConnection();
            mDB.Open();
            OleDbCommand cmd = new OleDbCommand(sql, mDB);
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read() == true)
            {
                planID.Add(rdr["PlanID"]);
            }
            rdr.Close();
        }
        catch (Exception ex)
        {
            ShowMessage("There was an unexpected problem when adding the client: " + ex.Message + ex.StackTrace);
        }
        finally
        {
            closeDatabaseConnection();
        }

        // Rebuild the trainer and exercise combo boxes, selecting one plan/trainer for the client.
        buildExerciseCombo();
        buildTrainerCombo();
        for (int i = 0; i < cboExercisePlan.Items.Count; i++)
        {
            clsComboBoxItem item = (clsComboBoxItem)cboExercisePlan.Items[i];
            if (planID.Contains(item.Value))
            {
                cboExercisePlan.SelectedIndex = i;
                break;
            }
        }
        // Make sure no trainer is selected.
        cboTrainer.SelectedIndex = -1;

        // Notify the user of the possible actions 
        ShowMessage("To delete " + temp.FirstName + " " + temp.LastName + " as a client, press the delete key. \n" +
            "To modify " + temp.FirstName + "'s data, edit the data in the input fields, select a trainer, select an exercise plan, and click Update.");
    }/*/

    // This method removes the selected client from the roster
    private void btnDelete_Click(object sender, EventArgs e)
    {
        string sql;
        int selectedClient = lstClients.SelectedIndex - 2;

        // Make sure a valid client was selected.
        if (selectedClient < 0 || selectedClient >= mClients.Count)
        {
            ShowMessage("Please select a valid program in the listbox.");
            lstClients.SelectedIndex = -1;
            return;
        }

        // Get the ID of the selected client to fill in the input boxes
        clsClients temp = (clsClients)mClients[selectedClient];

        // Delete the selected client and remove the corresponding record in the ClientPlan table
        try
        {
            openDatabaseConnection();
            mDB.Open();
            OleDbCommand cmd;
            sql = "DELETE FROM DiversityProgram WHERE NameofProgram = " + clsSQL.ToSql(temp.NameofProgram);
            cmd = new OleDbCommand(sql, mDB);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            ShowMessage("There was an unexpected problem when deleting the program: " + ex.Message);
        }
        finally
        {
            closeDatabaseConnection();
        }

        // Erase the input values, notify the user, and display the current client roster
        eraseInputFields();
        ShowMessage(temp.NameofProgram + " has been deleted.");
        loadClients("SELECT * FROM DiversityProgram");
        displayData();


    }

    // When the Update button is clicked, the user is able to modify the data
    // for the selected client.
    private void btnUpdate_Click(object sender, EventArgs e)
    {
        // Define all variables.
        // Define all variables.
        int Number;
        string sql;
        

        int selectedClient = lstClients.SelectedIndex - 2;

        // Make sure a valid client was selected.
        if (selectedClient < 0 || selectedClient >= mClients.Count)
        {
            ShowMessage("Please select a valid program in the listbox.");
            lstClients.SelectedIndex = -1;
            return;
        }

        // Get the ID of the selected client to fill in the input boxes
        clsClients temp = (clsClients)mClients[selectedClient];

        // Validate the user's input.
        if (txtName.Text == "")
        {
            ShowMessage("Please enter a program name.");
            txtName.Focus();
            return;
        }
        if (txtDate.Text == "")
        {
            ShowMessage("Please enter a date for the program.");
            txtDate.Focus();
            return;
        }
        if (txtAudience.Text == "")
        {
            ShowMessage("Please enter a target audience for the program.");
            txtDate.Focus();
            return;
        }
        if (validateInput(txtNumber, 0, 1000, out Number) == false)
        {
            return;
        }
        

        // Data is valid so modify the client and reload the data from the DB
        try
        {
            // Change a record in the Clients table.
            openDatabaseConnection();
            mDB.Open();
            OleDbCommand cmd;
            sql = "UPDATE DiversityProgram SET NameofProgram = " + clsSQL.ToSql(txtName.Text) + 
                ", DateofProgram = " + clsSQL.ToSql(txtDate.Text) + 
                ", TargetAudience = " + clsSQL.ToSql(txtAudience.Text) + 
                ", NumberinAttendance = " + clsSQL.ToSql(txtNumber.Text) +
                " WHERE NameofProgram = " + clsSQL.ToSql(temp.NameofProgram);
            cmd = new OleDbCommand(sql, mDB);
            cmd.ExecuteNonQuery();

            // If the client-plan already exists, ignore. Otherwise, add it.

           // sql = "SELECT * FROM  ClientPlan WHERE ClientID = " + clsSQL.ToSql(temp.ID) + " AND PlanID = " + clsSQL.ToSql(planID);
            //cmd = new OleDbCommand(sql, mDB);
           // OleDbDataReader rdr = cmd.ExecuteReader();
            //if (rdr.Read() == true) // no need to add a record
           // {
           //     rdr.Close();
           // }
          //  else // need to add the record
           // {
            //    rdr.Close();
              //  sql = "INSERT INTO ClientPlan (ClientID, PlanID) VALUES (" +
             //       clsSQL.ToSql(temp.ID) + ", " +
            //        clsSQL.ToSql(planID) + ")";
           //     cmd = new OleDbCommand(sql, mDB);
           //     cmd.ExecuteNonQuery();
           // }

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
        ShowMessage(temp.NameofProgram + " has been updated.");
        loadClients("SELECT * FROM DiversityProgram");
        displayData();

    }

    // When File-Open is clicked, the user is able to select the client file to open.
    private void mnuFileOpen_Click(object sender, EventArgs e)
    {
        OpenFileDialog ofd = new OpenFileDialog();
        ofd.Title = "Select Client DB file to open";
        ofd.Filter = "Client (*.accdb)|*.accdb|All files (*.*)|*.*";
        ofd.InitialDirectory = Path.Combine(Application.StartupPath, @"Databases");

        if (ofd.ShowDialog() == DialogResult.OK)
        {
            // Assign the filename
            mClientFile = ofd.FileName;
        }
        loadClients("SELECT * FROM DiversityProgram");

        // Build the combo boxes
       

        displayData();
    }

    // The loadClients helper method reads the data from the specified file and copies
    // to the client array.
    private void loadClients(string sql)
    {
        clsClients client;
        // Clear out the array before handling the file data.
        mClients.Clear();

        // Read the data from the specified file.

        if (File.Exists(mClientFile) == false)
        {
            ShowMessage(mClientFile + " does not exist. Please open another DB file.");
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
                client = new clsClients( 
                    (string)rdr["NameofProgram"],
                    (string)rdr["DateofProgram"],
                    (string)rdr["TargetAudience"],
                    (int)rdr["NumberinAttendance"]);
                mClients.Add(client);
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

    // The buildTrainerCombo helper method reads the data from the Trainers DB table and copies
    /*/ the available trainers to the appropriate combo box.
    private void buildTrainerCombo()
    {
        string sql;
        int selectedPlan = cboExercisePlan.SelectedIndex;
        if (selectedPlan >= 0)
        {
            sql = "SELECT DISTINCT Trainers.ID, FirstName, LastName FROM Trainers, TrainerPlan " +
                "WHERE Trainers.ID=TrainerPlan.TrainerID AND TrainerPlan.PlanID=" + clsSQL.ToSql(selectedPlan) + 
                " ORDER BY LastName, FirstName";
        }
        else
        {
            sql = "SELECT * FROM Trainers ORDER BY LastName, FirstName";
        }
        
        // Clear out the combo box first
        cboTrainer.Items.Clear();

        // Read the data from the specified file.

        if (File.Exists(mClientFile) == false)
        {
            ShowMessage(mClientFile + " does not exist. Please open another DB file.");
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
                // Add the data from the line just read to the next array element.
                clsComboBoxItem item = new clsComboBoxItem();
                item.Text = (string)rdr["FirstName"] + " " + (string)rdr["LastName"];
                item.Value = (int)rdr["ID"];
                cboTrainer.Items.Add(item);
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

    // The buildExerciseCombo helper method reads the data from the FitnessPlans DB table and copies
    // the available plans to the appropriate combo box.
    private void buildExerciseCombo()
    {
        string sql;

        // If a trainer was selected, show only the plans for that trainer.
        if (cboTrainer.SelectedIndex >= 0)
        {
            clsComboBoxItem trainer = (clsComboBoxItem) cboTrainer.SelectedItem;
            int trainerID = (int)trainer.Value;
            sql = "SELECT DISTINCT FitnessPlans.ID, PlanName, ActivityTime FROM TrainerPlan, FitnessPlans WHERE " +
                "TrainerPlan.TrainerID = " + clsSQL.ToSql(trainerID) + " AND PlanID = FitnessPlans.ID ORDER BY PlanName";
        }
        else
        {
            sql = "SELECT * FROM FitnessPlans ORDER BY PlanName";
        }

        // Clear out the combo box first
        cboExercisePlan.Items.Clear();

        // Read the data from the specified file.

        if (File.Exists(mClientFile) == false)
        {
            ShowMessage(mClientFile + " does not exist. Please open another DB file.");
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
                // Add the data from the line just read to the next array element.
                clsComboBoxItem item = new clsComboBoxItem();
                item.Text = (string)rdr["PlanName"];
                item.Value = (int)rdr["ID"];
                cboExercisePlan.Items.Add(item);
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
    }/*/

    // Search for the selected client.
    private void btnFind_Click(object sender, EventArgs e)
    {
        // Validate the user's input.
        if (txtName.Text == "")
        {
            ShowMessage("Please enter the name of the program to perform a search.");
            txtName.Focus();
            return;
        }

        // If both first and last names are given, sort the names and then do a binary search.
        if (txtName.Text != "") 
        {
            loadClients("SELECT * FROM DiversityProgram WHERE NameofProgram LIKE '%" + txtName.Text + "%';");
            displayData();
        }
       // else if (txtLastName.Text != "")
      //  {
       //     loadClients("SELECT * FROM Clients WHERE LastName=" + clsSQL.ToSql(txtLastName.Text));
      //      displayData();
      //  }
       // else if (txtFirstName.Text != "")
      //  {
       //     loadClients("SELECT * FROM Clients WHERE FirstName=" + clsSQL.ToSql(txtFirstName.Text));
      //      displayData();
       // }
      //  else // search is for weeks
       // {
        //    loadClients("SELECT * FROM Clients WHERE Weeks=" + clsSQL.ToSql(int.Parse(txtTotalWeeks.Text)));
      //      displayData();
        //}

    }

    // Terminate the program when File-Exit is selected.
    private void mnuFileExit_Click(object sender, EventArgs e)
    {
        Close();
    }

    // Build the appropriate exercises for the selected trainer.
    private void cboTrainer_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }

    // When View-Lastname is clicked, the data appears sorted by lastname
  //  private void mnuViewLastName_Click(object sender, EventArgs e)
 //   {
     //   clsSortLName comparer = new clsSortLName();
     //   mClients.Sort(comparer);
     //   displayData();
  //  }

    // When View-Firstname is clicked, the data appears sorted by firstname
  //  private void mnuViewFirstName_Click(object sender, EventArgs e)
  //  {
  //      clsSortFName comparer = new clsSortFName();
  //      mClients.Sort(comparer);
 //       displayData();
 //   }

    // When View-StartWeight is clicked, the data appears sorted by starting weight
  //  private void mnuViewStartWeight_Click(object sender, EventArgs e)
   // {
   //     clsSortStartWeight comparer = new clsSortStartWeight();
   //     mClients.Sort(comparer);
   //     displayData();
   // }

    // When View-GoalWeight is clicked, the data appears sorted by goal weight
   // private void mnuViewGoalWeight_Click(object sender, EventArgs e)
    //{
   //     clsSortGoalWeight comparer = new clsSortGoalWeight();
   //     mClients.Sort(comparer);
   //     displayData();
   // }

    // When View-Weeks is clicked, the data appears sorted by weeks to train
   // private void mnuViewWeeks_Click(object sender, EventArgs e)
  //  {
    //    clsSortWeeks comparer = new clsSortWeeks();
    //    mClients.Sort(comparer);
   //     displayData();

   // }

    private void frmMain_Load(object sender, EventArgs e)
    {

    }

    private void btnShow_Click(object sender, EventArgs e)
    {
        eraseInputFields();
        loadClients("SELECT * FROM DiversityProgram");
        displayData();
    }

}