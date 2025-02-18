using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using Task2_OS.Models;

public IActionResult Tickets(
    [FromQuery] string startDate,
    [FromQuery] string endDate,
    [FromQuery] string searchBoxValue,
    [FromQuery] string minimumValue,
    [FromQuery] string maximumValue,
    [FromQuery] string ticketTypes)

{
    //Parse ticketTypes
    string[] ticketTypesParsed;
    if (ticketTypes == null)
    {
        ticketTypesParsed = new string[0];
    }
    else
    {
        ticketTypesParsed = ticketTypes.Split(',');
    }
    
    //Return all active/available tickets
    List<TicketModel> tickets = sqlite3_context.Tickets.Where(t => t.Active).ToList();
    
    //Make a new BookingTicketsViewModel
    BookingTicketsViewModel bookingTicketsViewModel = new BookingTicketsViewModel
    {
        Tickets = tickets,
        TicketTypes = Enumerable.Range(1, 10).Select(i => $"Ticket Type {i}").ToList()
    };
    
    return View(bookingTicketsViewModel);
}