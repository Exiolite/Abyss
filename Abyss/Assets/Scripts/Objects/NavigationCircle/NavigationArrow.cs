using Core;
using Modules.Movements;
using Objects.SpaceObjects;
using Objects.SpaceObjects.Dynamic;
using Statics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Objects.NavigationCircle
{
    public class NavigationArrow : ObjectBehaviour
    {
        //Arrow
        [SerializeField] private GameObject toTargetSpring;
        [SerializeField] private GameObject canvasRotator;
        [SerializeField] private ArrowCollider arrowCollider;
        //TargetCanvas
        [SerializeField] private TextMeshProUGUI objectName;
        [SerializeField] private Image hitPoints;
        [SerializeField] private Image shield;
        
        [SerializeField, HideInInspector] private Movement movement;
        
        private SpaceObject _target;

        
        
        public void SetTarget(SpaceObject target)
        {
            _target = target;
            objectName.text = _target.ObjName;
        }

        public void SetPlayersTarget()
        {
            LevelManager.InstancedPlayer.SetTarget(_target);
        }
        
        
        
        protected override void Initialize()
        {
            NavigationEvent.RemoveArrow.AddListener(DestroyItSelf);
        }

        protected override void Execute()
        {
            if (_target == null) return;
            movement.HardRotateToTarget(transform, _target.transform);
            UpdateArrow();
        }

        
        
        private void UpdateArrow()
        {
            UpdateTargetStats();
            UpdateSpring();
        }

        private void UpdateTargetStats()
        {
            if (_target.GetType() == typeof(Ship))
            {
                var targetShip = (Ship) _target;
                shield.fillAmount = targetShip.HealthStats.Shield.GetPercent();
                hitPoints.fillAmount = targetShip.HealthStats.HitPoints.GetPercent();
            }
            else
            {
                shield.fillAmount = 0;
                hitPoints.fillAmount = 0;
            }
        }

        private void UpdateSpring()
        {
            canvasRotator.transform.eulerAngles = new Vector3(0,0,0);
            var distanceToTarget = RangeFinder.CalculateDistance(transform, _target);
            if (distanceToTarget < 15)
            {
                toTargetSpring.transform.localPosition = new Vector3(distanceToTarget, 0,0);
                arrowCollider.transform.localPosition = new Vector3(0,4,0);
            }
            else
            {
                toTargetSpring.transform.localPosition = new Vector3(15, 0,0);
                arrowCollider.transform.localPosition = new Vector3(0,0,0);
            }
        }

        private void DestroyItSelf(SpaceObject target)
        {
            if (_target == target)
            {
                NavigationEvent.RemoveArrow.RemoveListener(DestroyItSelf);
                Destroy(gameObject);
            }
        }
    }
}