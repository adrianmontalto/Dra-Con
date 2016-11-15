using UnityEngine;
using System.Collections;

public class GameItemList : MonoBehaviour
{
    [SerializeField]
    private GameItem barracks;
    [SerializeField]
    private GameItem dragonPortal;
    [SerializeField]
    private GameItem antiAirTurret;
    [SerializeField]
    private GameItem mine;
    [SerializeField]
    private GameItem wall;
    [SerializeField]
    private GameItem miner;
    [SerializeField]
    private GameItem advanceMiner;
    [SerializeField]
    private GameItem dragonWarrior;
    [SerializeField]
    private GameItem dragonTank;
    [SerializeField]
    private GameItem dragon;

    public GameItem GetBarracks()
    {
        return barracks;
    }

    public GameItem GetDragonPortal()
    {
        return dragonPortal;
    }

    public GameItem GetAntiAirTurret()
    {
        return antiAirTurret;
    }

    public GameItem GetMine()
    {
        return mine;
    }

    public GameItem GetWall()
    {
        return wall;
    }

    public GameItem GetMiner()
    {
        return miner;
    }

    public GameItem GetAdvanceMiner()
    {
        return advanceMiner;
    }

    public GameItem GetDragonWarrior()
    {
        return dragonWarrior;
    }

    public GameItem GetDragonTank()
    {
        return dragonTank;
    }

    public GameItem GetDragon()
    {
        return dragon;
    }
}
