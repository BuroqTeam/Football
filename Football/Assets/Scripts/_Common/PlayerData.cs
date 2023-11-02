using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{

    [Header("Circle Settings")]
    public float RotatorSpeed;
    public Vector3 RotatingAngle;

    [Header("Circle Color Settings")]
    [Range(0, 2.0f)]
    public float GrrenGap;
    [Range(0, 2.0f)]
    public float YellowGap;
    [Range(0, 1.0f)]
    public float AlphaTransparency;
    [Range(1, 2.0f)]
    public float MaxCircleSize;

    public float minimumKickForce;






}
