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
        [SerializeField] private GameObject _resourcesPanel;
        [SerializeField] private TextMeshProUGUI _creditsText;
        [SerializeField] private TextMeshProUGUI _materialsText;

        [SerializeField] private Slider _zoomSlider;

        [SerializeField] private GameObject _helpPanel;
        private bool _isHelpPanelActive;
        
        private bool _isResourcePanelActive;



        public void OnZoomSliderChanged()
        {
            GuiEvent.OnZoomSliderChanged.Invoke(_zoomSlider.value);
        }

        public void SwitchHelpPanel()
        {
            _isHelpPanelActive = !_isHelpPanelActive;
            _helpPanel.SetActive(_isHelpPanelActive);
        }
        

        protected override void Initialize()
        {
            _isResourcePanelActive = false;
            _resourcesPanel.SetActive(_isResourcePanelActive);
            GuiEvent.UpdateNavCircleResources.AddListener(UpdateText);
            _helpPanel.SetActive(_isHelpPanelActive);
        }

        protected override void Execute(){}

        
        
        private void UpdateText()
        {
            _isResourcePanelActive = true;
            _resourcesPanel.SetActive(_isResourcePanelActive);
            _creditsText.text = PlayersAccount.AccountSavedAccountResources.GetCredits().ToString(CultureInfo.InvariantCulture);
            _materialsText.text = PlayersAccount.AccountSavedAccountResources.GetMaterials().ToString(CultureInfo.InvariantCulture);
            StartCoroutine(DisableResourcesPanel());
        }
        
        private IEnumerator DisableResourcesPanel()
        {
            yield return new WaitForSeconds(2);
            if (_isResourcePanelActive)
            {
                _resourcesPanel.SetActive(false);
            }
        }
    }
}