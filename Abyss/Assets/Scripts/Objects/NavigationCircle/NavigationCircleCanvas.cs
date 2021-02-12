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
        [SerializeField] private GameObject resourcesPanel;
        [SerializeField] private TextMeshProUGUI creditsText;
        [SerializeField] private TextMeshProUGUI materialsText;

        private bool _isResourcePanelActive;


        protected override void Initialize()
        {
            _isResourcePanelActive = false;
            resourcesPanel.SetActive(_isResourcePanelActive);
            GuiEvent.UpdateNavCircleResources.AddListener(UpdateText);
        }

        protected override void Execute()
        {
        }


        private void UpdateText()
        {
            _isResourcePanelActive = true;
            resourcesPanel.SetActive(_isResourcePanelActive);
            creditsText.text = PlayersAccount.OnShipAccountResources.GetCredits().ToString(CultureInfo.InvariantCulture);
            materialsText.text = PlayersAccount.OnShipAccountResources.GetMaterials().ToString(CultureInfo.InvariantCulture);
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