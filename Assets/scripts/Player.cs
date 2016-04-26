using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 0;
    public int gold = 0;
    public int shards = 0;
    public int dragonWarriors = 0;
    public int dragonTanks = 0;
    public int dragons = 0;
    public int miners = 0;
    public int advanceminers = 0;

    public Text healthText;
    public Text goldText;
    public Text shardsText;
    public Text dragonWarriorsText;
    public Text dragonTanksText;
    public Text dragonsText;
    public Text minersText;
    public Text advanceminersText;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        SetHealthGoldShardText();
        SetUnitsText();
    }

    void SetHealthGoldShardText()
    {
        healthText.text = health.ToString();
        goldText.text = gold.ToString();
        shardsText.text = shards.ToString();
    }

    void SetUnitsText()
    {
         dragonWarriorsText.text = dragonWarriors.ToString();
         dragonTanksText.text = dragonTanks.ToString();
         dragonsText.text = dragons.ToString();
         minersText.text = miners.ToString();
         advanceminersText.text = advanceminers.ToString();
    }
}
