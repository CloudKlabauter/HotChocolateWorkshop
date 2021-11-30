namespace ConferencePlanner.GraphQL.Attendees;

public class RegisterAttendeeInput
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;
}