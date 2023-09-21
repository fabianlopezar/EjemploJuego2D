using UnityEngine;
using TMPro;
using System.IO;

[System.Serializable]
public class MonedasData
{
    public int valor;
    public TMP_Text nombreTXT;
}

public class Monedas : MonoBehaviour
{
    public TMP_Text valorUI;
    public TMP_Text nombreTXT;
    public TMP_Text seGuardoTXT;

    public int valor = 0;
    public string monedasTxt;
    public GameObject panelWin;

    private string dataFilePath = "monedasData.json"; // Nombre del archivo JSON
  
    public void Awake(){
Debug.Log("Se cargo la informacion");
            LoadDataFromJson();
        panelWin.SetActive(false);
}
    void Update()
    {
        // Detectar si se presiona la tecla 'G' para guardar datos
        if (Input.GetKeyDown(KeyCode.G))
        {
Debug.Log("Se guardo la informacion");
            SaveDataToJson();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Moneda")) 
        {
            valor++;
            GameManager.Instance.SumarPuntos(1);
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
        if (File.Exists(dataFilePath))
        {
            string jsonData = File.ReadAllText(dataFilePath);
            MonedasData monedasData = JsonUtility.FromJson<MonedasData>(jsonData);

            valor = monedasData.valor;
            UpdateUI();
        }
    }
    public void TraerInfo()
    {
       //GameManager.
    }

}

