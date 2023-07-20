using System.Reflection;
using Crumble;
using MelonLoader;

[assembly: AssemblyTitle(Crumble.Main.Description)]
[assembly: AssemblyDescription(Crumble.Main.Description)]
[assembly: AssemblyCompany(Crumble.Main.Company)]
[assembly: AssemblyProduct(Crumble.Main.Name)]
[assembly: AssemblyCopyright("Developed by " + Crumble.Main.Author)]
[assembly: AssemblyTrademark(Crumble.Main.Company)]
[assembly: AssemblyVersion(Crumble.Main.Version)]
[assembly: AssemblyFileVersion(Crumble.Main.Version)]
[assembly: MelonInfo(typeof(Crumble.Main), Crumble.Main.Name, Crumble.Main.Version, Crumble.Main.Author, Crumble.Main.DownloadLink)]
[assembly: MelonColor(System.ConsoleColor.White)]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("Stress Level Zero", "BONELAB")]