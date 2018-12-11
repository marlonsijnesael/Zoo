
using UnityEngine;

public abstract class AnimalAction : ScriptableObject {

	public abstract void Init(Animal _o);
    public abstract void DoAction(Animal _o);
}
