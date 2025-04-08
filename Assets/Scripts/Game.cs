using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Timer _timer;
    [SerializeField] private Button _restartButton;

    private bool _isGameOver = false;

    private void Update()
    {
        if (_isGameOver) return;

        if (_timer.IsTimeUp)
            Lose();

        if (_ball.oranges == 10)
            Win();
    }

    private void Lose()
    {
        _isGameOver = true;
        Time.timeScale = 0f;
        Debug.Log("Вы проиграли!");
        Cursor.lockState = CursorLockMode.None;
        _restartButton.gameObject.SetActive(true);
    }

    private void Win()
    {
        _isGameOver = true;
        Time.timeScale = 0f;
        Debug.Log("Вы победили!");
        Cursor.lockState = CursorLockMode.None;
        _restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
