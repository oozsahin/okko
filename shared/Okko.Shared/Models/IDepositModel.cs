using System;

namespace Okko.Shared.Models
{
    public interface IDepositModel
    {
        string Account_Type { get; set; }
        string Balance_Account { get; set; }
        string Branch { get; set; }
        string Code_Subject { get; set; }
        string Currency_Code { get; set; }
        DateTime Date_Open { get; set; }
        string File_Name { get; set; }
        string File_Name2 { get; set; }
        string Id { get; set; }
        string Id_Client { get; set; }
        string Id_Client2 { get; set; }
        string Name { get; set; }
        double s30 { get; set; }
    }
}