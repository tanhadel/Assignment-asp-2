using System.ComponentModel.DataAnnotations;

namespace SubApi_1.Models;

public class SubcribeForm
{

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    public bool DailyNewsletter { get; set; }
    public bool AdvertisingUpdates { get; set; }
    public bool WeekInReview { get; set; }
    public bool EventUpdates { get; set; }
    public bool StartupsWeekly { get; set; }
    public bool Podcasts { get; set; }

}
