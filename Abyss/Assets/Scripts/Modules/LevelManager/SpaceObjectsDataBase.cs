using Core;
using Objects.SpaceObjects;
using UnityEngine;

namespace Modules.LevelManager
{
    [System.Serializable]
    public class SpaceObjectsDataBase
    {
        public SpaceObject[] Abysses => abysses;
        public SpaceObject[] Containers => containers;
        public SpaceObject[] RepairStations => repairStations;
        public SpaceObject[] ShipYards => shipYards;
        public SpaceObject[] Shops => shops;

        public SpaceObject[] EnemyShips => enemyShips;
        public SpaceObject[] MarketShips => marketShips;

        [Header("SpaceObjects")]
        [Header("Static")]
        [SerializeField] private SpaceObject[] abysses;
        [SerializeField] private SpaceObject[] containers;
        [SerializeField] private SpaceObject[] repairStations;
        [SerializeField] private SpaceObject[] shipYards;
        [SerializeField] private SpaceObject[] shops;
        [Header("Ships")]
        [SerializeField] private SpaceObject[] enemyShips;
        [SerializeField] private SpaceObject[] marketShips;

        public void CallBackDataBase()
        {
            EventCore.CallBackDataBase.Invoke(this);
        }
    }
}