using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinningGoalsManager : MonoBehaviour
{
    [SerializeField]
    private Text goalText;
    [SerializeField]
    private Text shardText;

    private int goldNeeded = 0;
    private int shardsNeeded = 0;

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
