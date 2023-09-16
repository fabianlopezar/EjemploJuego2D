using UnityEngine;
using TMPro;

public class Monedas : MonoBehaviour
{
    public TMP_Text valorUI;
    public int valor = 0;
    public string monedasTxt;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Moneda")) 
        {
            Debug.Log("de");
            valor++;
            UpdateUI();
            Destroy(other.gameObject);
        }
    }
    public void UpdateUI()
    {
        valorUI.text = ""+valor;
    }
    

}

