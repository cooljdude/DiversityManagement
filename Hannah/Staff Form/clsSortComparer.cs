using System;
using System.Collections;
public class clsSortLFName : IComparer
{
    int IComparer.Compare(object object1, object object2)
    {
        clsStaff staff1 = (clsStaff)object1;
        clsStaff staff2 = (clsStaff)object2;
        string client1Name = staff1.LastName + staff1.FirstName;
        string client2Name = staff2.LastName + staff2.FirstName;
        return client1Name.CompareTo(client2Name);
    }
}

public class clsSortLName : IComparer
{
    int IComparer.Compare(object object1, object object2)
    {
        clsStaff staff1 = (clsStaff)object1;
        clsStaff staff2 = (clsStaff)object2;
        return staff1.LastName.CompareTo(staff2.LastName);
    }
}

public class clsSortFName : IComparer
{
    int IComparer.Compare(object object1, object object2)
    {
        clsStaff staff1 = (clsStaff)object1;
        clsStaff staff2 = (clsStaff)object2;
        return staff1.FirstName.CompareTo(staff2.FirstName);
    }
}

public class clsSortTitle : IComparer 
{
    int IComparer.Compare(object object1, object object2)
    {
        clsStaff staff1 = (clsStaff)object1;
        clsStaff staff2 = (clsStaff)object2;
        return staff2.Title.CompareTo(staff1.Title);
    }
}

public class clsSortEmail : IComparer  
{
    int IComparer.Compare(object object1, object object2)
    {
        clsStaff staff1 = (clsStaff)object1;
        clsStaff staff2 = (clsStaff)object2;
        return -(staff1.Email.CompareTo(staff2.Email));
    }
}

public class clsSortPhone : IComparer
{
    int IComparer.Compare(object object1, object object2)
    {
        clsStaff staff1 = (clsStaff)object1;
        clsStaff staff2 = (clsStaff)object2;
        return staff1.Phone.CompareTo(staff2.Phone);
    }
}
