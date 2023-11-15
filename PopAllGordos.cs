using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace PopAllGordos
{
    internal class Entry : MelonMod
    {
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {

            if (sceneName == "zoneCore" || !sceneName.Contains("zone")) return;
            foreach (var gordo in Resources.FindObjectsOfTypeAll<GordoEat>())
            {
                if (gordo.isActiveAndEnabled && gordo.CanEat())
                {
                    try
                    {
                        gordo.ImmediateReachedTarget();
                    }
                    catch (System.Exception e)
                    {
                        LoggerInstance.Msg($"Failed to pop {gordo.name}: {e}");
                    }
                    
                }
            }
        }
    }
}
