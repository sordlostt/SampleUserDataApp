using SampleDataApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SampleDataApp.Models
{
    /// <summary>
    /// Used for Serialization only
    /// </summary>
    [DataContract(Name = "Users", Namespace = "")]
    [KnownType(typeof(User))]
    public class XMLUsers
    {
        [DataMember]
        public List<IUser> Users;

        public XMLUsers()
        {
            if (UsersContainer.GetUsers() == null)
            {
                Users = new List<IUser> { };
            }
            else
            {
                Users = new List<IUser>(UsersContainer.GetUsers());
            }
        }
    }
}
