using UnityEngine;

namespace Objects.SpaceObjects.Static
{
    public class Abyss : SpaceObject
    {
        protected override void Execute(){}

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == LevelManager.InstancedPlayer.gameObject)
            {
                LevelManager.CreateNextLevel();
            }
        }
    }
}