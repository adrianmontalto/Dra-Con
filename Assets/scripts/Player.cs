using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 0;
    public int gold = 0;
    public int shards = 0;
    public Text healthText;
    public Text goldText;
    public Text shardsText;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthText.text = health.ToString();
        goldText.text = gold.ToString();
        shardsText.text = shards.ToString();
	}
}
