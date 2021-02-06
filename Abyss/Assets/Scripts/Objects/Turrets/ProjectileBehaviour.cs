using System;
using System.Collections;
using Modules.Movements;
using Objects.SpaceObjects;
using Objects.SpaceObjects.Dynamic;
using UnityEngine;

namespace Objects.Turrets
{
    public class ProjectileBehaviour : MonoBehaviour
    {
        [SerializeField] private Movement movement;
        [SerializeField] private float damage;
        
        private protected SpaceObject Target;


        
        private void Start()
        {
            StartCoroutine(Destroy());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (Target == null) return;
            if (other.gameObject == Target.gameObject)
            {
                var dynamicTarget = (Ship)Target;
                dynamicTarget.ApplyDamage(damage);
                Destroy(gameObject);
            }
        }

        public void SetTarget(SpaceObject target)
        {
            Target = target;
        }

        private void Update()
        {
            movement.MoveShipForward(transform);
        }

        private IEnumerator Destroy()
        {
            yield return new WaitForSeconds(5);
            Destroy(gameObject);
        }
    }
}