using System;
using UnityEngine;
using UnityEngine.UI;

public class IconClass : MonoBehaviour {
	
	[SerializeField, HideInInspector]
	private IconAssetData.IconData icon;

	[SerializeField]
	private int amount;

	[SerializeField]
	private Image edgeMask, inner, visibleEdge;

	private bool active = true;

	public bool Active {
		get {
			return active;
		}

		set {
			active = value;
			visibleEdge.color = inner.color = active ? icon.Color : IconAssetData.Instance.InActiveColor;
		}
	}

	public IconAssetData.IconData Icon {
		get {
			return icon;
		}

		set {
			icon = value;
			UpdateValues();
		}
	}

	private void Start() {
		UpdateValues();
	}

	public void UpdateValues() {
		Sprite newSprite = icon.Sprite;

		edgeMask.sprite = visibleEdge.sprite = newSprite;
		newSprite = null;

		switch(icon._Shading) {
			case IconAssetData.IconData.Shading.Open:
				newSprite = IconAssetData.Instance.OpenShadingSprite;
				break;
			case IconAssetData.IconData.Shading.Solid:
				newSprite = IconAssetData.Instance.SolidShadingSprite;
				break;
			case IconAssetData.IconData.Shading.Striped:
				newSprite = IconAssetData.Instance.StripedShadingSprite;
				break;
		}

		inner.sprite = newSprite;

		Color newColor = icon.Color;

		visibleEdge.color = inner.color = newColor;

		switch(amount) {
			case 1:

				break;
			case 2:

				break;
			case 3:

				break;
		}
	}
}
