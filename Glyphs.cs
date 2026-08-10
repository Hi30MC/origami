using Quintessential;
using PartType = class_139;
using System;

namespace Origami;

public static class Glyphs {
    public static PartType Composition;
    public static PartType Translation;

    public static readonly HexIndex CompositionInputA = new(-1, 0);
    public static readonly HexIndex CompositionInputB = new(0, 0);
    public static readonly HexIndex CompositionOutput = new(-1, 1);
    public static readonly class_256 CompositionBase = Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/Composition/base");

    public static readonly HexIndex TranslationInput = new (-1,0);
    public static readonly HexIndex TranslationNop = new (0,0);
    public static readonly HexIndex TranslationOutput = new (1,0);
    public static readonly class_256 TranslationBase = Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/Translation/base");

    public static void LoadParts() {
        Composition = Brimstone.API.CreateSimpleGlyph(
            ID: "Origami-Composition",
            name: "Glyph of Composition",
            description: "Composes two ordinals according to the Cayley graph of A4",
            cost: 10,
            glow: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/triple_glow"),
            stroke: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/triple_stroke"),
            icon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/Composition/icon"),
            hoveredIcon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/Composition/icon"),
            usedHexes: new HexIndex[] { CompositionInputA, CompositionInputB, CompositionOutput },
            customPermission: Origami.CompositionPermission
        );
        Translation = Brimstone.API.CreateSimpleGlyph(
            ID: "Origami-Translation",
            name: "Glyph of Translation",
            description: "Translates between neuvolics and ordinals",
            cost: 15,
            glow: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/triline_glow"),
            stroke: Brimstone.API.GetTexture("textures/select/Hi30MC/Origami/triline_stroke"),
            icon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/Translation/icon"),
            hoveredIcon: Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/Translation/icon"),
            usedHexes: new HexIndex[] { TranslationInput, TranslationNop, TranslationOutput },
            customPermission: Origami.TranslationPermission
        );

        QApi.AddPartTypeToPanel(Composition, false);
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
        QApi.AddPartType(Translation, static (part, pos, editor, renderer) => {
            PartSimState pss = editor.method_507().method_481(part);
            class_236 uco = editor.method_1989(part, pos);
            float time = editor.method_504();

            Vector2 centre = TranslationBase.method_691();
            renderer.method_523(TranslationBase, new Vector2(-1, -1), centre, 0f);

            renderer.method_530(class_238.field_1989.field_90.field_255.field_293, TranslationInput, 0);

            int IrisFrame = 15;
            bool AfterIrisOpens = false;
            Molecule RisingAtom = null;
            Vector2 RisingOffset = uco.field_1984 + class_187.field_1742.method_492(TranslationOutput).Rotated(uco.field_1985);
            renderer.method_528(class_238.field_1989.field_90.field_228.field_272, TranslationOutput, Vector2.Zero);

            if (pss.field_2743) {
                IrisFrame = class_162.method_404((int) (class_162.method_411(1f, -1f, time) * 16f), 0, 15);
                AfterIrisOpens = time > 0.5f;
                RisingAtom = Molecule.method_1121(pss.field_2744[0]);
                if (!AfterIrisOpens) {
                    Editor.method_925(RisingAtom, RisingOffset, new HexIndex (0, 0), 0f, 1f, time, 1f, false, null);
                }
            }

            renderer.method_529(class_238.field_1989.field_90.field_246[IrisFrame], TranslationOutput, Vector2.Zero);
            renderer.method_528(class_238.field_1989.field_90.field_228.field_271, TranslationOutput, Vector2.Zero);

            if (pss.field_2743 && AfterIrisOpens) {
                Editor.method_925(RisingAtom, RisingOffset, new HexIndex (0, 0), 0f, 1f, time, 1f, false, null);
            }
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
                    if (!sim.FindAtom(holeA).method_99(out AtomReference subjectA) || subjectA.field_2281 || subjectA.field_2282)
                    {
                        return;
                    }

                    if (!sim.FindAtom(holeB).method_99(out AtomReference subjectB) || subjectB. field_2281 || subjectB.field_2282)
                    {
                        return;
                    }

                    if (!GlyphLUT.CompositionLUT.TryGetValue(new Tuple<AtomType, AtomType>(subjectA.field_2280, subjectB.field_2280), out AtomType output))
                    {
                        return;
                    }

                    Brimstone.API.RemoveAtom(subjectA);
                    Brimstone.API.DrawFallingAtom(seb, subjectA);
                    Brimstone.API.RemoveAtom(subjectB);
                    Brimstone.API.DrawFallingAtom(seb, subjectB);

                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[] { output };
                }
                else if (pss.field_2743)
                {
                    Brimstone.API.AddAtom(sim, part, CompositionOutput, pss.field_2744[0]);
                }
            }

            if (type == Translation)
            {
                if (first)
                {
                    HexIndex hole = (part.method_1184(TranslationInput));
                    HexIndex iris = (part.method_1184(TranslationOutput));
                    if (sim.FindAtom(iris).method_1085())
                    {
                        return;
                    }
                    if (!sim.FindAtom(hole).method_99(out AtomReference subject) || subject.field_2281 || subject.field_2282)
                    {
                        return;
                    }
                    if (!GlyphLUT.TranslationLUT.TryGetValue(subject.field_2280, out AtomType output))
                    {
                        return;
                    }

                    Brimstone.API.RemoveAtom(subject);
                    Brimstone.API.DrawFallingAtom(seb, subject);

                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[] { output };
                }
                else if (pss.field_2743)
                {
                    Brimstone.API.AddAtom(sim, part, TranslationOutput, pss.field_2744[0]);
                }
            }
        });
    }
}
