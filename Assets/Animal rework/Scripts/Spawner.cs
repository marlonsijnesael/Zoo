using UnityEngine;

/// <summary>
/// This class is used to spawn animals, you can add the animals to the array in the inspector
/// </summary>
public class Spawner : MonoBehaviour {
    public GameObject[] animals;

    public void Start() {
        SpawnAnimals();
        }

    ///instantiate animal and add it to the list of animals in the gamemanager
    private void SpawnAnimals() {
        foreach (GameObject go in animals) {
            GameObject newewAnimal = Instantiate(go);
            newewAnimal.name = go.name;
            newewAnimal.transform.position = new Vector3(0, 0, 0);
            Animal animalScript = newewAnimal.GetComponent<Animal>();
            GameManager._Instance.animalList.Add(animalScript);
            }
        }
    }