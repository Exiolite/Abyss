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


        public Account()
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

        public void SetPlayerShipName(string name)
        {
            _playerShipName = name;
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

        public void AddResourcesToShip(int creditsValue, int materialsValue)
        {
            onShipAccountResources.AddCredits(creditsValue);
            onShipAccountResources.AddMaterials(materialsValue);
            Debug.Log(onShipAccountResources.GetCredits() + " " + onShipAccountResources.GetMaterials());
        }
        
        public void DepositToSave()
        {
            accountSavedAccountResources.AddCredits(onShipAccountResources.GetCredits());
            onShipAccountResources.ResetCredits();
            accountSavedAccountResources.AddMaterials(onShipAccountResources.GetMaterials());
            onShipAccountResources.ResetMaterials();
        }

        public void TryRemoveCredits(int creditsValue, out bool success)
        {
            accountSavedAccountResources.TryRemoveCredits(creditsValue, out success);
        }

        public bool HaveEnoughCredits(int value)
        {
            return accountSavedAccountResources.GetCredits() > value;
        }
        
        public void TryRemoveMaterials(int materialsValue, out bool success)
        {
            accountSavedAccountResources.TryRemoveMaterials(materialsValue, out success);
        }
        
        public bool HaveEnoughMaterials(int value)
        {
            return accountSavedAccountResources.GetMaterials() > value;
        }

        public void TryRemoveResources(int creditsValue, int materialsValue, out bool success)
        {
            accountSavedAccountResources.TryRemoveCredits(creditsValue, out success);
            accountSavedAccountResources.TryRemoveMaterials(materialsValue, out success);
        }
    }
}