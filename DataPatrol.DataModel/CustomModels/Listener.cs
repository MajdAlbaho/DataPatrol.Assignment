namespace DataPatrol.DataModel.CustomModels
{
    public class Listener
    {
        public string Name { get; set; }
        public int Target { get; set; }
        public int Counter { get; private set; }
    }
}
