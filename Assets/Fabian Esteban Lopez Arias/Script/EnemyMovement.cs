using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
    public Transform jugador; // Referencia al objeto del jugador
    public float distanciaSeguimiento = 5.0f; // Distancia m�nima para comenzar a seguir al jugador
    public float velocidad = 3.0f; // Velocidad de movimiento del enemigo
    private Animator Animator;


    private void Start()
    {
      
        Animator = GetComponent<Animator>();
    
    }
    private void Update()
    {
        if (jugador != null)
        {
            // Calcula la distancia entre el enemigo y el jugador
            float distancia = Vector3.Distance(transform.position, jugador.position);

            // Si el jugador est� lo suficientemente cerca, sigue al jugador
            if (distancia <= distanciaSeguimiento)
            {
                // Calcula la direcci�n hacia el jugador
                Vector3 direccion = jugador.position - transform.position;
                direccion.Normalize();

                // Mueve al enemigo en direcci�n al jugador a la velocidad especificada
                transform.Translate(direccion * velocidad * Time.deltaTime);
                Animator.SetBool("estaCorriendo",true );
            }
            else
            {
                Animator.SetBool("estaCorriendo", false);
            }
        }
    }
}
