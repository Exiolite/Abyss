using UnityEngine;

namespace Core
{
    public abstract class ObjectBehaviour : MonoBehaviour
    {
        protected Core Core;
        
        private void Start()
        {
            Core = Core.Instance;
            Initialize();
        }

        private void Update()
        {
            Execute();
        }

        protected abstract void Initialize();
        protected abstract void Execute();
    }
}