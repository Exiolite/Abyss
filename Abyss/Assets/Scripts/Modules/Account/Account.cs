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
            
            EventAccount.Save.AddListener(Save);
            EventAccount.Load.AddListener(Load);
            EventAccount.Reset.AddListener(Reset);
            EventAccount.SetPremium.AddListener(SetPremium);
            EventAccount.CallHaveProgress.AddListener(CallBackHaveProgress);
            EventAccount.CallPremium.AddListener(CallBackPremium);
            EventAccount.CallIsAlive.AddListener(CallBackIsAlive);

            EventAccountResources.AddCreditsToSave.AddListener(accountSavedAccountResources.AddCredits);
            EventAccountResources.AddMaterialsToSave.AddListener(accountSavedAccountResources.AddMaterials);
            EventAccountResources.CallForRemoveCredits.AddListener(TryRemoveCredits);
            EventAccountResources.CallForRemoveMaterials.AddListener(TryRemoveMaterials);
            EventAccountResources.CallForRemoveResources.AddListener(TryRemoveResources);
            EventAccountResources.CallForDepositFromShip.AddListener(DepositToSave);
        }
        
        
        
        //Account
        private void Save()
        {
            PlayerPrefs.SetInt("HaveProgress", 1);
            _haveProgress = true;
        }

        private void SetPremium()
        {
            PlayerPrefs.SetInt("Premium", 1);
            _isPremium = true;
        }
        
        private void Load()
        {
            if (PlayerPrefs.HasKey("Premium"))
            {
                if (PlayerPrefs.GetInt("Premium") == 1) _isPremium = true;
            }
            if (PlayerPrefs.HasKey("HaveProgress"))
            {
                if (PlayerPrefs.GetInt("HaveProgress") == 1) _haveProgress = true;
            }
        }

        private void Reset()
        {
            _haveProgress = false;
        }

        private void CallBackPremium(GameObject target)
        {
            EventAccount.CallBackPremium.Invoke(target,_isPremium);
        }

        private void CallBackHaveProgress(GameObject target)
        {
            EventAccount.CallBackHaveProgress.Invoke(target, _haveProgress);
        }

        private void CallBackIsAlive()
        {
            EventAccount.CallBackIsAlive.Invoke(_isPlayerAlive);
        }
        
        
        
        //Account Resources
        private void DepositToSave()
        {
            accountSavedAccountResources.AddCredits(onShipAccountResources.GetCredits());
            onShipAccountResources.ResetCredits();
            EventAccountResources.UpdateCreditsSaved.Invoke(accountSavedAccountResources.GetCredits());
            EventAccountResources.UpdateCreditsShip.Invoke(onShipAccountResources.GetCredits());
            accountSavedAccountResources.AddCredits(onShipAccountResources.GetMaterials());
            onShipAccountResources.ResetMaterials();
            EventAccountResources.UpdateMaterialsSaved.Invoke(accountSavedAccountResources.GetMaterials());
            EventAccountResources.UpdateMaterialsShip.Invoke(onShipAccountResources.GetMaterials());
        }

        private void TryRemoveCredits(GameObject target, int creditsValue)
        {
            accountSavedAccountResources.TryRemoveCredits(creditsValue, out var success);
            EventAccountResources.CallBackRemoveCredits.Invoke(target,success);
        }
        
        private void TryRemoveMaterials(GameObject target, int materialsValue)
        {
            accountSavedAccountResources.TryRemoveMaterials(materialsValue, out var success);
            EventAccountResources.CallBackRemoveMaterials.Invoke(target, success);
        }

        private void TryRemoveResources(GameObject target, int creditsValue, int materialsValue)
        {
            accountSavedAccountResources.TryRemoveCredits(creditsValue, out var success);
            accountSavedAccountResources.TryRemoveMaterials(materialsValue, out success);
            EventAccountResources.CallBackForRemoveResources.Invoke(target, success);
        }
    }
}