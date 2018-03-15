using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static Action OnBoardChange { get; private set; }

	[SerializeField]
	Circle[] circles;

	public static int Score { get; private set; }

	private void Start() {
		OnBoardChange = BoardChanged;
		Score = 0;
	}
																	  
	public void BoardChanged() {
		for(int i = 0; i <= 6; i += 3) {
			IconClass a = circles[0].GetIcon(i);
			IconClass b = circles[1].GetIcon(i);
			IconClass c = circles[2].GetIcon(i);

			if(a.Active && b.Active && c.Active) {
				if(IconAssetData.IconData.Set(a.Icon, b.Icon, c.Icon)) {
					Score++;
					a.Active = b.Active = c.Active = false;
				}
			}
		}
	}
}
