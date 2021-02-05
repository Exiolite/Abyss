using Core;
using Modules.Account;
using Modules.LevelManager.LevelCreation;
using Modules.LevelManager.LevelLoading;
using Objects.SpaceObjects;
using UnityEngine;

namespace Modules.LevelManager
{
    [System.Serializable]
    public class LevelManager
    {
        private readonly LevelCreator levelCreator = new LevelCreator();
        private readonly LevelLoader levelLoader = new LevelLoader();
        private SpaceObjectsDataBase _spaceObjectsDataBase;
        
        
        
        public void Initialize()
        {
            EventAccount.CallBackIsAlive.AddListener(CreateOrLoad);
            EventAccount.CallIsAlive.Invoke();
            EventCore.CallForDataBase.Invoke();
            EventCore.CallBackDataBase.AddListener(CallBackDataBase);
        }


        
        private void CallBackDataBase(SpaceObjectsDataBase spaceObjectsDataBase)
        {
            _spaceObjectsDataBase = spaceObjectsDataBase;
        }
        
        private void CreateOrLoad(bool isPlayerAlive)
        {
            if (isPlayerAlive)
            {
                levelLoader.LoadLevel();
            }
            else
            {
                levelCreator.CreateLevel();
            }
        }
    }
}