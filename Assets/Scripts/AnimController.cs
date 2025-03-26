using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con el texto

public class AnimController : MonoBehaviour
{
    public Animator animController;
    public AudioSource audioSource;
    public AudioClip[] clips;
    public Text[] markerTexts; // Los textos de los marcadores
    private int currentMarker = 0; // Indicador del marcador actual
    private string[] danceTypes = { "Hip Hop", "Rumba", "Twist" }; // Los tipos de baile

    void Start()
    {
        animController = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.Stop();
        animController.SetBool("ActivaBaile", false);
        animController.SetBool("ActivaRum", false);
        animController.SetBool("ActivaTwi", false);
    }

    public void ActivDance(int num)
    {
        print("El botón presionado es: " + num);

        // Establecer animación y audio basados en el número del botón
        SetAnimationAndAudio(num);

        // Verificar si la animación es la correcta
        if (markerTexts[currentMarker].text.Contains(danceTypes[num]))
        {
            // Si el baile es correcto, mover al siguiente marcador
            currentMarker++;
            if (currentMarker >= markerTexts.Length)
            {
                currentMarker = 0; // Si ya está al final, vuelve al marcador inicial
            }
        }
        else
        {
            // Si el baile es incorrecto, volver al marcador inicial
            currentMarker = 0;
        }
    }

    private void SetAnimationAndAudio(int num)
    {
        animController.SetBool("ActivaBaile", false);
        animController.SetBool("ActivaRum", false);
        animController.SetBool("ActivaTwi", false);

        switch (num)
        {
            case 0: // Hip Hop
                animController.SetBool("ActivaBaile", true);
                audioSource.clip = clips[0];
                break;
            case 1: // Rumba
                animController.SetBool("ActivaRum", true);
                audioSource.clip = clips[1];
                break;
            case 2: // Twist
                animController.SetBool("ActivaTwi", true);
                audioSource.clip = clips[2];
                break;
            case 3: // Detener
                animController.SetBool("ActivaBaile", false);
                animController.SetBool("ActivaRum", false);
                animController.SetBool("ActivaTwi", false);
                audioSource.Stop();
                break;
        }

        if (!audioSource.isPlaying && num != 3)
        {
            audioSource.Play();
        }
    }
}





// using UnityEngine;

// public class AnimController : MonoBehaviour
// {
//     public Animator animController;  // Referencia al componente Animator
//     public AudioSource audioSource;  // Para manejo de sonidos
//     public AudioClip[] clips;       // Array para los clips de audio (uno por cada animación)

//     void Start()
//     {
//         animController = gameObject.GetComponent<Animator>();  // Obtener el componente Animator
//         if (animController == null)
//         {
//             Debug.LogError("No se encontró el componente Animator en el objeto " + gameObject.name);
//         }

//         audioSource = gameObject.GetComponent<AudioSource>();  // Obtener el componente AudioSource
//         if (audioSource == null)
//         {
//             Debug.LogError("No se encontró el componente AudioSource en el objeto " + gameObject.name);
//         }

//         // Inicializamos el audio y las animaciones
//         audioSource.loop = true; 
//         audioSource.Stop();  
//         animController.SetBool("ActivaBaile", false);  
//         animController.SetBool("ActivaRum", false);  
//         animController.SetBool("ActivaTwi", false);
//     }

//     // Esta función es llamada desde el botón con el parámetro que le asignemos
//     public void ActivDance(int num)
//     {
//         print("El botón presionado es: " + num);
        
//         // Llamamos a la función para cambiar la animación y el audio según el número del botón
//         SetAnimationAndAudio(num);
//     }

//     // Método para activar animación y reproducir audio basado en el número de botón
//     private void SetAnimationAndAudio(int num)
//     {
//         // Detenemos todas las animaciones y desactivamos los bools
//         animController.SetBool("ActivaBaile", false);
//         animController.SetBool("ActivaRum", false);
//         animController.SetBool("ActivaTwi", false);

//         // Cambiar animación y audio según el número del botón
//         switch (num)
//         {
//             case 0: // Hip Hop Dancing (animación 1)
//                 animController.SetBool("ActivaBaile", true);  // Activamos Hip Hop
//                 audioSource.clip = clips[0];  // Audio de Hip Hop
//                 break;
//             case 1: // Rumba Dancing (animación 2)
//                 animController.SetBool("ActivaRum", true);  // Activamos Rumba
//                 audioSource.clip = clips[1];  // Audio de Rumba
//                 break;
//             case 2: // Twist Dancing (animación 3)
//                 animController.SetBool("ActivaTwi", true);  // Activamos Twist
//                 audioSource.clip = clips[2];  // Audio de Twist
//                 break;
//             case 3: // Detener todas las animaciones
//                 animController.SetBool("ActivaBaile", false);
//                 animController.SetBool("ActivaRum", false);
//                 animController.SetBool("ActivaTwi", false);
//                 audioSource.Stop();  // Detener el audio
//                 break;
//         }

