using System;

/* 8. Create a class Call to hold a call performed through a GSM.
 * It should contain date, time, dialed phone number and duration (in seconds).
 */
class Call
{
    public DateTime Date { get; set; }
    public string PhoneNumber { get; set; }
    public uint DurationInSeconds { get; set; }

    public Call(DateTime date, string phoneNumber, uint durationInSeconds)
    {
        this.Date = date;
        this.PhoneNumber = phoneNumber;
        this.DurationInSeconds = durationInSeconds;
    }

    public override string ToString()
    {
        string result = String.Format("Call at: {0,40}\nto number: {1,30}\nduration (in seconds): {2,15}.", this.Date, this.PhoneNumber, this.DurationInSeconds);
        return result;
    }
}