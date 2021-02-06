using Objects.SpaceObjects.Dynamic;
using Objects.SpaceObjects.Static;
using UnityEngine;

namespace Core.LevelManager
{
    public class SpaceObjectsData
    {
        private Ship[] _enemiesShips;
        private Ship[] _marketShips;
        
        private Abyss[] _abysses;
        private Container[] _containersSmall;
        private Container[] _containersMedium;
        private Container[] _containersBig;
        private RepairStation[] _repairStations;
        private ShipYard[] _shipYards;
        private Shop[] _shops;
        
        
        
        public void LoadData()
        {
            _enemiesShips = (Resources.LoadAll<Ship>("Prefabs/SpaceObjects/Dynamic/EnemiesShips/"));
            _marketShips = (Resources.LoadAll<Ship>("Prefabs/SpaceObjects/Dynamic/MarketShips/"));
            _abysses = (Resources.LoadAll<Abyss>("Prefabs/SpaceObjects/Static/Abysses/"));
            _containersSmall = (Resources.LoadAll<Container>("Prefabs/SpaceObjects/Static/Containers/Small/"));
            _repairStations = (Resources.LoadAll<RepairStation>("Prefabs/SpaceObjects/Static/RepairStations/"));
            _shipYards = (Resources.LoadAll<ShipYard>("Prefabs/SpaceObjects/Static/ShipYards/"));
            _shops = (Resources.LoadAll<Shop>("Prefabs/SpaceObjects/Static/Shops/"));
        }
    }
}