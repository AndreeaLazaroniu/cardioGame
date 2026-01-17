using UnityEngine;

public class PopupUI : MonoBehaviour
{
    public GameObject popupPanel;
    public KeyCode toggleKey = KeyCode.E;

    void Start()
    {
        popupPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            popupPanel.SetActive(!popupPanel.activeSelf);
        }
    }
}