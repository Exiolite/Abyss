using System.Collections.Generic;
using System.Linq;
using Objects.SpaceObjects;
using Objects.SpaceObjects.Dynamic;
using UnityEngine;

namespace Core.LevelManager
{
    public class SpaceObjectsData
    {
        private readonly List<SpaceObject> _allSpaceObjects = new List<SpaceObject>();
        private SpaceObject[] _enemiesShips;
        private SpaceObject[] _marketShips;
        private SpaceObject[] _abysses;
        private SpaceObject[] _containersSmall;
        private SpaceObject[] _containersMedium;
        private SpaceObject[] _containersBig;
        private SpaceObject[] _repairStations;
        private SpaceObject[] _shipYards;
        private SpaceObject[] _shops;



        public void Initialize()
        {
            LoadResources();
        }
        
        
        
        //Ships
        public Ship TryFindPlayersShip(string shipName, out bool success)
        {
            return (Ship)TryFindObjectByName(shipName, out success);
        }
        
        
        
        //Stations
        public SpaceObject TryGetRandomRepairStation(out bool success)
        {
            var spaceObject = TryGetRandomObject(_repairStations, out success);
            if (success) return spaceObject;
            success = false;
            return null;
        }
        
        public SpaceObject TryGetRandomShipYard(out bool success)
        {
            var spaceObject = TryGetRandomObject(_shipYards, out success);
            if (success) return spaceObject;
            success = false;
            return null;
        }
        
        public SpaceObject TryGetRandomShop(out bool success)
        {
            var spaceObject = TryGetRandomObject(_shops, out success);
            if (success) return spaceObject;
            success = false;
            return null;
        }
        
        public SpaceObject TryGetRandomAbyss(out bool success)
        {
            var spaceObject = TryGetRandomObject(_abysses, out success);
            if (success) return spaceObject;
            success = false;
            return null;
        }



        private SpaceObject TryGetRandomObject(SpaceObject[] spaceObjects, out bool success)
        {
            if (spaceObjects.Length == 0)
            {
                success = false;
                return null;
            }
            success = true;
            return spaceObjects[Random.Range(0, spaceObjects.Length)];
        }
        
        private SpaceObject TryFindObjectByName(string objectName, out bool success)
        {
            foreach (var spaceObject in _allSpaceObjects.Where(spaceObject => objectName == spaceObject.ObjName))
            {
                success = true;
                return spaceObject;
            }
            success = false;
            return null;
        }
        
        private void LoadResources()
        {
            _enemiesShips = (Resources.LoadAll<SpaceObject>("Prefabs/SpaceObjects/Dynamic/EnemiesShips/"));
            _marketShips = (Resources.LoadAll<SpaceObject>("Prefabs/SpaceObjects/Dynamic/MarketShips/"));
            _abysses = (Resources.LoadAll<SpaceObject>("Prefabs/SpaceObjects/Static/Abysses/"));
            _containersSmall = (Resources.LoadAll<SpaceObject>("Prefabs/SpaceObjects/Static/Containers/Small/"));
            _containersMedium = (Resources.LoadAll<SpaceObject>("Prefabs/SpaceObjects/Static/Containers/Medium/"));
            _containersBig = (Resources.LoadAll<SpaceObject>("Prefabs/SpaceObjects/Static/Containers/Big/"));
            _repairStations = (Resources.LoadAll<SpaceObject>("Prefabs/SpaceObjects/Static/RepairStations/"));
            _shipYards = (Resources.LoadAll<SpaceObject>("Prefabs/SpaceObjects/Static/ShipYards/"));
            _shops = (Resources.LoadAll<SpaceObject>("Prefabs/SpaceObjects/Static/Shops/"));
            
            
            //Crutch resource load to list //TODO: TBD Resource Load
            foreach (var enemiesShip in _enemiesShips)
            {
                _allSpaceObjects.Add(enemiesShip);
            }

            foreach (var marketShip in _marketShips)
            {
                _allSpaceObjects.Add(marketShip);
            }

            foreach (var abyss in _abysses)
            {
                _allSpaceObjects.Add(abyss);
            }

            foreach (var container in _containersSmall)
            {
                _allSpaceObjects.Add(container);
            }

            foreach (var container in _containersMedium)
            {
                _allSpaceObjects.Add(container);
            }

            foreach (var container in _containersBig)
            {
                _allSpaceObjects.Add(container);
            }

            foreach (var repairStation in _repairStations)
            {
                _allSpaceObjects.Add(repairStation);
            }

            foreach (var shipYard in _shipYards)
            {
                _allSpaceObjects.Add(shipYard);
            }

            foreach (var shop in _shops)
            {
                _allSpaceObjects.Add(shop);
            }
        }
    }
}