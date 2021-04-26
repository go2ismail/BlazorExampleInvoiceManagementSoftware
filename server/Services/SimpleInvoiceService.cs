using Radzen;
using System;
using System.Web;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Data;
using System.Text.Encodings.Web;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using SimpleInvoiceManagementSoftware.Data;

namespace SimpleInvoiceManagementSoftware
{
    public partial class SimpleInvoiceService
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

        public SimpleInvoiceService(SimpleInvoiceContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);

        public async Task ExportCompaniesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/companies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/companies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCompaniesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/companies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/companies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCompaniesRead(ref IQueryable<Models.SimpleInvoice.Company> items);

        public async Task<IQueryable<Models.SimpleInvoice.Company>> GetCompanies(Query query = null)
        {
            var items = Context.Companies.AsQueryable();

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

            OnCompaniesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCompanyCreated(Models.SimpleInvoice.Company item);
        partial void OnAfterCompanyCreated(Models.SimpleInvoice.Company item);

        public async Task<Models.SimpleInvoice.Company> CreateCompany(Models.SimpleInvoice.Company company)
        {
            OnCompanyCreated(company);

            Context.Companies.Add(company);
            Context.SaveChanges();

            OnAfterCompanyCreated(company);

            return company;
        }
        public async Task ExportCustomersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/customers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/customers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCustomersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/customers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/customers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCustomersRead(ref IQueryable<Models.SimpleInvoice.Customer> items);

        public async Task<IQueryable<Models.SimpleInvoice.Customer>> GetCustomers(Query query = null)
        {
            var items = Context.Customers.AsQueryable();

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

            OnCustomersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCustomerCreated(Models.SimpleInvoice.Customer item);
        partial void OnAfterCustomerCreated(Models.SimpleInvoice.Customer item);

        public async Task<Models.SimpleInvoice.Customer> CreateCustomer(Models.SimpleInvoice.Customer customer)
        {
            OnCustomerCreated(customer);

            Context.Customers.Add(customer);
            Context.SaveChanges();

            OnAfterCustomerCreated(customer);

            return customer;
        }
        public async Task ExportInvoicesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/invoices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/invoices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInvoicesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/invoices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/invoices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInvoicesRead(ref IQueryable<Models.SimpleInvoice.Invoice> items);

        public async Task<IQueryable<Models.SimpleInvoice.Invoice>> GetInvoices(Query query = null)
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

            OnInvoicesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnInvoiceCreated(Models.SimpleInvoice.Invoice item);
        partial void OnAfterInvoiceCreated(Models.SimpleInvoice.Invoice item);

        public async Task<Models.SimpleInvoice.Invoice> CreateInvoice(Models.SimpleInvoice.Invoice invoice)
        {
            OnInvoiceCreated(invoice);

            Context.Invoices.Add(invoice);
            Context.SaveChanges();

            OnAfterInvoiceCreated(invoice);

            return invoice;
        }
        public async Task ExportInvoiceLinesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/invoicelines/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/invoicelines/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInvoiceLinesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/invoicelines/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/invoicelines/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInvoiceLinesRead(ref IQueryable<Models.SimpleInvoice.InvoiceLine> items);

        public async Task<IQueryable<Models.SimpleInvoice.InvoiceLine>> GetInvoiceLines(Query query = null)
        {
            var items = Context.InvoiceLines.AsQueryable();

            items = items.Include(i => i.Invoice);

            items = items.Include(i => i.Product);

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

            OnInvoiceLinesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnInvoiceLineCreated(Models.SimpleInvoice.InvoiceLine item);
        partial void OnAfterInvoiceLineCreated(Models.SimpleInvoice.InvoiceLine item);

        public async Task<Models.SimpleInvoice.InvoiceLine> CreateInvoiceLine(Models.SimpleInvoice.InvoiceLine invoiceLine)
        {
            OnInvoiceLineCreated(invoiceLine);

            Context.InvoiceLines.Add(invoiceLine);
            Context.SaveChanges();

            OnAfterInvoiceLineCreated(invoiceLine);

            return invoiceLine;
        }
        public async Task ExportProductsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/products/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/products/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProductsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/products/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/products/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProductsRead(ref IQueryable<Models.SimpleInvoice.Product> items);

        public async Task<IQueryable<Models.SimpleInvoice.Product>> GetProducts(Query query = null)
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

        partial void OnProductCreated(Models.SimpleInvoice.Product item);
        partial void OnAfterProductCreated(Models.SimpleInvoice.Product item);

        public async Task<Models.SimpleInvoice.Product> CreateProduct(Models.SimpleInvoice.Product product)
        {
            OnProductCreated(product);

            Context.Products.Add(product);
            Context.SaveChanges();

            OnAfterProductCreated(product);

            return product;
        }
        public async Task ExportTaxesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/taxes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/taxes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTaxesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/simpleinvoice/taxes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/simpleinvoice/taxes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTaxesRead(ref IQueryable<Models.SimpleInvoice.Tax> items);

        public async Task<IQueryable<Models.SimpleInvoice.Tax>> GetTaxes(Query query = null)
        {
            var items = Context.Taxes.AsQueryable();

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

            OnTaxesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTaxCreated(Models.SimpleInvoice.Tax item);
        partial void OnAfterTaxCreated(Models.SimpleInvoice.Tax item);

        public async Task<Models.SimpleInvoice.Tax> CreateTax(Models.SimpleInvoice.Tax tax)
        {
            OnTaxCreated(tax);

            Context.Taxes.Add(tax);
            Context.SaveChanges();

            OnAfterTaxCreated(tax);

            return tax;
        }

        partial void OnCompanyDeleted(Models.SimpleInvoice.Company item);
        partial void OnAfterCompanyDeleted(Models.SimpleInvoice.Company item);

        public async Task<Models.SimpleInvoice.Company> DeleteCompany(int? companyId)
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

        partial void OnCompanyGet(Models.SimpleInvoice.Company item);

        public async Task<Models.SimpleInvoice.Company> GetCompanyByCompanyId(int? companyId)
        {
            var items = Context.Companies
                              .AsNoTracking()
                              .Where(i => i.CompanyId == companyId);

            var itemToReturn = items.FirstOrDefault();

            OnCompanyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SimpleInvoice.Company> CancelCompanyChanges(Models.SimpleInvoice.Company item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnCompanyUpdated(Models.SimpleInvoice.Company item);
        partial void OnAfterCompanyUpdated(Models.SimpleInvoice.Company item);

        public async Task<Models.SimpleInvoice.Company> UpdateCompany(int? companyId, Models.SimpleInvoice.Company company)
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

        partial void OnCustomerDeleted(Models.SimpleInvoice.Customer item);
        partial void OnAfterCustomerDeleted(Models.SimpleInvoice.Customer item);

        public async Task<Models.SimpleInvoice.Customer> DeleteCustomer(int? customerId)
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

        partial void OnCustomerGet(Models.SimpleInvoice.Customer item);

        public async Task<Models.SimpleInvoice.Customer> GetCustomerByCustomerId(int? customerId)
        {
            var items = Context.Customers
                              .AsNoTracking()
                              .Where(i => i.CustomerId == customerId);

            var itemToReturn = items.FirstOrDefault();

            OnCustomerGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SimpleInvoice.Customer> CancelCustomerChanges(Models.SimpleInvoice.Customer item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnCustomerUpdated(Models.SimpleInvoice.Customer item);
        partial void OnAfterCustomerUpdated(Models.SimpleInvoice.Customer item);

        public async Task<Models.SimpleInvoice.Customer> UpdateCustomer(int? customerId, Models.SimpleInvoice.Customer customer)
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

        partial void OnInvoiceDeleted(Models.SimpleInvoice.Invoice item);
        partial void OnAfterInvoiceDeleted(Models.SimpleInvoice.Invoice item);

        public async Task<Models.SimpleInvoice.Invoice> DeleteInvoice(int? invoiceId)
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

        partial void OnInvoiceGet(Models.SimpleInvoice.Invoice item);

        public async Task<Models.SimpleInvoice.Invoice> GetInvoiceByInvoiceId(int? invoiceId)
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

        public async Task<Models.SimpleInvoice.Invoice> CancelInvoiceChanges(Models.SimpleInvoice.Invoice item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnInvoiceUpdated(Models.SimpleInvoice.Invoice item);
        partial void OnAfterInvoiceUpdated(Models.SimpleInvoice.Invoice item);

        public async Task<Models.SimpleInvoice.Invoice> UpdateInvoice(int? invoiceId, Models.SimpleInvoice.Invoice invoice)
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

        partial void OnInvoiceLineDeleted(Models.SimpleInvoice.InvoiceLine item);
        partial void OnAfterInvoiceLineDeleted(Models.SimpleInvoice.InvoiceLine item);

        public async Task<Models.SimpleInvoice.InvoiceLine> DeleteInvoiceLine(int? invoiceLineId)
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

        partial void OnInvoiceLineGet(Models.SimpleInvoice.InvoiceLine item);

        public async Task<Models.SimpleInvoice.InvoiceLine> GetInvoiceLineByInvoiceLineId(int? invoiceLineId)
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

        public async Task<Models.SimpleInvoice.InvoiceLine> CancelInvoiceLineChanges(Models.SimpleInvoice.InvoiceLine item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnInvoiceLineUpdated(Models.SimpleInvoice.InvoiceLine item);
        partial void OnAfterInvoiceLineUpdated(Models.SimpleInvoice.InvoiceLine item);

        public async Task<Models.SimpleInvoice.InvoiceLine> UpdateInvoiceLine(int? invoiceLineId, Models.SimpleInvoice.InvoiceLine invoiceLine)
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

        partial void OnProductDeleted(Models.SimpleInvoice.Product item);
        partial void OnAfterProductDeleted(Models.SimpleInvoice.Product item);

        public async Task<Models.SimpleInvoice.Product> DeleteProduct(int? productId)
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

        partial void OnProductGet(Models.SimpleInvoice.Product item);

        public async Task<Models.SimpleInvoice.Product> GetProductByProductId(int? productId)
        {
            var items = Context.Products
                              .AsNoTracking()
                              .Where(i => i.ProductId == productId);

            var itemToReturn = items.FirstOrDefault();

            OnProductGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SimpleInvoice.Product> CancelProductChanges(Models.SimpleInvoice.Product item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnProductUpdated(Models.SimpleInvoice.Product item);
        partial void OnAfterProductUpdated(Models.SimpleInvoice.Product item);

        public async Task<Models.SimpleInvoice.Product> UpdateProduct(int? productId, Models.SimpleInvoice.Product product)
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

        partial void OnTaxDeleted(Models.SimpleInvoice.Tax item);
        partial void OnAfterTaxDeleted(Models.SimpleInvoice.Tax item);

        public async Task<Models.SimpleInvoice.Tax> DeleteTax(int? taxId)
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

        partial void OnTaxGet(Models.SimpleInvoice.Tax item);

        public async Task<Models.SimpleInvoice.Tax> GetTaxByTaxId(int? taxId)
        {
            var items = Context.Taxes
                              .AsNoTracking()
                              .Where(i => i.TaxId == taxId);

            var itemToReturn = items.FirstOrDefault();

            OnTaxGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SimpleInvoice.Tax> CancelTaxChanges(Models.SimpleInvoice.Tax item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTaxUpdated(Models.SimpleInvoice.Tax item);
        partial void OnAfterTaxUpdated(Models.SimpleInvoice.Tax item);

        public async Task<Models.SimpleInvoice.Tax> UpdateTax(int? taxId, Models.SimpleInvoice.Tax tax)
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
    }
}
