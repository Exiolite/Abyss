using Core;
using Events;
using TMPro;
using UnityEngine;

namespace Objects.Gui
{
    public class MarketGui : ObjectBehaviour
    {
        [SerializeField] private MarketShipRepresentor _shipRepresentor;

        [SerializeField] private TextMeshProUGUI _playerCredits;
        [SerializeField] private TextMeshProUGUI _playerMaterials;
        
        
        [SerializeField] private GameObject _marketContent;
        
        [SerializeField] private GameObject _marketPanel;
        private bool _marketPanelActive;
        
        

        public void ButtonSetPanelInActive()
        {
            _marketPanelActive = false;
            _marketPanel.SetActive(_marketPanelActive);
        }
        
        
        
        protected override void Initialize()
        {
            foreach (var marketShip in LevelManager.DataBase.MarketShips)
            {
                var shipRepresentor = Instantiate(_shipRepresentor, _marketContent.transform);
                shipRepresentor.SetRepresentor(marketShip, this);
            }
            _marketPanel.SetActive(_marketPanelActive);
            GuiEvent.ShowMarket.AddListener(SetPanelActive);
        }

        protected override void Execute()
        {
            
        }

        private void SetPanelActive()
        {
            _marketPanelActive = true;
            _marketPanel.SetActive(_marketPanelActive);
            _playerCredits.text = PlayersAccount.AccountSavedAccountResources.GetCredits().ToString();
            _playerMaterials.text = PlayersAccount.AccountSavedAccountResources.GetMaterials().ToString();
        }
    }
}