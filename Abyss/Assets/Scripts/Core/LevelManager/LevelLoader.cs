namespace Core.LevelManager
{
    public class LevelLoader
    {
        private SpaceObjectsData _spaceObjects;
        private Factory _factory;
        
        
        public void Initialize(SpaceObjectsData spaceObjects, Factory factory)
        {
            _spaceObjects = spaceObjects;
            _factory = factory;
        }
    }
}