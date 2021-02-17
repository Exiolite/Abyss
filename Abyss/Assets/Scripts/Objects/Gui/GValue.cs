using System.Globalization;
using TMPro;
using UnityEngine;

namespace Objects.Gui
{
    public class GValue : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _valueText;


        public void SetIntText(int value)
        {
            _valueText.text = value.ToString(CultureInfo.InvariantCulture);
        }
        
        public void SetFloatText(float value)
        {
            _valueText.text = value.ToString(CultureInfo.InvariantCulture);
        }
    }
}