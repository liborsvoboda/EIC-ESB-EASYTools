﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using EASYTools.HTMLFullEditor.Code;

namespace EASYTools.HTMLFullEditor.Localization
{
    /// <summary>
    /// Resource manager for localization of UI texts.
    /// </summary>
    public static partial class ResourceManager
    {
        private static readonly object InitLock = new object();
        private static List<IResourceManager> _loadedManagers;

        /// <summary>
        /// Will return localized string under the given key.
        /// </summary>
        public static string GetString(string key)
        {
            return GetString(key, CultureInfo.CurrentUICulture);
        }

        /// <summary>
        /// Will return localized string under the given key for given culture.
        /// </summary>
        public static string GetString(string key, CultureInfo culture)
        {
            foreach (var manager in Managers)
            {
                // if the localization was successful (and not empty text was returned)
                if (manager.TryProvideString(key, culture, out var localizedText) && !string.IsNullOrEmpty(localizedText))
                {
                    // it's done
                    return localizedText;
                }
            }

            // none of the managers succeed localizing this text - using default resource
            return DefaultResources.ResourceManager.GetString(key, culture);
        }

        /// <summary>
        /// You can add or remove any additional resource managers here.
        /// When localizing some text, all managers (based on order in this list) would have chance to return it's own text.
        /// </summary>
        public static List<IResourceManager> Managers
        {
            get
            {
                // ensure that all managers from external DLLs are loaded
                EnsureLoadedManagers();

                return _loadedManagers;
            }
        }

        /// <summary>
        /// Will ensure, that all managers from "EASYTools.HTMLFullEditor.Locale.*.dll" assemblies are loaded.
        /// </summary>
        private static void EnsureLoadedManagers()
        {
            if (_loadedManagers == null)
            {
                lock (InitLock)
                {
                    if (_loadedManagers == null)
                    {
                        _loadedManagers = new List<IResourceManager>();

                        try
                        {
                            // getting the current DLL path
                            var currentDllPath = typeof(ResourceManager).Assembly.CodeBase;
                            currentDllPath = new Uri(currentDllPath).LocalPath; // convert from file:\\\C:\Path\To\library.dll to simple path
                            var currentDllDirectory = Path.GetDirectoryName(currentDllPath);

                            // searching for all localization DLLs
                            var dlls = Directory.EnumerateFiles(currentDllDirectory, "EASYTools.HTMLFullEditor.Locale.*.dll", SearchOption.TopDirectoryOnly).ToList();
                            if (dlls.Count > 1)
                            {
                                // if there's the default dll (and is not last), i am moving it to the end of the list - so user can change resource texts
                                var defaultIndex = dlls.IndexOf(path => path.EndsWith("EASYTools.HTMLFullEditor.Locale.Default.dll", StringComparison.InvariantCultureIgnoreCase));
                                if (defaultIndex > -1 && defaultIndex < dlls.Count - 1)
                                {
                                    var defaultPath = dlls[defaultIndex];
                                    dlls.Remove(defaultPath);
                                    dlls.Add(defaultPath);
                                }
                            }

                            foreach (var assemblyPath in dlls)
                            {
                                try
                                {
                                    var loadedAssembly = Assembly.LoadFrom(assemblyPath);
                                    foreach (var managerType in loadedAssembly.GetTypes().Where(t => typeof(IResourceManager).IsAssignableFrom(t)))
                                    {
                                        try
                                        {
                                            var managerInstance = (IResourceManager)Activator.CreateInstance(managerType);
                                            _loadedManagers.Add(managerInstance);
                                        }
                                        catch (Exception e)
                                        {
                                            Trace.WriteLine($"[WYSitor] Failed to create manager of type {managerType.FullName}: " + e);
                                        }
                                    }
                                }
                                catch (Exception e)
                                {
                                    Trace.WriteLine("[WYSitor] Failed to load assembly: " + e);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            // better try-catch than fail loading Editor
                            Trace.WriteLine("[WYSitor] Failed to load locale assemblies: " + e);
                        }
                    }
                }
            }

            // noop - managers are loaded now
        }
    }
}
