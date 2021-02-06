using System.Collections;
using Modules.Movements;
using Objects.SpaceObjects;
using UnityEngine;

namespace Objects.Turrets
{
    public abstract class TurretBehaviour : MonoBehaviour
    {
        [SerializeField] private float attackDelay;
        [SerializeField] private Movement movement;
        
        
        private bool isAttacking;
        

        public void SetTarget(SpaceObject target)
        {
            movement.HardRotateToTarget(transform, target.transform);
            StartCoroutine(AttackCoroutine(target));
        }
        

        protected abstract void AttackTarget(SpaceObject target);

        private IEnumerator AttackCoroutine(SpaceObject target)
        {
            if (isAttacking) yield break;
            isAttacking = true;
            AttackTarget(target);
            yield return new WaitForSeconds(attackDelay);
            isAttacking = false;
        }
    }
}