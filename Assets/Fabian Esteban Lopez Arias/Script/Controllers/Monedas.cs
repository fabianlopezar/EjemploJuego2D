using UnityEngine;
using TMPro;
public class Monedas : MonoBehaviour
{
    public TMP_Text valorUI;
    public TMP_Text nombreTXT;
    public TMP_Text seGuardoTXT;
    public float valor;//este me sirve para actualizar la UI.
    public GameObject panelWin;

    public void Start(){
    panelWin.SetActive(false);
    UpdateUI();
    Debug.Log( GameManager.Instance._coins);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Moneda")) 
        {
            GameManager.Instance.AddCoins();
            UpdateUI();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Ganar"))
        {
            WinEvent();
        }
    }
    public void UpdateUI()
    {    
        valor = GameManager.Instance._coins;
        valorUI.text = "" + valor;
    }
  
    public void WinEvent()
    {
        panelWin.SetActive(true);
        Time.timeScale = 0;
    }
  

}

