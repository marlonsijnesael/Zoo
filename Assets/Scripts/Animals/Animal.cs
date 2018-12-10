using System.Collections;
using UnityEngine;

public class Animal : MonoBehaviour {
    //screen bounds
    [HideInInspector]
    public int left = -5;
    [HideInInspector]
    public int right = 5;
    [HideInInspector]
    public int top = 5;
    [HideInInspector]
    public int down = -5;

    [Header("Animal Info")]
    public string animalName;

    public AnimalType eatingType;
    public enum AnimalType { Carnivore, Herbivore };

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

    private TextMesh textMesh;
    private SpriteRenderer sprRend;

    
    private void Start() {
        this.gameObject.tag = eatingType.ToString();

        sprRend = gameObject.AddComponent<SpriteRenderer>();
        sprRend.sprite = sprite;

        //textMesh = textObject.GetComponent<TextMeshPro>();
        balloon.SetActive(false);
        }

    private void Update() {
        DoAction();
        }

    public void DoAction() {
        foreach (AnimalAction _action in actions)
            _action.DoAction(this);
        }

    public void DoTrick() {
        foreach (Trick _trick in tricks) {
            _trick.DoTrick();
            }
        }

    public void FeedMe() {
        //textMesh.
        StartCoroutine(ActivateUI(balloon));
        }

    public void SayHello() {
       // textMesh.text = helloText;
        StartCoroutine(ActivateUI(balloon));
        }

    public IEnumerator ActivateUI(GameObject _UI) {
        _UI.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        _UI.SetActive(false);
        }

    }
