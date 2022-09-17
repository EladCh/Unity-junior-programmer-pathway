using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIManager : MonoBehaviour
{
    private TMP_InputField nameInputField;

    private void Start()
    {
        nameInputField = GameObject.Find("InputField").GetComponent<TMP_InputField>();
    }

    public void InputName()
    {
        string name = nameInputField.text;
        Debug.Log(name);

        nameInputField.text = "";
    }

    public void StartNew()
    {
        MainManager.Instance.SetCurrentPlayerName(nameInputField.text);
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
