using System.Collections;
using Modules.Movements;
using Objects.SpaceObjects;
using UnityEngine;

namespace Objects.Turrets
{
    public abstract class Turret : MonoBehaviour
    {
        //Turret attributes
        [SerializeField] private float _attackDelay;
        private bool _isAttacking;
        
        //Modules
        [SerializeField] private Movement _movement;


        protected abstract void AttackTarget(SpaceObject target);

        
        
        public void SetTarget(SpaceObject target)
        {
            _movement.HardRotateToTarget(transform, target.transform);
            StartCoroutine(AttackCoroutine(target));
        }
        


        private IEnumerator AttackCoroutine(SpaceObject target)
        {
            if (_isAttacking) yield break;
            _isAttacking = true;
            AttackTarget(target);
            yield return new WaitForSeconds(_attackDelay);
            _isAttacking = false;
        }
    }
}