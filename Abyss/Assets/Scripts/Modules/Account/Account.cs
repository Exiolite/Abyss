using UnityEngine;

namespace Modules.Account
{
    public class Account
    {
        private readonly AccountResources accountSavedAccountResources = new AccountResources();
        private readonly AccountResources onShipAccountResources = new AccountResources();

        private bool _isPremium;
        private bool _haveProgress;
        private bool _isPlayerAlive;

        private string _playerShipName;


        public void Initialize()
        {
            Load();
        }
        
        
        
        //Account parameters
        public void Save()
        {
            _haveProgress = true;
        }

        public void SetPremium()
        {
            _isPremium = true;
        }
        
        private void Load()
        {
            if (_haveProgress)
            {
                
            }
            else
            {
                _playerShipName = "Falcon";
            }
        }

        public void Reset()
        {
            _haveProgress = false;
        }
        
        //Ship
        public string GetPlayersShipName()
        {
            return _playerShipName;
        }
        
        
        //Resources actions
        public void DepositToSave()
        {
            accountSavedAccountResources.AddCredits(onShipAccountResources.GetCredits());
            onShipAccountResources.ResetCredits();
            accountSavedAccountResources.AddCredits(onShipAccountResources.GetMaterials());
            onShipAccountResources.ResetMaterials();
        }

        public void TryRemoveCredits(int creditsValue, out bool success)
        {
            accountSavedAccountResources.TryRemoveCredits(creditsValue, out success);
        }
        
        public void TryRemoveMaterials(int materialsValue, out bool success)
        {
            accountSavedAccountResources.TryRemoveMaterials(materialsValue, out success);
        }

        public void TryRemoveResources(int creditsValue, int materialsValue, out bool success)
        {
            accountSavedAccountResources.TryRemoveCredits(creditsValue, out success);
            accountSavedAccountResources.TryRemoveMaterials(materialsValue, out success);
        }
    }
}