using UnityEngine;
using TMPro;
using System.IO;

[System.Serializable]
public class MonedasData
{
    public float valor;
    public TMP_Text nombreTXT;
}

public class Monedas : MonoBehaviour
{
    public TMP_Text valorUI;
    public TMP_Text nombreTXT;
    public TMP_Text seGuardoTXT;

    public float valor;    //SaveData
    public string monedasTxt;    //SaveData

    public GameObject panelWin;

    private string dataFilePath = "monedasData.json";     //SaveData

    public void Awake(){
         
            LoadDataFromJson();
            panelWin.SetActive(false);
            valor = GameManager.Instance._coins;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Moneda")) 
        {
            valor++;
            GameManager.Instance.SumarPuntos(1);
            GameManager.Instance.AddCoins();
            UpdateUI();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Ganar"))
        {
            panelWin.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void UpdateUI()
    {
        valorUI.text = "" + valor;
    }

    // Método para guardar los datos en formato JSON
    public void SaveDataToJson()
    {
        MonedasData monedasData = new MonedasData();
        monedasData.valor = valor;
        monedasData.nombreTXT = nombreTXT;

        string jsonData = JsonUtility.ToJson(monedasData);

        // Guardar la cadena JSON en un archivo
        File.WriteAllText(dataFilePath, jsonData);
        Debug.Log("se guardaromn los datos");
        seGuardoTXT.text = "Se guardo el nombre de: "+nombreTXT.text+"y el puntaje de: "+valor;
    }

    // Método para cargar los datos desde el archivo JSON
    public void LoadDataFromJson()
    {
        Debug.Log("Se cargo la informacion");
        if (File.Exists(dataFilePath))
        {
            string jsonData = File.ReadAllText(dataFilePath);
            MonedasData monedasData = JsonUtility.FromJson<MonedasData>(jsonData);

            valor = monedasData.valor;
            UpdateUI();
        }
    }
  

}

