using Core;
using Modules.Movements;
using Objects.SpaceObjects;
using Objects.SpaceObjects.Dynamic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Objects.NavigationCircle
{
    public class NavigationArrow : ObjectBehaviour
    {
        //Arrow
        [SerializeField] private GameObject toTargetSpring;
        [SerializeField] private GameObject toTargetStatsHolder;
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
            arrowCollider.transform.eulerAngles = new Vector3(0,0,0);
        }

        
        
        private void DestroyItSelf(SpaceObject target)
        {
            if (_target == target)
            {
                NavigationEvent.RemoveArrow.RemoveListener(DestroyItSelf);
                Destroy(gameObject);
            }
        }

        private void UpdateArrow()
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
    }
}