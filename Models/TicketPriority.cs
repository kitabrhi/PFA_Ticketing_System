using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace Ticketing_System.Models
{
    public enum TicketPriority
    {
        [Description("Low Priority")]
        Low,

        [Description("Medium Priority")]
        Medium,

        [Description("High Priority")]
        High,

        [Description("Critical Priority")]
        Critical
    }
}
