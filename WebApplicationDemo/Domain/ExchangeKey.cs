namespace Domain
{
    public class ExchangeKey
    {
        public int Id { get; set; }
        public ulong P { get; set; }
        public ulong G { get; set; }
        public ulong ASecret { get; set; }
        public ulong BSecret { get; set; }
        public ulong CommonSecret { get; set; }
    }
}