using Quintessential;
using PartType = class_139;
using System;

namespace Origami;

public static class Glyphs {
    public static PartType Composition;
    public static PartType Augmentation;
    public static PartType HighRegeneration;
    public static PartType LowRegeneration;
    public static PartType Translation;

    public static readonly HexIndex CompositionInputA = new(-1, 0);
    public static readonly HexIndex CompositionInputB = new(0, 0);
    public static readonly HexIndex CompositionOutput = new(0, 1);
    public static readonly class_256 CompositionBase = Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/composition_base");

    public static readonly HexIndex AugmentationInputA = new(-1, 0);
    public static readonly HexIndex AugmentationInputB = new(0, 0);
    public static readonly HexIndex AugmentationBowl = new(-1,2);
    public static readonly HexIndex AugmentationOutput = new(0,1);
    public static readonly class_256 AugmentationBase = Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/lowc_base");

    public static readonly HexIndex HighRegenerationBowlA = new (0, 0);
    public static readonly HexIndex HighRegenerationBowlB = new (-1, 2);
    public static readonly HexIndex HighRegenerationBowlC = new (-2, 2);
    public static readonly HexIndex HighRegenerationOutput = new (0, 1);
    public static readonly class_256 HighRegenerationBase = Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/highc_base");

    public static readonly HexIndex LowRegenerationBowlA = new (-1, 0);
    public static readonly HexIndex LowRegenerationBowlB = new (0, 1);
    public static readonly HexIndex LowRegenerationOutput = new (0, 0);
    public static readonly class_256 LowRegenerationBase = Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/low_regeneration_base");

    public static readonly HexIndex TranslationBowl = new (0,0);
    public static readonly class_256 TranslationBase = Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/single_base");

