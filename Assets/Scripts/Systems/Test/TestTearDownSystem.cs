using Entitas;

namespace Systems.Test
{
    public class TestTearDownSystem : ITearDownSystem
    {
        public void TearDown()
        {
            UnityEngine.Debug.Log("TearDown");
        }
    }
}