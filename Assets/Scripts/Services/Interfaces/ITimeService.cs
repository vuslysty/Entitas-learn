namespace Services.Interfaces
{
    public interface ITimeService
    {
        public float DeltaTime { get; }
        public float FixedDeltaTime { get; }
        public float Time { get; }
    }
}