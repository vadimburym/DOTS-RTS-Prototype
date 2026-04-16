//License
//- Repository: https://github.com/vadimburym/DOTS-Battle-Simulator-Prototype/tree/main/Assets/VadimBurym-DODBT
//- Copyright (c) 2026 vadimburym (Vadim Burym)
//- The repository root is licensed under a custom source-available license in LICENSE.md.
//- Assets/VadimBurym-DODBT is licensed separately under Assets/VadimBurym-DODBT/LICENSE.md.
//- Third-party assets and packages remain under their respective owners’ terms.

using _Project._Code.Gameplay.CoreFeatures.AI._Root;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace VadimBurym.DodBehaviourTree.Generated
{
    public ref struct RunnerState_BtContext
    {
        public Entity Agent;
        [ReadOnly] public LeafData LeafData;
        public LeafStateElement LeafState;
        [ReadOnly] public BtContext Context;
        public Random Random;
        public int SortKey;
    }
}
