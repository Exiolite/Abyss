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
                position = new Vector3(Random.Range(-160,160),Random.Range(-160,160),0);
            } while (Vector3.Distance(new Vector3(0,0,0), position) < minRange);
            return position;
        }
    }
}