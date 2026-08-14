using Mono.Cecil.Cil;
using MonoMod.Cil;
using Quintessential;
using PartType = class_139;
using System;
using System.Linq;
using Origami.Util;
using MonoMod.Utils;

namespace Origami;

public static class Glyphs
{
    #region GlyphMeta
    public static PartType Composition;
    public static PartType AugmentedComp;
    public static PartType HighRegeneration;
    public static PartType LowRegeneration;
    public static PartType Translation;
    public static PartType Sacrifice;

    public static readonly HexIndex CompositionInputA = new(-1, 0);
    public static readonly HexIndex CompositionInputB = new(0, 0);
    public static readonly HexIndex CompositionOutput = new(0, 1);
    public static readonly class_256 CompositionBase = Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/bent_base");

    public static readonly HexIndex AugmentedCompInputA = new(-1, 0);
    public static readonly HexIndex AugmentedCompInputB = new(0, 0);
    public static readonly HexIndex AugmentedCompBowl = new(-1, 2);
    public static readonly HexIndex AugmentedCompOutput = new(0, 1);
    public static readonly class_256 AugmentedCompBase = Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/lowc_base");

    public static readonly HexIndex HighRegenerationBowlA = new(0, 0);
    public static readonly HexIndex HighRegenerationBowlB = new(-1, 2);
    public static readonly HexIndex HighRegenerationBowlC = new(-2, 2);
    public static readonly HexIndex HighRegenerationOutput = new(0, 1);
    public static readonly class_256 HighRegenerationBase = Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/highc_base");

    public static readonly HexIndex LowRegenerationBowlA = new(-1, 0);
    public static readonly HexIndex LowRegenerationBowlB = new(0, 0);
    public static readonly HexIndex LowRegenerationOutput = new(-1, 1);
    public static readonly class_256 LowRegenerationBase = Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/triple_base");

    public static readonly HexIndex TranslationBowl = new(0, 0);
    public static readonly class_256 TranslationBase = Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/single_base");

    public static readonly HexIndex SacrificeArm = new(0, 0);
    public static readonly HexIndex SacrificeIO = new(1, 0);
    public static readonly class_256 SacrificeBase = Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/double_base");
    public static readonly string SacrificeStateField = "origami_sacrifice_state";
    public static readonly string SacrificeStateCycle = "origami_sacrifice_cycle";
    #endregion

    #region Hooks
    public static void AddHooks()
    {
        Logger.Log("Origami: Hanging 1000 cranes");
        IL.SolutionEditorBase.method_1984 += InjectDrawFlemmingAtom;
    }

    public static void RemoveHooks()
    {
        Logger.Log("Origami: Letting the cranes fall...");
        IL.SolutionEditorBase.method_1984 -= InjectDrawFlemmingAtom;
    }

    internal static void InjectDrawFlemmingAtom(ILContext context)
    {
        ILCursor cursor = new(context);
        if (!cursor.TryGotoNext(MoveType.After,
            instr => instr.MatchCallvirt("SolutionEditorBase", "method_2015")))
        {
            Logger.Log("Origami: Failed to inject draw call (no method_2015 call)");
            return;
        }

        if (!cursor.TryGotoNext(MoveType.After,
            instr => instr.MatchEndfinally()))
        {
            Logger.Log("Origami: Fail to inject draw call (no loop end)");
            return;
        }

        cursor.Index++;
        cursor.Emit(OpCodes.Ldarg_0);
        cursor.Emit(OpCodes.Ldloc_0);
        cursor.EmitDelegate<Action<SolutionEditorBase, SolutionEditorBase.class_423>>((self, uco) =>
        {
            if (self.method_503() != enum_128.Stopped)
            {
                var partList = self.method_502().field_3919;
                foreach (var Flemming in partList.Where(x => x.method_1159() == Wheel.Flemming))
                {
                    Wheel.DrawFlemmingAtoms(self, Flemming, uco.field_3959, true);
                }
            }
        });
    }

    #endregion

