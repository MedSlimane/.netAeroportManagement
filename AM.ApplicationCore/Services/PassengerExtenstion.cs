using AM.ApplicationDomain.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.Application.Core.Services
{

    public static class PassengerExtenstion
    {
        public static void UpperFullName(this Passenger p)
        {
            p.FirstName = p.FirstName[0]
                .ToString()
                .ToUpper()
                + p.FirstName.Substring(1);
            p.LastName = p.LastName[0]
                .ToString()
                .ToUpper()
                + p.LastName.Substring(1);
        }
    }
}
