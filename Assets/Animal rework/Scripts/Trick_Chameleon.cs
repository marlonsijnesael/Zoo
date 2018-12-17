using System.Collections;

using UnityEngine;
[CreateAssetMenu(menuName = "Animals/Tricks/chameleon")]
public class Trick_Chameleon : Trick {
    
    public override IEnumerator DoTrick(Animal _o) {
        Debug.Log("working");
        Color cRandom = Color.cyan;
        Color cOrinial = _o.GetComponent<SpriteRenderer>().color;
        _o.GetComponent<SpriteRenderer>().color = cRandom;
        yield return new WaitForSeconds(2f);
        _o.GetComponent<SpriteRenderer>().color = cOrinial;
        }
    }
