﻿using System;
using System.Reflection;
using MelonLoader;
using Main = Crumble.Main;

[assembly: AssemblyTitle(Main.Description)]
[assembly: AssemblyDescription(Main.Description)]
[assembly: AssemblyCompany(Main.Company)]
[assembly: AssemblyProduct(Main.Name)]
[assembly: AssemblyCopyright("Developed by " + Main.Author)]
[assembly: AssemblyTrademark(Main.Company)]
[assembly: AssemblyVersion(Main.Version)]
[assembly: AssemblyFileVersion(Main.Version)]
[assembly: MelonInfo(typeof(Main), Main.Name, Main.Version, Main.Author, Main.DownloadLink)]
[assembly: MelonColor(ConsoleColor.White)]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("Stress Level Zero", "BONELAB")]