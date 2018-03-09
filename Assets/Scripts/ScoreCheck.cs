using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCheck : MonoBehaviour {

	public static Action OnBoardChange { get; private set; }

	[SerializeField]
	Circle[] circles;

	private void Start() {
		OnBoardChange = BoardChanged;
	}
																	  
	public void BoardChanged() {
		for(int i = 0; i <= 6; i += 3) {
			IconClass a = circles[0].GetIcon(i);
			IconClass b = circles[1].GetIcon(i);
			IconClass c = circles[2].GetIcon(i);

			if(IconAssetData.IconData.Set(a.Icon, b.Icon, c.Icon)) {
				print("set at" + i);
			}
		}
	}
}
