using Quintessential;
using Brimstone;
namespace Origami;

public static class Atoms {
    public static AtomType id, three, four, seven, eight, eleven, twelve, fifteen, sixteen, nineteen, twenty, twentythree;

    public static void LoadAtoms() {
        id = Brimstone.API.CreateNormalAtom(
            ID: 201,
            modName: "Origami",
            name: "Identity",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/salt_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        three = Brimstone.API.CreateNormalAtom(
            ID: 203,
            modName: "Origami",
            name: "Three",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/salt_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        four = Brimstone.API.CreateNormalAtom(
            ID: 204,
            modName: "Origami",
            name: "Four",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/salt_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        seven = Brimstone.API.CreateNormalAtom(
            ID: 207,
            modName: "Origami",
            name: "Seven",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/salt_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        eight = Brimstone.API.CreateNormalAtom(
            ID: 208,
            modName: "Origami",
            name: "Eight",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/salt_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        eleven = Brimstone.API.CreateNormalAtom(
            ID: 211,
            modName: "Origami",
            name: "Eleven",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/salt_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        twelve = Brimstone.API.CreateNormalAtom(
            ID: 212,
            modName: "Origami",
            name: "Twelve",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/salt_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        fifteen = Brimstone.API.CreateNormalAtom(
            ID: 215,
            modName: "Origami",
            name: "Fifteen",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/salt_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        sixteen = Brimstone.API.CreateNormalAtom(
            ID: 216,
            modName: "Origami",
            name: "Sixteen",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/salt_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        nineteen = Brimstone.API.CreateNormalAtom(
            ID: 219,
            modName: "Origami",
            name: "Ninteen",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/salt_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        twenty = Brimstone.API.CreateNormalAtom(
            ID: 220,
            modName: "Origami",
            name: "Twenty",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/salt_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        twentythree = Brimstone.API.CreateNormalAtom(
            ID: 223,
            modName: "Origami",
            name: "Twenty Three",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/salt_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );

        QApi.AddAtomType(id);
        QApi.AddAtomType(three);
        QApi.AddAtomType(four);
        QApi.AddAtomType(seven);
        QApi.AddAtomType(eight);
        QApi.AddAtomType(eleven);
        QApi.AddAtomType(twelve);
        QApi.AddAtomType(fifteen);
        QApi.AddAtomType(sixteen);
        QApi.AddAtomType(nineteen);
        QApi.AddAtomType(twenty);
        QApi.AddAtomType(twentythree);
    }
}
