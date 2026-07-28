using System;
class Nullabletype
{
    static void Main()
    {
        int AvailableTickets;
        int? TicketsOnSale = null;

        // if (TicketsOnSale == null)
        // {
        //     AvailableTickets = 0;
        // }
        // else
        // {
        //     AvailableTickets = (int)TicketsOnSale;
        // }
          //Using null coalesce operator ??
          AvailableTickets = TicketsOnSale ?? 0;

        Console.WriteLine("Available Tickets={0}", AvailableTickets);
    }
}