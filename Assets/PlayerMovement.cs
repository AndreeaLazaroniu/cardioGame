using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    public Vector3 move;

    //intercaion
    public float playerReach = 3f;
    Interactable currentInteractable;

    public GameObject infoPanel; // Drag your Panel here in the Inspector
    public Camera playerCamera;
    public float interactRange = 3f;
    public TextMeshProUGUI uiText; // Drag your InfoPanel text here

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
        {
            SceneManager.LoadScene("quiz");
        }

        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            ToggleInfo();
        }

        if (Input.GetKeyDown(KeyCode.G) && currentInteractable != null)
        {
            SceneManager.LoadScene("HeartScene");
        }
    }

    public void ToggleInfo()
    {
        if (infoPanel.activeSelf)
        {
            infoPanel.SetActive(false);
            return;
        }

        // Shoots a ray from the center of the screen
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange))
        {
            // Try to find the InteractableItem script on what we hit
            InteractableItem item = hit.collider.GetComponent<InteractableItem>();

            if (item != null)
            {
                // Set the UI text to the specific text of that object
                uiText.text = "<b>" + item.itemName + "</b>\n" + item.infoText;
                infoPanel.SetActive(true);
            }
        }
    }

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        //if colliders with anything 
        if (Physics.Raycast(ray, out hit, playerReach))
        {
            if (hit.collider.tag == "Interactable") // if looking at an interactable obj
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                if (currentInteractable && newInteractable != currentInteractable)
                {
                    currentInteractable.DisableOutline();
                }
                if (newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }
                else
                {
                    DisableCurrentInteractable();
                }
            }
            else
            {
                DisableCurrentInteractable();
            }
        }
        else
        {
            DisableCurrentInteractable();
        }
    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
        TextController.instance.EnableInteractionText(currentInteractable.message);
    }

    void DisableCurrentInteractable()
    {
        TextController.instance.DisableInteractionText();
        if (currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }
}
