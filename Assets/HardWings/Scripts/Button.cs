using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
    public GameObject target;
    public string downMessage = "OnClickDown";
    public string upMessage = "OnClickUp";

    void OnMouseDown()
    {
        if (target && downMessage.Length>0) target.SendMessage(downMessage, SendMessageOptions.DontRequireReceiver);
    }
    void OnMouseUp()
    {
        if (target && upMessage.Length > 0) target.SendMessage(upMessage, SendMessageOptions.DontRequireReceiver);
    }

}
