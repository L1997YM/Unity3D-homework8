using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bulletin : MonoBehaviour{
	public Text text;
	private int frame = 20;

	void Start()
	{
		text.gameObject.SetActive(false);
		Button button = this.gameObject.GetComponent<Button>();
		button.onClick.AddListener(ClickButton);
	}

	void ClickButton()
	{
		if(text.gameObject.activeSelf)   StartCoroutine(messageIn());
		else   StartCoroutine(messageOut());
	}

	IEnumerator messageIn()
	{
		float rotation_x = 0;
		float height = 100;
		for(int i = 0;i < frame; ++i)
		{
			rotation_x -= 90f / frame;
			height -= 100f / frame;
			text.transform.rotation = Quaternion.Euler(rotation_x,0,0);
			text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x,height);
			yield return null;
		}
		text.gameObject.SetActive(false);
	}

	IEnumerator messageOut()
	{
		float rotation_x = -90;
		float height = 0;
		text.gameObject.SetActive(true);
		for(int i = 0;i < frame; ++i)
		{
			rotation_x += 90f / frame;
			height += 100f / frame;
			text.transform.rotation = Quaternion.Euler(rotation_x,0,0);
			text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x,height);
			yield return null;
		}
	}
}
