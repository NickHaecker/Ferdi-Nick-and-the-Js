using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EBuildType
{
    SERVER,CLIENT
}

[Serializable]
[CreateAssetMenu(fileName = "BuildType", menuName = "Data/BuildType")]
public class BuildType : ScriptableObject
{
    public EBuildType type;
}
