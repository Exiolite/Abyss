using Modules.Account;
using Modules.LevelManager.Factory;
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
        

        private void FirstInitialization()
        {
            InitializeCoreModules();
        }

        private void InitializeCoreModules()
        {
            _playersAccount.Initialize();
            gameObject.AddComponent<Factory>();
            _levelManager.CreateLevel();
        }
    }
}