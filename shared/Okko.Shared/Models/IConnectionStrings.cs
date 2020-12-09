namespace Okko.Shared.Models
{
    public interface IConnectionStrings
    {
        string OracleConnectionString { get; set; }
        string SQLConnectionString { get; set; }
    }
}