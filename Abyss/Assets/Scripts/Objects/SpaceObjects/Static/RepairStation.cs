using Modules.HealthStats;
using Objects.Gui;
using UnityEngine;

namespace Objects.SpaceObjects.Static
{
    public class RepairStation : SpaceObject
    {
        [SerializeField] private StationGui stationGui;

        [SerializeField] private int repairTax = 1;
        
        private int _playerHitPointsDifference;
        private Stat _playerHitPoints;
        private int _creditsForRepair;
        
        public void OnRepair()
        {
            _playerHitPoints = LevelManager.InstancedPlayer.HealthStats.HitPoints;
            PlayersAccount.TryRemoveCredits(_playerHitPointsDifference * repairTax, out var success);
            if (success)
            {
                _playerHitPoints.Add(_playerHitPoints.GetDifference());
                UpdateUi();
            }
        }
        
        
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (LevelManager.InstancedPlayer == null) return;
            if (other.gameObject != LevelManager.InstancedPlayer.gameObject) return;
            PlayersAccount.DepositToSave();

            _playerHitPointsDifference = ReadPlayerHitPointsDifference();
            _creditsForRepair = _playerHitPointsDifference * repairTax;
            UpdateUi();
        }
        
        protected override void Execute()
        {
            
        }
        
        
        private int ReadPlayerHitPointsDifference()
        {
            return LevelManager.InstancedPlayer.HealthStats.HitPoints.GetDifference();
        }

        private void UpdateUi()
        {
            stationGui.SetCredits(_creditsForRepair);
            stationGui.SetButtonColor(PlayersAccount.HaveEnoughCredits(_creditsForRepair));
        }
    }
}