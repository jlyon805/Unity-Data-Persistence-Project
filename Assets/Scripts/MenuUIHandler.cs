using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    public InputField NameEntry;
   // Start is called before the first frame update
    void Start()
    {

    }

    public void StartGame()
    {
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

    public void NameEntered()
    {
        if(GameDataManager.Instance == null)
        {
            Debug.Log("NULLREF: GameDataManager is null!");
        }

        if(NameEntry.text != null)
        {
            GameDataManager.Instance.PlayerName = NameEntry.text;
        }
        else
        {
            Debug.Log("Input Text is null!");
        }
    }
}
