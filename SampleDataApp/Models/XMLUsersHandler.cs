using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XMLLogicLibrary;

namespace SampleDataApp.Models
{
    /// <summary>
    /// A class that wraps all the deserializtion work of the ViewModel, so that the VM doesn't have to instantiate concrete types.
    /// </summary>
    public static class XMLUsersHandler
    {
        public static List<IUser> ReturnDeserializedUsers()
        {
            XMLUsers deserializedUsers = XMLDataSerializer.DeserializeUsers(new XMLUsers()) as XMLUsers;
            if (deserializedUsers.Users == null)
            {
                return new List<IUser> { };
            }
            else
            {
                return deserializedUsers.Users;
            }
        }
    }
}
