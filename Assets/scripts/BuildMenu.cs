using UnityEngine;
using System.Collections;

public class BuildMenu : MonoBehaviour
{
    [HideInInspector]
    public int minerNum = 0;
    [HideInInspector]
    public int advanceMinerNum = 0;
    [HideInInspector]
    public int dragonWarriorNum = 0;
    [HideInInspector]
    public int dragonTankNum = 0;
    [HideInInspector]
    public int dragonNum = 0;
    [HideInInspector]
    public int barracksNum = 0;
    [HideInInspector]
    public int dragonPortalsNum = 0;
    [HideInInspector]
    public int antiAirTurretNum = 0;
    [HideInInspector]
    public int minesNum = 0;
    [HideInInspector]
    public int wallNum = 0;
    public GameObject initImage;
    [HideInInspector]
    public GameObject previousImage;
    // Use this for initialization
    void Start ()
    {
        previousImage = initImage;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
