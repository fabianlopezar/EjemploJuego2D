using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
    public Transform jugador; // Referencia al objeto del jugador
    public float distanciaSeguimiento = 5.0f; // Distancia mínima para comenzar a seguir al jugador
    public float velocidad = 3.0f; // Velocidad de movimiento del enemigo
    private Animator Animator;
    public GameObject BulletPrefab;
    private float LastShoot;

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

            // Si el jugador está lo suficientemente cerca, sigue al jugador
            if (distancia <= distanciaSeguimiento)
            {
                // Calcula la dirección hacia el jugador
                Vector3 direccion = jugador.position - transform.position;
                direccion.Normalize();

                // Mueve al enemigo en dirección al jugador a la velocidad especificada
                transform.Translate(direccion * velocidad * Time.deltaTime);
                Animator.SetBool("estaCorriendo",true );

                Shoot();
                LastShoot = Time.time;
            }
            else
            {
                Animator.SetBool("estaCorriendo", false);
            }
        }
    }
    private void Shoot()
    {
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }
}

