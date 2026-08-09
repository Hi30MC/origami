using Quintessential;
namespace Origami;

public class Origami: QuintessentialMod {
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
        if (NeuvolicsLoaded) {
            ImportManager.ImportNeuvolics();
            QApi.AddPuzzlePermission(TranslationPermission, "Glyph of Transation", "Origami");
        }
        GlyphLUT.GenerateLUTs();
        Logger.Log(GlyphLUT.TranslationLUT);
    }
}
