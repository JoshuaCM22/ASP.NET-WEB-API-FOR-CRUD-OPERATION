using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ASP.NET_WEB_API_FOR_CRUD_OPERATION.Models;

namespace ASP.NET_WEB_API_FOR_CRUD_OPERATION.Controllers
{
    public class CustomerController : ApiController
    {
        // GET - Retrieve all data
        public IHttpActionResult GetAllCustomer()
        {
            IList<CustomerViewModel> customers = null;
            using (var x = new ASP.NET_WEB_API_FOR_CRUD_OPERATION.DBEntities())
            {
                customers = x.Customers
                        .Select(c => new CustomerViewModel()
                        {
                            Id = c.id,
                            Name = c.name,
                            Email = c.email,
                            Address = c.address,
                            Phone = c.phone
                        }).ToList<CustomerViewModel>();
            }
            if (customers.Count == 0)
                return NotFound();
            return Ok(customers);
        }

        // GET - Retrieve specific data
        public IHttpActionResult GetCustomer(int id)
        {
            using (var x = new ASP.NET_WEB_API_FOR_CRUD_OPERATION.DBEntities())
            {
                var customer = x.Customers
                   .Where(c => c.id == id)
                        .Select(c => new CustomerViewModel()
                        {
                            Id = c.id,
                            Name = c.name,
                            Email = c.email,
                            Address = c.address,
                            Phone = c.phone
                        }).ToList<CustomerViewModel>();
                if (customer.Count == 0)
                    return NotFound();
                return Ok(customer);
            }
        }

        // POST - Insert new data
        public IHttpActionResult PostNewCustomer(CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data. Please recheck!");
            using (var x = new DBEntities())
            {
                x.Customers.Add(new Customer()
                {
                    name = customer.Name,
                    email = customer.Email,
                    address = customer.Address,
                    phone = customer.Phone
                });
                x.SaveChanges();
            }
            return Ok();
        }
        // PUT - Update a data using id
        public IHttpActionResult PutCustomer(CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data. Please recheck!");
            using (var x = new DBEntities())
            {
                var checkExistingCustomer = x.Customers.Where(c => c.id == customer.Id)
                                            .FirstOrDefault<Customer>();

                if (checkExistingCustomer != null)
                {
                    checkExistingCustomer.name = customer.Name;
                    checkExistingCustomer.address = customer.Address;
                    checkExistingCustomer.phone = customer.Phone;
                    x.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
                return Ok();
            }
        }

        // DELETE - Delete a data using id
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Please enter valid Customer Id");
            using (var x = new DBEntities())
            {
                var customer = x.Customers
                    .Where(c => c.id == id)
                    .FirstOrDefault();
                x.Entry(customer).State = System.Data.Entity.EntityState.Deleted;
                x.SaveChanges();
            }
            return Ok();
        }

    }
}