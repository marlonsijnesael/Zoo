using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract class for tricks, each trick should derrive from this class 
/// </summary>
[System.Serializable]
public abstract class Trick : ScriptableObject {

    public abstract IEnumerator DoTrick(Animal _o);
  
}
