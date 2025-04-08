using UnityEngine;

public class ActivarYDesactivarModelo : MonoBehaviour
{
    public GameObject[] modelosAsociados; // Arreglo para varios modelos
    //public GameObject canvas;             // El Canvas que quieres activar

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Personaje"))
        {
            // Activar todos los modelos y el canvas cuando el personaje entra
            foreach (var modelo in modelosAsociados)
            {
                modelo.SetActive(true); // Mostrar cada modelo
            }

            // if (canvas != null)
            // {
            //     canvas.SetActive(true); // Mostrar el canvas
            // }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Personaje"))
        {
            // Desactivar todos los modelos y el canvas cuando el personaje sale
            foreach (var modelo in modelosAsociados)
            {
                modelo.SetActive(false); // Ocultar cada modelo
            }

            // if (canvas != null)
            // {
            //     canvas.SetActive(false); // Ocultar el canvas
            // }
        }
    }
}
