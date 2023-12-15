using UnityEngine;

/// <summary>
/// This scriptable object save football club name and logo. 
/// </summary>
[CreateAssetMenu(fileName = "TeamListData", menuName = "ScriptableObjects/TeamListData", order = 6)]
public class TeamListSO : ScriptableObject
{
    public string[] TeamNames;
    public Sprite[] TeamLogos;
    public Sprite[] TeamUniforms;
    public Sprite[] GoalKeeperUniforms;
}
