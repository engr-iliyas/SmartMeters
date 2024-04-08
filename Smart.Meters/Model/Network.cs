namespace Smart.Meters.Model
{
    public abstract class Network
    {
        public string? Description { get; set; }
        public string? Code { get; set; }
    }
    public class F33KV : Network
    {
        public int ID { get; set; }
        public List<F11KV>? Feeders { get; set; } = new();
    }
    public class F11KV : Network
    {
        public int ID { get; set; }
        public int F33KVID { get; set; }
        public F33KV? F33KV { get; set; } = new();

        public List<Transformer>? Transformers { get; set; } = new();
    }
    public class Transformer : Network
    {
        public int ID { get; set; }
        public List<Customer>? Customers { get; set; } = new();
    }
}
