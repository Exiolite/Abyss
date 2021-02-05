using Core;

namespace Objects.SpaceObjects
{
    public abstract class SpaceObject : ObjectBehaviour
    {
        public void DestroyItSelf()
        {
            Destroy(gameObject);
        }
    }
}