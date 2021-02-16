using System.Collections;
using System.Globalization;
using Core;
using Events;
using TMPro;
using UnityEngine;

namespace Objects.NavigationCircle
{
    public class NavigationCircleCanvas : ObjectBehaviour
    {
        [SerializeField] private GameObject _resourcesPanel;
        [SerializeField] private TextMeshProUGUI _creditsText;
        [SerializeField] private TextMeshProUGUI _materialsText;

        private bool _isResourcePanelActive;


        protected override void Initialize()
        {
            _isResourcePanelActive = false;
            _resourcesPanel.SetActive(_isResourcePanelActive);
            GuiEvent.UpdateNavCircleResources.AddListener(UpdateText);
        }

        protected override void Execute()
        {
        }


        private void UpdateText()
        {
            _isResourcePanelActive = true;
            _resourcesPanel.SetActive(_isResourcePanelActive);
            _creditsText.text = PlayersAccount.OnShipAccountResources.GetCredits().ToString(CultureInfo.InvariantCulture);
            _materialsText.text = PlayersAccount.OnShipAccountResources.GetMaterials().ToString(CultureInfo.InvariantCulture);
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