using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kalaching.Game
{
	public class Kalaching_InGame : KalachingState_Base<KalachingStates>
	{
		public Kalaching_InGame (GameManager manager) : base (KalachingStates.INGAME, manager)
		{
		}

		public override void GoToNextState()
		{
			Manager.StateMachine.SwitchState (KalachingStates.EXIT);
		}

		public override bool AllowTransition (KalachingStates nextState)
		{
			return (nextState == KalachingStates.EXIT);
		}
		public override void Start () {}
		public override void Update () {}
		public override void End () {}
	}
}