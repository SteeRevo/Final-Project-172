using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FollowMouse : MonoBehaviour
{
    public bool setActive = false;
    private TextMeshProUGUI textMesh;
    public string triggerName;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        setText();
        Vector3 mousePos = Input.mousePosition;
        this.transform.position = new Vector3(mousePos.x + 200, mousePos.y, mousePos.z);
    }

    void setText()
    {
        if(setActive)
        {
            textMesh.SetText(triggerName);
        }
        else
        {
            textMesh.SetText("");
        }
    }


}
