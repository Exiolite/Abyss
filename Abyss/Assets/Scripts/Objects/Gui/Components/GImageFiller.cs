using UnityEngine;
using UnityEngine.UI;

namespace Objects.Gui.Components
{
    public class GImageFiller : MonoBehaviour
    {
        [SerializeField] private Image _image;
        
        public void SetImageFill(float percent) => _image.fillAmount = percent;
    }
}