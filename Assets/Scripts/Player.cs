using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private float movementX;
    private float movementY;
    public GameObject winTextObject;

    public float speed = 0;

    // Referencia al material que usa el shader
    public Material shaderMaterial;
    public Material shaderMaterial2;
    public Material shaderMaterial3;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        winTextObject.SetActive(false);

        // Inicializar _RevealValue en 2.0
        shaderMaterial.SetFloat("_RevealValue", 2.0f);
        shaderMaterial2.SetFloat("_RevealValue", 2.0f);
        shaderMaterial3.SetFloat("_RevealValue", 2.0f);
    }

    void OnMove(InputValue movementValue)

    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
        SetCountText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lows"))
        {
            Destroy(other.gameObject);
            Vector3 velocidadActual = rb.linearVelocity;
            Vector3 FuerzaFreno = -velocidadActual.normalized * 5f;
            speed *= 0.1f;
            rb.AddForce(FuerzaFreno, ForceMode.Impulse);
        }
        if (other.gameObject.CompareTag("Afuera"))
        {
            // Aplica una fuerza hacia la izquierda (en el eje negativo X)
            Vector3 forceDirection = new Vector3(1f, 0f, 0f);  // Dirección hacia la izquierda
            float forceMagnitude = 20f;  // La magnitud de la fuerza aplicada (ajústalo según lo necesites)

            // Aplica la fuerza al Rigidbody
            rb.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);  // Usamos Impulse para una fuerza instantánea
        }
        if (other.gameObject.CompareTag("Hueco"))
        {
            Destroy(gameObject);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
            winTextObject.SetActive(true);
        }
    }

    void SetCountText()
    {
       
        if (transform.position.z >= 530f && transform.position.z <= 742f)
        {
            winTextObject.GetComponent<TextMeshProUGUI>().text = "Nivel 2";
            winTextObject.SetActive(true);

        }


        if (transform.position.z >= 742f && transform.position.z <= 920f)
        {
            winTextObject.GetComponent<TextMeshProUGUI>().text = "Nivel 3";
            winTextObject.SetActive(true);

        }


        if (transform.position.z >= 920f && transform.position.z <= 1282f)
        {
            winTextObject.GetComponent<TextMeshProUGUI>().text = "Nivel 4";
            winTextObject.SetActive(true);

        }

        if (transform.position.z >= 1282f && transform.position.z <= 1503f)
        {
            winTextObject.GetComponent<TextMeshProUGUI>().text = "Nivel 5";
            winTextObject.SetActive(true);

        }
        if (transform.position.z >= 1503f)
        {
            Destroy(gameObject);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "WIIIIIIN!";
            winTextObject.SetActive(true);

        }

        if (transform.position.x >= 10f)
        {
            Destroy(gameObject);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "YOU LOSE!";
            winTextObject.SetActive(true);

        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
            winTextObject.SetActive(true);
            Destroy(gameObject);


            // Cambiar el valor de _RevealValue
            shaderMaterial.SetFloat("_RevealValue", -2f);
            shaderMaterial2.SetFloat("_RevealValue", -2f);
            shaderMaterial3.SetFloat("_RevealValue", -2f);

            // Actualizar el texto del objeto de victoria/derrota

        }
    }
}
