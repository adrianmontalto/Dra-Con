using UnityEngine;
using System.Collections;

public class UtilityMaths 
{
    public float LinearNormalise(float min, float max, float value)
    {
        float clampedValue = Max(Min(max,value),min);
        float range = max - min;
        return (clampedValue - min) / range;
    }

    public float QuadraticNormalise(float min, float max, float value, float power)
    {
        float clampedValue = Max(Min(max,value),min);
        return Power(clampedValue,power) / Power(max,power);
    }

    float Max(float start, float end)
    {
        if(start > end)
        {
            return start;
        }
        else
        {
            return end;
        }
        
    }

    float Min(float start, float end)
    {
        if(start < end)
        {
            return start;
        }
        else
        {
            return end;
        }        
    }

    float Power(float value,float pow)
    {
        float power = pow;
        for(int i = 0; i < pow; ++i)
        {
            power *= power;
        }
        return power;
    }
}
