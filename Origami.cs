using Quintessential;
namespace Origami;

public class Origami: QuintessentialMod {
    public const string CompositionPermission = "Origami:Composition";
    public const string AugmentationPermission = "Origami:Augmentation";
    public const string HighRegenerationPermission = "Origami:HighRegeneration";
    public const string LowRegenerationPermission = "Origami:LowRegeneration";
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
        QApi.AddPuzzlePermission(AugmentationPermission, "Glyph of Augmented Composition", "Origami");
        QApi.AddPuzzlePermission(HighRegenerationPermission, "Glyph of High Regeneration", "Origami");
        QApi.AddPuzzlePermission(LowRegenerationPermission, "Glyph of Low Regeneration", "Origami");

        if (NeuvolicsLoaded) {
            ImportManager.ImportNeuvolics();
            QApi.AddPuzzlePermission(TranslationPermission, "Glyph of Translation", "Origami");
        }

        GlyphLUT.GenerateLUTs();
        Logger.Log("Origami: Assets loaded :3c");
    }
}
