using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string Name;
    public bool Purchased;
    public Animator ButtonAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetButtonState(bool clicked)
    {
        ButtonAnimator.SetBool("Clicked", clicked);
    }
}
