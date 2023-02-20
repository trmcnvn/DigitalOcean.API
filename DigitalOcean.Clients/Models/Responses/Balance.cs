using System;

namespace DigitalOcean.API.Models.Responses; 

public class Balance
{
    /// <summary>
    /// Balance as of the GeneratedAt time. This value includes the AccountBalance and MothToDateUsage.
    /// </summary>
    public string MonthToDateBalance { get; set; }

    /// <summary>
    /// Current balance of the customer's most recent billing activity. Does not reflect MothToDateUsage.
    /// </summary>
    public string AccountBalance { get; set; }

    /// <summary>
    /// Amount used in the current billing period as of the generated_at time.
    /// </summary>
    public string MonthToDateUsage { get; set; }

    /// <summary>
    /// The time at which balances were most recently generated.
    /// </summary>
    public DateTime GeneratedAt { get; set; }
}