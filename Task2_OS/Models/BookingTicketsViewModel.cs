namespace Task2_OS.Models;

public class BookingTicketsViewModel
{
    public required List<TicketModel> Tickets {get; set;}
    
    public required List<string> TicketTypes {get; set;}
}