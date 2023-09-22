using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
   
    public float _coins{ get;  set; }
    public string _name{ get;  set; }

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

    public void AddCoins()
    {
        _coins ++;
    }
    

}
