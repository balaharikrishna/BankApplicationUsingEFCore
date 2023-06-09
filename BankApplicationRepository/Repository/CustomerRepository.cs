﻿using BankApplication.Models;
using BankApplication.Models.Enums;
using BankApplication.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Repository.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BankDBContext _context;
        public CustomerRepository(BankDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomers(string branchId)
        {
            IEnumerable<Customer> customers = await _context.Customers.Where(c => c.BranchId.Equals(branchId) && c.IsActive).ToListAsync();
            if (customers.Any())
            {
                return customers;
            }
            else
            {
                return Enumerable.Empty<Customer>();
            }
        }
        public async Task<Customer?> GetCustomerById(string customerAccountId, string branchId)
        {
            Customer? customer =  await _context.Customers.FirstOrDefaultAsync(c => c.AccountId.Equals(customerAccountId)
            && c.BranchId.Equals(branchId) && c.IsActive);
            if (customer is not null)
            {
                return customer;
            }
            else
            {
                return null;
            }
        }
        public async Task<Customer?> GetCustomerByName(string customerName, string branchId)
        {
            Customer? customer = await _context.Customers.FirstOrDefaultAsync(c => c.Name.Equals(customerName)
            && c.BranchId.Equals(branchId) && c.IsActive);
            if (customer is not null)
            {
                return customer;
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> AddCustomerAccount(Customer customer, string branchId)
        {
            customer.BranchId = branchId;
            await _context.Customers.AddAsync(customer);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<bool> UpdateCustomerAccount(Customer customer, string branchId)
        {
            Customer? customerObj = await GetCustomerById(customer.AccountId, branchId);
            if (customer.Name is not null)
            {
                customerObj!.Name = customer.Name;
            }

            if (customer.Salt is not null)
            {
                customerObj!.Salt = customer.Salt;

                if (customer.HashedPassword is not null)
                {
                    customerObj.HashedPassword = customer.HashedPassword;
                }
            }

            if (customer.Balance > 0)
            {
                customerObj!.Balance = customer.Balance;
            }

            if (Enum.IsDefined(typeof(Gender), customer.Gender))
            {
                customerObj!.Gender = customer.Gender;
            }

            if (Enum.IsDefined(typeof(AccountType), customer.AccountType))
            {
                customerObj!.AccountType = customer.AccountType;
            }

            if (customer.Address is not null)
            {
                customerObj!.Address = customer.Address;
            }

            if (customer.DateOfBirth is not null)
            {
                customerObj!.DateOfBirth = customer.DateOfBirth;
            }

            if (customer.EmailId is not null)
            {
                customerObj!.EmailId = customer.EmailId;
            }

            if (customer.PhoneNumber is not null)
            {
                customerObj!.PhoneNumber = customer.PhoneNumber;
            }

            if (customer.PassbookIssueDate is not null)
            {
                customerObj!.PassbookIssueDate = customer.PassbookIssueDate;
            }

            _context.Customers.Update(customerObj!);
            int rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected > 0;
        }

        public async Task<bool> DeleteCustomerAccount(string customerAccountId, string branchId)
        {
            Customer? customer = await GetCustomerById(customerAccountId, branchId);
            customer!.IsActive = false;
            _context.Customers.Update(customer);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }
        public async Task<bool> IsCustomerExist(string customerAccountId, string branchId)
        {
            return await _context.Customers.AnyAsync(c => c.AccountId.Equals(customerAccountId) && c.IsActive);
        }
    }
}
