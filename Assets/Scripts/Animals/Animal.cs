
using UnityEngine;
using UnityEngine.UI;


public class Animal : MonoBehaviour {

    [Header("Animal Info")]
    public string animalName;

    public AnimalType eatingType;
    public enum AnimalType { Carnivore, Herbivore };

    [Header("Animal Settings")]
    public int left;
    public int right;
    public int top;
    public int down;

    public float speed;
    public Vector3 goal;
  
    [Header("Animal Behaviour")]
    public AnimalAction[] actions;
    public Trick[] tricks;

    [Header("Animal UI Components")]
    public Sprite sprite;
    public GameObject Balloon;
    public Text text;

    private void Start() {
        this.gameObject.tag = eatingType.ToString();
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

    }
