//License
//- Repository: https://github.com/vadimburym/DOTS-Battle-Simulator-Prototype/tree/main/Assets/VadimBurym-DODBT
//- Copyright (c) 2026 vadimburym (Vadim Burym)
//- The repository root is licensed under a custom source-available license in LICENSE.md.
//- Assets/VadimBurym-DODBT is licensed separately under Assets/VadimBurym-DODBT/LICENSE.md.
//- Third-party assets and packages remain under their respective owners’ terms.

using System.Collections.Generic;
using UnityEngine;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace VadimBurym.DodBehaviourTree
{
#if ODIN_INSPECTOR
    [HideMonoScript]
#endif
    public sealed class BtMonoDebug : MonoBehaviour
    {
#if ODIN_INSPECTOR
        [ShowInInspector, ReadOnly]
#endif
        internal BehaviourTreeAsset BehaviourTreeAsset;
#if UNITY_EDITOR
#if ODIN_INSPECTOR
        [ShowInInspector, ReadOnly]
#endif
        public IReadOnlyList<string> RunningLeafs { get; private set; }
        internal NodeStatus[] DebugStatus;

        public void Construct(
            BehaviourTreeAsset behaviourTreeAsset,
            IBtDebugState targetState)
        {
            BehaviourTreeAsset = behaviourTreeAsset;
            DebugStatus = targetState.DebugStatus;
            RunningLeafs = targetState.DebugRunningLeafs;
        }
#endif
    }
}
