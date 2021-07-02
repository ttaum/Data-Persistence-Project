using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public string inputName;
    public InputField inputField;
    public Text bestScoreText;

    private void Start()
    {
        PersistentData.Instance.LoadName();
        if (PersistentData.Instance.BestName != null)
        { 
            bestScoreText.text = $"Best Score: {PersistentData.Instance.BestName}:" +
            $" {PersistentData.Instance.BestScore}";
        }
       
       
        Debug.Log(Application.persistentDataPath);
        
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void StoreName()
    {
        inputName = inputField.text;
        PersistentData.Instance.PlayerName = inputName;
        PersistentData.Instance.SaveName();
    }

    public void Exit()
    {
        PersistentData.Instance.SaveName();   

#if UNITY_EDITOR
    EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
