using UnityEngine;
using UnityEngine.Events;

namespace Modules.Account
{
    public static class EventAccountResources
    {
        public static readonly AddCreditsToSave AddCreditsToSave = new AddCreditsToSave();
        public static readonly AddMaterialsToSave AddMaterialsToSave = new AddMaterialsToSave();
        
        public static readonly AddCreditsToShip AddCreditsToShip = new AddCreditsToShip();
        public static readonly AddMaterialsToShip AddMaterialsToShip = new AddMaterialsToShip();
        
        public static readonly CallForDepositFromShip CallForDepositFromShip = new CallForDepositFromShip();
        
        public static readonly CallForRemoveCredits CallForRemoveCredits = new CallForRemoveCredits();
        public static readonly CallForRemoveMaterials CallForRemoveMaterials = new CallForRemoveMaterials();
        public static readonly CallForRemoveResources CallForRemoveResources = new CallForRemoveResources();
        
        public static readonly CallBackRemoveCredits CallBackRemoveCredits = new CallBackRemoveCredits();
        public static readonly CallBackRemoveMaterials CallBackRemoveMaterials = new CallBackRemoveMaterials();
        public static readonly CallBackForRemoveResources CallBackForRemoveResources = new CallBackForRemoveResources();
        
        public static readonly UpdateCreditsSaved UpdateCreditsSaved = new UpdateCreditsSaved();
        public static readonly UpdateMaterialsSaved UpdateMaterialsSaved = new UpdateMaterialsSaved();
        public static readonly UpdateCreditsShip UpdateCreditsShip = new UpdateCreditsShip();
        public static readonly UpdateMaterialsShip UpdateMaterialsShip = new UpdateMaterialsShip();
        
    }
    
    public class AddCreditsToSave : UnityEvent <int> {}
    public class AddMaterialsToSave : UnityEvent <int> {}
    
    public class AddCreditsToShip : UnityEvent <int> {}
    public class AddMaterialsToShip : UnityEvent <int> {}
    
    public class CallForDepositFromShip : UnityEvent {}

    public class CallForRemoveCredits : UnityEvent <GameObject,int> {}
    public class CallForRemoveMaterials : UnityEvent <GameObject,int> {}
    public class CallForRemoveResources : UnityEvent <GameObject,int,int> {}
    
    public class CallBackRemoveCredits : UnityEvent <GameObject, bool> {}
    public class CallBackRemoveMaterials : UnityEvent <GameObject, bool> {}
    
    public class CallBackForRemoveResources : UnityEvent <GameObject, bool> {}
    public class UpdateCreditsSaved : UnityEvent <int> {}
    public class UpdateMaterialsSaved : UnityEvent <int> {}
    public class UpdateCreditsShip : UnityEvent <int> {}
    public class UpdateMaterialsShip : UnityEvent <int> {}
}
