using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Kalaching.Game
{
	public class Kalaching_Exit : KalachingState_Base<KalachingStates>
	{
		public Kalaching_Exit (GameManager manager) : base (KalachingStates.EXIT, manager)
		{
		}

		public override void Start ()
		{ 
			//START UNLOADING 
		}
		public override void End () 
		{ 
			//END EVERYTHING
		}
	}
}
