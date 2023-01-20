using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.SharedKernal.Shared.Enums
{
    public enum Roles
    {
        Admin = 1,
        /// <summary>
        /// Customer might be Resturant, House, or person
        /// </summary>
        Customer = 2,
        /// <summary>
        /// Delivery is the responsible for accepting the request and transporting 
        /// Trash to Factories or what so ever
        /// </summary>
        Delivery = 3,
        /// <summary>
        /// Reciever is the Factory that would process the Nufaia
        /// </summary>
        Reciever = 4
    }
}
