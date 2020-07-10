using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_WEB_API_FOR_CRUD_OPERATION.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}