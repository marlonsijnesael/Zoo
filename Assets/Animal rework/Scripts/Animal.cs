using System.Collections;
using UnityEngine;
using TMPro;

public class Animal : MonoBehaviour {
    //screen bounds
    
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

    [Header("Animal Info")]
    public string animalName;
    public string animalType;

    public AnimalType eatingType;
    public enum AnimalType { Carnivore, Herbivore, Omnivore };

    [Header("Animal Settings")]
    public float speed;
    public Vector3 goal;

    [Header("Animal Behaviour")]
    public AnimalAction[] actions;
    public Trick[] tricks;
    public string helloText;
    public string thanksText;

    [Header("Animal UI Components")]
    public Sprite sprite;
    public GameObject balloon;
    public GameObject textObject;
    private TextMeshPro textMesh;
    private SpriteRenderer sprRend;
    private bool DoingTrick = false;
    
    private void Start() {
        this.gameObject.tag = eatingType.ToString();

        sprRend = gameObject.AddComponent<SpriteRenderer>();
        sprRend.sprite = sprite;

        textMesh = textObject.GetComponent<TextMeshPro>();
        balloon.SetActive(false);
        }

    private void Update() {
        if (!DoingTrick)
            DoAction();
        }

    public void DoAction() {
        if (actions.Length == 0)
        {
            return;
        }
        foreach (AnimalAction _action in actions)
        {
            _action.DoAction(this);
        }
        
        }

    public void DoTrick() {
        if (tricks.Length == 0)
        {
            return;
        }
        foreach (Trick _trick in tricks) {
            StartCoroutine(_trick.DoTrick(this));
            }
        }

    public void FeedMe() {
        textMesh.SetText( thanksText);
        StartCoroutine(ActivateUI(balloon));
        }

    public void SayHello() {
        textMesh.SetText(helloText);
        StartCoroutine(ActivateUI(balloon));
        }

    public IEnumerator ActivateUI(GameObject _UI) {
        _UI.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        _UI.SetActive(false);
        }

    }
