namespace Modules.Resources
{
    public class Resource
    {
        private int _resource;
        
        public void Add(int value)
        {
            _resource += value;
        }
        
        public void Remove(int value)
        {
            _resource -= value;
        }

        public int Get()
        {
            return _resource;
        }

        public bool IsEnough(int value)
        {
            return value >= _resource;
        }
        
        public void Reset()
        {
            _resource = 0;
        }
    }
}