using UnityEngine;

public class ChangeColorTet : MonoBehaviour
{
    public GameObject tetWirt;
    public Material[] materials; // Array de materiales para asignar aleatoriamente
    private Color[] colors = new Color[] {Color.white, Color.magenta, Color.green, Color.yellow, Color.cyan}; // Array de colores
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() // Se ejecuta una sola vez cuando se inicia nuestra escena
    {
        if (materials.Length == 0) {
            Debug.LogError("No se han asignado materiales en el array 'materials'");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void ChangeColor_BTN(){
        if (tetWirt != null)
        {
            Renderer renderer1 = tetWirt.GetComponent<Renderer>();

            if (renderer1 != null)
            {
                // Verificar que hay materiales en el array antes de acceder a ellos
                if (materials.Length > 0)
                {
                    // Genera un índice aleatorio para el color y para el material
                    int randomColorIndex = Random.Range(0, colors.Length);
                    int randomMaterialIndex = Random.Range(0, materials.Length);

                    // Aplica el color aleatorio en el Albedo (color principal) del material
                    renderer1.material.color = colors[randomColorIndex];

                    // Aplica un material aleatorio
                    renderer1.material = materials[randomMaterialIndex];

                    // Cambia el color de la propiedad Albedo dentro del material asignado
                    renderer1.material.SetColor("_Color", colors[randomColorIndex]); // Cambia el color del material
                }
                else
                {
                    Debug.LogError("No hay materiales asignados en el array 'materials'.");
                }
            }
            else
            {
                Debug.LogError("El componente Renderer no está adjunto a alguno de los objetos.");
            }
        }
        else
        {
            Debug.LogError("Los objetos conoWirt y tetWirt no están asignados.");
        }
    }
}
