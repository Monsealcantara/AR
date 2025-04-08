using UnityEngine;

public class cambioMarcador : MonoBehaviour
{
    public GameObject harryPotter;  // Referencia al modelo "HarryPotter"
    private Transform originalParent;

    // Este método se llama cuando otro collider entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto que entra en la zona es "HarryPotter"
        if (other.gameObject == harryPotter)
        {
            // Cambiar el "padre" de HarryPotter al marcador actual
            harryPotter.transform.SetParent(transform);
            originalParent = transform; // Guardamos el padre actual
        }
    }

    // Este método se llama cuando otro collider sale del trigger
    private void OnTriggerExit(Collider other)
    {
        // Si "HarryPotter" sale del área del marcador
        if (other.gameObject == harryPotter)
        {
            // Aquí puedes decidir si mantenerlo en su lugar o devolverlo a su estado inicial
            harryPotter.transform.SetParent(null);  // Opcional: Desasociarlo del marcador
        }
    }
}



// using UnityEngine;
// using Vuforia;

// public class cambioMarcador : MonoBehaviour
// {
//     public GameObject harryPotter;  // Referencia al modelo "HarryPotter"
//     public GameObject[] marcadores;  // Lista de marcadores
//     private Transform currentParent;

//     void Start()
//     {
//         // Asegúrate de que no haya un padre asignado al principio
//         currentParent = null;
//     }

//     void Update()
//     {
//         // Verificar todos los marcadores
//         foreach (GameObject marcador in marcadores)
//         {
//             // Verificar si el marcador está siendo detectado
//             if (IsMarkerVisible(marcador))
//             {
//                 // Cambiar el padre solo si el marcador detectado es diferente
//                 if (currentParent != marcador.transform)
//                 {
//                     harryPotter.transform.SetParent(marcador.transform);
//                     currentParent = marcador.transform;
//                 }
//                 return;  // Salir del ciclo una vez que un marcador es detectado
//             }
//         }
//     }

//     // Función para comprobar si el marcador está visible
//     bool IsMarkerVisible(GameObject marker)
//     {
//         // Usamos Vuforia para verificar si el marcador está siendo seguido
//         TrackableBehaviour.Status status = marker.GetComponent<TrackableBehaviour>().CurrentStatus;
//         return status == TrackableBehaviour.Status.TRACKED || status == TrackableBehaviour.Status.EXTENDED_TRACKED;
//     }
// }
