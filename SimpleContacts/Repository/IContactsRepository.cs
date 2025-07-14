using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleContacts.Repository
{
    internal interface IContactsRepository
    {
        DataTable SelectAll();
        DataTable SelectRow(int ContactID);
        DataTable Search(string Parameter);
        bool InsertContacts(string name, string family,string
            mobile , string email , int age , string address);
        bool UpdateContacts(int contactID,string name, string family, string
    mobile, string email, int age, string address);

        bool DeleteContacts(int contactID);


    }
}
