using CustomerProject.DAL.BusinessEntities;
using CustomerProject.DAL.Repositories;
using System;

namespace Customer.WebForm
{
    public partial class AddressDelete : System.Web.UI.Page
    {
        public IRepository<Address> _addressRepository;
        public AddressDelete()
        {
            _addressRepository = new AddressRepository();
        }
        public AddressDelete(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var addressIDReq = Convert.ToInt32(Request.QueryString["addressID"]);
            _addressRepository.Delete(addressIDReq);
            Response.Redirect("AddressesList.aspx");
        }
    }
}