    #region GlyphInit
    public static void LoadParts()
    {
        Composition = Brimstone.API.CreateSimpleGlyph(
            ID: "origami_composition",
            name: "Glyph of Composition",
            description: "Composes two orimetals according to the Cayley table of A4",
            cost: 15,
            glow: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/bent_glow"),
            stroke: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/bent_stroke"),
            icon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/composition_icon"),
            hoveredIcon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/composition_icon"),
            usedHexes: new HexIndex[] { CompositionInputA, CompositionInputB, CompositionOutput },
            customPermission: Origami.CompositionPermission
        );
        AugmentedComp = Brimstone.API.CreateSimpleGlyph(
            ID: "origami_AugmentedComp",
            name: "Glyph of Augmented Composition",
            description: "Composes two orimetals according to the Cayley table of A4, augmented by the atom in the bowl. This performs C(a,C(b,c)) where C is the Cayley table. If the bowl is empty, the glyph defaults to Rei.",
            cost: 20,
            glow: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/lowc_glow"),
            stroke: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/lowc_stroke"),
            icon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/AugmentedComp_icon"),
            hoveredIcon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/AugmentedComp_icon"),
            usedHexes: new HexIndex[] { AugmentedCompBowl, AugmentedCompInputA, AugmentedCompInputB, AugmentedCompOutput },
            customPermission: Origami.AugmentedCompPermission
        );
        HighRegeneration = Brimstone.API.CreateSimpleGlyph(
            ID: "origami_high_regeneration",
            name: "Glyph of High Regeneration",
            description: "Completes the group of four dual-cycle orimetals: Rei, Chronos, Homonculum, and Tao. Place three on the bowl and the last of the four is retrieved from storage vials.",
            cost: 20,
            glow: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/highc_glow"),
            stroke: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/highc_stroke"),
            icon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/high_regeneration_icon"),
            hoveredIcon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/high_regeneration_icon"),
            usedHexes: new HexIndex[] { HighRegenerationBowlA, HighRegenerationBowlB, HighRegenerationBowlC, HighRegenerationOutput },
            customPermission: Origami.HighRegenerationPermission
        );
        LowRegeneration = Brimstone.API.CreateSimpleGlyph(
            ID: "origami_low_regeneration",
            name: "Glyph of Low Regeneration",
            description: "Completes the four groups of three-cycle orimetals. Place two on the bowl and the last of the triple is retrieved from storage vials.",
            cost: 15,
            glow: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/triple_glow"),
            stroke: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/triple_stroke"),
            icon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/low_regeneration_icon"),
            hoveredIcon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/low_regeneration_icon"),
            usedHexes: new HexIndex[] { LowRegenerationBowlA, LowRegenerationBowlB, LowRegenerationOutput },
            customPermission: Origami.LowRegenerationPermission
        );
        Translation = Brimstone.API.CreateSimpleGlyph(
            ID: "origami_translation",
            name: "Glyph of Translation",
            description: "If you're seeing this, dm me at hi30 on discord, because something is wrong!",
            cost: 10,
            glow: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/single_glow"),
            stroke: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/single_stroke"),
            icon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/translation_icon"),
            hoveredIcon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/translation_icon"),
            usedHexes: new HexIndex[] { TranslationBowl },
            customPermission: Origami.TranslationPermission
        );
        Sacrifice = Brimstone.API.CreateSimpleGlyph(
            ID: "origami_sacrifice",
            name: "Glyph of Sacrifice",
            description: "One can obtain immortality, but it must come at a cost. Minimum requirement: 666 lives (6 mors).",
            cost: 50,
            glow: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/double_glow"),
            stroke: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/double_stroke"),
            icon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/sacrifice_icon"),
            hoveredIcon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/sacrifice_icon"),
            usedHexes: new HexIndex[] { SacrificeArm, SacrificeIO },
            customPermission: Origami.SacrificePermission
        );

        // update Translation flavortext depending on what mod(s) are loaded
        if (Origami.NeuvolicsLoaded)
        {
            Translation.field_1530 = class_134.method_253("Translates between orineuvolic pairs", string.Empty);
        }
        else if (Origami.SennmetalsLoaded)
        {
            Translation.field_1530 = class_134.method_253("Translates between orisennmetallic pairs", string.Empty);
        }
        if (Origami.NeuvolicsLoaded && Origami.SennmetalsLoaded)
        {
            Translation.field_1530 = class_134.method_253("Translates between orisenneuvolic pairs", string.Empty);
        }

        HighRegeneration.field_1552 = true; // only one!
        LowRegeneration.field_1552 = true; // only one!
        Sacrifice.field_1533 = true; // programmable
        // not sure if I want one or many...
        // Sacrifice.field_1552 = true; //only one!

        QApi.AddPartTypeToPanel(Composition, false);
        QApi.AddPartTypeToPanel(AugmentedComp, false);
        QApi.AddPartTypeToPanel(HighRegeneration, false);
        QApi.AddPartTypeToPanel(LowRegeneration, false);
        if (Origami.NeuvolicsLoaded || Origami.SennmetalsLoaded) QApi.AddPartTypeToPanel(Translation, false);
        QApi.AddPartTypeToPanel(Sacrifice, false);

        QApi.AddPartType(Composition, static (part, pos, editor, renderer) =>
        {
            PartSimState pss = editor.method_507().method_481(part);
            class_236 uco = editor.method_1989(part, pos);
            float time = editor.method_504();

            // draw base
            Vector2 centre = CompositionBase.method_691();
            renderer.method_523(CompositionBase, new Vector2(-1, -1), centre, 0f);
            // draw inputs
            renderer.method_530(class_238.field_1989.field_90.field_255.field_293, CompositionInputA, 0);
            renderer.method_530(class_238.field_1989.field_90.field_255.field_293, CompositionInputB, 0);

            // standard iris code
            int IrisFrame = 15;
            bool AfterIrisOpens = false;
            Molecule RisingAtom = null;
            Vector2 RisingOffset = uco.field_1984 + class_187.field_1742.method_492(CompositionOutput).Rotated(uco.field_1985);

            //output under iris
            renderer.method_528(class_238.field_1989.field_90.field_228.field_272, CompositionOutput, Vector2.Zero);

            // if ejecting, animate iris
            if (pss.field_2743)
            {
                // LERP at double speed (from 1 to 0 is closed to open, but double the range for double speed).
                IrisFrame = class_162.method_404((int)(class_162.method_411(1f, -1f, time) * 16f), 0, 15);
                AfterIrisOpens = time > 0.5f;
                RisingAtom = Molecule.method_1121(pss.field_2744[0]);
                if (!AfterIrisOpens)
                {
                    // if before iris opened halfway, draw rising atom under
                    Editor.method_925(RisingAtom, RisingOffset, new HexIndex(0, 0), 0f, 1f, time, 1f, false, null);
                }
            }

            //iris, then lip above
            renderer.method_529(class_238.field_1989.field_90.field_246[IrisFrame], CompositionOutput, Vector2.Zero);
            renderer.method_528(class_238.field_1989.field_90.field_228.field_271, CompositionOutput, Vector2.Zero);

            // if iris half open, draw rising atom on top
            if (pss.field_2743 && AfterIrisOpens)
            {
                Editor.method_925(RisingAtom, RisingOffset, new HexIndex(0, 0), 0f, 1f, time, 1f, false, null);
            }
        });

        // omit comments that are the same bits of code, use Composition for reference
        QApi.AddPartType(AugmentedComp, static (part, pos, editor, renderer) =>
        {
            PartSimState pss = editor.method_507().method_481(part);
            class_236 uco = editor.method_1989(part, pos);
            float time = editor.method_504();

            Vector2 centre = AugmentedCompBase.method_691();
            renderer.method_523(AugmentedCompBase, new Vector2(-1, -1), centre, 0f);

            renderer.method_530(class_238.field_1989.field_90.field_255.field_293, AugmentedCompInputA, 0);
            renderer.method_530(class_238.field_1989.field_90.field_255.field_293, AugmentedCompInputB, 0);

            renderer.method_528(class_238.field_1989.field_90.field_170, AugmentedCompBowl, Vector2.Zero);

            int IrisFrame = 15;
            bool AfterIrisOpens = false;
            Molecule RisingAtom = null;
            Vector2 RisingOffset = uco.field_1984 + class_187.field_1742.method_492(AugmentedCompOutput).Rotated(uco.field_1985);
            renderer.method_528(class_238.field_1989.field_90.field_228.field_272, AugmentedCompOutput, Vector2.Zero);

            if (pss.field_2743)
            {
                IrisFrame = class_162.method_404((int)(class_162.method_411(1f, -1f, time) * 16f), 0, 15);
                AfterIrisOpens = time > 0.5f;
                RisingAtom = Molecule.method_1121(pss.field_2744[0]);
                if (!AfterIrisOpens)
                {
                    Editor.method_925(RisingAtom, RisingOffset, new HexIndex(0, 0), 0f, 1f, time, 1f, false, null);
                }
            }

            renderer.method_529(class_238.field_1989.field_90.field_246[IrisFrame], AugmentedCompOutput, Vector2.Zero);
            renderer.method_528(class_238.field_1989.field_90.field_228.field_271, AugmentedCompOutput, Vector2.Zero);

            if (pss.field_2743 && AfterIrisOpens)
            {
                Editor.method_925(RisingAtom, RisingOffset, new HexIndex(0, 0), 0f, 1f, time, 1f, false, null);
            }
        });

        QApi.AddPartType(HighRegeneration, static (part, pos, editor, renderer) =>
        {
            PartSimState pss = editor.method_507().method_481(part);
            class_236 uco = editor.method_1989(part, pos);
            float time = editor.method_504();

            Vector2 centre = HighRegenerationBase.method_691();
            renderer.method_523(HighRegenerationBase, new Vector2(-1, -1), centre, 0f);

            renderer.method_528(class_238.field_1989.field_90.field_170, HighRegenerationBowlA, Vector2.Zero);
            renderer.method_528(class_238.field_1989.field_90.field_170, HighRegenerationBowlB, Vector2.Zero);
            renderer.method_528(class_238.field_1989.field_90.field_170, HighRegenerationBowlC, Vector2.Zero);

            int IrisFrame = 15;
            bool AfterIrisOpens = false;
            Molecule RisingAtom = null;
            Vector2 RisingOffset = uco.field_1984 + class_187.field_1742.method_492(HighRegenerationOutput).Rotated(uco.field_1985);
            renderer.method_528(class_238.field_1989.field_90.field_228.field_272, HighRegenerationOutput, Vector2.Zero);

            if (pss.field_2743)
            {
                IrisFrame = class_162.method_404((int)(class_162.method_411(1f, -1f, time) * 16f), 0, 15);
                AfterIrisOpens = time > 0.5f;
                RisingAtom = Molecule.method_1121(pss.field_2744[0]);
                if (!AfterIrisOpens)
                {
                    Editor.method_925(RisingAtom, RisingOffset, new HexIndex(0, 0), 0f, 1f, time, 1f, false, null);
                }
            }

            renderer.method_529(class_238.field_1989.field_90.field_246[IrisFrame], HighRegenerationOutput, Vector2.Zero);
            renderer.method_528(class_238.field_1989.field_90.field_228.field_271, HighRegenerationOutput, Vector2.Zero);

            if (pss.field_2743 && AfterIrisOpens)
            {
                Editor.method_925(RisingAtom, RisingOffset, new HexIndex(0, 0), 0f, 1f, time, 1f, false, null);
            }
        });

        QApi.AddPartType(LowRegeneration, static (part, pos, editor, renderer) =>
        {
            PartSimState pss = editor.method_507().method_481(part);
            class_236 uco = editor.method_1989(part, pos);
            float time = editor.method_504();

            Vector2 centre = LowRegenerationBase.method_691();
            renderer.method_523(LowRegenerationBase, new Vector2(-1, -1), centre, 0f);

            renderer.method_528(class_238.field_1989.field_90.field_170, LowRegenerationBowlA, Vector2.Zero);
            renderer.method_528(class_238.field_1989.field_90.field_170, LowRegenerationBowlB, Vector2.Zero);

            int IrisFrame = 15;
            bool AfterIrisOpens = false;
            Molecule RisingAtom = null;
            Vector2 RisingOffset = uco.field_1984 + class_187.field_1742.method_492(LowRegenerationOutput).Rotated(uco.field_1985);
            renderer.method_528(class_238.field_1989.field_90.field_228.field_272, LowRegenerationOutput, Vector2.Zero);

            if (pss.field_2743)
            {
                IrisFrame = class_162.method_404((int)(class_162.method_411(1f, -1f, time) * 16f), 0, 15);
                AfterIrisOpens = time > 0.5f;
                RisingAtom = Molecule.method_1121(pss.field_2744[0]);
                if (!AfterIrisOpens)
                {
                    Editor.method_925(RisingAtom, RisingOffset, new HexIndex(0, 0), 0f, 1f, time, 1f, false, null);
                }
            }

            renderer.method_529(class_238.field_1989.field_90.field_246[IrisFrame], LowRegenerationOutput, Vector2.Zero);
            renderer.method_528(class_238.field_1989.field_90.field_228.field_271, LowRegenerationOutput, Vector2.Zero);

            if (pss.field_2743 && AfterIrisOpens)
            {
                Editor.method_925(RisingAtom, RisingOffset, new HexIndex(0, 0), 0f, 1f, time, 1f, false, null);
            }
        });

        QApi.AddPartType(Translation, static (part, pos, editor, renderer) =>
        {
            PartSimState pss = editor.method_507().method_481(part);
            class_236 uco = editor.method_1989(part, pos);
            float time = editor.method_504();

            Vector2 centre = TranslationBase.method_691();
            renderer.method_523(TranslationBase, new Vector2(-1, -1), centre, 0f);

            renderer.method_528(class_238.field_1989.field_90.field_170, TranslationBowl, Vector2.Zero);
        });

        // one of the worst reverse-engineerings that I have done (in terms of difficulty). please use this code for your sump-type things...
        QApi.AddPartType(Sacrifice, static (part, pos, editor, renderer) =>
        {
            PartSimState pss = editor.method_507().method_481(part);
            class_236 uco = editor.method_1989(part, pos);
            float time = editor.method_504();

            // get current cycle
            var currentCycle = 0;
            if (editor.method_503() != enum_128.Stopped && editor.GetType() == typeof(SolutionEditorScreen))
            {
                var maybeSim = new DynamicData(editor).Get<Maybe<Sim>>("field_4022");
                if (maybeSim.method_1085())
                {
                    currentCycle = maybeSim.method_1087().method_1818();
                }
            }

            // init dyn
            var pss_dyn = new DynamicData(pss);
            var stateOb = pss_dyn.Get(SacrificeStateField);
            var prevCycleOb = pss_dyn.Get(SacrificeStateCycle);

            SacrificeState state = new(0b11000000);
            int prevCycle = 0;
            if (stateOb != null)
            {
                state = (SacrificeState)stateOb;
            }
            if (prevCycleOb != null)
            {
                prevCycle = (int)prevCycleOb;
            }

            // update state and dyn
            if (currentCycle > prevCycle || time > 0.5)
            {
                state.Update();
                pss_dyn.Set(SacrificeStateCycle, currentCycle);
            }

            // currState: has an atom over top of it (or is about to have one above) -> false (open)
            HexIndex key = part.method_1184(SacrificeIO);
            state.CurrState = !pss.field_2743; // if we are about to spit a Hom., default is false (open), else true (closed)

            // forces false if any one-atom molecules are over the IO
            state.CurrState &= !editor.method_507().method_483() // set.GetMolecules()
                               .Any(x => x.method_1100().Count == 1 // one-atom molecule
                                      && x.method_1100().ContainsKey(key)); // atom at IO
            pss_dyn.Set(SacrificeStateField, state); // update dyn with new currState

            bool animate = state.PrevState != state.CurrState; // animate iris if the state has changed; else draw static iris

            // get iris frames
            int irisFrame = 15; // 15 is closed, 00 is open
            if (animate)
            { // transition from closed to open
                // state.CurrState true: go from 0 to 2 (end closed)
                // state.CurrState false: go from 1 to -1 (end open)
                // normally would go from 0 -> 1 and 1 -> 0 but need double speed in standard sim speed, so we extend our LERP to cover double length in the same time.
                irisFrame = class_162.method_404((int)(class_162.method_411(state.CurrState ? 0f : 1f, state.CurrState ? 2f : -1f, time) * 16f), 0, 15);
            }
            else
            {
                irisFrame = state.CurrState ? 15 : 0; // if true, closed (15), if false open (0)
            }

            //draw everything!!
            Molecule RisingHomonculum = Molecule.method_1121(Atoms.sixteen);
            Molecule RisingMors = Molecule.method_1121(Brimstone.API.VanillaAtoms.mors);
            Vector2 RisingOffset = uco.field_1984 + class_187.field_1742.method_492(SacrificeIO).Rotated(uco.field_1985);

            // draw base
            Vector2 centre = SacrificeBase.method_691();
            renderer.method_523(SacrificeBase, new Vector2(-1, -1), centre, 0f);

            // draw arm, todo: change to indicator
            renderer.method_528(class_238.field_1989.field_90.field_253.field_279, SacrificeArm, Vector2.Zero);
            // byte MorsCount = state.MorsCount;

            // underiris
            renderer.method_528(class_238.field_1989.field_90.field_228.field_272, SacrificeIO, Vector2.Zero); //draw output under iris

            bool AfterIrisOpens = false;
            if (pss.field_2743)
            {
                AfterIrisOpens = time >= 0.5f;
            }

            // for times before iris is half open, draw rising atom before iris
            if (!AfterIrisOpens)
            { // iris not yet open. For the case of both drawing simultaenously, draw mors on top of hom. for first half...
                if (pss.field_2743) Editor.method_925(RisingHomonculum, RisingOffset, new HexIndex(0, 0), 0f, 1f, time, 1f, false, null); // drawRisingAtom below iris if needed
                if (state.ConsumingMors) Editor.method_925(RisingMors, RisingOffset, new HexIndex(0, 0), 0f, 1f, 1f - time, 1f, false, null); // drawRisingAtom in reverse after iris
            }

            renderer.method_529(class_238.field_1989.field_90.field_246[irisFrame], SacrificeIO, Vector2.Zero); //draw iris with correct frame
            renderer.method_528(class_238.field_1989.field_90.field_228.field_271, SacrificeIO, Vector2.Zero); //draw output ring above iris

            // for times before iris is half open, draw rising atom before iris
            if (AfterIrisOpens)
            { // ...and draw hom. on top of mors for the second half.
                if (state.ConsumingMors) Editor.method_925(RisingMors, RisingOffset, new HexIndex(0, 0), 0f, 1f, 1f - time, 1f, false, null); //drawRisingAtom in reverse after iris
                if (pss.field_2743) Editor.method_925(RisingHomonculum, RisingOffset, new HexIndex(0, 0), 0f, 1f, time, 1f, false, null); // drawRisingAtom after iris if needed
            }
        });
        #endregion

        #region GlyphActivate
        QApi.RunDuringCycle(static (sim, part, pss, first) =>
        {
            SolutionEditorBase seb = sim.field_3818;
            PartType type = part.method_1159();

            var test = seb.method_502().method_1934().field_2770[0];

            if (type == Composition)
            {
                if (first) //first half-cycle
                {
                    HexIndex holeA = part.method_1184(CompositionInputA);
                    HexIndex holeB = part.method_1184(CompositionInputB);
                    HexIndex iris = part.method_1184(CompositionOutput);
                    if (sim.FindAtom(iris).method_1085())
                    { //iris full
                        return;
                    }
                    if (!sim.FindAtom(holeA).method_99(out AtomReference inputAtomA) || inputAtomA.field_2281 || inputAtomA.field_2282)
                    { // no atom over hole, atom over hole is part of molecule (is bonded), or atom is held
                        return;
                    }

                    if (!sim.FindAtom(holeB).method_99(out AtomReference inputAtomB) || inputAtomB.field_2281 || inputAtomB.field_2282)
                    { // no atom over hole, atom over hole is part of molecule (is bonded), or atom is held
                        return;
                    }

                    if (!GlyphLUT.CompositionLUT.TryGetValue(new Tuple<AtomType, AtomType>(inputAtomA.field_2280, inputAtomB.field_2280), out AtomType output))
                    {  // no matching (key, value) pair in the look-up table (LUT)
                        return;
                    }

                    // if all checks pass, remove input atoms
                    Brimstone.API.RemoveAtom(inputAtomA);
                    Brimstone.API.DrawFallingAtom(seb, inputAtomA);
                    Brimstone.API.RemoveAtom(inputAtomB);
                    Brimstone.API.DrawFallingAtom(seb, inputAtomB);

                    Brimstone.API.AddSmallCollider(sim, part, iris);

                    // mark glyph to render and what to output
                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[] { output };
                }
                else if (pss.field_2743)
                {   // add atom to sim on the second half-cycle
                    Brimstone.API.AddAtom(sim, part, CompositionOutput, pss.field_2744[0]);
                }
            }

            // comments are disregarded unless non-duplicate from Composition
            if (type == AugmentedComp)
            {
                if (first)
                {
                    HexIndex holeA = part.method_1184(AugmentedCompInputA);
                    HexIndex holeB = part.method_1184(AugmentedCompInputB);
                    HexIndex bowl = part.method_1184(AugmentedCompBowl);
                    HexIndex iris = part.method_1184(AugmentedCompOutput);
                    AtomType bowlAtomType;

                    if (sim.FindAtom(iris).method_1085())
                    { //iris full
                        return;
                    }

                    if (!sim.FindAtom(holeA).method_99(out AtomReference inputAtomA) || inputAtomA.field_2281 || inputAtomA.field_2282)
                    {  //invalid holeA
                        return;
                    }

                    if (!sim.FindAtom(holeB).method_99(out AtomReference inputAtomB) || inputAtomB.field_2281 || inputAtomB.field_2282)
                    { //invalid holeB
                        return;
                    }

                    bowlAtomType = sim.FindAtom(bowl).method_99(out AtomReference temp) || Wheel.MaybeFindFlemmingWheelAtom(sim, bowl).method_99(out temp) ? temp.field_2280 : Atoms.id; // get bowl atom type, if any.

                    if (!GlyphLUT.CompositionLUT.TryGetValue(new Tuple<AtomType, AtomType>(inputAtomB.field_2280, bowlAtomType), out AtomType temp2))
                    {
                        return;
                    }

                    if (!GlyphLUT.CompositionLUT.TryGetValue(new Tuple<AtomType, AtomType>(inputAtomA.field_2280, temp2), out AtomType output))
                    {
                        return;
                    }

                    Brimstone.API.RemoveAtom(inputAtomA);
                    Brimstone.API.DrawFallingAtom(seb, inputAtomA);
                    Brimstone.API.RemoveAtom(inputAtomB);
                    Brimstone.API.DrawFallingAtom(seb, inputAtomB);

                    Brimstone.API.AddSmallCollider(sim, part, iris);

                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[] { output };
                }
                else if (pss.field_2743)
                {
                    Brimstone.API.AddAtom(sim, part, AugmentedCompOutput, pss.field_2744[0]);
                }
            }

            if (type == HighRegeneration)
            {
                if (first)
                {
                    HexIndex bowlA = part.method_1184(HighRegenerationBowlA);
                    HexIndex bowlB = part.method_1184(HighRegenerationBowlB);
                    HexIndex bowlC = part.method_1184(HighRegenerationBowlC);
                    HexIndex iris = part.method_1184(HighRegenerationOutput);

                    if (sim.FindAtom(iris).method_1085())
                    { //iris full
                        return;
                    }
                    if (!sim.FindAtom(bowlA).method_99(out AtomReference bowlAtomA) && !Wheel.MaybeFindFlemmingWheelAtom(sim, bowlA).method_99(out bowlAtomA))
                    { // bowl A empty
                        return;
                    }
                    if (!sim.FindAtom(bowlB).method_99(out AtomReference bowlAtomB) && !Wheel.MaybeFindFlemmingWheelAtom(sim, bowlB).method_99(out bowlAtomB))
                    { // bowl B empty
                        return;
                    }
                    if (!sim.FindAtom(bowlC).method_99(out AtomReference bowlAtomC) && !Wheel.MaybeFindFlemmingWheelAtom(sim, bowlC).method_99(out bowlAtomC))
                    { // bowl C empty
                        return;
                    }

                    if (!GlyphLUT.HighRegenerationLUT.TryGetValue(new Tuple<AtomType, AtomType, AtomType>(bowlAtomA.field_2280, bowlAtomB.field_2280, bowlAtomC.field_2280), out AtomType output))
                    {
                        return;
                    }

                    Brimstone.API.AddSmallCollider(sim, part, iris);

                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[] { output };
                }
                else if (pss.field_2743)
                {
                    Brimstone.API.AddAtom(sim, part, HighRegenerationOutput, pss.field_2744[0]);
                }
            }

            if (type == LowRegeneration)
            {
                if (first)
                {
                    HexIndex bowlA = part.method_1184(LowRegenerationBowlA);
                    HexIndex bowlB = part.method_1184(LowRegenerationBowlB);
                    HexIndex iris = part.method_1184(LowRegenerationOutput);

                    if (sim.FindAtom(iris).method_1085())
                    { //iris full
                        return;
                    }
                    if (!sim.FindAtom(bowlA).method_99(out AtomReference bowlAtomA) && !Wheel.MaybeFindFlemmingWheelAtom(sim, bowlA).method_99(out bowlAtomA))
                    { // bowl A empty
                        return;
                    }
                    if (!sim.FindAtom(bowlB).method_99(out AtomReference bowlAtomB) && !Wheel.MaybeFindFlemmingWheelAtom(sim, bowlB).method_99(out bowlAtomB))
                    { // bowl B empty
                        return;
                    }

                    if (!GlyphLUT.LowRegenerationLUT.TryGetValue(new Tuple<AtomType, AtomType>(bowlAtomA.field_2280, bowlAtomB.field_2280), out AtomType output))
                    {
                        return;
                    }

                    Brimstone.API.AddSmallCollider(sim, part, iris);

                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[] { output };
                }
                else if (pss.field_2743)
                {
                    Brimstone.API.AddAtom(sim, part, LowRegenerationOutput, pss.field_2744[0]);
                }
            }

            if (type == Translation)
            {
                if (!first)
                {
                    HexIndex bowl = part.method_1184(TranslationBowl);
                    if (!sim.FindAtom(bowl).method_99(out AtomReference bowlAtom))
                    { //empty bowl
                        return;
                    }
                    if (!GlyphLUT.TranslationLUT.TryGetValue(bowlAtom.field_2280, out AtomType output))
                    {
                        return;
                    }

                    Brimstone.API.ChangeAtom(bowlAtom, output);
                    bowlAtom.field_2279.field_2276 = new class_168(seb, 0, (enum_132)1, bowlAtom.field_2280, class_238.field_1989.field_81.field_614, 30f);
                }
            }

            if (type == Sacrifice)
            {
                HexIndex io = part.method_1184(SacrificeIO);

                // init dyn
                var pss_dyn = new DynamicData(pss);
                var stateOb = pss_dyn.Get(SacrificeStateField);
                SacrificeState state = new(0b11000000);
                if (stateOb != null)
                {
                    state = (SacrificeState)stateOb;
                }

                int MorsCount = state.MorsCount;
                state.ConsumingMors = false;
                if (first)
                {
                    // check mors consume
                    if (sim.FindAtom(io).method_99(out AtomReference ioAtom)) // if atom above...
                    {
                        if (ioAtom.field_2280 == Brimstone.API.VanillaAtoms.mors // ...is mors...
                            && !ioAtom.field_2281 // ...and not bonded...
                            && !ioAtom.field_2282) // ...and not held
                        {
                            if (MorsCount < 6) MorsCount++;
                            Brimstone.API.RemoveAtom(ioAtom);
                            state.ConsumingMors = true; // mark renderer to render mors consumption
                        }
                    }
                    // check sacrifice
                    if (!sim.FindAtom(io).method_1085() // if no atom above...
                        && MorsCount == 6 // ... and sufficient souls ...
                        && sim.method_1820().method_852(sim.method_1818(), part, out Maybe<int> _).field_2548 == (enum_144)5) // ... and curr instr is grab or drop...
                    {
                        // Logger.Log("sacrifice your loved ones");
                        MorsCount = 0;
                        pss.field_2743 = true;
                        Brimstone.API.AddSmallCollider(sim, part, io);
                    }

                    // update state
                    state.MorsCount = (byte)MorsCount;
                    pss_dyn.Set(SacrificeStateField, state);
                }
                else if (pss.field_2743)
                {
                    Brimstone.API.AddAtom(sim, part, SacrificeIO, Atoms.sixteen);
                }
            }
        });
        #endregion
    }
}
