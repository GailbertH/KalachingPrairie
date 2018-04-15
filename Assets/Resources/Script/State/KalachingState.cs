using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kalaching.Game
{
	public enum KalachingStates
	{
		LOADING = 0,
		INGAME = 1,
		EXIT = 2
	}

	public class KalachingState_Base<KalachingStates>
	{
		private KalachingStates state;
		private GameManager manager;

		public KalachingStates State { get { return state; } }
		public GameManager Manager { get { return manager; } }

		public KalachingState_Base(KalachingStates state, GameManager manager)
		{
			this.state = state;
			this.manager = manager;
		}

		public virtual bool AllowTransition (KalachingStates nextState)
		{
			return true;
		}

		public virtual void GoToNextState() {}
		public virtual void Start () {}
		public virtual void Update () {}
		public virtual void End () {}
		public virtual void Destroy () 
		{
			End ();
			manager = null;
		}
	}
}
