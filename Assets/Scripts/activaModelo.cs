using UnityEngine;

public class ActivarModeloAlLlegar : MonoBehaviour
{
    public GameObject[] modelos; // Arreglo para varios modelos

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Personaje"))
        {
            // Activar todos los modelos
            foreach (var modelo in modelos)
            {
                modelo.SetActive(true); // Muestra cada modelo
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Personaje"))
        {
            // Desactivar todos los modelos
            foreach (var modelo in modelos)
            {
                modelo.SetActive(false); // Oculta cada modelo
            }
        }
    }
}
