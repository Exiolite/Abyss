using Core;
using Events;
using UnityEngine;
using UnityEngine.UI;

namespace Objects.Gui
{
    public class Gui : ObjectBehaviour
    {
        [SerializeField] private ResourcesGui _resourcesGui;
        [SerializeField] private PanelFlipFlopper _resourcesFlipFlopper;

        [SerializeField] private Slider _zoomSlider;



        public void OnZoomSliderChanged()
        {
            GuiEvent.OnZoomSliderChanged.Invoke(_zoomSlider.value);
        }
        
        

        protected override void Initialize()
        {
            _resourcesFlipFlopper.ActivateDisable();
            GuiEvent.UpdateNavCircleResources.AddListener(UpdateResources);
        }

        protected override void Execute(){}

        
        
        private void UpdateResources()
        {
            _resourcesFlipFlopper.ActivateCoroutineDisable();
            _resourcesGui.SetResources(PlayersAccount.AccountSavedAccountResources);
        }
    }
}