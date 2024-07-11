namespace TimerService.API.Models
{
    public class TimerList
    {
        public Guid Id { get; set; }
        public string Given {  get; set; }
        public string When { get; set; }
        public string Then { get; set; }
    }
}
