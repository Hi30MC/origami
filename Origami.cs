using Quintessential;
namespace Origami;

public class Origami: QuintessentialMod {
    public override void Load () {
        Logger.Log("your mother");
    }

    public override void PostLoad() {}
    public override void Unload() {}

    public override void LoadPuzzleContent() {
        Atoms.LoadAtoms();
    }
}
