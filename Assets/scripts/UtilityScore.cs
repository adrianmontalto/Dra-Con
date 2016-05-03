using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UtilityScore : MonoBehaviour
{
    public UtilityValue m_utilityvalue;
    public float m_score = 0.0f;
    public class UtilityInfo
    {
        public UtilityValue m_value;
        public float m_modifier;

        public UtilityInfo(UtilityValue value,float mod)
        {
            m_value = value;
            m_modifier = mod;
        }
    };
    public List<UtilityInfo> m_values;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void AddUtilityValue(UtilityValue value,float modifier)
    {
        m_values.Add(new UtilityInfo(value,modifier));
    }

    public float GetUtilityScore()
    {
        float score = 0.0f;
        for(int i = 0; i < m_values.Count; ++i)
        {
            if(score > 0)
            {
                score *= (m_values[i].m_value.Evaluate() * m_values[i].m_modifier);
            }
            else
            {
                score = (m_values[i].m_value.Evaluate() * m_values[i].m_modifier);
            }
        }
        return score;
    }
}
