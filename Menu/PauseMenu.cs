using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool pauseActive = false;
    [SerializeField] private GameObject _thisUI;
    [SerializeField] private GameObject _playerUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseActive)
            {
                Reaume();
            }
            else
            {                
                Pause();
            }
        }
    }

    public void Reaume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _thisUI.SetActive(false);
        _playerUI.SetActive(true);
        Time.timeScale = 1f;
        pauseActive = false;
    }

    private void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        _thisUI.SetActive(true);
        _playerUI.SetActive(false);
        Time.timeScale = 0f;
        pauseActive = true;
    }

    public void LoadMenu()
    {
        _thisUI.SetActive(false);
        _playerUI.SetActive(true);
        Time.timeScale = 1f;
        pauseActive = false;
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Interface.QuitGame();
    }
}
