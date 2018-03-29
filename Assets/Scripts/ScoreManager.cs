using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static Action OnBoardChange { get; private set; }

    [SerializeField]
    private int setScoreValue = 10;

    [SerializeField]
	Circle[] circles;

    public static int Score { get; private set; }

	private void Start() {
		OnBoardChange = BoardChanged;
		Score = 0;
	}

	public void BoardChanged() {
		StartCoroutine(BoardChanged_Int());
	}

	public IEnumerator BoardChanged_Int() {
		for(int i = 0; i <= 6; i += 3) {
			IconClass a = circles[0].GetIcon(i);
			IconClass b = circles[1].GetIcon(i);
			IconClass c = circles[2].GetIcon(i);

			if(a.Active && b.Active && c.Active) {
				if(IconAssetData.IconData.Set(a.Icon, b.Icon, c.Icon)) {
					Score += setScoreValue;
					a.Active = b.Active = c.Active = false;

					bool aDone, bDone, cDone = false;

					a.Disintegrate(out aDone);
					b.Disintegrate(out bDone);
					c.Disintegrate(out cDone);

					yield return new WaitUntil(() => aDone && bDone && cDone);

					IconAssetData.Instance.RemoveIcon(a.Icon);
					IconAssetData.Instance.RemoveIcon(b.Icon);
					IconAssetData.Instance.RemoveIcon(c.Icon);

					a.Icon = IconAssetData.Instance.GetRandomIcon();
					b.Icon = IconAssetData.Instance.GetRandomIcon();
					c.Icon = IconAssetData.Instance.GetRandomIcon();
				}
			}
		}
	}
}
