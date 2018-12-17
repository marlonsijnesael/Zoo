using System.Collections;
using UnityEngine;

/// <summary>
/// Implementation of the trick base class, added a createAssetMenu header so it can be called and created from the project folder 
/// </summary>
[CreateAssetMenu(menuName = "Animals/Tricks/360")]
public class Trick_360 : Trick {

    public override IEnumerator DoTrick(Animal _o) {
        for (int i = 0; i < 360; i += 2) {
            _o.transform.localRotation = Quaternion.Euler(0, 0, -i);
            yield return new WaitForEndOfFrame();
            }
        }
    }
