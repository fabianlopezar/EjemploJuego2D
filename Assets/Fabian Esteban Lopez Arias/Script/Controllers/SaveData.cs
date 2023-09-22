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
    public TMP_Text _showName;
    public TMP_Text _showCoin;
    private string dataFilePath = "monedasData.json";

    public void Awake()
    {
        LoadDataFromJson();      
    }

    public void SaveDataToJson()
    {
        RecibirNombre();//actualizo la variable del _name GameManager con lo que recibo.
        DataPlayer dataPlayer = new DataPlayer(); //Creo una instancia de la clase que quiero guardar en Json.
        dataPlayer._coinsValue = GameManager.Instance._coins;//declaro las variables que recibe esa clase.
        dataPlayer._name = GameManager.Instance._name;//declaro las variables que recibe esa clase.

        string jsonData = JsonUtility.ToJson(dataPlayer);

        // Guardar la cadena JSON en un archivo
        File.WriteAllText(dataFilePath, jsonData);
        Debug.Log("se guardaromn los datos: "+dataPlayer+"-"+dataPlayer._name+"-"+dataPlayer._coinsValue);
MostrarDatosGuardados();
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
    public void RecibirNombre() //Este Metodo actualiza la variable nombre del GameManager.
    {
        GameManager.Instance._name = _nameTMP.text;
    }
public void MostrarDatosGuardados(){

_showName.text=_nameTMP.text;
_showCoin.text=""+GameManager.Instance._coins;
}
    

}
