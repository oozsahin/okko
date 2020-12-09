using Microsoft.AspNetCore.Mvc;
using okko.uzapi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace okko.uzapi
{
    public static class SD
    {
        public const int PaginationDepositPageSize = 50;
        public const string AdminRole = "Admin";
        public const string OperationRole = "Operation";
        public const string ManagerRole = "Manager";
        public const string MarketingRole = "Marketing";
        public const string AcountantRole = "Accountant";
        public const string CreditRole = "Credit";
        public const string SwiftRole = "Swift";
        public const string UsersRole = "Users";

        public const string StatusSubmitted = "Submitted";
        public const string StatusInProcess = "Being Prepared";
        public const string StatusReady = "Ready for Pickup";
        public const string StatusCompleted = "Completed";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";

        public static string APIBaseUrl = "https://localhost:44336/api/v1/controllers";
        public static string DepositAPIPath = APIBaseUrl + "api/v1/deposits/";
  
    }

}

