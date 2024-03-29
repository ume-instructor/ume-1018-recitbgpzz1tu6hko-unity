using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace UME
{
    [AddComponentMenu("UME/Triggers/PickupTrigger")]
    public class PickupTrigger : BaseTrigger {
	    
		private AudioSource audioSrc;
		private bool soundPlaying = false;
		private bool die = false;

		void FixedUpdate () {
			audioSrc = gameObject.GetComponent<AudioSource> ();
			if (audioSrc != null) {
				soundPlaying = audioSrc.isPlaying;
			}
			if (die == true && soundPlaying == false ) {
				Destroy (gameObject);
			} 
		}
		public override void Activate(Collider2D other)
		{
			if(GetComponent<SpriteRenderer>()!=null){
				GetComponent<SpriteRenderer>().enabled = false;
			}
			if(GetComponent<TrailRenderer>()!=null){
				GetComponent<TrailRenderer>().enabled = false;
			}
			if(GetComponent<Rigidbody2D>()!=null){
				GetComponent<Rigidbody2D>().Sleep();
			}
			foreach(Collider2D c in GetComponentsInParent<Collider2D> ()){
				c.enabled=false;
			}
			die = true;
		}

	}
}