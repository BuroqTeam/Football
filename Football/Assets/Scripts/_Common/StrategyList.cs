using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StrategyEvent", menuName = "ScriptableObjects/StrategyEvent", order = 7)]
public class StrategyList : ScriptableObject // F++
{
    public TeamPosition[] ListOfTeamPositions;
}
