namespace apiProject
{
    public class eventObject
    {
        public string id { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string status { get; set; }
        public string subject { get; set; }
    }

        public class EventApiResponse
    {
        public string email { get; set; }
        public int number_of_events { get; set; }
        public eventObject[] events { get; set; }


    }
}