    public static void LoadParts() {
        Composition = Brimstone.API.CreateSimpleGlyph(
            ID: "Origami-Composition",
            name: "Glyph of Composition",
            description: "Composes two ordinals according to the Cayley table of A4",
            cost: 15,
            glow: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/bent_glow"),
            stroke: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/bent_stroke"),
            icon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/composition_icon"),
            hoveredIcon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/composition_icon"),
            usedHexes: new HexIndex[] { CompositionInputA, CompositionInputB, CompositionOutput },
            customPermission: Origami.CompositionPermission
        );
        Augmentation = Brimstone.API.CreateSimpleGlyph(
            ID: "Origami-Augmentation",
            name: "Glyph of Augmented Composition",
            description: "Composes two ordinals according to the Cayley table of A4, augmented by the atom in the bowl. This performs C(a,C(b,c)) where C is the Cayley table. If the bowl is empty, the glyph defaults to Rei.",
            cost: 20,
            glow: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/lowc_glow"),
            stroke: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/lowc_stroke"),
            icon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/augmentation_icon"),
            hoveredIcon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/augmentation_icon"),
            usedHexes: new HexIndex[] { AugmentationBowl, AugmentationInputA, AugmentationInputB, AugmentationOutput },
            customPermission: Origami.AugmentationPermission
        );
        HighRegeneration = Brimstone.API.CreateSimpleGlyph(
            ID: "Origami-High-Regeneration",
            name: "Glyph of High Regeneration",
            description: "Completes the group of four dual-cycle ordinals: Rei, Chronos, Homonculum, and Tao. Place three on the bowl and the last of the four is retrieved from the Aether.",
            cost: 20,
            glow: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/highc_glow"),
            stroke: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/highc_stroke"),
            icon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/high_regeneration_icon"),
            hoveredIcon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/high_regeneration_icon"),
            usedHexes: new HexIndex[] { HighRegenerationBowlA, HighRegenerationBowlB, HighRegenerationBowlC, HighRegenerationOutput },
            customPermission: Origami.HighRegenerationPermission
        );
        LowRegeneration = Brimstone.API.CreateSimpleGlyph(
            ID: "Origami-Low-Regeneration",
            name: "Glyph of Low Regeneration",
            description: "Completes the four groups of three-cycle ordinals. Place two on the bowl and the last of the triple is retrieved from the Aether.",
            cost: 15,
            glow: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/bent_glow"),
            stroke: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/bent_stroke"),
            icon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/low_regeneration_icon"),
            hoveredIcon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/low_regeneration_icon"),
            usedHexes: new HexIndex[] { LowRegenerationBowlA, LowRegenerationBowlB, LowRegenerationOutput },
            customPermission: Origami.LowRegenerationPermission
        );
        Translation = Brimstone.API.CreateSimpleGlyph(
            ID: "Origami-Translation",
            name: "Glyph of Translation",
            description: "Translates between neuvolics and ordinals",
            cost: 10,
            glow: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/single_glow"),
            stroke: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/single_stroke"),
            icon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/translation_icon"),
            hoveredIcon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/translation_icon"),
            usedHexes: new HexIndex[] {TranslationBowl},
            customPermission: Origami.TranslationPermission
        );

        HighRegeneration.field_1552 = true; // only one!
        LowRegeneration.field_1552 = true; // only one!

        QApi.AddPartTypeToPanel(Composition, false);
        QApi.AddPartTypeToPanel(Augmentation, false);
        QApi.AddPartTypeToPanel(HighRegeneration, false);
        QApi.AddPartTypeToPanel(LowRegeneration, false);
        QApi.AddPartTypeToPanel(Translation, false);

        QApi.AddPartType(Composition, static (part, pos, editor, renderer) => {
            PartSimState pss = editor.method_507().method_481(part);
            class_236 uco = editor.method_1989(part, pos);
            float time = editor.method_504();

            Vector2 centre = CompositionBase.method_691();
            renderer.method_523(CompositionBase, new Vector2(-1, -1), centre, 0f);

            renderer.method_530(class_238.field_1989.field_90.field_255.field_293, CompositionInputA, 0);
            renderer.method_530(class_238.field_1989.field_90.field_255.field_293, CompositionInputB, 0);

            int IrisFrame = 15;
            bool AfterIrisOpens = false;
            Molecule RisingAtom = null;
            Vector2 RisingOffset = uco.field_1984 + class_187.field_1742.method_492(CompositionOutput).Rotated(uco.field_1985);
            renderer.method_528(class_238.field_1989.field_90.field_228.field_272, CompositionOutput, Vector2.Zero);

            if (pss.field_2743) {
                IrisFrame = class_162.method_404((int) (class_162.method_411(1f, -1f, time) * 16f), 0, 15);
                AfterIrisOpens = time > 0.5f;
                RisingAtom = Molecule.method_1121(pss.field_2744[0]);
                if (!AfterIrisOpens) {
                    Editor.method_925(RisingAtom, RisingOffset, new HexIndex (0, 0), 0f, 1f, time, 1f, false, null);
                }
            }

            renderer.method_529(class_238.field_1989.field_90.field_246[IrisFrame], CompositionOutput, Vector2.Zero);
            renderer.method_528(class_238.field_1989.field_90.field_228.field_271, CompositionOutput, Vector2.Zero);

            if (pss.field_2743 && AfterIrisOpens) {
                Editor.method_925(RisingAtom, RisingOffset, new HexIndex (0, 0), 0f, 1f, time, 1f, false, null);
            }
        });

        QApi.AddPartType(Augmentation, static (part, pos, editor, renderer) => {
            PartSimState pss = editor.method_507().method_481(part);
            class_236 uco = editor.method_1989(part, pos);
            float time = editor.method_504();

            Vector2 centre = AugmentationBase.method_691();
            renderer.method_523(AugmentationBase, new Vector2(-1, -1), centre, 0f);

            renderer.method_530(class_238.field_1989.field_90.field_255.field_293, AugmentationInputA, 0);
            renderer.method_530(class_238.field_1989.field_90.field_255.field_293, AugmentationInputB, 0);

            renderer.method_528(class_238.field_1989.field_90.field_170, AugmentationBowl, Vector2.Zero);

            int IrisFrame = 15;
            bool AfterIrisOpens = false;
            Molecule RisingAtom = null;
            Vector2 RisingOffset = uco.field_1984 + class_187.field_1742.method_492(AugmentationOutput).Rotated(uco.field_1985);
            renderer.method_528(class_238.field_1989.field_90.field_228.field_272, AugmentationOutput, Vector2.Zero);

            if (pss.field_2743) {
                IrisFrame = class_162.method_404((int) (class_162.method_411(1f, -1f, time) * 16f), 0, 15);
                AfterIrisOpens = time > 0.5f;
                RisingAtom = Molecule.method_1121(pss.field_2744[0]);
                if (!AfterIrisOpens) {
                    Editor.method_925(RisingAtom, RisingOffset, new HexIndex (0, 0), 0f, 1f, time, 1f, false, null);
                }
            }

            renderer.method_529(class_238.field_1989.field_90.field_246[IrisFrame], AugmentationOutput, Vector2.Zero);
            renderer.method_528(class_238.field_1989.field_90.field_228.field_271, AugmentationOutput, Vector2.Zero);

            if (pss.field_2743 && AfterIrisOpens) {
                Editor.method_925(RisingAtom, RisingOffset, new HexIndex (0, 0), 0f, 1f, time, 1f, false, null);
            }
        });

        QApi.AddPartType(HighRegeneration, static (part, pos, editor, renderer) => {
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

            if (pss.field_2743) {
                IrisFrame = class_162.method_404((int) (class_162.method_411(1f, -1f, time) * 16f), 0, 15);
                AfterIrisOpens = time > 0.5f;
                RisingAtom = Molecule.method_1121(pss.field_2744[0]);
                if (!AfterIrisOpens) {
                    Editor.method_925(RisingAtom, RisingOffset, new HexIndex (0, 0), 0f, 1f, time, 1f, false, null);
                }
            }

            renderer.method_529(class_238.field_1989.field_90.field_246[IrisFrame], HighRegenerationOutput, Vector2.Zero);
            renderer.method_528(class_238.field_1989.field_90.field_228.field_271, HighRegenerationOutput, Vector2.Zero);

            if (pss.field_2743 && AfterIrisOpens) {
                Editor.method_925(RisingAtom, RisingOffset, new HexIndex (0, 0), 0f, 1f, time, 1f, false, null);
            }
        });

        QApi.AddPartType(LowRegeneration, static (part, pos, editor, renderer) => {
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

            if (pss.field_2743) {
                IrisFrame = class_162.method_404((int) (class_162.method_411(1f, -1f, time) * 16f), 0, 15);
                AfterIrisOpens = time > 0.5f;
                RisingAtom = Molecule.method_1121(pss.field_2744[0]);
                if (!AfterIrisOpens) {
                    Editor.method_925(RisingAtom, RisingOffset, new HexIndex (0, 0), 0f, 1f, time, 1f, false, null);
                }
            }

            renderer.method_529(class_238.field_1989.field_90.field_246[IrisFrame], LowRegenerationOutput, Vector2.Zero);
            renderer.method_528(class_238.field_1989.field_90.field_228.field_271, LowRegenerationOutput, Vector2.Zero);

            if (pss.field_2743 && AfterIrisOpens) {
                Editor.method_925(RisingAtom, RisingOffset, new HexIndex (0, 0), 0f, 1f, time, 1f, false, null);
            }
        });

        QApi.AddPartType(Translation, static (part, pos, editor, renderer) => {
            PartSimState pss = editor.method_507().method_481(part);
            class_236 uco = editor.method_1989(part, pos);
            float time = editor.method_504();

            Vector2 centre = TranslationBase.method_691();
            renderer.method_523(TranslationBase, new Vector2(-1, -1), centre, 0f);

            renderer.method_528(class_238.field_1989.field_90.field_170, TranslationBowl, Vector2.Zero);
        });

        QApi.RunDuringCycle(static (sim, part, pss, first) => {
            SolutionEditorBase seb = sim.field_3818;
            PartType type = part.method_1159();

            if (type == Composition) {
                if (first) {
                    HexIndex holeA = (part.method_1184(CompositionInputA));
                    HexIndex holeB = (part.method_1184(CompositionInputB));
                    HexIndex iris = (part.method_1184(CompositionOutput));
                    if (sim.FindAtom(iris).method_1085()) { //iris full
                        return;
                    }
                    if (!sim.FindAtom(holeA).method_99(out AtomReference inputAtomA) || inputAtomA.field_2281 || inputAtomA.field_2282) { //invalid hole A
                        return;
                    }

                    if (!sim.FindAtom(holeB).method_99(out AtomReference inputAtomB) || inputAtomB. field_2281 || inputAtomB.field_2282) { //invalid hole B
                        return;
                    }

                    if (!GlyphLUT.CompositionLUT.TryGetValue(new Tuple<AtomType, AtomType>(inputAtomA.field_2280, inputAtomB.field_2280), out AtomType output)) {
                        return;
                    }

                    Brimstone.API.RemoveAtom(inputAtomA);
                    Brimstone.API.DrawFallingAtom(seb, inputAtomA);
                    Brimstone.API.RemoveAtom(inputAtomB);
                    Brimstone.API.DrawFallingAtom(seb, inputAtomB);

                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[] { output };
                }
                else if (pss.field_2743) {
                    Brimstone.API.AddAtom(sim, part, CompositionOutput, pss.field_2744[0]);
                }
            }

            if (type == Augmentation) {
                if (first) {
                    HexIndex holeA = (part.method_1184(AugmentationInputA));
                    HexIndex holeB = (part.method_1184(AugmentationInputB));
                    HexIndex bowl = (part.method_1184(AugmentationBowl));
                    HexIndex iris = (part.method_1184(AugmentationOutput));
                    AtomType bowlAtomType;

                    if (sim.FindAtom(iris).method_1085()) { //iris full
                        return;
                    }

                    if (!sim.FindAtom(holeA).method_99(out AtomReference inputAtomA) || inputAtomA.field_2281 || inputAtomA.field_2282) {  //invalid holeA
                        return;
                    }

                    if (!sim.FindAtom(holeB).method_99(out AtomReference inputAtomB) || inputAtomB. field_2281 || inputAtomB.field_2282) { //invalid holeB
                        return;
                    }

                    bowlAtomType = sim.FindAtom(bowl).method_99(out AtomReference temp) ? temp.field_2280 : Atoms.id; // get bowl atom type, if any.

                    if (!GlyphLUT.CompositionLUT.TryGetValue(new Tuple<AtomType, AtomType>(inputAtomB.field_2280, bowlAtomType), out AtomType temp2)) {
                        return;
                    }

                    if (!GlyphLUT.CompositionLUT.TryGetValue(new Tuple<AtomType, AtomType>(inputAtomA.field_2280, temp2), out AtomType output)) {
                        return;
                    }

                    Brimstone.API.RemoveAtom(inputAtomA);
                    Brimstone.API.DrawFallingAtom(seb, inputAtomA);
                    Brimstone.API.RemoveAtom(inputAtomB);
                    Brimstone.API.DrawFallingAtom(seb, inputAtomB);

                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[] { output };
                }
                else if (pss.field_2743) {
                    Brimstone.API.AddAtom(sim, part, AugmentationOutput, pss.field_2744[0]);
                }
            }

            if (type == HighRegeneration) {
                if (first) {
                    HexIndex bowlA = (part.method_1184(HighRegenerationBowlA));
                    HexIndex bowlB = (part.method_1184(HighRegenerationBowlB));
                    HexIndex bowlC = (part.method_1184(HighRegenerationBowlC));
                    HexIndex iris = (part.method_1184(HighRegenerationOutput));

                    if (sim.FindAtom(iris).method_1085()) { //iris full
                        return;
                    }
                    if (!sim.FindAtom(bowlA).method_99(out AtomReference bowlAtomA)) { // bowl A empty
                        return;
                    }
                    if (!sim.FindAtom(bowlB).method_99(out AtomReference bowlAtomB)) { // bowl B empty
                        return;
                    }
                    if (!sim.FindAtom(bowlC).method_99(out AtomReference bowlAtomC)) { // bowl C empty
                        return;
                    }

                    if (!GlyphLUT.HighRegenerationLUT.TryGetValue(new Tuple<AtomType, AtomType, AtomType>(bowlAtomA.field_2280, bowlAtomB.field_2280, bowlAtomC.field_2280), out AtomType output)) {
                        return;
                    }

                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[] { output };
                } else if (pss.field_2743) {
                    Brimstone.API.AddAtom(sim, part, HighRegenerationOutput, pss.field_2744[0]);
                }
            }

            if (type == LowRegeneration) {
                if (first) {
                    HexIndex bowlA = (part.method_1184(LowRegenerationBowlA));
                    HexIndex bowlB = (part.method_1184(LowRegenerationBowlB));
                    HexIndex iris = (part.method_1184(LowRegenerationOutput));

                    if (sim.FindAtom(iris).method_1085()) { //iris full
                        return;
                    }
                    if (!sim.FindAtom(bowlA).method_99(out AtomReference bowlAtomA)) { // bowl A empty
                        return;
                    }
                    if (!sim.FindAtom(bowlB).method_99(out AtomReference bowlAtomB)) { // bowl B empty
                        return;
                    }

                    if (!GlyphLUT.LowRegenerationLUT.TryGetValue(new Tuple<AtomType, AtomType>(bowlAtomA.field_2280, bowlAtomB.field_2280), out AtomType output)) {
                        return;
                    }

                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[] { output };
                } else if (pss.field_2743) {
                    Brimstone.API.AddAtom(sim, part, LowRegenerationOutput, pss.field_2744[0]);
                }
            }

            if (type == Translation) {
                if (first) {
                    HexIndex bowl = (part.method_1184(TranslationBowl));
                    if (!sim.FindAtom(bowl).method_99(out AtomReference bowlAtom)) { //empty bowl
                        return;
                    }
                    if (!GlyphLUT.TranslationLUT.TryGetValue(bowlAtom.field_2280, out AtomType output)) {
                        return;
                    }

                    Brimstone.API.ChangeAtom(bowlAtom, output);
                    bowlAtom.field_2279.field_2276 = new class_168(seb, 0, (enum_132) 1, bowlAtom.field_2280, class_238.field_1989.field_81.field_614, 30f);
                }
            }
        });
    }
}
