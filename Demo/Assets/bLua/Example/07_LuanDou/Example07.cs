using UnityEngine;

namespace bLua
{
    public class Example07 : LuaBehaviour
    {
        private void Awake()
        {
            var state = LuaClient.State;
            LoadModule(state);

            if (onAwake != null)
                onAwake.Call();
        }

    }
}


