using System.ComponentModel.DataAnnotations;

namespace Smart.Meters.Model
{
    public interface IWizard
    {
    }

    public enum Protocol
    {
        HDLC,
        DLMS,
    }
    public enum Phase
    {
        Single,
        TwoPhase,
        ThreePhase,
    }
    public class Log
    {
        public int ID { get; set; }
        public int MeterID { get; set; }
        public Meter? Meter { get; set; } = new();

        public string Message { get; set; } = default!;
        public DateTime Date { get; set; }
    }
    public class Meter : IWizard
    {
        public int ID { get; set; }
        public string Model { get; set; } = default!;
        public string Seal { get; set; } = default!;
        public Phase? Type { get; set; } = Phase.Single;
        public DateTime InstallationDate { get; set; }

        public List<Reading>? Readings { get; set; } = new();
        public List<Log>? Logs { get; set; } = new();
        //public int ProfileID { get; set; }
        public Profile? Profile { get; set; }// = new();
    }
    public class Reading
    {
        public int ID { get; set; }
        public int MeterID { get; set; }
        public Meter? Meter { get; set; } = new();
        
        public DateTime Date { get; set; }

        public double TotalImpActiveEnergy { get; set; }
        public double ImpActiveEnergyT1 { get; set; }
        public double ImpActiveEnergyT2 { get; set; }
        public double ImpActiveEnergyT3 { get; set; }
        public double ImpActiveEnergyT4 { get; set; }

        public double TotalExpActiveEnergy { get; set; }
        public double ExpActiveEnergyT1 { get; set; }
        public double ExpActiveEnergyT2 { get; set; }
        public double ExpActiveEnergyT3 { get; set; }
        public double ExpActiveEnergyT4 { get; set; }
    }
    public class Profile : IWizard
    {
        public int ID { get; set; }
        public int MeterID { get; set; }
        public Meter? Meter { get; set; } = new();

        [Required] public string IP { get; set; } = default!;
        [Required] public string Port { get; set; } = default!;
        [Required] public string SimCardNumber { get; set; } = default!;

        [Required] public string HDLC_Address { get; set; } = default!;
        public Protocol LinkLayerProtocol { get; set; }
        public Protocol ApplicationLayerProtocol { get; set; }

        [Required] public string TransmissionMode { get; set; } = default!;
        [Required] public string MeterRemoteMode { get; set; } = default!;
    }
}
