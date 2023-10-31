using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleColorChanger : MonoBehaviour
{
    public PlayerData PlayerDataSO;


    public void ChangeColor(float lengthOfMouseDrag)
    {
        SpriteRenderer circle = GetComponent<SpriteRenderer>();
        if (lengthOfMouseDrag > 0 && lengthOfMouseDrag <= PlayerDataSO.GrrenGap)
        {
            circle.color = Color.green;
        }
        else if (lengthOfMouseDrag > PlayerDataSO.GrrenGap && lengthOfMouseDrag <= PlayerDataSO.YellowGap)
        {
            circle.color = Color.yellow;
        }
        else
        {
            circle.color = Color.red;
        }
        Color currentColor = circle.color;
        currentColor.a = PlayerDataSO.AlphaTransparency;
        circle.color = currentColor;
    }


}
