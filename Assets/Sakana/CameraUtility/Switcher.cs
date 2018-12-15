
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Switcher: MonoBehaviour
{
	[SerializeField] Transform[] _targetList;
	[SerializeField] float _interval = 5;
	public GameObject Player;
	
	IEnumerator Start () {
		var follower = Player.GetComponent<Follow>();
		follower.target = _targetList[0];
		yield return null;
		
		while (true)
		{
			foreach (var target in _targetList)
			{
				follower.target = target;
				yield return new WaitForSeconds(_interval);
			}
		}
	}
}
