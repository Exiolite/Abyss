using System.Collections;
using UnityEngine;

namespace Objects.Gui
{
    public class PanelFlipFlopper : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;

        private bool _isPanelActive;


        public void FlipPanelActive()
        {
            _isPanelActive = !_isPanelActive;
            _panel.SetActive(_isPanelActive);
        }

        public void ActivateCoroutineDisable()
        {
            Activate();
            
            StartCoroutine(DisableResourcesPanel());
        }
        
        public void ActivateDisable()
        {
            Activate();
            Deactivate();
        }

        public void Activate()
        {
            _isPanelActive = true;
            _panel.SetActive(_isPanelActive);
        }
        
        public void Deactivate()
        {
            _isPanelActive = false;
            _panel.SetActive(_isPanelActive);
        }
        

        private IEnumerator DisableResourcesPanel()
        {
            yield return new WaitForSeconds(2);
            Deactivate();
        }
    }
}