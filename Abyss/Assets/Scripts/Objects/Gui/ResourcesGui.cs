using Modules.Account;
using Objects.Gui.Components;
using UnityEngine;

namespace Objects.Gui
{
    public class ResourcesGui : MonoBehaviour
    {
        [SerializeField] private GValue _credits;
        [SerializeField] private GValue _materials;
        

        public void SetResources(AccountResources accountResources)
        {
            _credits.SetIntText(accountResources.GetCredits());
            _materials.SetIntText(accountResources.GetMaterials());
        }

        public void SetDividedResources(AccountResources accountResources)
        {
            _credits.SetIntText(accountResources.GetCredits()/4);
            _materials.SetIntText(accountResources.GetMaterials()/4);
        }
    }
}