using Services.Interfaces;
using Zenject;

namespace Services
{
    public class UnityTimeService : ITimeService, ITickable, IFixedTickable
    {
        public float DeltaTime { get; set; }
        public float FixedDeltaTime { get; set; }
        public float Time { get; set; }

        public void Tick()
        {
            Time = UnityEngine.Time.time;
            DeltaTime = UnityEngine.Time.deltaTime;
        }

        public void FixedTick()
        {
            FixedDeltaTime = UnityEngine.Time.fixedDeltaTime;
        }
    }
}