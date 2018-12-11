
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager _Instance;

    public List<Animal> animalList;
    public InputField nameInput;

    private void Awake() {
        if (_Instance == null) {
            _Instance = this;
            } else {
            Destroy(this);
            }
        }

   public void PerfomTricks()
    {
        foreach (Animal _animal in animalList)
        {
            if (_animal.tricks.Length > 0)
            {
                _animal.DoTrick();
            }
        }
    }

    public void FeedAnimals(string _tag) {
        foreach (Animal _animal in animalList) {
            if (_animal.tag == _tag || _animal.tag == "Omnivore") {
                _animal.FeedMe();
                }
            }
        }

    public Animal CheckListForName(string _name) {
        foreach (Animal _animal in animalList) {
            if (_animal.animalName == _name) {
                return _animal;
                }
            }
        return null;
        }

    public void SayHello() {
        if (CheckListForName(nameInput.text) != null) {
            CheckListForName(nameInput.text).SayHello();
            } else {
            foreach (Animal _animal in animalList) {
                _animal.SayHello();
                }
            }
        }
    }