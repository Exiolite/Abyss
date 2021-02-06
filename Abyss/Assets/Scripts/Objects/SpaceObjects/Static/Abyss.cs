using UnityEngine;

namespace Objects.SpaceObjects.Static
{
    public class Abyss : SpaceObject
    {
        protected override void Execute()
        {
            transform.eulerAngles = new Vector3(0,0, transform.eulerAngles.z - (Time.deltaTime * 4));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == LevelManager.InstancedPlayer.gameObject)
            {
                LevelManager.CreateNextLevel();
            }
        }
    }
}