﻿// <copyright file="IFolderDialog.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface.FolderBrowseDialog
{
    using JetBrains.Annotations;
    using System.Windows;

    [PublicAPI]
    public interface IFolderDialog
    {
        string? InitialFolder { get; set; }

        string? DefaultFolder { get; set; }

        string? Folder { get; set; }

        bool ShowDialog(Window owner);
    }
}
