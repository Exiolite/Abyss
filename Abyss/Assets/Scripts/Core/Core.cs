using System;
using Core.LevelManaging;
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

        public Account PlayersAccount => _playersAccount;
        public LevelManager LevelManager => _levelManager;
        
        
        private Account _playersAccount;
        private LevelManager _levelManager;
        private Factory _factory;

        
        
        private void FirstInitialization()
        {
            InitializeCoreModules();
            GameStart();
        }

        private void InitializeCoreModules()
        {
            _factory = gameObject.AddComponent<Factory>();
            _playersAccount = new Account();
            _levelManager = new LevelManager(_factory);
        }

        private void GameStart()
        {
            _levelManager.ManageLevelCreation();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            _playersAccount.Save();
        }

        private void OnApplicationQuit()
        {
            _playersAccount.Save();
        }
    }
}