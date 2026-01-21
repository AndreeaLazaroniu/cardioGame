using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [TextArea(3, 10)]
    public string infoText; // Type the unique info here for each object
    public string itemName;
}