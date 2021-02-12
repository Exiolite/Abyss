using System.Globalization;
using Core;
using Objects.SpaceObjects;
using Objects.SpaceObjects.Static;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

namespace Objects.Gui
{
    public class StationGui : ObjectBehaviour
    {
        [SerializeField] private SpaceObject parentSpaceObject;
        
        [SerializeField] private Image buyImage;
        [SerializeField] private TextMeshProUGUI creditsPriceText;
        [SerializeField] private TextMeshProUGUI materialsPriceText;

        private int _credits;
        private int _materials;
        

        
        public void SetCredits(int credits)
        {
            _credits = credits;
            UpdateCreditsCounter();
        }
        
        public void SetMaterials(int materials)
        {
            _materials = materials;
            UpdateMaterialsCounter();
        }

        public void SetButtonColor(bool flag)
        {
            if (flag) buyImage.color = Color.green;
            else buyImage.color = Color.red;
        }


        protected override void Initialize()
        {
            GetComponent<Canvas>().worldCamera = FindObjectOfType<UnityEngine.Camera>();
        }

        protected override void Execute()
        {
            
        }



        private void UpdateCreditsCounter()
        {
            creditsPriceText.text = _credits.ToString(CultureInfo.InvariantCulture);
        }

        private void UpdateMaterialsCounter()
        {
            materialsPriceText.text = _materials.ToString(CultureInfo.InvariantCulture);
        }
    }
}