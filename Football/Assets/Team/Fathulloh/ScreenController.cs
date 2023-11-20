using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class responsible for detect game scene horizontal or vertical.
/// </summary>
public class ScreenController : MonoBehaviour
{
    public enum ScreenType {Horizontal, Vertical };
    public ScreenType CurrentType;
    
    void Start()
    {
        Debug.Log("Screen.orientation = " + Screen.orientation);
        if (CurrentType == ScreenType.Horizontal) 
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
        else
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        
        Debug.Log("Screen.orientation = " + Screen.orientation);
    }

    
}
