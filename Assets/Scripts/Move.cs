using UnityEngine;
using Vuforia;
using System.Collections;

public class Move : MonoBehaviour
{
    public GameObject modelW;
    public GameObject modelG;
    public ObserverBehaviour[] ImageTargets;
    public float speed = 1.0f; 
    private bool isMoving = false; 

    void Start()
    {
        
    }

    // Mueve el modelo al marcador específico indicado por el índice
    public void MoveToMarker(int indexT)
    {
        if (!isMoving && indexT >= 0 && indexT < ImageTargets.Length)
        {
            StartCoroutine(MoveModel(indexT));
        }
    }

    private IEnumerator MoveModel(int indexT)
    {
        isMoving = true;
        ObserverBehaviour target = ImageTargets[indexT];

        if (target == null || !(target.TargetStatus.Status == Status.TRACKED || target.TargetStatus.Status == Status.EXTENDED_TRACKED))
        {
            isMoving = false;
            yield break;
        }

        Vector3 startPositionG = modelG.transform.position;
        Vector3 startPositionW = modelW.transform.position;
        Vector3 endPosition = target.transform.position;

        float journey = 0;

        while (journey <= 1f)
        {
            journey += Time.deltaTime * speed;  
            modelG.transform.position = Vector3.Lerp(startPositionG, endPosition, journey);
            modelW.transform.position = Vector3.Lerp(startPositionW, endPosition, journey);
            yield return null;    
        }

        isMoving = false;
    }
}


// using UnityEngine;
// using Vuforia;
// using System.Collections;

// public class Move : MonoBehaviour
// {
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     public GameObject modelW;
//     public GameObject modelG;
//     public ObserverBehaviour[] ImageTargets;
//     public int currentTarget;   //me ayuda a indicar cual es el marcador actual
//     public float speed = 1.0f; //velocidad de traslado del modelo
//     //si pongo algo como privado, no aparecerá el unity
//     private bool isMoving = false; //para saber si llegó al marcador final, indica si se está moviendo o no
//     void Start()
//     {
        
//     }
// //corutinas
//     public void moveToNextMarker(){
//         if(!isMoving){  //si no se está moviendo....
//             StartCoroutine(MoveModel());    //...comienzo el moviemiento
//         }
//     }

//     //generación de corrutinas
//     private IEnumerator MoveModel(){
//         isMoving = true;
//         ObserverBehaviour target = GetNextDetectedTarget();
//         if(target == null){
//             isMoving = false;
//             yield break;
//         }
//         Vector3 startPosition=modelG.transform.position;
//         Vector3 startPositionW=modelW.transform.position;
//         Vector3 endPosition=target.transform.position;

//         float journey = 0;

//         while(journey <= 1f){
//             journey+=Time.deltaTime*speed;  //se va a trasladar cuando llegue a 1
//             modelG.transform.position=Vector3.Lerp(startPosition,endPosition, journey);  //indicamos que la nueva posición del modelo va a ser un vector3
//             modelW.transform.position=Vector3.Lerp(startPositionW,endPosition, journey);
//             yield return null;    //detengo la corrutina
//         }
        
//         currentTarget = (currentTarget + 1) % ImageTargets.Length;
//         isMoving=false;     //esto para indicar que ya terminé el recorrido
//     }
//     private ObserverBehaviour GetNextDetectedTarget(){
//         foreach(ObserverBehaviour target in ImageTargets){
//             if(target != null && (target.TargetStatus.Status==Status.TRACKED || target.TargetStatus.Status==Status.EXTENDED_TRACKED)){
//                 return target;
//             }
//         }
//         return null;
//     }
//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }