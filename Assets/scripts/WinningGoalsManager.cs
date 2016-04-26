using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinningGoalsManager : MonoBehaviour
{

    public int goldNeeded = 0;
    public int shardsNeeded = 0;
    public Text goalText;
    public Text shardText;

	// Use this for initialization
	void Start ()
    {
        goalText.text = goldNeeded.ToString();
        shardText.text = shardsNeeded.ToString();

	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
