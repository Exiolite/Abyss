using UnityEngine;

namespace Modules.HealthStats
{
    [System.Serializable]
    public class Stat
    {

        [SerializeField] private float statValue;
        public float StatValue => statValue;
        
        [SerializeField] private float maxStatValue;
        public float MaxStatValue => maxStatValue;
        
        [SerializeField] private float regenerateValue;


        
        
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
        
        public bool CheckStat()
        {
            return (statValue > 0);
        }

        public bool CheckStatRegenerated()
        {
            return !(statValue == maxStatValue);
        }
    }
}