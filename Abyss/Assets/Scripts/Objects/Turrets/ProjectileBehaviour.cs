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
        
        private protected Ship Target;


        
        private void Start()
        {
            StartCoroutine(Destroy());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (Target == null) return;
            if (other.gameObject == Target.gameObject)
            {
                Target.ApplyDamage(damage);
                Destroy(gameObject);
            }
        }

        public void SetTarget(SpaceObject target)
        {
            Target = (Ship)target;
        }

        private void Update()
        {
            if (Target == null) return;
            movement.MoveShipForward(transform);
        }

        private IEnumerator Destroy()
        {
            yield return new WaitForSeconds(5);
            Destroy(gameObject);
        }
    }
}