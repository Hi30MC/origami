using Quintessential;
using PartType = class_139;

namespace Origami;

public static class Glyphs {
    public static PartType Translation;
    public static readonly HexIndex TranslationInput = new (-1,0);
    public static readonly HexIndex TranslationNop = new (0,0);
    public static readonly HexIndex TranslationOutput = new (1,0);
    public static readonly class_256 TranslationBase = Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/Translation/base");

    public static void LoadParts() {
        Translation = Brimstone.API.CreateSimpleGlyph(
            ID: "Origami-Translation",
            name: "Glyph of Translation",
            description: "Translates between Neumetals and Orimetals",
            cost: 15,
            glow: "textures/select/Hi30MC/Origami/triline_glow",
            stroke: "textures/select/Hi30MC/Origami/triline_stroke",
            icon: "textures/select/Hi30MC/Origami/triline_glow",
            hoveredIcon: "textures/select/Hi30MC/Origami/triline_glow",
            usedHexes: new HexIndex [] {TranslationInput, TranslationNop, TranslationOutput},
            customPermission: Origami.TranslationPermission
        );
        QApi.AddPartTypeToPanel(Translation, false);
        QApi.AddPartType(Translation, static (part, pos, editor, renderer) => {
            PartSimState pss = editor.method_507().method_481(part);
            class_236 uco = editor.method_1989(part, pos);
            float time = editor.method_504();

            Vector2 pivot = new (123f, 48f);
            Vector2 offset = new (0f, -1f);

            renderer.method_523(TranslationBase, offset, pivot, 0);

            renderer.method_530(class_238.field_1989.field_90.field_255.field_293, TranslationInput, 0);

            int IrisFrame = 15;
            bool AfterIrisOpens = false;
            Molecule RisingAtom = null;
            Vector2 RisingOffset = uco.field_1984 + class_187.field_1742.method_492(TranslationOutput).Rotate(uco.field_1985);
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

            if (type == Translation) {
                if (first) {
                    HexIndex hole = (part.method_1184(TranslationInput));
                    HexIndex iris = (part.method_1184(TranslationOutput));
                    if (sim.FindAtom(iris).method_1085()) {
                        return
                    }
                    if (!sim.FindAtom(hole).method_99(out AtomReference subject) || subject.field_2281 || subject.field_2282) {
                        return
                    }
                } else {

                }
            }
        });
    }
}
