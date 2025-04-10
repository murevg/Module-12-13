using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Timer _timer;
    [SerializeField] private Button _restartButton;
    [SerializeField] private OrbitCamera _camera;

    private string _winText = "Вы победили!";
    private string _loseText = "Вы проиграли!";

    [SerializeField] private int _winCondition = 10;

    private bool _isGameOver = false;

    private void Update()
    {
        if (_isGameOver)
            return;

        if (_timer.IsTimeUp)
            Lose();

        if (_wallet.Value == _winCondition)
            Win();
    }

    private void Lose()
    {
        _isGameOver = true;
        Pause();
        Debug.Log(_loseText);
        _restartButton.gameObject.SetActive(true);
    }

    private void Win()
    {
        _isGameOver = true;
        Pause();
        Debug.Log(_winText);
        _restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        Unpause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Pause()
    {
        _camera.PauseCamera();
        Time.timeScale = 0f;
    }

    private void Unpause()
    {
        _camera.UnpauseCamera();
        Time.timeScale = 1f;
    }
}
