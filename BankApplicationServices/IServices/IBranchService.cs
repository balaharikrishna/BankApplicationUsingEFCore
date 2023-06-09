﻿using BankApplication.Models;

namespace BankApplication.Services.IServices
{
    public interface IBranchService
    {
        /// <summary>
        /// Gets All Available Branches in a Bank.
        /// </summary>
        /// <param name="bankId">The ID of the bank.</param>
        /// <returns>All Branches Available in a Bank</returns>
        Task<IEnumerable<Branch>> GetAllBranchesAsync(string bankId);

        /// <summary>
        /// Gets a Branch by using Branch Id.
        /// </summary>
        /// <param name="id">The ID of the branch.</param>
        /// <returns>Branch with Id.</returns>
        Task<Branch?> GetBranchByIdAsync(string id);

        /// <summary>
        /// Gets a Branch by using Branch Name.
        /// </summary>
        /// <param name="name">The Name of the branch.</param>
        /// <returns>Branch with Name.</returns>
        Task<Branch?> GetBranchByNameAsync(string name);

        /// <summary>
        /// Checks whether any branches exist for a given bank.
        /// </summary>
        /// <param name="bankId">The ID of the bank to check.</param>
        /// <returns>A message about Status of the operation whether branches exist or not.</returns>
        Task<Message> IsBranchesExistAsync(string bankId);

        /// <summary>
        /// Creates a new branch for a given bank.
        /// </summary>
        /// <param name="bankId">The ID of the bank in which to create the branch.</param>
        /// <param name="branchName">The name of the new branch.</param>
        /// <param name="branchPhoneNumber">The phone number of the new branch.</param>
        /// <param name="branchAddress">The address of the new branch.</param>
        /// <returns>A message about the status of  branch Creation.</returns>
        Task<Message> CreateBranchAsync(string bankId, string branchName, string branchPhoneNumber, string branchAddress);

        /// <summary>
        /// Deletes an existing branch for a given bank.
        /// </summary>
        /// <param name="branchId">The ID of the branch to delete.</param>
        /// <returns>A message about the Status of Bank Deletion.</returns>
        Task<Message> DeleteBranchAsync(string branchId);

        /// <summary>
        /// Gets the transaction charges for a given bank and branch.
        /// </summary>
        /// <param name="branchId">The ID of the branch for which to get transaction charges.</param>
        /// <returns>A message about Status of Availbility of transaction charges.</returns>
        Task<IEnumerable<TransactionCharge>> GetTransactionChargesAsync(string branchId);

        /// <summary>
        /// Authenticates the given branch ID for a given bank.
        /// </summary>
        /// <param name="branchId">The ID of the branch to authenticate.</param>
        /// <returns>A message about Status of Branch Authentication.</returns>
        Task<Message> AuthenticateBranchIdAsync(string branchId);

        /// <summary>
        /// Updates an existing branch for a given bank.
        /// </summary>
        /// <param name="branchId">The ID of the branch to update.</param>
        /// <param name="branchName">The new name of the branch.</param>
        /// <param name="branchPhoneNumber">The new phone number of the branch.</param>
        /// <param name="branchAddress">The new address of the branch.</param>
        /// <returns>A message about Status of Branch Updation.</returns>
        Task<Message> UpdateBranchAsync(string branchId, string branchName, string branchPhoneNumber, string branchAddress);
    }
}