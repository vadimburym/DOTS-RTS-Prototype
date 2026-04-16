//License
//- Repository: https://github.com/vadimburym/DOTS-Battle-Simulator-Prototype/tree/main/Assets/VadimBurym-DODBT
//- Copyright (c) 2026 vadimburym (Vadim Burym)
//- The repository root is licensed under a custom source-available license in LICENSE.md.
//- Assets/VadimBurym-DODBT is licensed separately under Assets/VadimBurym-DODBT/LICENSE.md.
//- Third-party assets and packages remain under their respective owners’ terms.

using System.Collections.Generic;

#if UNITY_EDITOR
namespace VadimBurym.DodBehaviourTree
{
    public interface IBtDebugState
    {
        NodeStatus[] DebugStatus { get; }
        List<string> DebugRunningLeafs { get; }
    }
}
#endif
