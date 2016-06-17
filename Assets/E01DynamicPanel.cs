using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class E01DynamicPanel : MonoBehaviour
{
    [SerializeField]
    private Text _title;

    [SerializeField]
    private Image _image;

    [SerializeField]
    private Button _button;

    private E01Window _parentWindow = null;

    public void SetData(E01Window parentWindow,string title)
    {
        _title.text   = title;
        _parentWindow = parentWindow;
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        if(_parentWindow != null)
        {
            _parentWindow.SetMainText("Last Pressed "+_title.text);
        }
        Debug.LogWarning("Button Clicked");
    }

}
