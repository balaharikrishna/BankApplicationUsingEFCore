﻿using BankApplication.Models;
using BankApplication.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Repository.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly BankDBContext _context;
        public StaffRepository(BankDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Staff>> GetAllStaffs(string branchId)
        {
            IEnumerable<Staff> staff = await _context.Staffs.Where(c => c.BranchId.Equals(branchId) && c.IsActive).ToListAsync();
            if (staff.Any())
            {
                return staff;
            }
            else
            {
                return Enumerable.Empty<Staff>();
            }
        }
        public async Task<bool> AddStaffAccount(Staff staff, string branchId)
        {
            staff.BranchId = branchId;
            await _context.Staffs.AddAsync(staff);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<bool> UpdateStaffAccount(Staff staff, string branchId)
        {
            Staff? staffObj = await GetStaffById(staff.AccountId, branchId);

            if (staff.Name is not null)
            {
                staffObj!.Name = staff.Name;
            }

            if (staff.Salt is not null)
            {
                staffObj!.Salt = staff.Salt;

                if (staff.HashedPassword is not null)
                {
                    staffObj.HashedPassword = staff.HashedPassword;
                }
            }

            _context.Staffs.Update(staffObj!);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteStaffAccount(string staffAccountId, string branchId)
        {
            Staff? staff = await GetStaffById(staffAccountId, branchId);
            staff!.IsActive = false;
            _context.Staffs.Update(staff);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }
        public async Task<bool> IsStaffExist(string staffAccountId, string branchId)
        {
            return await _context.Staffs.AnyAsync(c => c.AccountId.Equals(staffAccountId) && c.BranchId.Equals(branchId) && c.IsActive);
        }
        public async Task<Staff?> GetStaffById(string staffAccountId, string branchId)
        {
            Staff? staff = await _context.Staffs.FirstOrDefaultAsync(c => c.AccountId.Equals(staffAccountId)
            && c.BranchId.Equals(branchId) && c.IsActive);
            if (staff is not null)
            {
                return staff;
            }
            else
            {
                return null;
            }
        }
        public async Task<Staff?> GetStaffByName(string staffName, string branchId)
        {
            Staff? staff = await _context.Staffs.FirstOrDefaultAsync(c => c.Name.Equals(staffName)
            && c.BranchId.Equals(branchId) && c.IsActive);
            if (staff is not null)
            {
                return staff;
            }
            else
            {
                return null;
            }
        }
    }
}
