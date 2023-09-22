using UnityEngine;
using TMPro;
using System.IO;

[System.Serializable]
public class DataPlayer
{
    public float _coinsValue;
    public string _name;
}

public class SaveData : MonoBehaviour
{
    public TMP_Text _nameTMP;
    private string dataFilePath = "monedasData.json";

    public void Start()
    {
        LoadDataFromJson();
      
    }

    public void SaveDataToJson()
    {
        RecibirNombre();//actualizo la variable del GameManager
        DataPlayer dataPlayer = new DataPlayer(); //Creo una instancia de la clase que quiero guardar en Json.
        dataPlayer._coinsValue = GameManager.Instance._coins;//declaro las variables que recibe esa clase.
        dataPlayer._name = GameManager.Instance._name;//declaro las variables que recibe esa clase.

        string jsonData = JsonUtility.ToJson(dataPlayer);

        // Guardar la cadena JSON en un archivo
        File.WriteAllText(dataFilePath, jsonData);
        Debug.Log("se guardaromn los datos: "+dataPlayer+"-"+dataPlayer._name+"-"+dataPlayer._coinsValue);
        //Debug.Log("se guardaromn los datos: "+);
       // seGuardoTXT.text = "Se guardo el nombre de: " + nombreTXT.text + "y el puntaje de: " + valor;
    }
   public void LoadDataFromJson()
    {
        Debug.Log("Se cargo la informacion");
        if (File.Exists(dataFilePath))
        {
            string jsonData = File.ReadAllText(dataFilePath);
            DataPlayer dataPlayer = JsonUtility.FromJson<DataPlayer>(jsonData);

            GameManager.Instance._coins = dataPlayer._coinsValue;
            GameManager.Instance._name = dataPlayer._name;
        }
    }
    public void RecibirNombre() //Este Metodo actualiza el nombre del GameManager.
    {
        GameManager.Instance._name = _nameTMP.text;
    }

}
