using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Animals/Tricks/360")]
public class Trick_360 : Trick {

    public override IEnumerator DoTrick(Animal _o)
    {
        for (int i = 0; i < 360; i++)
        {
            _o.transform.localRotation = Quaternion.Euler(0, 0, i);
            yield return new WaitForEndOfFrame();
        }
    }
}
