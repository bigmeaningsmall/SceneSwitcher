using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// An example of displaying the version number from static data if developermode is active
/// </summary>


public class UI_VersionDisplay : MonoBehaviour
{
    private TextMeshProUGUI versionText;
    
    void Start()
    {
        //get the text component
        versionText = GetComponent<TextMeshProUGUI>();
        //set the text to the game version
        versionText.text = "Version: " + StaticData.gameVersion;
    }
    
    void Update()
    {
        //this is a little expensive for to have it always check but for example purposes its fine
        if(GameManager.instance.developerMode)
        {
            //set the text to the game version
            versionText.text = "V: " + StaticData.gameVersion;
        }
        else
        {
            //dont render the version text
            versionText.text = "";
        }
    }
}
