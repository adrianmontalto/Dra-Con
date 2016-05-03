using UnityEngine;
using System.Collections;

public class UtilityValue : MonoBehaviour
{
    public enum NormalizationType
    {
        LINEAR,
        INVERSE_LINEAR,
        QUADRATIC,
        INVERSE_QUADRATIC
    }

    public float m_min;
    public float m_max;
    public float m_power;
    public float m_value;
    public float m_normalizedValue;
    public NormalizationType m_normalizationType;

    public UtilityValue(NormalizationType type, float min, float max)
    {
        m_min = min;
        m_max = max;
        m_value = min;
        m_normalizedValue = 0.0f;
        m_normalizationType = type;
    }
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void SetMinMaxValue(float min,float max)
    {
        m_min = min;
        m_max = max;
    }

    public void SetNormaliztionType(NormalizationType type)
    {
        m_normalizationType = type;
    }

    public void SetQuadraticPower(float power)
    {
        m_power = power;
    }

    public void SetValue(float value)
    {
        m_value = value;
    }

    public float Evaluate()
    {
        switch(m_normalizationType)
        {
            case NormalizationType.LINEAR:
                break;
            case NormalizationType.INVERSE_LINEAR:
                break;
            case NormalizationType.QUADRATIC:
                break;
            case NormalizationType.INVERSE_QUADRATIC:
                break;
            default:
                break;
               
        }
        m_normalizedValue = 0;
        return m_normalizedValue;
    }
}
