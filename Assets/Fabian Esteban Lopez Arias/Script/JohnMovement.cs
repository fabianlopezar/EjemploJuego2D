using UnityEngine;
using TMPro;

public class JohnMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
   public GameObject BulletPrefab;
    private AudioSource audioSource;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private float LastShoot;
    public  int Health = 5;
    public GameObject panelOver;
    public GameObject panelWin;

    public TMP_Text heartTxt;
    public bool estaMuerto = false;
    #region

    [Header("Audios")]
    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip runSound;
    #endregion
    private void Start()
    {

        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        heartTxt.text = "" + Health;
        panelOver.SetActive(false);
        panelWin.SetActive(false);


    }

    private void Update()
    {
        // Movimiento
        if (estaMuerto == false) {
            Horizontal = Input.GetAxisRaw("Horizontal");

            if (Horizontal < 0.0f) { transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f); PlaySound(runSound); }
            else if (Horizontal > 0.0f ) { transform.localScale = new Vector3(1.0f, 1.0f, 1.0f); PlaySound(runSound); }

            Animator.SetBool("running", Horizontal != 0.0f);

            // Detectar Suelo
            Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
            if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
            {
                Grounded = true;
            }
            else Grounded = false;

            // Salto
            if (Input.GetKeyDown(KeyCode.W) && Grounded)
            {

                Jump();
            }

            // Disparar
            if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f)
            {
                Shoot();
                LastShoot = Time.time;
            } }
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        PlaySound(jumpSound);
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit()
    {
        if (Health > 0)
        {
            Health -= 1;
            PlaySound(deathSound);
        }
       
        if (Health == 0)
        {
            //    Time.timeScale = 0;
            // panelWin.SetActive(true);
            estaMuerto = true;
            Animator.SetBool("muerto", true);
        }
        heartTxt.text = "" + Health;
        
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}