using UnityEngine;
public class Manager : MonoBehaviour
{
    public GameObject panelInicio, panelPausa, panelGameOver;
    public void Start()
    {
        Time.timeScale = 0;
        panelPausa.SetActive(false);
        panelGameOver.SetActive(false);
    }
    public void Iniciar()
    {
        Time.timeScale = 1;
        panelInicio.SetActive(false);
        panelPausa.SetActive(false);
        panelGameOver.SetActive(false);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        panelPausa.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        panelPausa.SetActive(false);
    }
}

