using Core;
using Events;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Objects.Gui
{
    public class DeathScreen : ObjectBehaviour
    {
        [SerializeField] private GameObject _deathPanel;
        [SerializeField] private TextMeshProUGUI _creditsToSave;
        [SerializeField] private TextMeshProUGUI _materialsToSave;
        
        
        public void ButtonWatchAd()
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show();
            }
            PlayersAccount.DepositQuadToSave();
            LevelEvent.RestartGame.Invoke();
            PlayersAccount.OnShipAccountResources.ResetCredits();
            PlayersAccount.OnShipAccountResources.ResetMaterials();
            _deathPanel.SetActive(false);
        }

        public void ButtonRestart()
        {
            PlayersAccount.OnShipAccountResources.ResetCredits();
            PlayersAccount.OnShipAccountResources.ResetMaterials();
            LevelEvent.RestartGame.Invoke();
            _deathPanel.SetActive(false);
        }
        
        

        private void SetDeathPanelActive()
        {
            _deathPanel.SetActive(true);
            var creditsOnShip = PlayersAccount.OnShipAccountResources.GetCredits() / 4;
            var materialsOnShip = PlayersAccount.OnShipAccountResources.GetMaterials() / 4;
            _creditsToSave.text = creditsOnShip.ToString();
            _materialsToSave.text = materialsOnShip.ToString();
        }

        protected override void Initialize()
        {
            _deathPanel.SetActive(false);
            LevelEvent.PlayerDeath.AddListener(SetDeathPanelActive);
        }

        protected override void Execute()
        {
            
        }
    }
}