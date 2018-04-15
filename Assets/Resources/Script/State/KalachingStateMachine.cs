using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kalaching.Game
{
	public class KalachingStateMachine 
	{
		public delegate void OnStateSwitch(KalachingStates nextState);
		public event OnStateSwitch OnStatePreSwitchEvent = null;

		private Dictionary<KalachingStates, KalachingState_Base<KalachingStates>> states = new Dictionary<KalachingStates, KalachingState_Base<KalachingStates>>();
		private KalachingState_Base<KalachingStates> currentState = null;
		private List<KalachingStates> prevGameState;

		public KalachingStateMachine (GameManager manager)
		{
			states = new Dictionary<KalachingStates, KalachingState_Base<KalachingStates>> ();

			Kalaching_Loading loading = new Kalaching_Loading (manager);
			Kalaching_InGame inGame = new Kalaching_InGame (manager);
			Kalaching_Exit exit = new Kalaching_Exit (manager);

			states.Add (loading.State, (KalachingState_Base<KalachingStates>)loading);
			states.Add (inGame.State, (KalachingState_Base<KalachingStates>)inGame);
			states.Add (exit.State, (KalachingState_Base<KalachingStates>)exit);

			currentState = loading;
			currentState.Start ();

			prevGameState = new List<KalachingStates> ();
			prevGameState.Add (currentState.State);
		}

		public void Update ()
		{
			if (currentState != null)
				currentState.Update ();				
		}

		public void Destroy ()
		{
			if (states != null)
			{
				foreach (KalachingStates key in states.Keys)
				{
					states [key].Destroy ();
				}
				states.Clear ();
				states = null;
			}
		}

		public KalachingState_Base<KalachingStates> GetCurrentState
		{
			get { return currentState; }
		}

		public string GetPreviousStateList ()
		{
			string prevStates = "PREVIOUS STATES: ";

			#if UNITY_EDITOR
			if(prevGameState != null)
			{
				for(int i = prevGameState.Count-1; i >= 0; i--)
				{
					prevStates += "\n-> " + prevGameState[i].ToString();
				}
			}
			#endif

			return prevStates;
		}


		public bool SwitchState (KalachingStates newState)
		{
			bool switchSuccess = false;
			if (states != null && states.ContainsKey (newState))
			{
				if (currentState == null)
				{
					currentState = states [newState];
					currentState.Start ();
					switchSuccess = true;
				}
				else if (currentState.AllowTransition (newState))
				{
					currentState.End ();
					currentState = states [newState];
					currentState.Start ();
					switchSuccess = true;
				}
				else
				{
					Debug.Log (string.Format ("{0} does not allow transition to {1}", currentState.State, newState));
				}
			}

			if (switchSuccess)
			{
				// Updating state history
				#if UNITY_EDITOR
				if(prevGameState != null)
				{
					prevGameState.Add(newState);
					if(prevGameState.Count > 20)
					{
						prevGameState.RemoveAt(0);
					}
				}
				#endif

				if (this.OnStatePreSwitchEvent != null)
				{
					this.OnStatePreSwitchEvent (newState);
				}
			}
			else
			{
				Debug.Log ("States dictionary not ready for switching to " + newState);
			}

			return switchSuccess;
		}
	}
}
