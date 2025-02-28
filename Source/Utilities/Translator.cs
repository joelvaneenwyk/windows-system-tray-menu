﻿// <copyright file="Translator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System.Globalization;
    using System.Resources;
    using Properties;
    using UserInterface;

    internal static class Translator
    {
        private static CultureInfo? culture;

        internal static void Initialize()
        {
            if (string.IsNullOrEmpty(
                Settings.Default.CurrentCultureInfoName))
            {
                Settings.Default.CurrentCultureInfoName = "en";
                Settings.Default.Save();
            }

            culture = CultureInfo.CreateSpecificCulture(
                Settings.Default.CurrentCultureInfoName);
        }

        internal static string GetText(string id)
        {
            ResourceManager rm = new(
                // #todo
                // nameof(SystemTrayMenu.Resources.Languages.lang),
                "SystemTrayMenu.Resources.Languages.lang",
                typeof(Menu).Assembly);
            return rm.GetString(id, culture) ?? id;
        }
    }
}
