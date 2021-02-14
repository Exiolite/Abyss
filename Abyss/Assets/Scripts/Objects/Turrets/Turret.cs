using System.Collections;
using Modules.Movements;
using Objects.SpaceObjects;
using UnityEngine;

namespace Objects.Turrets
{
    public abstract class Turret : MonoBehaviour
    {
        //Turret attributes
        [SerializeField] private float attackDelay;
        private bool isAttacking;
        
        //Modules
        [SerializeField] private Movement movement;
        
        

        protected abstract void AttackTarget(SpaceObject target);
        
        
        
        public void SetTarget(SpaceObject target)
        {
            movement.HardRotateToTarget(transform, target.transform);
            StartCoroutine(AttackCoroutine(target));
        }
        


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