//         // Reproducir el nuevo clip de audio si no está sonando
//         if (!audioSource.isPlaying && num != 3) // Solo reproducir si no estamos en el caso de "detener"
//         {
//             audioSource.Play();
//         }
//     }
// }
//*/*/*/*/*/*/*/*/*/**/*/*/*/*/*/*/*/*
// using UnityEngine;

// public class AnimController : MonoBehaviour
// {
//     public Animator animController;  
//     public AudioSource audioSource;  
//     public AudioClip[] clips;       

//     private int danceCounter = 0; 

//     void Start()
//     {
//         animController = gameObject.GetComponent<Animator>();  
//         if (animController == null)
//         {
//             Debug.LogError("No se encontró el componente Animator en el objeto " + gameObject.name);
//         }

//         audioSource = gameObject.GetComponent<AudioSource>();  
//         if (audioSource == null)
//         {
//             Debug.LogError("No se encontró el componente AudioSource en el objeto " + gameObject.name);
//         }

//         // Inicializamos el audio y las animaciones
//         audioSource.loop = true; 
//         audioSource.clip = clips[0]; 
//         audioSource.Play(); 
//         animController.SetBool("ActivaBaile", true); 
//     }

//     void Update()
//     {
        
//         if (animController != null && audioSource != null)
//         {
//             // Cambiar la animación y el audio al presionar la barra espaciadora
//             if (Input.GetKeyDown(KeyCode.Space))
//             {
//                 // Incrementar el contador
//                 danceCounter++;

                
//                 if (danceCounter >= clips.Length)
//                 {
//                     danceCounter = 0;
//                 }

//                 // Cambiar animación y audio según el contador
//                 switch (danceCounter)
//                 {
//                     case 0: // Idle (primera animación)
//                         animController.SetBool("ActivaBaile", true);
//                         animController.SetBool("ActivaRum", false);
//                         animController.SetBool("ActivaTwi", false);
//                         audioSource.clip = clips[0]; // Audio de la primera animación
//                         break;
//                     case 1: // Rumba Dancing (segunda animación)
//                         animController.SetBool("ActivaBaile", false);
//                         animController.SetBool("ActivaRum", true);
//                         animController.SetBool("ActivaTwi", false);
//                         audioSource.clip = clips[1]; // Audio de la segunda animación
//                         break;
//                     case 2: // Twist Dancing (tercera animación)
//                         animController.SetBool("ActivaBaile", false);
//                         animController.SetBool("ActivaRum", false);
//                         animController.SetBool("ActivaTwi", true);
//                         audioSource.clip = clips[2]; // Audio de la tercera animación
//                         break;
//                 }

                
//                 if (!audioSource.isPlaying)
//                 {
//                     audioSource.Play();
//                 }
//             }

//             // Detener la animación y el audio al presionar la tecla "O"
//             if (Input.GetKeyDown(KeyCode.O))
//             {
                
//                 animController.SetBool("ActivaBaile", false);
//                 animController.SetBool("ActivaRum", false);
//                 animController.SetBool("ActivaTwi", false);
//                 audioSource.Stop();  
//             }
//         }
//     }
// }








// using UnityEngine;

// public class AnimController : MonoBehaviour
// {
//     //public AnimatorCrontoller
//     public Animator animController;
//     public AudioSource audioSource;
//     //public AudioClip[] clips;

//     // Start is called once before the first execution of Update after the MonoBehaviour is created
    
//     void Start()
//     {
//         animController=gameObject.GetComponent<Animator>();
//         //audioSource = gameObject.GetComponent<AudioSource>();
//         //audioSource.clip = clips[0];
//     }
//     // Update is called once per frame
//     void Update()
//     {
//         if(Input.GetKeyDown(KeyCode.Space))
//         {
//             //animController.SetTrigger("ActivRebote");
//             animController.SetBool("ActivaBaile", true);
//             //animController.SetBool(KeyCode.O);       //accede a la tecla O
//             // if (!audioSource.isPlaying){
//             //      audioSource.Play();
//             // }
//         }
//         if (Input.GetKeyDown(KeyCode.O)){
//             animController.SetBool("ActivaBaile", false);
//             //audioSource.Stop();
//         }
//     }
// }