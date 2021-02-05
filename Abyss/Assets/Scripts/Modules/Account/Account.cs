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



        public void Initialize()
        {
            Load();
        }
        
        private void Save()
        {
            _haveProgress = true;
        }

        private void SetPremium()
        {
            _isPremium = true;
        }
        
        private void Load()
        {
            
        }

        private void Reset()
        {
            _haveProgress = false;
        }
        
        private void DepositToSave()
        {
            accountSavedAccountResources.AddCredits(onShipAccountResources.GetCredits());
            onShipAccountResources.ResetCredits();
            accountSavedAccountResources.AddCredits(onShipAccountResources.GetMaterials());
            onShipAccountResources.ResetMaterials();
        }

        private void TryRemoveCredits(GameObject target, int creditsValue)
        {
            accountSavedAccountResources.TryRemoveCredits(creditsValue, out var success);
        }
        
        private void TryRemoveMaterials(GameObject target, int materialsValue)
        {
            accountSavedAccountResources.TryRemoveMaterials(materialsValue, out var success);
        }

        private void TryRemoveResources(GameObject target, int creditsValue, int materialsValue)
        {
            accountSavedAccountResources.TryRemoveCredits(creditsValue, out var success);
            accountSavedAccountResources.TryRemoveMaterials(materialsValue, out success);
        }
    }
}