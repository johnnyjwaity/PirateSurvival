﻿using UnityEngine;
using System;

public class ReSkinAnimation : MonoBehaviour {

	public string spriteSheetName;
    void Start()
    {
        spriteSheetName = PlayerPrefs.GetString("skin");
    }

    void LateUpdate () {
        
		var subSprites = Resources.LoadAll<Sprite>("Characters/" + spriteSheetName);

		foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
		{
			string spriteName = renderer.sprite.name;
			var newSprite = Array.Find(subSprites, item => item.name == spriteName);

			if (newSprite)
				renderer.sprite = newSprite;
		}
	}
}
