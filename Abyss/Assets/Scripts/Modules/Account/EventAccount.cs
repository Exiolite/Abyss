using UnityEngine;
using UnityEngine.Events;

namespace Modules.Account
{
    public static class EventAccount
    {
        public static readonly Save Save = new Save();
        public static readonly Load Load = new Load();
        public static readonly Reset Reset = new Reset();
        public static readonly SetPremium SetPremium = new SetPremium();
        
        public static readonly CallHaveProgress CallHaveProgress = new CallHaveProgress();
        public static readonly CallPremium CallPremium = new CallPremium();
        public static readonly CallBackHaveProgress CallBackHaveProgress = new CallBackHaveProgress();
        public static readonly CallBackPremium CallBackPremium = new CallBackPremium();
        
        public static readonly CallIsAlive CallIsAlive = new CallIsAlive();
        public static readonly CallBackIsAlive CallBackIsAlive = new CallBackIsAlive();
        
        
    }
    public class Save : UnityEvent  { }
    public class Load : UnityEvent  { }
    public class Reset : UnityEvent  { }
    public class SetPremium : UnityEvent  { }
    
    public class CallHaveProgress : UnityEvent <GameObject>  { }
    public class CallPremium : UnityEvent <GameObject> { }
    public class CallBackHaveProgress : UnityEvent <GameObject, bool> { }
    public class CallBackPremium : UnityEvent <GameObject, bool> { }
    
    public class CallIsAlive : UnityEvent { }
    public class CallBackIsAlive : UnityEvent <bool> { }
}