using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalObject : MonoBehaviour {

    public Animal animal;

    private void Start() {
     
        }

    private void Update() {
        animal.DoAction();
        }
    }
