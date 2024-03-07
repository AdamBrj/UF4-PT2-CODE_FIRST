using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Converters;
using System.Xml.Serialization;
using UF4_PT2_CODE_FIRST.MODEL;

namespace UF4_PT2_CODE_FIRST.DAO
{
    public interface IDAOManager
    {
        public void AddCustomers();
        public void AddEmployees();
        public void AddOffices();
        public void AddOrdersDetails();
        public void AddOrders();
        public void AddPayments();
        public void AddProductLines();
        public void AddProducts();

        public void GetCustomers();
        public void GetProducts();
        public void GetCustomersWithCreditGreaterThan5000();
        public Task GetEmployeesWithCustomers();
        public void GetProductsWithOrderDetails();
        public Task GetTotalProductsByProductLine();
        public Task GetTotalOrdersByCustomer();
        public Task GetProductLinesWithProducts();
        public Task GetOrdersWithOrderDetails();
        public Task GetTopProducts();
        public Task GetTopEmployees();




    }
}
