using System;


namespace teamProject
{
    class clsSchool
    {
        // List of the class data members.

        private int mSchoolID;
        private string mSchoolName;
        private string mAddress;
        private string mCity;
        private string mState;
        private string mContactName;
        private string mPhone;

        // ----------- Class constructors ----------------

        public clsSchool()
        {
            mSchoolName = "";
            mAddress = "";
            mCity = "";
            mState = "";
            mContactName = "";
            mPhone = "";
        }

        public clsSchool(string mySchoolName, string myAddress, string myCity, string myState, string myContactName, string myPhone)
        {
            mSchoolName = mySchoolName;
            mAddress = myAddress;
            mCity = myCity;
            mState = myState;
            mContactName = myContactName;
            mPhone = myPhone;
        }

        public clsSchool(int mySchoolID, string mySchoolName, string myAddress, string myCity, string myState, string myContactName, string myPhone)
        {
            mSchoolID = mySchoolID;
            mSchoolName = mySchoolName;
            mAddress = myAddress;
            mCity = myCity;
            mState = myState;
            mContactName = myContactName;
            mPhone = myPhone;
        }

        // ----------- Accessor methods for data members ----------------

        // Purpose: Reads or writes the mName data member.
        public int SchoolID
        {
            get
            {
                return mSchoolID;
            }
            set
            {
                mSchoolID = value;
            }
        }

        public string SchoolName
        {
            get
            {
                return mSchoolName;
            }

            set
            {
                mSchoolName = value;
            }
        }

        public string Address
        {
            get
            {
                return mAddress;
            }

            set
            {
                mAddress = value;
            }
        }

        public string City
        {
            get
            {
                return mCity;
            }

            set
            {
                mCity = value;
            }
        }

        public string State
        {
            get
            {
                return mState;
            }

            set
            {
                mState = value;
            }
        }

        public string ContactName
        {
            get
            {
                return mContactName;
            }

            set
            {
                mContactName = value;
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

        // ----------- End Accessor methods for data members ------------

        // We need a way to display the school information.
        public string dispSchool()
        {
            string outputLine;

            // ...Which we do here.
            outputLine = mSchoolName.PadRight(20) + "  " +
                mAddress.PadLeft(20) + "  " +
                mCity.PadLeft(10) + "  " +
                mState.PadLeft(13) + "  " +
                mContactName.PadLeft(13) + "  " +
                mPhone.PadLeft(10);
            return outputLine;
        }
    }
}
