using Core;
using Events;
using Objects.SpaceObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Objects.NavigationCircle
{
    public class NavigationCircle : ObjectBehaviour
    {
        [SerializeField] private NavigationArrow _navigationArrow;

        [SerializeField] private Image _hitPoints;
        [SerializeField] private Image _shield;


        private void AddArrow(SpaceObject target)
        {
            if (target == LevelManager.InstancedPlayer) return;
            var arrow = Instantiate(_navigationArrow, transform);
            arrow.SetTarget(target);
        }

        protected override void Initialize()
        {
            NavigationEvent.AddArrow.AddListener(AddArrow);
            LevelEvent.PlayerDeath.AddListener(DestroyItSelf);
        }

        protected override void Execute()
        {
            if (LevelManager.InstancedPlayer == null) return;
            transform.position = LevelManager.InstancedPlayer.transform.position; //TODO: Fix motionlag
            var playerShip = LevelManager.InstancedPlayer;
            _hitPoints.fillAmount = playerShip.HealthStats.HitPoints.GetPercent();
            _shield.fillAmount = playerShip.HealthStats.Shield.GetPercent();
        }


        private void DestroyItSelf()
        {
            Destroy(gameObject);
        }
    }
}