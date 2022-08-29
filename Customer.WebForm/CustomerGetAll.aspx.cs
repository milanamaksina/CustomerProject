﻿using CustomerProject.DAL.BusinessEntities;
using CustomerProject.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Customer.WebForm
{
    public partial class CustomersList : System.Web.UI.Page
    {
        private IRepository<Customers> _customerRepository;
        public List<Customers> Customers { get; set; }
        public CustomersList()
        {
            _customerRepository = new CustomerRepository();
        }
        public CustomersList(IRepository<Customers> customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public void LoadCustomersFromDatabase()
        {
            Customers = _customerRepository.GetAll();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCustomersFromDatabase();
            if (!IsPostBack)
            {
                var customerIDReq = Convert.ToInt32(Request.QueryString["customerID"]);
                _customerRepository.Delete(customerIDReq);
            }

        }
    }
}