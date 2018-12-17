using UnityEngine;
using UnityEditor;

/// <summary>
/// The following functions are made to keep the code inside the OnGUI method readable and most of them are not project specific and are reusabale
/// All functions use the screen.width as a scaler to keep the UI responsive, screen.width returns a width relative to the width of the current editor window
/// The main point of this is to do most of the scaling, UI design and input outside of the editor window. I put it inside of this class because I could not extend the editor scripts from unity directly
/// </summary>
public class ExtensionMethods {

    //creates a textfield and a label, returns the input text to the given text parameter
    public static string GetText(string _name, string _text) {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label(_name, GUILayout.Width(Screen.width / 2));
        string _newText = EditorGUILayout.TextField(_text, GUILayout.Width(Screen.width * 0.45f));
        EditorGUILayout.EndHorizontal();
        return _newText;
        }

    //creates an object field made for folders inside of the unity project, you can then extract the path to that folder with the following GetPath() function.
    public static DefaultAsset GetFolder(string _name, DefaultAsset _asset) {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label(_name, GUILayout.Width(Screen.width / 2));
        DefaultAsset targetFolder = (DefaultAsset)EditorGUILayout.ObjectField("", _asset, typeof(DefaultAsset), false, GUILayout.Width(Screen.width * 0.45f));
        EditorGUILayout.EndHorizontal();
        return targetFolder;
        }

    //returns the path of _targetfolder parameter
    public static string GetPath(string _name, string _path, DefaultAsset _targetFolder) {
        return AssetDatabase.GetAssetPath(_targetFolder);
        }

    //returns the value of a toggle box
    public static bool GetToggle(string _name, bool _bool) {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label(_name, GUILayout.Width(Screen.width / 2));
        bool _newBool = EditorGUILayout.Toggle("", _bool, GUILayout.Width(Screen.width * 0.45f));
        EditorGUILayout.EndHorizontal();
        return _newBool;
        }

    //returns the selected gameObject
    public static GameObject GameObjectField(string _name, GameObject _prefab) {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label(_name, GUILayout.Width(Screen.width / 2));

        GameObject _newGameObject = (GameObject)EditorGUILayout.ObjectField(_prefab, typeof(GameObject), false, GUILayout.Width(Screen.width * 0.45f));
        EditorGUILayout.EndHorizontal();
        return _newGameObject;
        }

    //returns sprite
    public static Sprite Spritefield(string _name, Sprite _sprite) {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label(_name, GUILayout.Width(Screen.width / 2));

        Sprite _newSprite = (Sprite)EditorGUILayout.ObjectField(_sprite, typeof(Sprite), false, GUILayout.Width(Screen.width * 0.45f));
        EditorGUILayout.EndHorizontal();
        return _newSprite;
        }

    //returns the selected scriptable animal
    public static ScriptableAnimal AnimalInfoField(string _name, ScriptableAnimal _prefab) {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label(_name, GUILayout.Width(Screen.width / 2));

        ScriptableAnimal _newObject = (ScriptableAnimal)EditorGUILayout.ObjectField(_prefab, typeof(ScriptableAnimal), false, GUILayout.Width(Screen.width * 0.45f));
        EditorGUILayout.EndHorizontal();
        return _newObject;
        }


    /// <summary>
    /// The trick and the move functions are different from the rest, because they required me to find a way to use arrays in a dynamic way.
    /// I store the _tricks/_moves parameter inside of a temporary array and resize the old _trick/_move parameter to the new amount of tricks.
    /// then all we have to do is repopulate the _trick/_moves array, so the previous information won't get lost when changes are made
    /// </summary>
    public static Trick[] SelectTricks(string _name, Trick[] _tricks, int _amountOfTricks) {

        Trick[] _tmp = _tricks;
        _tricks = new Trick[_amountOfTricks];

        GUILayout.BeginVertical();
        for (int i = 0; i < _amountOfTricks; i++) {
            if (i < _tmp.Length) {
                _tricks[i] = (Trick)EditorGUILayout.ObjectField(_tmp[i], typeof(Trick), false, GUILayout.Width(Screen.width * 0.45f));
                }
            }
        GUILayout.EndVertical();
        return _tricks;
        }

    public static AnimalAction[] SelectActions(string _name, AnimalAction[] _actions, int _amountOfActions) {

        AnimalAction[] _tmp = _actions;
        _actions = new AnimalAction[_amountOfActions];

        GUILayout.BeginVertical();
        for (int i = 0; i < _amountOfActions; i++) {
            if (i < _tmp.Length) {
                _actions[i] = (AnimalAction)EditorGUILayout.ObjectField(_tmp[i], typeof(AnimalAction), false, GUILayout.Width(Screen.width * 0.45f));
                }
            }
        GUILayout.EndVertical();
        return _actions;
        }

    }
