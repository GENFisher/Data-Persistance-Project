using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuManager : MonoBehaviour
{
    public TMPro.TMP_InputField playerNameInput;
    public TMPro.TextMeshProUGUI highScoreText;

    private void Start()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.LoadScore();
            if(!string.IsNullOrEmpty(ScoreManager.Instance.lastName))
            {
                playerNameInput.text = ScoreManager.Instance.lastName;
            }
            highScoreText.text = $"Best Score : {ScoreManager.Instance.playerName} : {ScoreManager.Instance.highScore}";
        }
    }
    public void StartGame()
    {
        ScoreManager.Instance.lastName = playerNameInput.text;
        ScoreManager.Instance.SaveScore();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
