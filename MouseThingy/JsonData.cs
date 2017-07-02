using System.Runtime.Serialization;

namespace MouseThingy
{
    [DataContract]
    public class JsonData
    {
        public JsonData()
        {

        }

        public JsonData(decimal fov, decimal offset, string hSensitivity, string vSensitivity)
        {
            Fov = fov;
            CrosshairOffset = offset;
            HorizontalSensitivty = hSensitivity;
            VerticalSensitvity = vSensitivity;
        }

        [DataMember]
        public decimal Fov
        {
            get; set;
        }

        [DataMember]
        public decimal CrosshairOffset
        {
            get; set;
        }

        [DataMember]
        public string HorizontalSensitivty
        {
            get; set;
        }

        [DataMember]
        public string VerticalSensitvity
        {
            get; set;
        }
    }
}
