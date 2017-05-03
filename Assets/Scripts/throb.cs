// found here lol http://answers.unity3d.com/questions/1074165/how-to-increase-and-decrease-object-scale-over-tim.html
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throb : MonoBehaviour {

	private float _currentScale = InitScale;
	private const float TargetScale = 3.9f;
	private const float InitScale = 3.0f;
	private const int FramesCount = 10;
	private const float AnimationTimeSeconds = 0.5f;
	private float _deltaTime = AnimationTimeSeconds/FramesCount;
	private float _dx = (TargetScale - InitScale)/FramesCount;
	private bool _upScale = true;
	private IEnumerator Breath()

	{
		while (true)
		{
			while (_upScale)
			{
				_currentScale += _dx;
				if (_currentScale > TargetScale)
				{
					_upScale = false;
					_currentScale = TargetScale;
				}
				transform.localScale = Vector3.one * _currentScale;
				yield return new WaitForSeconds(_deltaTime);
			}

			while (!_upScale)
			{
				_currentScale -= _dx;
				if (_currentScale < InitScale)
				{
					_upScale = true;
					_currentScale = InitScale;
				}
				transform.localScale = Vector3.one * _currentScale;
				yield return new WaitForSeconds(_deltaTime);
			}
		}
	}
	private void Start()
	{
		StartCoroutine(Breath());
	}
}
