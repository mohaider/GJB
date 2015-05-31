using UnityEngine;
using System.Collections;


namespace Assets.Scripts.GameLogic.Controls{
public interface IPausable  {

	void PauseSignal();
		bool IsPaused{ get; set; }
}
	}