using Quintessential;
using PartType = class_139;
using System;

namespace Origami;

public static class Glyphs {
    public static PartType Composition;
    public static PartType Augmentation;
    public static PartType HighRetrieval;
    public static PartType LowRetrieval;
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

    public static readonly HexIndex HighRetrievalBowlA = new (0, 0);
    public static readonly HexIndex HighRetrievalBowlB = new (-1, 2);
    public static readonly HexIndex HighRetrievalBowlC = new (-2, 2);
    public static readonly HexIndex HighRetrievalOutput = new (0, 1);
    public static readonly class_256 HighRetrievalBase = Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/highc_base");

    public static readonly HexIndex LowRetrievalBowlA = new (-1, 0);
    public static readonly HexIndex LowRetrievalBowlB = new (0, 1);
    public static readonly HexIndex LowRetrievalOutput = new (0, 0);
    public static readonly class_256 LowRetrievalBase = Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/low-order_retrieval_base");

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
            icon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/composition_icon"),
            hoveredIcon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/composition_icon"),
            usedHexes: new HexIndex[] { AugmentationBowl, AugmentationInputA, AugmentationInputB, AugmentationOutput },
            customPermission: Origami.AugmentationPermission
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

        QApi.AddPartTypeToPanel(Composition, false);
        QApi.AddPartTypeToPanel(Augmentation, false);
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
            if (type == Composition)
            {
                if (first)
                {
                    HexIndex holeA = (part.method_1184(CompositionInputA));
                    HexIndex holeB = (part.method_1184(CompositionInputB));
                    HexIndex iris = (part.method_1184(CompositionOutput));
                    if (sim.FindAtom(iris).method_1085())
                    {
                        return;
                    }
                    if (!sim.FindAtom(holeA).method_99(out AtomReference inputAAtom) || inputAAtom.field_2281 || inputAAtom.field_2282)
                    {
                        return;
                    }

                    if (!sim.FindAtom(holeB).method_99(out AtomReference inputBAtom) || inputBAtom. field_2281 || inputBAtom.field_2282)
                    {
                        return;
                    }

                    if (!GlyphLUT.CompositionLUT.TryGetValue(new Tuple<AtomType, AtomType>(inputAAtom.field_2280, inputBAtom.field_2280), out AtomType output))
                    {
                        return;
                    }

                    Brimstone.API.RemoveAtom(inputAAtom);
                    Brimstone.API.DrawFallingAtom(seb, inputAAtom);
                    Brimstone.API.RemoveAtom(inputBAtom);
                    Brimstone.API.DrawFallingAtom(seb, inputBAtom);

                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[] { output };
                }
                else if (pss.field_2743)
                {
                    Brimstone.API.AddAtom(sim, part, CompositionOutput, pss.field_2744[0]);
                }
            }

            if (type == Augmentation)
            {
                if (first)
                {
                    HexIndex holeA = (part.method_1184(AugmentationInputA));
                    HexIndex holeB = (part.method_1184(AugmentationInputB));
                    HexIndex bowl = (part.method_1184(AugmentationBowl));
                    HexIndex iris = (part.method_1184(AugmentationOutput));
                    AtomType bowlAtomType;

                    if (sim.FindAtom(iris).method_1085()) //iris full
                    {
                        return;
                    }

                    if (!sim.FindAtom(holeA).method_99(out AtomReference inputAAtom) || inputAAtom.field_2281 || inputAAtom.field_2282) //invalid holeA
                    {
                        return;
                    }

                    if (!sim.FindAtom(holeB).method_99(out AtomReference inputBAtom) || inputBAtom. field_2281 || inputBAtom.field_2282) //invalid holeB
                    {
                        return;
                    }

                    bowlAtomType = sim.FindAtom(bowl).method_99(out AtomReference temp) ? temp.field_2280 : Atoms.id; // get bowl atom type, if any.

                    if (!GlyphLUT.CompositionLUT.TryGetValue(new Tuple<AtomType, AtomType>(inputBAtom.field_2280, bowlAtomType), out AtomType temp2))
                    {
                        return;
                    }

                    if (!GlyphLUT.CompositionLUT.TryGetValue(new Tuple<AtomType, AtomType>(inputAAtom.field_2280, temp2), out AtomType output))
                    {
                        return;
                    }

                    Brimstone.API.RemoveAtom(inputAAtom);
                    Brimstone.API.DrawFallingAtom(seb, inputAAtom);
                    Brimstone.API.RemoveAtom(inputBAtom);
                    Brimstone.API.DrawFallingAtom(seb, inputBAtom);

                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[] { output };
                }
                else if (pss.field_2743)
                {
                    Brimstone.API.AddAtom(sim, part, AugmentationOutput, pss.field_2744[0]);
                }
            }

            if (type == Translation)
            {
                if (first)
                {
                    HexIndex bowl = (part.method_1184(TranslationBowl));
                    if (!sim.FindAtom(bowl).method_99(out AtomReference bowlAtom))
                    {
                        return;
                    }
                    if (!GlyphLUT.TranslationLUT.TryGetValue(bowlAtom.field_2280, out AtomType output))
                    {
                        return;
                    }

                    Brimstone.API.ChangeAtom(bowlAtom, output);
                    bowlAtom.field_2279.field_2276 = new class_168(seb, 0, (enum_132) 1, bowlAtom.field_2280, class_238.field_1989.field_81.field_614, 30f);
                }
            }
        });
    }
}
