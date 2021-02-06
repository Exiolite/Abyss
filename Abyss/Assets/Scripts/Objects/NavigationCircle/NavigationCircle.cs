using Core;
using Objects.SpaceObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Objects.NavigationCircle
{
    public class NavigationCircle : ObjectBehaviour
    {
        [SerializeField] private NavigationArrow navigationArrow;

        [SerializeField] private Image hitPoints;
        [SerializeField] private Image shield;

        
        private void AddArrow(SpaceObject target)
        {
            if(target == LevelManager.InstancedPlayer) return;
            var arrow = Instantiate(navigationArrow, transform);
            arrow.SetTarget(target);
        }
        
        protected override void Initialize()
        {
            NavigationEvent.AddArrow.AddListener(AddArrow);
        }
        
        protected override void Execute()
        {
            if (LevelManager.InstancedPlayer == null) return;
            transform.position = LevelManager.InstancedPlayer.transform.position; //TODO: Fix motionlag
            var playerShip = LevelManager.InstancedPlayer;
            hitPoints.fillAmount = playerShip.HealthStats.HitPoints.GetPercent();
            shield.fillAmount = playerShip.HealthStats.Shield.GetPercent();
        }
    }
}