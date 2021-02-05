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
        
        
        private protected SpaceObject Target;
        private bool isAttacking;
        

        public void SetTarget(SpaceObject target)
        {
            Target = target;
        }

        
        
        private void Update()
        {
            if (Target != null)
            {
                movement.HardRotateToTarget(transform, Target.transform);
                StartCoroutine(AttackCoroutine());
            }
        }

        protected abstract void AttackTarget();

        private IEnumerator AttackCoroutine()
        {
            if (isAttacking) yield break;
            isAttacking = true;
            AttackTarget();
            yield return new WaitForSeconds(attackDelay);
            isAttacking = false;
        }
    }
}