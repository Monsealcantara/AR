using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimationTrigger : MonoBehaviour
{
    public Button button;  // El botón con el que interactuaremos
    public Animator[] animators;  // Un array de Animators (para los diferentes objetos)

    void Start()
    {
        // Asegúrate de que el botón no esté vacío
        if (button != null)
        {
            // Asocia la función al evento OnClick del botón
            button.onClick.AddListener(TriggerAnimation);
        }
    }

    // Esta función será llamada cuando se haga clic en el botón
    void TriggerAnimation()
    {
        foreach (Animator animator in animators)
        {
            if (animator != null)
            {
                // Activa la animación en cada Animator
                animator.SetTrigger("animLaves1");
            }
        }
    }
}
