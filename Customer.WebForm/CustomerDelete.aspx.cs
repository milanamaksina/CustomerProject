using CustomerProject.DAL.Repositories;
using System;
using CustomerProject.DAL.BusinessEntities;

namespace CustomerWebForm
{
    public partial class CustomerDelete : System.Web.UI.Page
    {
        
        private IRepository<Customer> _customerRepository;
        public CustomerDelete()
        {
            _customerRepository = new CustomerRepository();
        }
        public CustomerDelete(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var customerIDReq = Convert.ToInt32(Request.QueryString["customerID"]);
            _customerRepository.Delete(customerIDReq);
            Response.Redirect("CustomersList.aspx");
        }
    }
}