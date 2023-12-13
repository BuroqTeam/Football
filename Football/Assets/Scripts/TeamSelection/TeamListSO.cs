using UnityEngine;

[CreateAssetMenu(fileName = "TeamListData", menuName = "ScriptableObjects/TeamListData", order = 6)]
public class TeamListSO : ScriptableObject
{
    public string[] TeamNames;
    public Sprite[] TeamLogos;
        
}
