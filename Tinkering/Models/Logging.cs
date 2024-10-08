namespace Tinkering.Models;

public class Logging
{
    public bool Use { get; set; }
    public LoggingDestination Destination { get; set; }
    public string LogFileName { get; set; }
}