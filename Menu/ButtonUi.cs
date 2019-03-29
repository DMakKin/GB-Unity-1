using UnityEngine;
using UnityEngine.UI;

public class ButtonUi : MonoBehaviour, IControl
{
    private Text _text;
    private Button _control;
    private void Awake()
    {
        _control = transform.GetComponentInChildren<Button>();
        _text = transform.GetComponentInChildren<Text>();
    }
    public Text GetText
    {
        get { return _text; }
    }
    public Button GetControl
    {
        get { return _control; }
    }
    public void Interactable(bool value)
    {
        GetControl.interactable = value;
    }
    public GameObject Instance { get { return gameObject; } }
    public Selectable Control { get { return GetControl; } }
}
