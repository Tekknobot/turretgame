//InputManager.cs, place this on a single GameObject in the scene.
using UnityEngine;
 
public class InputManager : MonoBehaviour
{
    public delegate void KeyboardActionDash();
    public static event KeyboardActionDash Dash;
 
    private void Update()
    {
        if ( Input.anyKeyDown )
        {
            if ( Input.GetButtonDown("RightBumper" ) )
            {
                if ( Dash != null )
                {
                    Dash ( );
                    return;
                }
            }
        }
    }
}