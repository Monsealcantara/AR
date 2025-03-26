using UnityEngine;
using Vuforia;
using UnityEngine.UI; // Necesario para manejar el texto

using System.Collections;
public class MoveObject : MonoBehaviour
{
    public GameObject modelPerson;
    public ObserverBehaviour[] ImageTargets2;
    public Text[] markerTexts; // Aquí asignaremos los textos que mostrarán el baile en cada marcador
    public float speed2 = 1.0f;
    private bool isMoving2 = false;
    private string[] danceTypes = { "Hip Hop", "Rumba", "Twist" }; // Las animaciones posibles

    public void MoveToMarker2(int indexT)
    {
        if (!isMoving2 && indexT >= 0 && indexT < ImageTargets2.Length)
        {
            StartCoroutine(MovePerson(indexT));
        }
    }

    private IEnumerator MovePerson(int indexT)
    {
        isMoving2 = true;
        ObserverBehaviour target = ImageTargets2[indexT];

        if (target == null || !(target.TargetStatus.Status == Status.TRACKED || target.TargetStatus.Status == Status.EXTENDED_TRACKED))
        {
            isMoving2 = false;
            yield break;
        }

        // Mostrar un texto aleatorio en el marcador
        string randomDance = danceTypes[Random.Range(0, danceTypes.Length)];
        markerTexts[indexT].text = "Baile: " + randomDance;

        Vector3 startPositionW = modelPerson.transform.position;
        Vector3 endPosition = target.transform.position;

        float journey = 0;

        while (journey <= 1f)
        {
            journey += Time.deltaTime * speed2;
            modelPerson.transform.position = Vector3.Lerp(startPositionW, endPosition, journey);
            yield return null;
        }

        isMoving2 = false;
    }
}


// using UnityEngine;
// using Vuforia;
// using System.Collections;

// public class MoveObject : MonoBehaviour
// {
//     public GameObject modelPerson;
//     //public GameObject modelG;
//     public ObserverBehaviour[] ImageTargets2;
//     public float speed2 = 1.0f; 
//     private bool isMoving2 = false; 

//     // Mueve el modelo al marcador específico indicado por el índice
//     public void MoveToMarker2(int indexT)
//     {
//         if (!isMoving2 && indexT >= 0 && indexT < ImageTargets2.Length)
//         {
//             StartCoroutine(MovePerson(indexT));
//         }
//     }

//     private IEnumerator MovePerson(int indexT)
//     {
//         isMoving2 = true;
//         ObserverBehaviour target = ImageTargets2[indexT];

//         if (target == null || !(target.TargetStatus.Status == Status.TRACKED || target.TargetStatus.Status == Status.EXTENDED_TRACKED))
//         {
//             isMoving2 = false;
//             yield break;
//         }

//         Vector3 startPositionW = modelPerson.transform.position;
//         Vector3 endPosition = target.transform.position;

//         float journey = 0;

//         while (journey <= 1f)
//         {
//             journey += Time.deltaTime * speed2;  
//             modelPerson.transform.position = Vector3.Lerp(startPositionW, endPosition, journey);
//             yield return null;    
//         }

//         isMoving2 = false;
//     }
// }