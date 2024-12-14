using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{

    public TMP_InputField inputText;
    public int HighScore;
    public TextMeshProUGUI menuBestScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     menuBestScore.text = $"LastScore is of {SessionManager.Instance.playerName} is {SessionManager.Instance.highScore}";   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        Debug.Log("start button is start");

        string playerName = inputText.text;

        SessionManager.Instance.playerName = playerName;
        Debug.Log("written by player : " + playerName);

        SessionManager.Instance.highScore = HighScore;

        SceneManager.LoadScene(1);
    }

    //exit scene management
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
