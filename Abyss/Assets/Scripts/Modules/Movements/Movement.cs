using Objects.SpaceObjects;
using Objects.SpaceObjects.Dynamic;
using Statics;
using UnityEngine;

namespace Modules.Movements
{
    [System.Serializable]
    public class Movement
    {
        //Movement attributes
        [SerializeField] private float _velocity;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _angleSpeed;
        private float _speed;



        public void HardRotateToTarget(Transform transform, Transform target)
        {
            var deirectionToTarget = target.transform.position - transform.position;
            var angleToTarget = Mathf.Atan2(deirectionToTarget.y, deirectionToTarget.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angleToTarget);
        }

        public float GetSpeed()
        {
            return _speed * Time.deltaTime;
        }

        public void SmoothRotateToTarget(Transform transform, Transform target)
        {
            var deirectionToTarget = target.transform.position - transform.position;
            var angleToTarget = Mathf.Atan2(deirectionToTarget.y, deirectionToTarget.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0,0, angleToTarget);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _angleSpeed / 10);
        }
        
        public void HardMoveForward(Transform transform)
        {
            transform.Translate(transform.right * (Time.deltaTime * _maxSpeed), Space.World);
        }
        
        public void HardMoveForwardWithCurrentSpeed(Transform transform)
        {
            transform.position += transform.right * (Time.deltaTime * _speed);
        }

        public void HardMoveForwardWithMinSpeed(Transform transform)
        {
            transform.position += transform.right * (Time.deltaTime * 3);
        }

        public void SmoothMoveForward(Transform transform, bool flag)
        {
            if (flag)
            {
                _speed = Mathf.Clamp(_speed + (_velocity * Time.deltaTime), 0, _maxSpeed);
            }
            else
            {
                _speed = Mathf.Clamp(_speed - (_speed * Time.deltaTime), 0, _maxSpeed);
            }
            transform.Translate(transform.right * (Time.deltaTime * _speed), Space.World);
        }

        public void MoveSlowDownToMinSpeed(Transform transform)
        {
            _speed = Mathf.Clamp(_speed - (_speed * Time.deltaTime), 3, _maxSpeed);
            transform.position += transform.right * (Time.deltaTime * _speed);
        }

        public void MoveShipToTarget(Transform transform, SpaceObject target)
        {
            if (target == null)
            {
                SmoothMoveForward(transform, false);
                return;
            }
            SmoothRotateToTarget(transform, target.transform);
            if (target.GetType() == typeof(Ship))
            {
                SmoothMoveForward(transform, true);
            }
            else
            {
                if (RangeFinder.CalculateDistance(transform, target)>20)
                {
                    SmoothMoveForward(transform, true);
                }
                else
                {
                    if (RangeFinder.CalculateDistance(transform, target) < 1)
                    {
                        _speed = 0;
                    }
                    else
                    {
                        MoveSlowDownToMinSpeed(transform);
                    }
                }
            }
        }

        public void HardMoveRandomSpeed(Transform transform)
        {
            transform.position += transform.right * (Time.deltaTime * Random.Range(_maxSpeed-Random.Range(0,50),_maxSpeed+Random.Range(0,50)));
        }
        
        public void MicroWarp(Transform transform, SpaceObject target)
        {
            if (RangeFinder.CalculateDistance(transform, target) > 50.0f)
            {
                transform.position += transform.right * (RangeFinder.CalculateDistance(transform, target)-50);
            }
        }
    }
}