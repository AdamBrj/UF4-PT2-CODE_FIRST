using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UF4_PT2_CODE_FIRST.MODEL;
using static UF4_PT2_CODE_FIRST.MainWindow;

namespace UF4_PT2_CODE_FIRST.DAO
{
    public class DAOManager : IDAOManager
    {
        private MyDbContext context;
        private MainWindow mainWindow;

        private const string CUSTOMERS_FILENAME = "./CUSTOMERS.csv";
        private const string EMPLOYEES_FILENAME = "./EMPLOYEES.csv";
        private const string OFFICES_FILENAME = "./OFFICES.csv";
        private const string ORDER_DETAILS_FILENAME = "./ORDERDETAILS.csv";
        private const string ORDERS_FILENAME = "./ORDERS.csv";
        private const string PAYMENTS_FILENAME = "./PAYMENTS.csv";
        private const string PRODUCT_LINES_FILENAME = "./PRODUCTLINES.csv";
        private const string PRODUCTS_FILENAME = "./PRODUCTS.csv";

        public DAOManager(MyDbContext context)
        {
            this.context = context;
        }

        public DAOManager(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            context = new MyDbContext();
        }

        #region AddData
        public void AddCustomers()
        {
            try
            {
                using (TextFieldParser parser = new TextFieldParser(CUSTOMERS_FILENAME))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] fields = parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        fields = parser.ReadFields();

                        var customer = new Customer
                        {
                            CustomerNumber = Convert.ToInt32(fields[0]),
                            CustomerName = fields[1],
                            ContactLastName = fields[2],
                            ContactFirstName = fields[3],
                            Phone = fields[4],
                            AddressLine1 = fields[5],
                            AddressLine2 = fields[6],
                            City = fields[7],
                            State = fields[8],
                            PostalCode = fields[9],
                            Country = fields[10],
                            SalesRepEmployeeNumber = fields[11].ToLower().Equals("null") ? null : Convert.ToInt32(fields[11]),
                            CreditLimit = fields[12].ToLower().Equals("null") ? null : Convert.ToDecimal(fields[12])
                        };
                        context.Customers.Add(customer);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void AddEmployees()
        {
            try
            {
                using (TextFieldParser parser = new TextFieldParser(EMPLOYEES_FILENAME))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] fields = parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        fields = parser.ReadFields();

                        var employee = new Employee
                        {
                            EmployeeNumber = Convert.ToInt32(fields[0]),
                            LastName = fields[1],
                            FirstName = fields[2],
                            Extension = fields[3],
                            Email = fields[4],
                            OfficeCode = fields[5],
                            ReportsTo = fields[6].ToLower().Equals("null") ? null : Convert.ToInt32(fields[6]),
                            JobTitle = fields[7]
                        };
                        context.Employees.Add(employee);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddOffices()
        {
            try
            {
                using (TextFieldParser parser = new TextFieldParser(OFFICES_FILENAME))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] fields = parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        fields = parser.ReadFields();

                        var office = new Office
                        {
                            OfficeCode = fields[0],
                            City = fields[1],
                            Phone = fields[2],
                            AddressLine1 = fields[3],
                            AddressLine2 = fields[4],
                            State = fields[5],
                            Country = fields[6],
                            PostalCode = fields[7],
                            Territory = fields[8]
                        };
                        context.Offices.Add(office);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddOrdersDetails()
        {
            try
            {
                using (TextFieldParser parser = new TextFieldParser(ORDER_DETAILS_FILENAME))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] fields = parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        fields = parser.ReadFields();

                        var orderDetail = new OrderDetail
                        {
                            OrderNumber = Convert.ToInt32(fields[0]),
                            ProductCode = fields[1],
                            QuantityOrdered = Convert.ToInt32(fields[2]),
                            PriceEach = Convert.ToDecimal(fields[3]),
                            OrderLineNumber = Convert.ToInt16(fields[4])
                        };
                        context.OrderDetails.Add(orderDetail);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddOrders()
        {
            try
            {
                using (TextFieldParser parser = new TextFieldParser(ORDERS_FILENAME))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] fields = parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        fields = parser.ReadFields();
                        DateTime orderDate, requiredDate, shippedDate;
                        DateTime.TryParse(fields[1], out orderDate);
                        DateTime.TryParse(fields[2], out requiredDate);
                        DateTime.TryParse(fields[3], out shippedDate);
                        var order = new Orders
                        {
                            OrderNumber = Convert.ToInt32(fields[0]),
                            OrderDate = orderDate,
                            RequiredDate = requiredDate,
                            ShippedDate = shippedDate,
                            Status = fields[4],
                            Comments = fields[5],
                            CustomerNumberId = fields[6].ToLower().Equals("null") ? null : Convert.ToInt32(fields[6])
                        };
                        context.Orders.Add(order);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddPayments()
        {
            try
            {
                using (TextFieldParser parser = new TextFieldParser(PAYMENTS_FILENAME))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] fields = parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        fields = parser.ReadFields();

                        var payment = new Payment
                        {
                            CustomerNumber = Convert.ToInt32(fields[0]),
                            CheckNumber = fields[1],
                            PaymentDate = Convert.ToDateTime(fields[2]),
                            Amount = Convert.ToDecimal(fields[3])
                        };
                        context.Payments.Add(payment);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddProductLines()
        {
            try
            {
                using (TextFieldParser parser = new TextFieldParser(PRODUCT_LINES_FILENAME))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;
                    string[] fields = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        fields = parser.ReadFields();

                        var productLine = new ProductLine()
                        {
                            ProductLines = fields[0],
                            TextDescription = fields[1],
                            HtmlDescription = fields[2],
                            Image = Convert.FromBase64String(fields[3])
                        };

                        context.ProductLines.Add(productLine);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void AddProducts()
        {
            try
            {
                using (TextFieldParser parser = new TextFieldParser(PRODUCTS_FILENAME))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] fields = parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        fields = parser.ReadFields();

                        var product = new Product
                        {
                            ProductCode = fields[0],
                            ProductName = fields[1],
                            ProductLineId = fields[2],
                            ProductScale = fields[3],
                            ProductVendor = fields[4],
                            ProductDescription = fields[5],
                            QuantityInStock = Convert.ToInt16(fields[6]),
                            BuyPrice = Convert.ToDecimal(fields[7]),
                            MSRP = Convert.ToDecimal(fields[8])
                        };
                        context.Products.Add(product);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Functions queries
        public List<T> ExecuteQuerySet<T>(string query) where T : class
        {
            using (var context = new MyDbContext())
            {
                return context.Set<T>().FromSqlRaw(query).ToList();
            }
        }

        public async Task<List<T>> ExecuteQuery<T>(string query) where T : class, new()
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                await context.Database.OpenConnectionAsync();

                using (var result = await command.ExecuteReaderAsync())
                {
                    var entities = new List<T>();

                    while (await result.ReadAsync())
                    {
                        var entity = new T();
                        var props = typeof(T).GetProperties();

                        foreach (var prop in props)
                        {
                            if (!Equals(result[prop.Name], DBNull.Value))
                            {
                                prop.SetValue(entity, result[prop.Name]);
                            }
                        }

                        entities.Add(entity);
                    }

                    return entities;
                }
            }
        }

        #endregion


        #region Queries

        public void GetCustomers()
        {
            var customers = ExecuteQuerySet<Customer>("SELECT * FROM Customers");
            mainWindow.dataGrid.ItemsSource = customers;
        }

        public void GetProducts()
        {
            var products = ExecuteQuerySet<Product>("SELECT * FROM Products");
            mainWindow.dataGrid.ItemsSource = products;
        }

        public void GetCustomersWithCreditGreaterThan5000()
        {
            var filteredCustomers = ExecuteQuerySet<Customer>("SELECT * FROM Customers WHERE CreditLimit > 5000 ORDER BY CustomerName");
            mainWindow.dataGrid.ItemsSource = filteredCustomers;
        }

        public async Task GetEmployeesWithCustomers()
        {
            var employeesWithCustomers = await ExecuteQuery<EmployeeWithCustomer>("SELECT e.*, c.* FROM Employees e JOIN Customers c ON e.EmployeeNumber = c.SalesRepEmployeeNumber");
            mainWindow.dataGrid.ItemsSource = employeesWithCustomers;
        }

        public void GetProductsWithOrderDetails()
        {
            var productsWithOrderDetails = ExecuteQuerySet<Product>("SELECT p.ProductCode, p.ProductName, p.ProductLineId, p.ProductScale, p.ProductVendor, p.ProductDescription, p.QuantityInStock, p.BuyPrice, p.MSRP FROM Products p JOIN OrderDetails od ON p.ProductCode = od.ProductCode");
            mainWindow.dataGrid.ItemsSource = productsWithOrderDetails;
        }

        public async Task GetTotalProductsByProductLine()
        {
            var totalProductsByProductLine = await ExecuteQuery<ProductLineWithCount>("SELECT pl.ProductLines, COUNT(p.ProductCode) as TotalProducts FROM ProductLines pl JOIN Products p ON pl.ProductLines = p.ProductLineId GROUP BY pl.ProductLines");
            mainWindow.dataGrid.ItemsSource = totalProductsByProductLine;
        }

        public async Task GetTotalOrdersByCustomer()
        {
            var totalOrdersByCustomer = await ExecuteQuery<CustomerWithCount>("SELECT c.CustomerNumber, COUNT(o.OrderNumber) as TotalOrders FROM Customers c JOIN Orders o ON c.CustomerNumber = o.CustomerNumberId GROUP BY c.CustomerNumber");
            mainWindow.dataGrid.ItemsSource = totalOrdersByCustomer;
        }

        public async Task GetProductLinesWithProducts()
        {
            var productLinesWithProducts = await ExecuteQuery<ProductLineWithProduct>("SELECT pl.*, p.* FROM ProductLines pl JOIN Products p ON pl.ProductLines = p.ProductLineId");
            mainWindow.dataGrid.ItemsSource = productLinesWithProducts;
        }

        public async Task GetOrdersWithOrderDetails()
        {
            var ordersWithOrderDetails = await ExecuteQuery<OrderWithOrderDetail>("SELECT o.*, od.* FROM Orders o JOIN OrderDetails od ON o.OrderNumber = od.OrderNumber");
            mainWindow.dataGrid.ItemsSource = ordersWithOrderDetails;
        }

        public async Task GetTopProducts()
        {
            var topProducts = await ExecuteQuery<ProductWithTotalQuantity>("SELECT p.ProductName, SUM(od.QuantityOrdered) as TotalQuantity FROM Products p JOIN OrderDetails od ON p.ProductCode = od.ProductCode GROUP BY p.ProductName ORDER BY TotalQuantity DESC LIMIT 10");
            mainWindow.dataGrid.ItemsSource = topProducts;
        }

        public async Task GetTopEmployees()
        {
            var topEmployees = await ExecuteQuery<EmployeeWithTotalSales>("SELECT e.FirstName, e.LastName, COUNT(o.OrderNumber) as TotalSales FROM Employees e JOIN Customers c ON e.EmployeeNumber = c.SalesRepEmployeeNumber JOIN Orders o ON c.CustomerNumber = o.CustomerNumberId GROUP BY e.EmployeeNumber HAVING TotalSales > 10");
            mainWindow.dataGrid.ItemsSource = topEmployees;
        }
        #endregion


        #region queries with parameters


        public class ProductLineWithCount
        {
            public string ProductLines { get; set; }
            public long TotalProducts { get; set; }
        }
        public class CustomerWithCount
        {
            public int CustomerNumber { get; set; }
            public long TotalOrders { get; set; }
        }

        public class EmployeeWithCustomer
        {
            public int EmployeeNumber { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public int CustomerNumber { get; set; }
            public string CustomerName { get; set; }
        }

        public class ProductLineWithProduct
        {
            public string ProductLineId { get; set; }
            public string TextDescription { get; set; }

            public string ProductCode { get; set; }
            public string ProductName { get; set; }
        }

        public class OrderWithOrderDetail
        {
            public int OrderNumber { get; set; }
            public DateTime OrderDate { get; set; }

            public string ProductCode { get; set; }
            public int QuantityOrdered { get; set; }
        }

        public class ProductWithTotalQuantity
        {
            public string ProductName { get; set; }
            public decimal TotalQuantity { get; set; }
        }

        public class EmployeeWithTotalSales
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public long TotalSales { get; set; }
        }

        #endregion


    }
}