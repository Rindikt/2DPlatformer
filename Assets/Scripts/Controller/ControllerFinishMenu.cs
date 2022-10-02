using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class ControllerFinishMenu
{
    private FinishMenuView _finishMenu;
    public ControllerFinishMenu(FinishMenuView finishMenu)
    {
        _finishMenu = finishMenu;
        _finishMenu.Restart.onClick.AddListener(Restart);
        _finishMenu.Exit.onClick.AddListener(Exit);
    }
    
    public void OnFinishMenu(int score)
    {
        SetScore(score);
        _finishMenu.gameObject.SetActive(true);

    }
    private void Restart()
    {
        _finishMenu.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
    private void Exit()
    {
        Application.Quit();
    }
    private void SetScore(int score)
    {
        _finishMenu.Score.text = score.ToString();
    }

}
