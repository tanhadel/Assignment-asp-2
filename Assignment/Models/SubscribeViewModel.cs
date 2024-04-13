using System.ComponentModel.DataAnnotations;

namespace Assignment.Models;

public class SubscribeViewModel
{      
    [Display(Name = "", Prompt = "Your Email")]
    [Required(ErrorMessage = "A valid email address is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    public bool DailyNewsletter { get; set; }
    public bool AdvertisingUpdates { get; set; }
    public bool WeekInReview { get; set; }
    public bool EventUpdates { get; set; }
    public bool StartupsWeekly { get; set; }
    public bool Podcasts { get; set; }




}
