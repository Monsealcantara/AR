using UnityEngine;
using UnityEngine.UI;  // Necesario para el botón

public class AdvertenciaUI : MonoBehaviour
{
    public GameObject advertenciaPanel;  // El Panel que contiene el mensaje
    public Button continuarButton;       // El botón de "OK"
    public GameObject botonInicio;       // El botón de inicio que estará desactivado al principio

    void Start()
    {
        // Desactivar el botón de inicio al inicio
        botonInicio.SetActive(false); 

        // Mostrar el panel de advertencia
        advertenciaPanel.SetActive(true);

        // Añadir el listener al botón de continuar
        continuarButton.onClick.AddListener(OcultarAdvertencia);
    }

    // Función que oculta la advertencia y activa el botón de inicio
    void OcultarAdvertencia()
    {
        advertenciaPanel.SetActive(false);  // Desactiva el panel de advertencia

        // Activar el botón de inicio
        botonInicio.SetActive(true);  
    }
}
