using Objects.SpaceObjects.Dynamic;

namespace Core.LevelManager
{
    public class LevelManager
    {
        public int DepthCounter { get; private set; }
        public SpaceObjectsData DataBase { get; } = new SpaceObjectsData();
        public Ship InstancedPlayer { get; private set; }
        public Factory Factory { get; private set; }
        
        private readonly LevelLoader _levelLoader = new LevelLoader();
        private readonly LevelCreator _levelCreator = new LevelCreator();


        public void Initialize(Factory factory)
        {
            Factory = factory;
            DataBase.Initialize();
            _levelLoader.Initialize(this);
            _levelCreator.Initialize(this);
        }

        public void ManageLevelCreation()
        {
            _levelCreator.CreateLevel();
            DepthCounter++;
        }

        public void SetPlayer(Ship target)
        {
            InstancedPlayer = target;
        }
    }
}