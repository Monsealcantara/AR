using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public GameObject modelOvGWall;
    private Color[] colors = new Color[] {Color.white, Color.magenta, Color.green, Color.yellow, Color.cyan}; // Array de 5 colores
    private int colorIndex = 0; // Índice para saber el color actual
    //public Color color;
    //public Material colorMaterial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() //Se ejecuta una sola vez cuando se inicia nuestra escena
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//Función para cambiar de color
    public void ChangeColor_BTN(){
        modelOvGWall.GetComponent<Renderer>().material.color = Color.white;
        if (modelOvGWall != null)
        {
            Renderer renderer = modelOvGWall.GetComponent<Renderer>();
            if (renderer != null)
            {
                // Cambia al siguiente color
                colorIndex = (colorIndex + 1) % colors.Length;  // Aumenta el índice y lo reinicia cuando llega al final del array
                renderer.material.color = colors[colorIndex];  // Aplica el nuevo color
            }
            else
            {
                Debug.LogError("El componente Renderer no está adjunto al objeto modelOvGWall.");
            }
        }
        //colorMaterial.color = color;
    }
}
