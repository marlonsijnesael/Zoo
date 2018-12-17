
using UnityEngine;
using UnityEditor;


public class AnimalTool : EditorWindow {

    //Animal settings

    private string animalName = "animal name";
    private string animalSpecies = "animal species";
    private string helloText, thankText;
    private int speed = 0;
    private ScriptableAnimal.AnimalType eatingType;
    private enum AnimalType { Carnivore, Herbivore, Omnivore };
    private Trick[] tricks;
    private int amountOfTricks = 0;
    private AnimalAction[] actions;
    private int amountOfActions = 0;
    private Sprite animalSprite;


    //editor window settings
    private bool showCreateNewAnimal = false;
    public string animalInfoPath;
    private DefaultAsset animalInfoFolder;
    private GameObject animalPrefab;
    public string animalPrefabPath;
    private DefaultAsset animalPrefabFolder;
    private ScriptableAnimal animalInfo;



    [MenuItem("Window/Animal/Creator")]
    public static void ShowWindow() {
        GetWindow<AnimalTool>("Animal creator");

        }

    private void OnGUI() {
        GUILayout.Label("Animal creation tool", EditorStyles.boldLabel);
        GUILayout.Label("Tool setup", EditorStyles.boldLabel);

        //--------------------------------------------------------------------------------Tool settings-------------------------------------------------------//
        #region tool settings
        animalPrefab = ExtensionMethods.GameObjectField("Animal Template", animalPrefab);
        animalPrefabFolder = ExtensionMethods.GetFolder("Animal prefab folder", animalPrefabFolder);
        animalPrefabPath = ExtensionMethods.GetPath("target path", animalInfoPath, animalPrefabFolder);

        animalInfoFolder = ExtensionMethods.GetFolder("Animal info folder", animalInfoFolder);
        animalInfoPath = ExtensionMethods.GetPath("target path", animalInfoPath, animalInfoFolder);



        showCreateNewAnimal = ExtensionMethods.GetToggle("Create new Animal?", showCreateNewAnimal);

        #endregion

        if (showCreateNewAnimal) {
            GUILayout.Label("Animal stats", EditorStyles.boldLabel);
            //-----------------------------------------------------------------------------Animal stats--------------------------------------------------------//
            #region stats
            animalSprite = ExtensionMethods.Spritefield("animal sprite", animalSprite);
            animalName = ExtensionMethods.GetText("Animal name", animalName);
            animalSpecies = ExtensionMethods.GetText("Animal species", animalSpecies);
            helloText = ExtensionMethods.GetText("Hello text", helloText);
            thankText = ExtensionMethods.GetText("thankText", thankText);

            GUILayout.BeginHorizontal();
            GUILayout.Label("Speed", GUILayout.Width(Screen.width / 2));
            speed = EditorGUILayout.IntField(speed, GUILayout.Width(Screen.width / 2));
            GUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Select eating type", GUILayout.Width(Screen.width / 2));
            eatingType = (ScriptableAnimal.AnimalType)EditorGUILayout.EnumPopup("", eatingType, GUILayout.Width(Screen.width * 0.45f));
            EditorGUILayout.EndHorizontal();

            #endregion
            //---------------------------------------------------------------------------Moves and tricks------------------------------------------------------//
            #region tricks and moves
            GUILayout.Label("Animal moves and tricks", EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Amount of Actions", GUILayout.Width(Screen.width / 4));
            amountOfActions = EditorGUILayout.IntField(amountOfActions, GUILayout.Width(Screen.width / 4));
            actions = ExtensionMethods.SelectActions("", actions, amountOfActions);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Amount of tricks", GUILayout.Width(Screen.width / 4));
            amountOfTricks = EditorGUILayout.IntField(amountOfTricks, GUILayout.Width(Screen.width / 4));
            tricks = ExtensionMethods.SelectTricks("", tricks, amountOfTricks);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();
            #endregion

            //---------------------------------------------------------------------------create animal--------------------------------------------------------//
            if (GUILayout.Button("create animal")) {
                CreateNew(CreateAnimalScriptableObject());
                }
            } else {
            animalInfo = ExtensionMethods.AnimalInfoField("", animalInfo);
            if (GUILayout.Button("create animal")) {
                CreateNew(animalInfo);
                }
            }
        }

    //create new scriptable animal and assing all editor window values to it
    private ScriptableAnimal CreateAnimalScriptableObject() {
        ScriptableAnimal newAnimal = ScriptableObject.CreateInstance<ScriptableAnimal>();

        newAnimal.animalName = animalName;
        newAnimal.animalType = animalSpecies;
        newAnimal.eatingType = eatingType;
        newAnimal.tricks = tricks;
        newAnimal.actions = actions;
        newAnimal.helloText = helloText;
        newAnimal.thanksText = thankText;
        newAnimal.speed = speed;
        newAnimal.spr = animalSprite;

        AssetDatabase.CreateAsset(newAnimal, animalInfoPath + "/" + animalSpecies + ".asset");
        AssetDatabase.SaveAssets();

        return newAnimal;
        }

    //create a new animal and assign the scriptable animals to it
    private void CreateNew(ScriptableAnimal _animalInfo) {
        GameObject _animal = animalPrefab;
        _animal.GetComponent<Animal>().animalInfo = _animalInfo;
        _animal.GetComponent<Animal>().sprite = _animalInfo.spr;
        Object prefab = new Object();

        //check if asset already exists and if so, ask if the user is sure about overwriting the existing prefab
        if (AssetDatabase.LoadAssetAtPath(animalPrefabPath + "/" + _animalInfo.animalType + ".prefab", typeof(GameObject))) {
            if (EditorUtility.DisplayDialog("Are you sure?",
                    "The Prefab already exists. Do you want to overwrite it?",
                    "Yes",
                    "No"))
                //If the user presses the yes button, create the Prefab
                {
                prefab = PrefabUtility.CreatePrefab(animalPrefabPath + "/" + _animalInfo.animalType + ".prefab", _animal);
                PrefabUtility.ReplacePrefab(_animal, prefab, ReplacePrefabOptions.ConnectToPrefab);
                EditorUtility.FocusProjectWindow();
                }
            } else {
            prefab = PrefabUtility.CreatePrefab(animalPrefabPath + "/" + _animalInfo.animalType + ".prefab", _animal);
            PrefabUtility.ReplacePrefab(_animal, prefab, ReplacePrefabOptions.ConnectToPrefab);
            EditorUtility.FocusProjectWindow();
            }
        }
    }

