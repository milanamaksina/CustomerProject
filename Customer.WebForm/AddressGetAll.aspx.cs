using CustomerProject.DAL.BusinessEntities;
using CustomerProject.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace Customer.WebForm
{
    public partial class AddressesList : System.Web.UI.Page
    {
        private readonly IRepository<Address> _addressRepository;
        public List<Address> Addresses { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAddressesFromDatabase();
        }
        public AddressesList()
        {
            _addressRepository = new AddressRepository();
        }
        public AddressesList(IRepository<Address> addressesRepository)
        {
            _addressRepository = addressesRepository;
        }
        public void LoadAddressesFromDatabase()
        {
            Addresses = _addressRepository.GetAll();
        }

    }
}