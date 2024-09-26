using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _clickerZone;
    [SerializeField] private TMP_Text _currntPointsText;

    private float _currntPoints = 0f;
    private float _maxPoints;

    private void Start()
    {
        _maxPoints = PlayerPrefs.GetFloat("MaxPoints");
        _player.SetActive(true);
        _losePanel.SetActive(false);
        _clickerZone.SetActive(true);
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
        _clickerZone.SetActive(false);
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
