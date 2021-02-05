using UnityEngine;

namespace Modules.HealthStats
{
    [System.Serializable]
    public class Stat
    {
        [SerializeField] private float statValue;
        [SerializeField] private float maxStatValue;
        [SerializeField] private float regenerateValue;


        public void Remove(float value)
        public void SetStat(float value)
        {
            statValue = value;
        }

        public float GetPercent()
        {
            return statValue / maxStatValue;
        }
        
        public void RegenerateStat()
        {
            statValue = Mathf.Clamp(statValue + (regenerateValue * Time.deltaTime), 0, maxStatValue);
        }
        
        public bool IsEnough(float value)
        {
            return statValue > value;
        }

        public bool CheckStatRegenerated()
        {
            return !(statValue == maxStatValue);
        }
    }
}