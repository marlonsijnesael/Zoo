using System.Collections;
using UnityEngine;
using TMPro;

/// <summary>
/// Baseclass for every Enemey
/// </summary>
public class Animal : MonoBehaviour {
    
    //bounds for random walk
    #region bounds
    [HideInInspector]
    public int left = -5;
    [HideInInspector]
    public int right = 5;
    [HideInInspector]
    public int top = 5;
    [HideInInspector]
    public int down = -5;

    #endregion


    [Header("Animal UI Components")]
    public Sprite sprite;
    public GameObject balloon;
    public GameObject textObject;
    private TextMeshPro textMesh;
    private SpriteRenderer sprRend;
    private bool doingTrick = false;

    
    public ScriptableAnimal animalInfo;

    private void Start() {
        this.gameObject.tag = animalInfo.eatingType.ToString();

        sprRend = gameObject.AddComponent<SpriteRenderer>();
        sprRend.sprite = sprite;

        textMesh = textObject.GetComponent<TextMeshPro>();
        balloon.SetActive(false);
        }

    private void Update() {
        if (!doingTrick)
            DoAction();
        }



    public void DoAction() {
        if (animalInfo.actions.Length == 0) {
            return;
            }
        foreach (AnimalAction _action in animalInfo.actions) {
            _action.DoAction(this);
            }
        }

    public void DoTrick() {
        if (animalInfo.tricks.Length == 0) {
            return;
            }
        foreach (Trick _trick in animalInfo.tricks) {
            StartCoroutine(_trick.DoTrick(this));
            }
        }

    public void FeedMe() {
        textMesh.SetText(animalInfo.thanksText);
        StartCoroutine(ActivateUI(balloon));
        }

    public void SayHello() {
        textMesh.SetText(animalInfo.helloText);
        StartCoroutine(ActivateUI(balloon));
        }

    public IEnumerator ActivateUI(GameObject _UI) {
        _UI.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        _UI.SetActive(false);
        }

    }
