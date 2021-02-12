using Objects.SpaceObjects.Dynamic;
using UnityEngine;

namespace Objects.SpaceObjects.Static
{
    public class ShipYard : Station
    {
        [SerializeField] private Transform spawnPosition;
        
        private Ship _marketShip;
        
        
        
        public void OnBuyShip() // GUI Button Event.
        {
            TryRemoveCredits(_marketShip.ShipPriceCredits , out var successRemovedCredits);
            TryRemoveMaterials(_marketShip.ShipPriceMaterials, out var successRemovedMaterials);
            if (successRemovedCredits && successRemovedMaterials)
            {
                SwitchPlayerToShip();
            }
        }
        
        

        protected override void Initialize()
        {
            base.Initialize();
            SpawnShip();
        }

        protected override void Execute()
        {
            
        }



        private void SwitchPlayerToShip()
        {
            LevelManager.SetPlayersShip(_marketShip);
            PlayersAccount.SetPlayerShipName(_marketShip.ObjName);
        }

        private void SpawnShip()
        {
            _marketShip = LevelManager.SpawnRandomShipOnShipYard(spawnPosition);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (LevelManager.InstancedPlayer == null) return;
            if (other.gameObject != LevelManager.InstancedPlayer.gameObject) return;
            PlayersAccount.DepositToSave();
            
            UpdateCreditsUi(_marketShip.ShipPriceCredits);
            UpdateMaterialsUi(_marketShip.ShipPriceMaterials);
        }
    }
}