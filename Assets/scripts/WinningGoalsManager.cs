using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinningGoalsManager : MonoBehaviour
{
    [SerializeField]
    private Text m_goalText;
    [SerializeField]
    private Text m_shardText;

    private int m_goldNeeded = 0;
    private int m_shardsNeeded = 0;

    // Use this for initialization
    void Start ()
    {
        m_goldNeeded = Random.Range(2000, 7000);
        m_shardsNeeded = Random.Range(2000, 7000);
        m_goalText.text = m_goldNeeded.ToString();
        m_shardText.text = m_shardsNeeded.ToString();

	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public int GetGoldNeeded()
    {
        return m_goldNeeded;
    }

    public int GetShardsNeeded()
    {
        return m_shardsNeeded;
    }
}
