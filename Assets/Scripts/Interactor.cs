using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public LayerMask InteractableLayerMask;
    private Camera _cameraMain;
    private UnityEvent onInteracted;

    // Start is called before the first frame update
    void Start()
    {
        _cameraMain = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(_cameraMain.transform.position, _cameraMain.transform.forward, out hit, 2,
                InteractableLayerMask))
        {
            // Debug.Log(hit.collider.name);
        }
    }

    public void OnInteract(InputValue value)
    {
        RaycastHit hit;

        if (Physics.Raycast(_cameraMain.transform.position, _cameraMain.transform.forward, out hit, 2,
                InteractableLayerMask))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable)
            {
                Debug.Log("I'm interacting with something");
                bool purchased = GameManager.Instance.PurchaseUpgrade(interactable.Name);
                interactable.SetButtonState(purchased);
            }
        }
    }
    
    private bool _firstJump = false;

    public void OnJump(InputValue value)
    {
        if (_firstJump) return;

        _firstJump = true;
        
        AudioManager.Instance.Play("OfficeWorker");
    }

    public void OnExit(InputValue value)
    {
        if (value.isPressed)
        {
            Application.Quit();
        }
    }
}
