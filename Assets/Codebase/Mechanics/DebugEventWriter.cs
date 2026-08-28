using UnityEngine;

namespace Mechanics
{
    public class DebugEventWrtiter : MonoBehaviour
    {
        public void Write(string text){
            Debug.Log(text);
        }
    }
}