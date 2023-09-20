using UnityEngine;
using TMPro;
using System.IO;

[System.Serializable]
public class MonedasData
{
    public int valor;
}

public class Monedas : MonoBehaviour
{
    public TMP_Text valorUI;
    public int valor = 0;
    public string monedasTxt;

    private string dataFilePath = "monedasData.json"; // Nombre del archivo JSON
public void Awake(){
Debug.Log("Se cargo la informacion");
            LoadDataFromJson();
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
            UpdateUI();
            Destroy(other.gameObject);
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

        string jsonData = JsonUtility.ToJson(monedasData);

        // Guardar la cadena JSON en un archivo
        File.WriteAllText(dataFilePath, jsonData);
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
}

/*
  using TMPro;                  // Importacion   
  public TMP_Text valorUI;      // Declaracion
  valorUI.text = "" + valor;    // Actualizacion
 */