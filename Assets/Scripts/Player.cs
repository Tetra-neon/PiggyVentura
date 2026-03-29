using System.Runtime.CompilerServices;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5; //variable para la velocidad del cerdito
    private Rigidbody2D rb2D; //variable para modificar luego el salto o el movimiento del cerdito
    private float move; //Variable para almacenar el movimiento del cerdito
    public float jumpForce = 4; //Variable para la fuerza del salto del cerdito
    private bool isGrounded; //Variable para saber si el cerdito está en el suelo
    public Transform groundCheck; //Variable para el punto de comprobación del suelo
    public float groundCheckRadius = 0.1f; //Variable para el radio de comprobación del suelo
    public LayerMask groundLayer; //Variable para la capa del suelo
    private Animator animator; //Variable para el componente de animación del cerdito
    private int frutas; //Variable para contar las frutas que el cerdito ha recogido
    public TMP_Text frutasText; //Variable para mostrar el número de frutas recogidas
    public AudioSource audioSource; //Variable para el sonido
    public AudioClip frutaClip; //Variable para el sonido de la fruta
    public AudioClip barrilClip; //Variable para el sonido de la colision de los barriles

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); //para poder acceder al componente dentro de unity
        animator = GetComponent<Animator>(); //para poder acceder al componente de animación dentro de unity
    }

    void Update()
    {
        move= Input.GetAxisRaw("Horizontal"); //para mover al cerdito a la izquierda o derecha
        rb2D.linearVelocity = new Vector2(move * speed, rb2D.linearVelocity.y); //para que el cerdito se mueva a la izquierda o derecha dependiendo de la variable move y la velocidad
    
        if(move != 0) //para que el cerdito gire dependiendo de la dirección a la que se mueva
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1); //para que el cerdito gire dependiendo de la dirección a la que se mueva
        
        if (Input.GetButtonDown("Jump") && isGrounded) //para que el cerdito salte si se presiona la barra espaciadora y el cerdito está en el suelo
            {
                rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpForce); //para que el cerdito salte dependiendo de la fuerza del salto
            }
            animator.SetFloat("Speed", Mathf.Abs(move)); //para que el valor sea siempre positivo
            animator.SetFloat("VerticalVelocity", rb2D.linearVelocity.y); //para saber si estamos saltando o cayendo
            animator.SetBool("IsGrounded", isGrounded); //para saber si el cerdito está en el suelo
        }
        private void FixedUpdate() //para comprobar si el cerdito está en el suelo
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); //para comprobar si el cerdito está en el suelo dependiendo de la posición del punto de comprobación, el radio de comprobación y la capa del suelo
        }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.transform.CompareTag("Fruta")) //para comprobar si el cerdito colisiona con una fruta
        {
            audioSource.PlayOneShot(frutaClip);
            Destroy(collision.gameObject); //para destruir la fruta si el cerdito colisiona con ella
            frutas++; //para aumentar el contador de frutas recogidas
            frutasText.text = frutas.ToString(); //para actualizar el texto que muestra el número de frutas recogidas
        }

        if (collision.transform.CompareTag("Puas")) //para comprobar si el cerdito colisiona con las puas
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //para reiniciar el nivel si el cerdito colisiona con las puas
        }

        if (collision.transform.CompareTag("Barril")) //para comprobar si el cerdito colisiona con el barril
        {
            audioSource.PlayOneShot(barrilClip);
            Vector2 knockbackDir = (rb2D.position - (Vector2)collision.transform.position).normalized; //para calcular la dirección del knockback dependiendo de la posición del cerdito y la posición del barril
            rb2D.linearVelocity = Vector2.zero; //para resetear la velocidad del cerdito antes de aplicar el knockback
            rb2D.AddForce(knockbackDir * 3, ForceMode2D.Impulse); //para aplicar la fuerza de impulso

            BoxCollider2D[] colliders= collision.gameObject.GetComponents<BoxCollider2D>(); //para obtener el componente de colisión del barril
            
            foreach (BoxCollider2D col in colliders) //para desactivar el componente de colisión del barril durante un corto período de tiempo para evitar colisiones múltiples
            {
                col.enabled = false; //para desactivar el componente de colisión del barril
            }
            collision.GetComponent<Animator>().enabled = true; //para activar la animación de destrucción del barril
            Destroy(collision.gameObject, 0.5f); //para destruir el barril después de 0.5 segundos para que se vea la animación de destrucción
        }
    }
}