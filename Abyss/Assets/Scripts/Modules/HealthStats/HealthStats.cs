using UnityEngine;

namespace Modules.HealthStats
{
    [System.Serializable]
    public class HealthStats
    {
        public Stat HitPoints => hitPoints;
        public Stat Shield => shield;
        
        [SerializeField] private Stat hitPoints;
        [SerializeField] private Stat shield;
        [SerializeField] private float delayBeforeRegenerateShield;


        public void Add(float hitPointsValue, float shieldValue)
        {
            hitPoints.Add(hitPointsValue);
            shield.Add(shieldValue);
        }

        public void RegenerateShield()
        {
            shield.RegenerateStat();
        }

        public void TryApplyDamage(float value, out bool isLastShot)
        {
            TryRemoveShield(value, out var success);
            if (!success)
            {
                TryRemoveHitPoints(value, out var haveHp);
                if (!haveHp)
                {
                    isLastShot = true;
                    return;
                }
                isLastShot = false;
            }
            isLastShot = false;
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
            if (shield.CheckUnderZero())
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