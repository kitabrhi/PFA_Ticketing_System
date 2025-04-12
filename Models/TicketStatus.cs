using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace Ticketing_System.Models
{
    public enum TicketStatus
    {
        [Description("Open")]
        Open,

        [Description("In Progress")]
        InProgress,

        [Description("Resolved")]
        Resolved,

        [Description("Closed")]
        Closed
    }
}
