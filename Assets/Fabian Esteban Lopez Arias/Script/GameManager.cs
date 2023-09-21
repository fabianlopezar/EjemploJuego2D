using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    //Estás declarando una propiedad llamada PuntosTotales. Esta propiedad es de tipo int y tiene un get público y un set privado. Esto permite acceder al valor de los puntos totales desde fuera de la clase GameManager, pero solo la clase GameManager puede modificarlo directamente.
    public int PuntosTotales { get; private set; }
    //Estás declarando una variable de instancia privada llamada puntosTotales.Esta variable se utiliza para almacenar el valor real de los puntos totales en el juego.
    private int puntosTotales;
    public float _coins{ get; private set; }

private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Mas de un GameManager en escena.");
        }
    }

    public void SumarPuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
    }
    public void AddCoins()
    {
        _coins ++;
    }
    

}
