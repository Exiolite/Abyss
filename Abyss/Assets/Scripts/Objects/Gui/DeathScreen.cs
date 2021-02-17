using Core;
using Events;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Objects.Gui
{
    public class DeathScreen : ObjectBehaviour
    {
        [SerializeField] private GameObject _deathPanel;
        [SerializeField] private ResourcesGui _resourcesGui;


        public void ButtonWatchAd()
        {
            if (Advertisement.IsReady())
                Advertisement.Show();

            PlayersAccount.DepositQuadToSave();
            LevelEvent.RestartGame.Invoke();
            PlayersAccount.Reset();
            _deathPanel.SetActive(false);
        }

        public void ButtonRestart()
        {
            PlayersAccount.Reset();
            LevelEvent.RestartGame.Invoke();
            _deathPanel.SetActive(false);
        }


        protected override void Initialize()
        {
            _deathPanel.SetActive(false);
            LevelEvent.PlayerDeath.AddListener(SetDeathPanelActive);
        }

        protected override void Execute()
        {
        }


        private void SetDeathPanelActive()
        {
            _deathPanel.SetActive(true);
            _resourcesGui.SetDividedResources(PlayersAccount.OnShipAccountResources);
        }
    }
}