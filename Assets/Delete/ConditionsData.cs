using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "NewConditionsData", menuName = "CreateConditionsData", order = 0)]
public class ConditionsData : ScriptableObject
{
    public static void Summoned()
    {
        Debug.Log("Summoned");
    }
}
