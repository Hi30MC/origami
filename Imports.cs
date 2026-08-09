using MonoMod.ModInterop;

namespace Origami;

class ImportManager {
    public static void ImportNeuvolics() {
        typeof (NeuvolicAtoms).ModInterop();
    }

    [ModImportName ("Neuvolics.Atoms")]
    public static class NeuvolicsAtoms {
        public static Func <AtomType> GetAzulum;
        public static Func <AtomType> GetTaceum;
        public static Func <AtomType> GetIridium;
        public static Func <AtomType> GetMitrum;
        public static Func <AtomType> GetZephiron;
    }
}
