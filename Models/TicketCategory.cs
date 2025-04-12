using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace Ticketing_System.Models
{
    public enum TicketCategory
    {
        [Description("Software Issue")]
        SoftwareIssue,

        [Description("Hardware Issue")]
        HardwareIssue,

        [Description("Network Problem")]
        NetworkProblem,

        [Description("General Inquiry")]
        GeneralInquiry
    }
}
