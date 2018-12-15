using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MidiJack
{
	public class MidiManager : MonoBehaviour
	{
		private int _KnobNum = 8;//自分のmidiコンのノブの数
		public float[] knobValue;
		void Start()
		{
			knobValue = new float[_KnobNum];
		}

		void Update()
		{
			for (int i = 0; i < _KnobNum; i++)
			{
				knobValue[i] = MidiMaster.GetKnob(MidiChannel.Ch1, i);
			}
		}
	}
}
