using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Radzen;
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using TlaxRatio.Data;
using TlaxRatio.Models.RatioModels;
namespace TlaxRatio
{
    public  partial class RatioDataService
    {
        SimpleInvoiceContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly SimpleInvoiceContext context;
        private readonly NavigationManager navigationManager;
        public RatioDataService(SimpleInvoiceContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }
        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);

        #region Export

        public async Task ExportCompaniesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/companies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/companies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        public async Task ExportCompaniesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/companies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/companies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        public async Task ExportCustomersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/customers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/customers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        public async Task ExportCustomersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/customers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/customers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        public async Task ExportInvoicesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/invoices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/invoices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        public async Task ExportInvoicesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ?
                
                 query.ToUrl($"export/simpleinvoice/invoices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : 
                             $"export/simpleinvoice/invoices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInvoiceLinesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/invoicelines/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/invoicelines/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        public async Task ExportInvoiceLinesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/invoicelines/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/invoicelines/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        public async Task ExportProductsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/products/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/products/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        public async Task ExportProductsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/products/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/products/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        public async Task ExportTaxesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/taxes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/taxes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        public async Task ExportTaxesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/taxes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/taxes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        public async Task PrintInvoiceToPDF(int invoiceId, string fileName = null)
        {
            navigationManager.NavigateTo($"export/SimpleInvoice/invoice/pdf(invoiceId={invoiceId},fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        #endregion

        #region Company
        public async Task<Company> CreateCompany(Company company)
        {
            OnCompanyCreated(company);
            Context.Companies.Add(company);
            Context.SaveChanges();
            OnAfterCompanyCreated(company);
            return company;
        }
        public async Task<IQueryable<Company>> GetCompanies(Query query = null)
        {
            var items = Context.Companies.AsQueryable();
            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach (var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }
                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCompaniesRead(ref items);
            return await Task.FromResult(items);
        }
        public async Task<Company> DeleteCompany(int? companyId)
        {
            var itemToDelete = Context.Companies
                              .Where(i => i.CompanyId == companyId)
                              .Include(i => i.Invoices)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
                throw new Exception("Item no longer available");
            }

            OnCompanyDeleted(itemToDelete);

            Context.Companies.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCompanyDeleted(itemToDelete);

            return itemToDelete;
        }
        public async Task<Company> GetCompanyByCompanyId(int? companyId)
        {
            var items = Context.Companies
                              .AsNoTracking()
                              .Where(i => i.CompanyId == companyId);

            var itemToReturn = items.FirstOrDefault();

            OnCompanyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }
        public async Task<Company> CancelCompanyChanges(Company item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }
        public async Task<Company> UpdateCompany(int? companyId, Company company)
        {
            OnCompanyUpdated(company);

            var itemToUpdate = Context.Companies
                              .Where(i => i.CompanyId == companyId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(company);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterCompanyUpdated(company);

            return company;
        }
        #endregion

        #region Customer
        public async Task<IQueryable<Customer>> GetCustomers(Query query = null)
        {
            var items = Context.Customers.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach (var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCustomersRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            OnCustomerCreated(customer);

            Context.Customers.Add(customer);
            Context.SaveChanges();

            OnAfterCustomerCreated(customer);

            return customer;
        }
        public async Task<Customer> DeleteCustomer(int? customerId)
        {
            var itemToDelete = Context.Customers
                              .Where(i => i.CustomerId == customerId)
                              .Include(i => i.Invoices)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
                throw new Exception("Item no longer available");
            }

            OnCustomerDeleted(itemToDelete);

            Context.Customers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCustomerDeleted(itemToDelete);

            return itemToDelete;
        }
        public async Task<Customer> GetCustomerByCustomerId(int? customerId)
        {
            var items = Context.Customers
                              .AsNoTracking()
                              .Where(i => i.CustomerId == customerId);

            var itemToReturn = items.FirstOrDefault();

            OnCustomerGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }
        public async Task<Customer> CancelCustomerChanges(Customer item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }
        public async Task<Customer> UpdateCustomer(int? customerId, Customer customer)
        {
            OnCustomerUpdated(customer);

            var itemToUpdate = Context.Customers
                              .Where(i => i.CustomerId == customerId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(customer);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterCustomerUpdated(customer);

            return customer;
        }
        #endregion

        #region Invoce
        public async Task<IQueryable<Invoice>> GetInvoices(Query query = null)
        {
            var items = Context.Invoices.AsQueryable();

            items = items.Include(i => i.Company);

            items = items.Include(i => i.Customer);

            items = items.Include(i => i.Tax);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach (var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnInvoicesRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task<Invoice> CreateInvoice(Invoice invoice)
        {
            OnInvoiceCreated(invoice);

            Context.Invoices.Add(invoice);
            Context.SaveChanges();

            OnAfterInvoiceCreated(invoice);

            return invoice;
        }
        public async Task<IQueryable<InvoiceLine>> GetInvoiceLines(Query query = null)
        {
            var items = Context.InvoiceLines.AsQueryable();

            items = items.Include(i => i.Invoice);

            items = items.Include(i => i.Product);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach (var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnInvoiceLinesRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task<InvoiceLine> CreateInvoiceLine(InvoiceLine invoiceLine)
        {
            OnInvoiceLineCreated(invoiceLine);

            Context.InvoiceLines.Add(invoiceLine);
            Context.SaveChanges();

            OnAfterInvoiceLineCreated(invoiceLine);

            return invoiceLine;
        }
        public async Task<Invoice> DeleteInvoice(int? invoiceId)
        {
            var itemToDelete = Context.Invoices
                              .Where(i => i.InvoiceId == invoiceId)
                              .Include(i => i.InvoiceLines)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
                throw new Exception("Item no longer available");
            }

            OnInvoiceDeleted(itemToDelete);

            Context.Invoices.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterInvoiceDeleted(itemToDelete);

            return itemToDelete;
        }
        public async Task<Invoice> GetInvoiceByInvoiceId(int? invoiceId)
        {
            var items = Context.Invoices
                              .AsNoTracking()
                              .Where(i => i.InvoiceId == invoiceId);

            items = items.Include(i => i.Company);

            items = items.Include(i => i.Customer);

            items = items.Include(i => i.Tax);

            var itemToReturn = items.FirstOrDefault();

            OnInvoiceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }
        public async Task<Invoice> CancelInvoiceChanges(Invoice item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }
        public async Task<Invoice> UpdateInvoice(int? invoiceId, Invoice invoice)
        {
            OnInvoiceUpdated(invoice);

            var itemToUpdate = Context.Invoices
                              .Where(i => i.InvoiceId == invoiceId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(invoice);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterInvoiceUpdated(invoice);

            return invoice;
        }
        public async Task<InvoiceLine> DeleteInvoiceLine(int? invoiceLineId)
        {
            var itemToDelete = Context.InvoiceLines
                              .Where(i => i.InvoiceLineId == invoiceLineId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
                throw new Exception("Item no longer available");
            }

            OnInvoiceLineDeleted(itemToDelete);

            Context.InvoiceLines.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterInvoiceLineDeleted(itemToDelete);

            return itemToDelete;
        }
        public async Task<InvoiceLine> GetInvoiceLineByInvoiceLineId(int? invoiceLineId)
        {
            var items = Context.InvoiceLines
                              .AsNoTracking()
                              .Where(i => i.InvoiceLineId == invoiceLineId);

            items = items.Include(i => i.Invoice);

            items = items.Include(i => i.Product);

            var itemToReturn = items.FirstOrDefault();

            OnInvoiceLineGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }
        public async Task<InvoiceLine> CancelInvoiceLineChanges(InvoiceLine item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }
        public async Task<InvoiceLine> UpdateInvoiceLine(int? invoiceLineId, InvoiceLine invoiceLine)
        {
            OnInvoiceLineUpdated(invoiceLine);

            var itemToUpdate = Context.InvoiceLines
                              .Where(i => i.InvoiceLineId == invoiceLineId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(invoiceLine);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterInvoiceLineUpdated(invoiceLine);

            return invoiceLine;
        }

        #endregion

        #region Product

        public async Task<IQueryable<Product>> GetProducts(Query query = null)
        {
            var items = Context.Products.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnProductsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task<Product> CreateProduct(Product product)
        {
            OnProductCreated(product);

            Context.Products.Add(product);
            Context.SaveChanges();

            OnAfterProductCreated(product);

            return product;
        }
        public async Task<Product> DeleteProduct(int? productId)
        {
            var itemToDelete = Context.Products
                              .Where(i => i.ProductId == productId)
                              .Include(i => i.InvoiceLines)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProductDeleted(itemToDelete);

            Context.Products.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProductDeleted(itemToDelete);

            return itemToDelete;
        }
        public async Task<Product> GetProductByProductId(int? productId)
        {
            var items = Context.Products
                              .AsNoTracking()
                              .Where(i => i.ProductId == productId);

            var itemToReturn = items.FirstOrDefault();

            OnProductGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }
        public async Task<Product> CancelProductChanges(Product item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }
        public async Task<Product> UpdateProduct(int? productId, Product product)
        {
            OnProductUpdated(product);

            var itemToUpdate = Context.Products
                              .Where(i => i.ProductId == productId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(product);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterProductUpdated(product);

            return product;
        }
        #endregion

        #region Tax
        public async Task<IQueryable<Tax>> GetTaxes(Query query = null)
        {
            var items = Context.Taxes.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach (var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTaxesRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task<Tax> CreateTax(Tax tax)
        {
            OnTaxCreated(tax);

            Context.Taxes.Add(tax);
            Context.SaveChanges();

            OnAfterTaxCreated(tax);

            return tax;
        }
        public async Task<Tax> DeleteTax(int? taxId)
        {
            var itemToDelete = Context.Taxes
                              .Where(i => i.TaxId == taxId)
                              .Include(i => i.Invoices)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTaxDeleted(itemToDelete);

            Context.Taxes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTaxDeleted(itemToDelete);

            return itemToDelete;
        }
        public async Task<Tax> GetTaxByTaxId(int? taxId)
        {
            var items = Context.Taxes
                              .AsNoTracking()
                              .Where(i => i.TaxId == taxId);

            var itemToReturn = items.FirstOrDefault();

            OnTaxGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }
        public async Task<Tax> CancelTaxChanges(Tax item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }
        public async Task<Tax> UpdateTax(int? taxId, Tax tax)
        {
            OnTaxUpdated(tax);

            var itemToUpdate = Context.Taxes
                              .Where(i => i.TaxId == taxId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tax);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterTaxUpdated(tax);

            return tax;
        }
        #endregion
      
        public bool DataInitializationOk()
        {
            var result = Context.Companies.Count() > 0;
            return !result;
        }
        public void DataInitialization()
        {
            var company = Context.Companies.FirstOrDefault();
            if (company == null)
            {
                company = new Company();
                company.Name = "YourCompany, Inc.";
                company.Description = "My next great company.";
                company.Address = "1st Pajajaran Street.";
                company.City = "Bandung City.";

                Context.Companies.Add(company);

                var customer = new Customer();
                customer.Name = "Default Customer";
                customer.Description = "My best loyal customer";
                customer.Address = "1st Sudirman Street.";
                customer.City = "Jakarta City.";

                Context.Customers.Add(customer);

                var officeBasic = new Product();
                officeBasic.Name = "Basic, MS Office 365.";
                officeBasic.UnitPrice = 50;

                var officeStandard = new Product();
                officeStandard.Name = "Standard, MS Office 365.";
                officeStandard.UnitPrice = 100;

                var officePremium = new Product();
                officePremium.Name = "Premium, MS Office 365.";
                officePremium.UnitPrice = 200;

                Context.Products.AddRange(officeBasic, officeStandard, officePremium);

                var tax = new Tax();
                tax.Name = "VAT";
                tax.TaxTariffPercentage = 10;

                Context.Taxes.Add(tax);

                Context.SaveChanges();


            }
        }
    }
}
