using System.Runtime.Serialization;

namespace MouseThingy
{
    [DataContract]
    public class JsonData
    {
        public JsonData(decimal fov, decimal offset, decimal hSensitivity, decimal vSensitivity)
        {
            Fov = fov;
            CrosshairOffset = offset;
            HorizontalSensitivty = hSensitivity;
            VerticalSensitvity = vSensitivity;
        }

        [DataMember]
        public decimal Fov { get; set; }

        [DataMember]
        public decimal CrosshairOffset { get; set; }

        [DataMember]
        public decimal HorizontalSensitivty { get; set; }

        [DataMember]
        public decimal VerticalSensitvity { get; set;}
    }
}
