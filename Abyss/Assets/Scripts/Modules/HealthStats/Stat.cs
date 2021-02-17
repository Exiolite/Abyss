using UnityEngine;

namespace Modules.HealthStats
{
    [System.Serializable]
    public class Stat
    {
        public float StatValue => _statValue;
        
        [SerializeField] private float _statValue;
        [SerializeField] private float _maxStatValue;
        [SerializeField] private float _regenerateValue;


        
        public void Add(float value)
        {
            _statValue = Mathf.Clamp(_statValue + value, 0, _maxStatValue);
        }

        public int GetDifference()
        {
            return (int)_maxStatValue - (int)_statValue;
        }
        
        public void Remove(float value)
        {
            _statValue = Mathf.Clamp(_statValue - value, 0, _maxStatValue);
        }
        
        public void SetStat(float value)
        {
            _statValue = value;
        }

        public float GetPercent()
        {
            return _statValue / _maxStatValue;
        }
        
        public void RegenerateStat()
        {
            _statValue = Mathf.Clamp(_statValue + (_regenerateValue * Time.deltaTime), 0, _maxStatValue);
        }
        
        public bool IsEnough(float value)
        {
            return _statValue > value;
        }
        
        public bool CheckUnderZero()
        {
            return _statValue > 0;
        }

        public bool CheckStatRegenerated()
        {
            return _statValue == _maxStatValue;
        }
    }
}