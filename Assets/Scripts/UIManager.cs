using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    public InputField inputField;
    private string playerName;

    void Start()
    {
        DataManager.instance.load();
        highScoreText.text = $"High Score: {DataManager.instance.highScorePlayerName} : {DataManager.instance.highScore}";
    }
    public void StartGame()
    {
        DataManager.instance.playerName = playerName;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        DataManager.instance.save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void updateName()
    {
        playerName = inputField.text;
        Debug.Log(playerName);
    }

    public void resetData()
    {
        DataManager.instance.deleteSave();
    }
}