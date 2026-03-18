using UnityEngine;

public class ButtonClickScript : MonoBehaviour
{

    HUDScript HUDScript;
    private Animator animator;


    void Start()
    {
        HUDScript = Object.FindFirstObjectByType<HUDScript>(); // Auto-finds it in the scene
        animator = GetComponent<Animator>();

    }

    void OnMouseDown()
    {
        Debug.Log("Button pressed");
        animator.Play("ButtonClick");
        HUDScript.StartGame();
    }
}
