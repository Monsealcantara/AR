using UnityEngine;

public class ActivarModeloAlLlegar : MonoBehaviour
{
    public GameObject[] modelos; // Arreglo para varios modelos
    //public GameObject canvas;    // Canvas que también quieres activar

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Personaje"))
        {
            // Activar todos los modelos
            foreach (var modelo in modelos)
            {
                modelo.SetActive(true); // Muestra cada modelo
            }

            // Activar el Canvas
            // if (canvas != null)
            // {
            //     canvas.SetActive(true);
            // }
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

            // Desactivar el Canvas
            // if (canvas != null)
            // {
            //     canvas.SetActive(false);
            // }
        }
    }
}
