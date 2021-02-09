using UnityEngine;
using Random = UnityEngine.Random;

namespace Objects.SpaceObjects.Static
{
    public class Container : SpaceObject
    {
        [SerializeField] private int credits;
        [SerializeField] private int materials;


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (LevelManager.InstancedPlayer == null) return;
            if (other.gameObject != LevelManager.InstancedPlayer.gameObject) return;
            PlayersAccount.AddResourcesToShip(Random.Range(0, credits), Random.Range(0, materials));
            DestroyItSelf();
        }

        protected override void Execute()
        {
           
        }
    }
}