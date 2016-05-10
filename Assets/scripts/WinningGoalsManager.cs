using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinningGoalsManager : MonoBehaviour
{
    public Text goalText;
    public Text shardText;
    [HideInInspector]
    public int goldNeeded = 0;
    [HideInInspector]
    public int shardsNeeded = 0;

    // Use this for initialization
    void Start ()
    {
        goldNeeded = Random.Range(2000, 7000);
        shardsNeeded = Random.Range(2000, 7000);
        goalText.text = goldNeeded.ToString();
        shardText.text = shardsNeeded.ToString();

	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
