using Services.Interfaces;
using UnityEngine;

namespace Services
{
    public class UnityDebugLogService : ILogService
    {
        public void LogMessage(string message)
        {
            Debug.Log(message);
        }
    }
}