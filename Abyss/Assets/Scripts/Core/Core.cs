using Modules.Account;
using UnityEngine;

namespace Core
{
    public class Core : MonoBehaviour
    {
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

        
        
        private readonly Account _playersAccount = new Account();
        private readonly LevelManager.LevelManager _levelManager = new LevelManager.LevelManager();
        private Factory _factory;

        private void FirstInitialization()
        {
            InitializeCoreModules();
        }

        private void InitializeCoreModules()
        {
            _playersAccount.Initialize();
            _factory = gameObject.AddComponent<Factory>();
            _levelManager.Initialize(_factory);
            _levelManager.ManageLevelCreation();
        }
    }
}