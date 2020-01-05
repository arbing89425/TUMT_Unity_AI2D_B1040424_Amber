using UnityEngine;
using UnityEngine.SceneManagement;


namespace Bing
{
	public class GM : MonoBehaviour
	{
		public void Replay()
		{
			SceneManager.LoadScene("final");
		}
		public void Quit()
		{
			Application.Quit();
		}
	}
}