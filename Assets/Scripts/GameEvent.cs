using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class CurrencyChangeGameEvent : GameEvent
{
    public CurrencyType currencyType;
    public int amount;

    public CurrencyChangeGameEvent(CurrencyType currencyType, int amount)
    {
        this.amount = amount;
        this.currencyType = currencyType;
    }
}

public class EnoughCurrencyGameEvent : GameEvent
{

}

public class NotEnoughCurrencyGameEvent : GameEvent
{
    public CurrencyType currencyType;
    public int amount;

    public NotEnoughCurrencyGameEvent(CurrencyType currencyType, int amount)
    {
        this.amount = amount;
        this.currencyType = currencyType;
    }
}

public class XPAddedGameEvent : GameEvent
{
    public int amount;

    public XPAddedGameEvent(int amount)
    {
        this.amount = amount;
    }
}

public class LevelChangedGameEvent
{
    public int newLevel;

    public LevelChangedGameEvent(int currentLevel)
    {
        newLevel = currentLevel;
    }
}