using System;

namespace DigitalOcean.API.Models.Responses; 

public class BackupWindow {
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}