using System.Collections;
using System.Globalization;
using Core;
using Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Objects.Gui
{
    public class Gui : ObjectBehaviour
    {
        [SerializeField] private GameObject resourcesPanel;
        [SerializeField] private TextMeshProUGUI creditsText;
        [SerializeField] private TextMeshProUGUI materialsText;

        [SerializeField] private Slider zoomSlider;

        [SerializeField] private GameObject helpPanel;
        private bool _isHelpPanelActive;
        
        private bool _isResourcePanelActive;



        public void OnZoomSliderChanged()
        {
            GuiEvent.OnZoomSliderChanged.Invoke(zoomSlider.value);
        }

        public void SwitchHelpPanel()
        {
            _isHelpPanelActive = !_isHelpPanelActive;
            helpPanel.SetActive(_isHelpPanelActive);
        }
        

        protected override void Initialize()
        {
            _isResourcePanelActive = false;
            resourcesPanel.SetActive(_isResourcePanelActive);
            GuiEvent.UpdateNavCircleResources.AddListener(UpdateText);
            helpPanel.SetActive(_isHelpPanelActive);
        }

        protected override void Execute(){}

        
        
        private void UpdateText()
        {
            _isResourcePanelActive = true;
            resourcesPanel.SetActive(_isResourcePanelActive);
            creditsText.text = PlayersAccount.AccountSavedAccountResources.GetCredits().ToString(CultureInfo.InvariantCulture);
            materialsText.text = PlayersAccount.AccountSavedAccountResources.GetMaterials().ToString(CultureInfo.InvariantCulture);
            StartCoroutine(DisableResourcesPanel());
        }
        
        private IEnumerator DisableResourcesPanel()
        {
            yield return new WaitForSeconds(2);
            if (_isResourcePanelActive)
            {
                resourcesPanel.SetActive(false);
            }
        }
    }
}