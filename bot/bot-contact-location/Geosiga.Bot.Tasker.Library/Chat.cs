namespace Geosiga.Bot.Tasker.Library
{
    public class Service
    {
        public int Id { get; set; }
        public string Order { get; set; }
        public string Type { get; set; }

    }
    public class Chat
    {
        /// <summary>
        /// Active Order
        /// </summary>
        public Service Service { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; }


        public long DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceImei { get; set; }
        public string DevicePhone { get; set; }
        public string DeviceLocation { get; set; }


        public bool HasWorkerInfo { get; set; }
        public string WorkerName { get; set; }
        public string WorkerPhone { get; set; }
        public float WorkerLatitude { get; set; }
        public float WorkerLongitude { get; set; }


        public string Reason { get; set; }
        public bool Unproductive { get; set; }
    }
}
 