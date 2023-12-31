using UnityEngine;
using TMPro;
using System.IO;

[System.Serializable]
public class DataPlayer //Esta Clase va a ser la plantilla para guardar mis datos.
{
    public float _coinsValue;
    public string _name;
}

public class SaveData : MonoBehaviour
{
    public TMP_Text _nameTMP; //Este es el texto que recibo y guardo(_name).
    public TMP_Text _showName;//Este texto muestra el nombre guardado.
    public TMP_Text _showCoin;//Este texto muestra las monedas guardadas.
    private string dataFilePath = "monedasData.json"; //Creo un string con el nombre del archivo que quiero crear.

    public void Awake()
    {
        LoadDataFromJson();      
    }

    public void SaveDataToJson()
    {
        RecibirNombre();//actualizo la variable (GameManager._name) con lo que recibo por pantalla.
        DataPlayer dataPlayer = new DataPlayer(); //Creo una instancia de la clase que quiero guardar en Json.
        dataPlayer._coinsValue = GameManager.Instance._coins;//declaro las variables que recibe esa clase.
        dataPlayer._name = GameManager.Instance._name;//declaro las variables que recibe esa clase.

        string jsonData = JsonUtility.ToJson(dataPlayer);//Esta linea sirve para convertir un objeto llamado dataPlayer en una cadena de texto que representa ese objeto en formato JSON. 

        // Guardar la cadena JSON en un archivo
        File.WriteAllText(dataFilePath, jsonData);//esta línea de código toma la cadena jsonData y la escribe en el archivo especificado por dataFilePath.
       
	MostrarDatosGuardados();
    }
   public void LoadDataFromJson()
    {
        Debug.Log("Se cargo la informacion");
        if (File.Exists(dataFilePath))
        {
            string jsonData = File.ReadAllText(dataFilePath);
            DataPlayer dataPlayer = JsonUtility.FromJson<DataPlayer>(jsonData);//El propósito de este método es convertir una cadena JSON en un objeto del tipo especificado, que en este caso es DataPlayer.

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
