namespace PostOfficeBackend.Entities
{
    public class Parcel
    {
        public int Id { get; set; }
        public string Recipient { get; set; }
        public decimal Weight { get; set; }
        public string Phone { get; set; }
        public string Info { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
