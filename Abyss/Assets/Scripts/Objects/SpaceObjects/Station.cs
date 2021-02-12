using Objects.Gui;
using UnityEngine;

namespace Objects.SpaceObjects
{
    public class Station : SpaceObject
    {
        [SerializeField] protected StationGui stationGui;

        protected int PlayersCredits;
        protected int PlayersMaterials;
        
        
        
        protected override void Execute()
        {
            
        }
        
        protected void UpdateCreditsUi(int value)
        {
            stationGui.SetCredits(value);
            stationGui.SetButtonColor(PlayersAccount.HaveEnoughCredits(value));
        }
        
        protected void UpdateMaterialsUi(int value)
        {
            stationGui.SetMaterials(value);
            stationGui.SetButtonColor(PlayersAccount.HaveEnoughMaterials(value));
        }

        protected void TryRemoveCredits(int value ,out bool success)
        {
            PlayersAccount.TryRemoveCredits(value, out success);
        }
        
        protected void TryRemoveMaterials(int value ,out bool success)
        {
            PlayersAccount.TryRemoveMaterials(value, out success);
        }
    }
}