using Individuellt_arbete.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Individuellt_arbete.Model
{
    public class Service
    {
        ContactDAL _contact;
        public ContactDAL Contact
        {
            get
            {
                return _contact ?? (_contact = new ContactDAL());
            }
        }
        //Add all functions to get all data from database
    }
}