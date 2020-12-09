using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace okko.uzapi.Models
{
    public class Deposit
    {
        public string Branch { get; set; }
        public string Id_Client { get; set; }
        public DateTime Date_Open { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string Balance_Account { get; set; }
        public string Currency_Code { get; set; }
        public double s30 { get; set; }
        public string Id_Client2 { get; set; }
        public string Code_Subject { get; set; }
        public string File_Name { get; set; }
        public string File_Name2 { get; set; }
        public string Account_Type { get; set; }

    }
}
