using UnityEngine;


/// <summary>
/// scriptable object for creating different animals
/// </summary>
[CreateAssetMenu(menuName = "Animals/AnimalInfo")]
public class ScriptableAnimal : ScriptableObject {
    [Header ("Do not forget to attach this scriptable object to an animalObject script instance")]
    [Header("Animal Info")]
    public string animalName;
    public string animalType;

    public AnimalType eatingType;
    public enum AnimalType { Carnivore, Herbivore, Omnivore };

    public Sprite spr;

    [Header("Animal Settings")]
    public float speed;
    
    [HideInInspector]
    public Vector3 goal;

    [Header("Animal Behaviour")]
    public AnimalAction[] actions;
    public Trick[] tricks;
    public string helloText;
    public string thanksText;
    }
