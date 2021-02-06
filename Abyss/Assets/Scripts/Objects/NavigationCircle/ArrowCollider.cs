using Core;
using UnityEngine;

namespace Objects.NavigationCircle
{
    public class ArrowCollider : ObjectBehaviour
    {
        [SerializeField] private NavigationArrow navigationArrow;


        private void OnMouseDown()
        {
            navigationArrow.SetPlayersTarget();
        }

        protected override void Initialize(){}
        protected override void Execute(){}
    }
}