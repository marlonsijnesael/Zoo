using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trick : ScriptableObject {

    public abstract IEnumerator DoTrick(Animal _o);

   
}
