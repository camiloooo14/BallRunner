using UnityEngine;

public class Moviles : MonoBehaviour
{
    public Transform[] objetos;
    public float rango = 5f;
    public float velocidad = 5f;

    private Vector3[] posicionesIniciales;

    private void Start()
    {
        // Almacena las posiciones iniciales de todos los objetos
        posicionesIniciales = new Vector3[objetos.Length];
        for (int i = 0; i < objetos.Length; i++)
        {
            posicionesIniciales[i] = objetos[i].position;
        }
    }

    private void Update()
    {
        for (int i = 0; i < objetos.Length; i++)
        {
            // Calcula el movimiento para cada objeto
            float movimiento = Mathf.PingPong(Time.time * velocidad, rango) - rango;
            objetos[i].position = new Vector3(posicionesIniciales[i].x + movimiento, posicionesIniciales[i].y, posicionesIniciales[i].z);
        }
    }
}
