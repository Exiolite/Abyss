using UnityEngine;

namespace Core.LevelManager
{
    public class LevelCreator
    {
        private LevelManager _levelManager;



        public void Initialize(LevelManager levelManager)
        {
            _levelManager = levelManager;
        }

        
        
        public void CreateLevel()
        {
            CreatePlayer();
            CreateStation();
            CreateEnemies();
            CreateAbyss();
        }

        private void CreatePlayer()
        {
            if (_levelManager.InstancedPlayer != null) return;
            var playerShipName = Core.Instance.PlayersAccount.GetPlayersShipName();
            var playersShip = _levelManager.DataBase.TryFindPlayersShip(playerShipName, out var success);
            if (success) _levelManager.SetPlayer(_levelManager.Factory.SpawnPlayer(playersShip));
        }
        
        private void CreateStation()
        {
            if (_levelManager.DepthCounter % 10 == 0)
            {
                var shop = _levelManager.DataBase.TryGetRandomShop(out var success);
                if (success) _levelManager.Factory.SpawnSpaceObjectAtRange(shop);
            }

            if (_levelManager.DepthCounter % 5 != 0 || _levelManager.DepthCounter == 0) return;
            {
                var shipyardOrRepairStationChance = Random.Range(0, 100);
                if (shipyardOrRepairStationChance > 50)
                {
                    var shipYard = _levelManager.DataBase.TryGetRandomShipYard(out var success);
                    if (success) _levelManager.Factory.SpawnSpaceObjectAtRange(shipYard);
                }
                else
                {
                    var repairStation = _levelManager.DataBase.TryGetRandomRepairStation(out var success);
                    if (success) _levelManager.Factory.SpawnSpaceObjectAtRange(repairStation);
                }
            }
        }

        private void CreateEnemies()
        {
            
        }

        private void CreateAbyss()
        {
            var abyss = _levelManager.DataBase.TryGetRandomAbyss(out var succes);
            if (succes) _levelManager.Factory.SpawnSpaceObjectAtRange(abyss);
        }
    }
}