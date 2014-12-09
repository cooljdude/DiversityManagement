using System;
using teamProject;

namespace teamProject
{
    class clsStaff
    {
        // List of the class data members.

        private int mStaffID;
        private string mLName;
        private string mFName;
        private string mTitle;
        private string mEmail;
        private string mPhone;
        private string mFax;
        private string mOffice;

        // ----------- Class constructors ----------------

        public clsStaff()
        {
            mLName = "";
            mFName = "";
            mTitle = "";
            mEmail = "";
            mPhone = "";
            mFax = "";
            mOffice = "";
        }

        public clsStaff(string myLName, string myFName, string myTitle, string myEmail, string myPhone, string myFax, string myOffice)
        {
            mLName = myLName;
            mFName = myFName;
            mTitle = myTitle;
            mEmail = myEmail;
            mPhone = myPhone;
            mFax = myFax;
            mOffice = myOffice;
        }

        public clsStaff(int staffID, string myLName, string myFName, string myTitle, string myEmail, string myPhone, string myFax, string myOffice)
        {
            mStaffID = staffID;
            mLName = myLName;
            mFName = myFName;
            mTitle = myTitle;
            mEmail = myEmail;
            mPhone = myPhone;
            mFax = myFax;
            mOffice = myOffice;
        }

        // ----------- Accessor methods for data members ----------------

        // Purpose: Reads or writes the mName data member.
        public int StaffID
        {
            get
            {
                return mStaffID;
            }
            set
            {
                mStaffID = value;
            }
        }

        public string LastName
        {
            get
            {
                return mLName;
            }

            set
            {
                mLName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return mFName;
            }

            set
            {
                mFName = value;
            }
        }

        public string Title
        {
            get
            {
                return mTitle;
            }

            set
            {
                mTitle = value;
            }
        }

        public string Email
        {
            get
            {
                return mEmail;
            }

            set
            {
                mEmail = value;
            }
        }

        public string Phone
        {
            get
            {
                return mPhone;
            }

            set
            {
                mPhone = value;
            }
        }

        public string Fax
        {
            get
            {
                return mFax;
            }

            set
            {
                mFax = value;
            }
        }

        public string Office
        {
            get
            {
                return mOffice;
            }

            set
            {
                mOffice = value;
            }
        }
        // ----------- End Accessor methods for data members ------------

        // Purpose: Construct a line of output for this staff member.
        public string ShowStaff()
        {
            string outputLine;
            string staffName = mFName + " " + mLName;

            // Construct the output line.
            outputLine = staffName.PadRight(30) + "  " +
                mTitle.PadLeft(50) + "  " +
                mEmail.PadLeft(30) + "  " +
                mPhone.PadLeft(13) + "  " +
                mFax.PadLeft(13) + "  " +
                mOffice.PadLeft(20);
            return outputLine;
        }
    }
}
