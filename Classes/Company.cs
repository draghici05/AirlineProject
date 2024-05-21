using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineProject.Classes
{
    [Serializable]
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public string Email { get; set; }
        public List<Booking> Bookings { get; set; }
        public Company() 
        {
            CompanyId = 1;
            Bookings = new List<Booking>();
        }
        public Company(int companyId, string companyName, string companyNumber, string email) : this()
        {
            CompanyId = companyId;
            CompanyName = companyName;
            CompanyNumber = companyNumber;
            Email = email;
        }

        /* public Route GetRoute(int routeId)
        {
            return Routes.Find(route => route.RouteId == routeId);
        }
        public void AddRoute(Route route)
        {
            Routes.Add(route);
        }
        public void RemoveRoute(int routeId)
        {
            Routes.RemoveAll(route => route.RouteId == routeId);
        } */
    }
}
