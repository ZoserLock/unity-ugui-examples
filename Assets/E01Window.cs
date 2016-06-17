using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class E01Window : MonoBehaviour
{
    [SerializeField]
    private Button _controlButtonAdd;

    [SerializeField]
    private Button _controlButtonRemove;

    [SerializeField]
    private Transform _dynamicPanelParent;

    [SerializeField]
    private GameObject _referenceDynamicPanel;

    [SerializeField]
    private Text _mainText;

    private List<E01DynamicPanel> _panelList = new List<E01DynamicPanel>();

    // Use this for initialization
    void Start()
    {
        _controlButtonAdd.onClick.AddListener(AddDynamicPanel);
        _controlButtonRemove.onClick.AddListener(RemoveDynamicPanel);

        _referenceDynamicPanel.gameObject.SetActive(false);
    }
	
    public void AddDynamicPanel()
    {
        E01DynamicPanel panel = CreateDynamicPanel("Panel: "+Random.Range(0,100));

        _panelList.Add(panel);
    }

    public void RemoveDynamicPanel()
    {
        if(_panelList.Count > 0)
        {
            E01DynamicPanel panel = _panelList[_panelList.Count - 1];
            _panelList.RemoveAt(_panelList.Count - 1);
            Destroy(panel.gameObject);
        }
    }

    private E01DynamicPanel CreateDynamicPanel(string title)
    {
        GameObject newDynamicPanel = GameObject.Instantiate(_referenceDynamicPanel);

        E01DynamicPanel dynamicPanel = newDynamicPanel.GetComponent<E01DynamicPanel>();

        dynamicPanel.SetData(this,title);
        dynamicPanel.transform.SetParent(_dynamicPanelParent);
        dynamicPanel.transform.localScale = Vector3.one;
        dynamicPanel.transform.localPosition = Vector3.zero;
        dynamicPanel.gameObject.SetActive(true);


        return dynamicPanel;
    }

    public void SetMainText(string text)
    {
        _mainText.text = text;
    }
    
}
