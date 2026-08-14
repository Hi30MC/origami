using Quintessential;
namespace Origami;

public static class Atoms
{
    public static AtomType id, three, four, seven, eight, eleven, twelve, fifteen, sixteen, nineteen, twenty, twentythree;

    public static void LoadAtoms()
    {
        id = Brimstone.API.CreateNormalAtom(
            ID: 201,
            modName: "Origami",
            name: "Rei",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/id_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        three = Brimstone.API.CreateNormalAtom(
            ID: 203,
            modName: "Origami",
            name: "Nazum",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/three_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        four = Brimstone.API.CreateNormalAtom(
            ID: 204,
            modName: "Origami",
            name: "Reyja",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/four_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        seven = Brimstone.API.CreateNormalAtom(
            ID: 207,
            modName: "Origami",
            name: "Chronos",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/seven_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        eight = Brimstone.API.CreateNormalAtom(
            ID: 208,
            modName: "Origami",
            name: "Zaryan",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/eight_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        eleven = Brimstone.API.CreateNormalAtom(
            ID: 211,
            modName: "Origami",
            name: "Iaso",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/eleven_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        twelve = Brimstone.API.CreateNormalAtom(
            ID: 212,
            modName: "Origami",
            name: "Tano",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/twelve_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        fifteen = Brimstone.API.CreateNormalAtom(
            ID: 215,
            modName: "Origami",
            name: "Maru",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/fifteen_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        sixteen = Brimstone.API.CreateNormalAtom(
            ID: 216,
            modName: "Origami",
            name: "Homonculum",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/sixteen_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        nineteen = Brimstone.API.CreateNormalAtom(
            ID: 219,
            modName: "Origami",
            name: "Lono",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/ninteen_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        twenty = Brimstone.API.CreateNormalAtom(
            ID: 220,
            modName: "Origami",
            name: "Lua",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/twenty_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Origami/copper_diffuse"
        );
        twentythree = Brimstone.API.CreateNormalAtom(
            ID: 223,
            modName: "Origami",
            name: "Tao",
            pathToSymbol: "textures/atoms/Hi30MC/Origami/twentythree_symbol",
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
