using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kalaching.Game
{
	public class Kalaching_Loading : KalachingState_Base<KalachingStates>
	{
		private Coroutine cdNextState;

		public Kalaching_Loading (GameManager manager) : base (KalachingStates.LOADING, manager)
		{
		}

		public override void GoToNextState()
		{
			Manager.StateMachine.SwitchState (KalachingStates.INGAME);
		}

		public override bool AllowTransition (KalachingStates nextState)
		{
			return (nextState == KalachingStates.INGAME);
		}

		public override void Start ()
		{
			this.ShowUI ();
		}

		private void ShowUI()
		{
			GameManager.Instance.GameControls.ShowGameControls ();
			cdNextState = Manager.StartCoroutine (DelayedStateSwitch (2f));
		}

		public override void End () 
		{
			if (cdNextState != null && Manager != null)
				Manager.StopCoroutine (cdNextState);

			cdNextState = null;
		}

		public override void Destroy ()
		{
			End ();
			base.Destroy ();
		}


		private IEnumerator DelayedStateSwitch (float delay)
		{
			yield return new WaitForSeconds(delay);
			GoToNextState ();
		}
	}
}