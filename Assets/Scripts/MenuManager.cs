using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public TMP_Text BestScoreText;
    public TMP_InputField InputName;

    // Start is called before the first frame update
    void Start()
    {

        InputName.text = MainUIManager.Instance.Username;
        InputName.onValueChanged.AddListener(TextMeshUpdated);
        MainUIManager.Instance.LoadScore();

        BestScoreText.text = $"Best Score :{MainUIManager.Instance.BestUsername} : {MainUIManager.Instance.bestScore}";
    }

    public void TextMeshUpdated(string text)
    {
        MainUIManager.Instance.Username = text;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        //MainManager.Instance.SaveScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
