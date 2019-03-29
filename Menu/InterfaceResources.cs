using UnityEngine;
using UnityEngine.UI;

public class InterfaceResources : MonoBehaviour
{

    public ButtonUi ButtonPrefab { get; private set; }
    public Canvas MainCanvas { get; private set; }
    public LayoutGroup MainPanel { get; private set; }
    private void Awake()
    {
        InterfaceResources _interfaceResources = GetComponent<InterfaceResources>();
        LangManager.Instance.Init("Language");

        ButtonPrefab = Resources.Load<ButtonUi>("Button");
        MainCanvas = FindObjectOfType<Canvas>();
        MainPanel = MainCanvas.GetComponentInChildren<LayoutGroup>();
    }
}
