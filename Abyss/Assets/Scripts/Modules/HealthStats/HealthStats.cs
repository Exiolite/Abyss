using UnityEngine;

namespace Modules.HealthStats
{
    [System.Serializable]
    public class HealthStats
    {
        [SerializeField] private Stat hitPoints;
        [SerializeField] private Stat shield;



        public void Add(float hitPointsValue, float shieldValue)
        {
            hitPoints.Add(hitPointsValue);
            shield.Add(shieldValue);
        }

        public void TryRemoveHitPoints(float value, out bool success)
        {
            if (hitPoints.IsEnough(value))
            {
                hitPoints.Remove(value);
                success = true;
            }
            else
            {
                success = false;
            }
        }
        public void TryRemoveShield(float value, out bool success)
        {
            if (shield.IsEnough(value))
            {
                shield.Remove(value);
                success = true;
            }
            else
            {
                success = false;
            }
        }
    }
}