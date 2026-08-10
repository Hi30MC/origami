using Quintessential;
namespace Origami;

public class Origami: QuintessentialMod {
    public const string CompositionPermission = "Origami:Composition";
    public const string TranslationPermission = "Origami:Translation";
    public static bool NeuvolicsLoaded = Brimstone.API.IsModLoaded("Neuvolics");

    public override void Load () {
        Logger.Log("Origami: Paper ready to fold!");
    }

    public override void PostLoad() {}
    public override void Unload() {}

    public override void LoadPuzzleContent() {
        Atoms.LoadAtoms();
        Glyphs.LoadParts();
        QApi.AddPuzzlePermission(CompositionPermission, "Glyph of Composition", "Origami");
        if (NeuvolicsLoaded) {
            ImportManager.ImportNeuvolics();
            QApi.AddPuzzlePermission(TranslationPermission, "Glyph of Translation", "Origami");
        }
        GlyphLUT.GenerateLUTs();
        Logger.Log("Origami: Assets loaded :3c");
    }
}
