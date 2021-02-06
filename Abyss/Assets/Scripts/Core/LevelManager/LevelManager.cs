namespace Core.LevelManager
{
    public class LevelManager
    {
        private readonly SpaceObjectsData _spaceObjects = new SpaceObjectsData();
        private readonly LevelLoader _levelLoader = new LevelLoader();
        private readonly LevelCreator _levelCreator = new LevelCreator();
        
        
        public void Initialize(Factory factory)
        {
            _spaceObjects.LoadData();
            _levelLoader.Initialize(_spaceObjects, factory);
            _levelCreator.Initialize(_spaceObjects, factory);
        }

        public void ManageLevelCreation()
        {
            _levelCreator.CreateLevel();
        }
    }
}