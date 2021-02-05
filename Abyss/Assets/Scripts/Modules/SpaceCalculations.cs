using System;
using UnityEngine;

namespace Modules
{
    [Serializable]
    public static class SpaceCalculations
    {
        public static void CalculateAngleToTarget(Transform transform, Transform target, float value)
        {
            var deirectionToTarget = target.transform.position - transform.position;
            var angleToTarget = Mathf.Atan2(deirectionToTarget.y, deirectionToTarget.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angleToTarget + value);
        }

        public static void CalculateShipAngleToTarget(Transform transform, Transform target, float value)
        {
            var deirectionToTarget = target.transform.position - transform.position;
            var angleToTarget = Mathf.Atan2(deirectionToTarget.y, deirectionToTarget.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0,0, angleToTarget);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * value / 10);
        }


        public static void MoveShipForward(Transform transform, float speed)
        {
            transform.position += transform.right * (Time.deltaTime * speed);
        }
    
        public static void MicroWarpShip(Transform transform, float distance)
        {
            transform.position += transform.right * distance;
        }

    
        public static void MoveProjectileForward(Transform transform, float speed)
        {
            transform.position += transform.right * (Time.deltaTime * speed);
        }
    

        public static float LoadStatParameter(float maxValue, float value)
        {
            return Mathf.Clamp(value, 0, maxValue);
        }
    }
}