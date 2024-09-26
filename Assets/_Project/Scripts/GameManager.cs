using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _player;
    [SerializeField] private TMP_Text _currntPointsText;

    private float _currntPoints = 0f;
    private float _maxPoints;

    private void Start()
    {
        _maxPoints = PlayerPrefs.GetFloat("MaxPoints");
    }

    private void ComparePoints()
    {
        if (_currntPoints > _maxPoints)
        {
            _maxPoints = _currntPoints;
            PlayerPrefs.SetFloat("MaxPoints", _maxPoints);
        }
    }  
    
    private void AddCurrentPointsPoints(float value)
    {
        _currntPoints += value;
        _currntPointsText.text = _currntPoints.ToString();
    }

    private void ShowLosePanel()
    {
        _player.SetActive(false);
        _losePanel.SetActive(true);
    }

    public void LoadMainMenu()
    {
        ComparePoints();
        SceneManager.LoadScene(0);
    }

    private void OnEnable()
    {
        EventBus.OnEnemyDied += AddCurrentPointsPoints;
        EventBus.OnGameOver += ComparePoints;
        EventBus.OnGameOver += ShowLosePanel;
    }

    private void OnDisable()
    {
       EventBus.OnEnemyDied -= AddCurrentPointsPoints;
       EventBus.OnGameOver -= ComparePoints;
       EventBus.OnGameOver -= ShowLosePanel;
    }
}
