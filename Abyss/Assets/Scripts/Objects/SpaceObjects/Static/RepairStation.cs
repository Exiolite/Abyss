using UnityEngine;

namespace Objects.SpaceObjects.Static
{
    public class RepairStation : SpaceObject
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (LevelManager.InstancedPlayer == null) return;
            if (other.gameObject != LevelManager.InstancedPlayer.gameObject) return;
            PlayersAccount.DepositToSave();
        }
        
        protected override void Execute()
        {
            
        }
    }
}