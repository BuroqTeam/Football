using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScaler : MonoBehaviour
{

    public PlayerData PlayerDataSO;


    public void ScaleCircle(float lengthOfMouseDrag)
    {
        if (lengthOfMouseDrag > 0 && lengthOfMouseDrag <= PlayerDataSO.MaxCircleSize)
        {
            Vector3 temp = transform.localScale;
            temp.x = lengthOfMouseDrag / 0.6f;
            temp.y = lengthOfMouseDrag / 0.6f;
            temp.z = 0;
            transform.localScale = temp;
        }
    }

    public void ResetCircleInitialScale()
    {
        transform.localScale = new Vector3(0, 0, 0);
    }

    
}
