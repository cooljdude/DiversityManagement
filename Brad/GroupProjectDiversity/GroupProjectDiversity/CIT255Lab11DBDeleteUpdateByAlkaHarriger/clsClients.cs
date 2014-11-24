using System;

public class clsClients
{
    // List of the class data members.

    private string mNameOfProgram;
    private string mDateOfProgram;
    private string mTargetAudience;
    private int mNumberInAttendance;

    

    // ----------- Class constructors ----------------

    public clsClients()
    {
        mNameOfProgram = "";
        mDateOfProgram = "";
        mTargetAudience = "";
        mNumberInAttendance = 0;
        
    }

    public clsClients(string myName, string myDate, string myTarget, int myNumber)
    {
        mNameOfProgram = myName;
        mDateOfProgram = myDate;
        mTargetAudience = myTarget;
        mNumberInAttendance = myNumber;
    }

 

    // ----------- Accessor methods for data members ----------------

    // Purpose: Reads or writes the mName data member.
    public string NameofProgram
    {
        get
        {
            return mNameOfProgram;
        }
        set
        {
            mNameOfProgram = value;
        }
    }

    public string DateofProgram
    {
        get
        {
            return mDateOfProgram;
        }

        set
        {
            mDateOfProgram = value;
        }
    }

    public string TargetAudience
    {
        get
        {
            return mTargetAudience;
        }

        set
        {
            mTargetAudience = value;
        }
    }

    public int NumberinAttendance
    {
        get
        {
            return mNumberInAttendance;
        }

        set
        {
            mNumberInAttendance = value;
        }
    }

    

    // ----------- End Accessor methods for data members ------------

    // Purpose: Construct a line of output for this client.
    public string ShowClient()
    {
        string outputLine;

        // Construct the output line.
        outputLine = mNameOfProgram.PadRight(30) + "  " +
            mDateOfProgram.PadLeft(15) + "    " +
            mTargetAudience.PadLeft(25) + "      " +
            mNumberInAttendance.ToString().PadLeft(5);
        return outputLine;
    }

    // The calcBMI helper method computes and returns the BMI value, given height in inches and weight in 
    // pounds.
    public double calcBMI(double hgt, double wgt)
    {
        const int BMI_Factor = 703;
        return (wgt / (hgt * hgt)) * BMI_Factor;
    }


}