﻿using RimWorld;
using UnityEngine;
using Verse;

namespace AnimalGenetics
{
    public class PawnColumnWorker_CapacityGene : PawnColumnWorker
    {
        static StatDef statDef = StatDefOf.CarryingCapacity;
        public override void DoCell(Rect rect, Pawn pawn, PawnTable table)
        {
            float gene = Genes.GetGene(pawn, statDef);
            GUI.color = Utilities.TextColor(gene);
            Text.Anchor = TextAnchor.MiddleCenter;
            Widgets.Label(rect, (gene * 100).ToString("F0") + "%");
            Text.Anchor = TextAnchor.UpperLeft;
            GUI.color = Color.white;
        }
        protected override GameFont DefaultHeaderFont
        {
            get
            {
                return GameFont.Tiny;
            }
        }

        public override int GetMinWidth(PawnTable table)
        {
            return 80;
        }

        public override int Compare(Pawn a, Pawn b)
        {
            return Genes.GetGene(a, statDef).CompareTo(Genes.GetGene(b, statDef));
        }
    }
}