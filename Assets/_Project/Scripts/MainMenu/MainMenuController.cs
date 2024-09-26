using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private TMP_Text _highScroteText;

    private void Start()
    {
        _highScroteText.text = PlayerPrefs.GetFloat("MaxPoints").ToString();
    }

    public void LoadGamePlayScene()
    {
        SceneManager.LoadScene(1);
    }
}
