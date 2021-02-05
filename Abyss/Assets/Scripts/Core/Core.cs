using Modules.Account;
using Modules.LevelManager;
using Modules.LevelManager.Factory;
using UnityEngine;

namespace Core
{
    public class Core : MonoBehaviour
    {
        //Запуск ядра. НЕ ТРОГАТЬ!!!
        #region Singleton

        private static Core _instance;

        public static Core Instance => _instance;

        void Awake()
        {
            if (_instance == null)
                _instance = this;
            else if (_instance != this)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            FirstInitialization();
        }

       
        #endregion
        
        
        [SerializeField] private SpaceObjectsDataBase spaceObjectsDataBase;
        
        private readonly Account _playersAccount = new Account();
        private readonly LevelManager _levelManager = new LevelManager();
        
        
        
        
        private void FirstInitialization()
        {
            InitializeCoreModules();
        }

        private void InitializeCoreModules()
        {
            EventCore.CallForDataBase.AddListener(spaceObjectsDataBase.CallBackDataBase);
            
            _playersAccount.Initialize();
            gameObject.AddComponent<Factory>();
            _levelManager.Initialize();
        }
    }
}