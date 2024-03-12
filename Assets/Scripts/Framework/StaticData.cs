using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// static variables to be used across the game
/// note this is a 'static' class with 'static' variables!
/// variables in this class should not be changed but set outside of the runtime
/// it can be accessed from any script without needing to create an instance of the class
/// it can't be added to a game object as it's not a monobehaviour
/// </summary>

public static class StaticData
{
    [Space(10)] 
    [Header("Set Developer Mode")] 
    public static bool developerMode = true; //set true to enable developer settings
    
}
