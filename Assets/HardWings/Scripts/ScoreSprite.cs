using UnityEngine;
using System.Collections;

public class ScoreSprite : MonoBehaviour {
    UISprite[] spriteList;
    public string text = "0";
    public bool isCenter = false;
    int[] widths = new int[] { 47, 35, 39, 40, 49, 41, 44, 44, 44, 44 };

	void Start () {
        spriteList = GetComponentsInChildren<UISprite>();
        for (int i = 0; i < spriteList.Length; i++)
            spriteList[i].transform.localPosition = Vector3.right * 44f * i;
		DrawNumbers ("0");
	}

    public void DrawNumbers(string str){
        text = (str.Length>6) ? str.Substring(0,6) : str;
        int i, pos = 0, first = 0;
        for (i = 0; i < text.Length; i++)
        {
            UISprite sprite = spriteList[i];
            string letter = text.Substring(i,1);
            int val = int.Parse(letter);
            sprite.spriteName = letter;
            if (!sprite.enabled) sprite.enabled = true;
            sprite.MakePixelPerfect();
            float delta = (val == 1) ? -5f : 0f;
            sprite.transform.localPosition = Vector3.right * (pos + delta);
            pos += widths[val];
            if (i == 0) first = widths[val];
        }
        while (i < spriteList.Length)
        {
            UISprite sprite = spriteList[i];
            if (sprite.enabled) sprite.enabled = false;
            i++;
        }
        float half = pos / 2 - first / 2;
        if (isCenter) transform.localPosition = Vector3.left * half + Vector3.up * transform.localPosition.y;
    }
	
	void Update () {
	
	}
}
