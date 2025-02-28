namespace register_and_login.Models
{
    public class product
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }

        public category categorys { get; set; }

        public int CategoryId { get; set; }

    }
}
