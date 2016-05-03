using UnityEngine;
using System.Collections;

public class UtilityMaths : MonoBehaviour
{
    static float LinearNormalise(float min,float max,float value)
    {
        float clampedValue = 0.0f;
        float range = max - min;
        return (clampedValue - min) / range;
    }

    static float QuadraticNormalise(float min,float max,float value,float power)
    {
        float clampedValue = 0.0f;
        return 0.0f;
    }
}
