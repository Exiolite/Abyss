using UnityEngine;

namespace Statics
{
    public static class Randomizer
    {
        public static Vector3 GenerateDotOfInterest(float minRange)
        {
            Vector3 position;
            do
            {
                position = new Vector3(Random.Range(-300,300),Random.Range(-300,300),0);
            } while (Vector3.Distance(new Vector3(0,0,0), position) < minRange);
            return position;
        }
        
        public static Vector3 GenerateAsteroids(float minRange, float maxRange)
        {
            Vector3 position;
            do
            {
                position = new Vector3(Random.Range(-maxRange*2,maxRange*2),Random.Range(-10.0f,10.0f),Random.Range(-maxRange*2,maxRange*2));

            } while (Vector3.Distance(Vector3.zero, position) < minRange || Vector3.Distance(Vector3.zero, position) > maxRange);
            
            return position;
        }
    }
}