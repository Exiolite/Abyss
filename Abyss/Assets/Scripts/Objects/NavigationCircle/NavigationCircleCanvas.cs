using Core;
using Events;
using Objects.Gui;
using UnityEngine;

namespace Objects.NavigationCircle
{
    public class NavigationCircleCanvas : ObjectBehaviour
    {
        [SerializeField] private ResourcesGui _resourcesGui;
        [SerializeField] private PanelFlipFlopper _panelFlipFlopper;

        

        protected override void Initialize()
        {
            _panelFlipFlopper.Activate();
            GuiEvent.UpdateNavCircleResources.AddListener(UpdateText);
            _panelFlipFlopper.Deactivate();
        }

        protected override void Execute()
        {
            
        }


        private void UpdateText()
        {
            _panelFlipFlopper.ActivateCoroutineDisable();
            _resourcesGui.SetResources(PlayersAccount.OnShipAccountResources);
        }
    }
}