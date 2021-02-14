using Core;
using Events;
using Objects.SpaceObjects.Dynamic;
using Statics;
using UnityEngine;

namespace Objects.BackGrounds
{
    public class PlanetHandler : BackGroundBehaviour
    {
        [SerializeField] private Sprite[] planetsSprites;

        [Header("Asteroids field")]
        [SerializeField] private GameObject asteroidFieldHolder;
        private const float MinDistance = 400.0f;
        [SerializeField] private float maxDistance;
        [SerializeField] private AsteroidHandler asteroidHandler;
        
        

        private SpriteRenderer _spriteRenderer;
        private readonly AsteroidHandler[] _instancedAsteroids = new AsteroidHandler[2000];
        
        protected override void Initialize()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = GetRandomPlanetSprite(_spriteRenderer.sprite);

            FirstSpawn();
            
            LevelEvent.DestroyAllExcludePlayer.AddListener(UpdateTest);
        }

        protected override void Execute()
        {
            
        }

        private Sprite GetRandomPlanetSprite(Sprite sprite)
        {
            var newSprite = planetsSprites[GetRandomIndex(planetsSprites.Length)];
            while (newSprite == sprite)
            {
                newSprite = planetsSprites[GetRandomIndex(planetsSprites.Length)];
            }
            return newSprite;
        }

        private int GetRandomIndex(int max)
        {
            return Random.Range(0, max);
        }

        private void FirstSpawn()
        {
            for (int i = 0; i < 2000; i++)
            {
                _instancedAsteroids[i] = SpawnAsteroid();
            }

            UpdateAsteroidsField();
        }

        private void UpdateTest(Ship test)
        {
            UpdateAsteroidsField();
            _spriteRenderer.sprite = GetRandomPlanetSprite(_spriteRenderer.sprite);
        }

        private void UpdateAsteroidsField()
        {
            asteroidFieldHolder.transform.eulerAngles = new Vector3(Random.Range(0.0f,359.0f),Random.Range(0.0f,359.0f), Random.Range(0.0f,359.0f));
            for (int i = 0; i < 2000; i++)
            {
                SetAsteroid(_instancedAsteroids[i]);
            }
        }
        
        private AsteroidHandler SpawnAsteroid()
        {
            var asteroid = Instantiate(asteroidHandler, asteroidFieldHolder.transform);
            return asteroid;
        }

        private void SetAsteroid(AsteroidHandler target)
        {
            target.transform.localPosition = Randomizer.GenerateAsteroids(MinDistance, maxDistance + MinDistance);
            target.transform.eulerAngles = new Vector3(0,0, 0);
        }
    }
}