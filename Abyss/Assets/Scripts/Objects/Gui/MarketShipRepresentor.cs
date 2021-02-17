using System;
using System.Globalization;
using Events;
using Objects.SpaceObjects.Dynamic;
using Objects.SpaceObjects.Static;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Objects.Gui
{
    public class MarketShipRepresentor : MonoBehaviour
    {
        [SerializeField] private Image _shipIconHolder;
        [SerializeField] private TextMeshProUGUI _shipNameText;
        
        [SerializeField] private TextMeshProUGUI _shipHitPointsText;
        [SerializeField] private TextMeshProUGUI _shipShieldText;
        [SerializeField] private TextMeshProUGUI _shipDpsText;
        [SerializeField] private TextMeshProUGUI _shipDepthText;
        
        [SerializeField] private TextMeshProUGUI _shipPriceCreditsText;
        [SerializeField] private TextMeshProUGUI _shipPriceMaterialsText;

        private Ship _targetShip;
        private ShipYard _targetShipYard;
        private MarketGui _marketGui;


        private void Awake()
        {
            LevelEvent.SetShipYard.AddListener(SetShipYard);
        }

        public void SetRepresentor(Ship target, MarketGui marketGui)
        {
            _marketGui = marketGui;
            _targetShip = target;
            
            _shipIconHolder.sprite = _targetShip.GetComponent<SpriteRenderer>().sprite;
            _shipNameText.text = _targetShip.ObjName;

            _shipHitPointsText.text = _targetShip.HealthStats.HitPoints.StatValue.ToString(CultureInfo.InvariantCulture);
            _shipShieldText.text = _targetShip.HealthStats.Shield.StatValue.ToString(CultureInfo.InvariantCulture);

            _shipDepthText.text = _targetShip.MaxDepth.ToString();

            _shipPriceCreditsText.text = _targetShip.ShipPriceCredits.ToString();
            _shipPriceMaterialsText.text = _targetShip.ShipPriceMaterials.ToString();
        }

        public void ButtonBuyClicked()
        {
            _targetShipYard.OnBuyShip(_targetShip);
            _marketGui.ButtonSetPanelInActive();
        }



        private void SetShipYard(ShipYard shipYard)
        {
            _targetShipYard = shipYard;
        }
    }
}