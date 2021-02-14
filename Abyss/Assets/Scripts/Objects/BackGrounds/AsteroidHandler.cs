using Core;
using UnityEngine;

namespace Objects.BackGrounds
{
    public class AsteroidHandler : BackGroundBehaviour
    {
        [SerializeField] private Sprite[] asteroidsSprites;

        private SpriteRenderer _spriteRenderer;

        protected override void Initialize()
        {
            base.Initialize();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = asteroidsSprites[Random.Range(0, asteroidsSprites.Length)];
        }
    }
}