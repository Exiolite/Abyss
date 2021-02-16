using System.Collections;
using Modules.Movements;
using Objects.SpaceObjects;
using Objects.SpaceObjects.Dynamic;
using UnityEngine;

namespace Objects.Turrets
{
    public class Projectile : MonoBehaviour
    {
        //Projectile attributes
        [SerializeField] private float _damage;

        //Modules
        [SerializeField] private Movement _movement;

        //Targeting
        private protected SpaceObject Target;


        public void SetTarget(SpaceObject target)
        {
            Target = target;
        }


        private void Start()
        {
            StartCoroutine(Destroy());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (Target == null) return;
            if (other.gameObject == Target.gameObject)
            {
                var dynamicTarget = (Ship) Target;
                dynamicTarget.ApplyDamage(_damage);
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            _movement.HardMoveRandomSpeed(transform);
        }

        private IEnumerator Destroy()
        {
            yield return new WaitForSeconds(5);
            Destroy(gameObject);
        }
    }
}