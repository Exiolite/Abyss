using Core;
using Events;
using UnityEngine;

namespace Objects.Gui
{
    public class MarketGui : ObjectBehaviour
    {
        [SerializeField] private MarketShipRepresentor _shipRepresentor;
        
        [SerializeField] private ResourcesGui _resourcesGui;

        [SerializeField] private GameObject _marketContent;
        
        private PanelFlipFlopper _marketFlipFlopper;

        

        protected override void Initialize()
        {
            _marketFlipFlopper = GetComponent<PanelFlipFlopper>();
            
            foreach (var marketShip in LevelManager.DataBase.MarketShips)
            {
                var shipRepresentor = Instantiate(_shipRepresentor, _marketContent.transform);
                shipRepresentor.SetRepresentor(marketShip, _marketFlipFlopper);
            }

            GuiEvent.ShowMarket.AddListener(SetPanelActive);
            _marketFlipFlopper.Deactivate();
        }

        protected override void Execute()
        {
        }


        private void SetPanelActive()
        {
            _marketFlipFlopper.Activate();
            _resourcesGui.SetResources(PlayersAccount.AccountSavedAccountResources);
        }
    }
}