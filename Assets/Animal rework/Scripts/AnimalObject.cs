using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalObject : MonoBehaviour {

    public Animal animal;

    private void Start() {
        this.gameObject.tag = animal.eatingType.ToString();
        }

    private void Update() {
        animal.DoAction();
        }
    }
