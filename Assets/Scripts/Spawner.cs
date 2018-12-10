
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject[] animals;

    public void Start() {
        foreach (GameObject go in animals) {
            GameObject newewAnimal = Instantiate(go);
            newewAnimal.name = go.name;
            newewAnimal.transform.position = new Vector3(0, 0, 0);
            Animal animalScript = newewAnimal.GetComponent<Animal>();
            GameManager._Instance.animalList.Add(animalScript);
            }
        }
    }