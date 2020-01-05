using UnityEngine;

public class Switch : MonoBehaviour
{

    public enum state
    {
        //	 一般、尚未完成、完成
        normal, notComplete, complete
    }
    public state _state = state.normal;
    private void Start()
    {
       
    }
}